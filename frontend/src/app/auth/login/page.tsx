'use client'

import { useApi } from '@/hooks/use-api'
import { ChangeEvent, MouseEvent, useState } from 'react'
import { useRouter } from 'next/navigation'
import { User, Lock, Eye, EyeOff, LogIn, AlertCircle } from 'lucide-react'
import Image from 'next/image'

export default function Login() {
  const [showPassword, setShowPassword] = useState(false)
  const [formData, setFormData] = useState({
    username: '',
    password: '',
  })
  const [error, setError] = useState('')
  const [loading, setLoading] = useState(false)
  const { login } = useApi()
  const router = useRouter()

  const handleSubmit = async (e: MouseEvent<HTMLElement>) => {
    e.preventDefault()
    setError('')
    setLoading(true)

    try {
      const response = await login(formData.username, formData.password)

      if (response.success) {
        router.push('/')
        return
      }

      if (response.errorMessage) setError(String(response.errorMessage))
    } catch {
      setError('No se pudo conectar con el servidor. Por favor, intenta nuevamente más tarde.')
    } finally {
      setLoading(false)
    }
  }

  const handleChange = (e: ChangeEvent<HTMLInputElement>) => {
    setFormData({
      ...formData,
      [e.target.name]: e.target.value
    })
    setError('')
  }

  return (
    <div className="min-h-screen flex items-center justify-center bg-linear-to-br from-blue-50 to-blue-100 p-4">
      <div className="w-full max-w-md">
        {/* Card Container */}
        <div className="bg-white rounded-2xl shadow-2xl overflow-hidden">
          {/* Header Section */}
          <div
            className="p-8 text-center"
            style={{ backgroundColor: 'rgba(13, 48, 72, 0.9)' }}
          >
            {/* Logo */}
            <div className="mb-4 flex justify-center">
              <Image src="../icons/logo.svg" alt="Logo" width={400} height={500} className="object-contain" />
            </div>

            <p className="text-blue-100 text-sm">
              Ingresa tus credenciales para continuar
            </p>
          </div>

          {/* Form Section */}
          <div className="p-8">
            {/* Error Message */}
            {error && (
              <div className="mb-6 p-4 bg-red-50 border border-red-200 rounded-lg flex items-start gap-3">
                <AlertCircle className="text-red-500 shrink-0 mt-0.5" size={20} />
                <div>
                  <p className="text-red-800 font-medium text-sm">Error de autenticación</p>
                  <p className="text-red-600 text-sm">{error}</p>
                </div>
              </div>
            )}

            <div className="space-y-6">
              {/* Username Input */}
              <div>
                <label
                  htmlFor="username"
                  className="block text-sm font-medium text-gray-700 mb-2"
                >
                  Usuario
                </label>
                <div className="relative">
                  <div className="absolute inset-y-0 left-0 pl-3 flex items-center pointer-events-none">
                    <User className="text-black" size={20} />
                  </div>
                  <input
                    id="username"
                    name="username"
                    type="text"
                    required
                    value={formData.username}
                    onChange={handleChange}
                    className="block w-full text-black pl-10 pr-3 py-3 border border-gray-300 rounded-lg focus:ring-2 focus:ring-blue-500 focus:border-blue-500 transition-colors"
                    placeholder="Ingresa tu usuario"
                    disabled={loading}
                  />
                </div>
              </div>

              {/* Password Input */}
              <div>
                <label
                  htmlFor="password"
                  className="block text-sm text-black font-medium mb-2"
                >
                  Contraseña
                </label>
                <div className="relative">
                  <div className="absolute inset-y-0 left-0 pl-3 flex items-center pointer-events-none">
                    <Lock className="text-black" size={20} />
                  </div>
                  <input
                    id="password"
                    name="password"
                    type={showPassword ? 'text' : 'password'}
                    required
                    value={formData.password}
                    onChange={handleChange}
                    className="block w-full text-black pl-10 pr-12 py-3 border border-gray-300 rounded-lg focus:ring-2 focus:ring-blue-500 focus:border-blue-500 transition-colors"
                    placeholder="Ingresa tu contraseña"
                    disabled={loading}
                  />
                  <button
                    type="button"
                    onClick={() => setShowPassword(!showPassword)}
                    className="absolute inset-y-0 right-0 pr-3 flex items-center hover:text-blue-600 transition-colors"
                    disabled={loading}
                  >
                    {showPassword ? (
                      <EyeOff className="text-black" size={20} />
                    ) : (
                      <Eye className="text-black" size={20} />
                    )}
                  </button>
                </div>
              </div>

              {/* Submit Button */}
              <button
                onClick={handleSubmit}
                disabled={loading}
                className="w-full flex items-center justify-center gap-2 py-3 px-4 border border-transparent rounded-lg shadow-sm text-white font-medium transition-all disabled:opacity-50 disabled:cursor-not-allowed"
                style={{
                  backgroundColor: loading ? 'rgba(13, 48, 72, 0.6)' : 'rgba(13, 48, 72, 0.9)',
                }}
              >
                {loading ? (
                  <>
                    <div className="w-5 h-5 border-2 border-white border-t-transparent rounded-full animate-spin"></div>
                    <span>Iniciando sesión...</span>
                  </>
                ) : (
                  <>
                    <LogIn size={20} />
                    <span>Iniciar Sesión</span>
                  </>
                )}
              </button>
            </div>

            {/* Demo Credentials */}
            <div className="mt-6 p-4 bg-blue-50 border border-blue-200 rounded-lg">
              <p className="text-sm font-medium text-blue-900 mb-2">
                Credenciales de prueba:
              </p>
              <div className="space-y-1 text-sm text-blue-700">
                <p><strong>Admin:</strong> admin / admin</p>
                <p><strong>Usuario:</strong> usuario1 / user</p>
              </div>
            </div>
          </div>
        </div>

        {/* Footer */}
        <div className="text-center mt-6">
          <p className="text-gray-600 text-sm">
            © 2025 Prueba Tecnica.
          </p>
        </div>
      </div>
    </div>
  )
}