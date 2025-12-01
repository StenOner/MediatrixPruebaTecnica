import { useState } from 'react'
import { Menu, Home, Users, DollarSign, FileText, LogOut, ChevronLeft, ChevronRight, Settings, User } from 'lucide-react'
import Footer from './footer'

export default function MainLayout() {
  const [sideBarOpen, setSidebarOpen] = useState(false)

  const menuItems = [
    { icon: Home, label: 'Dashboard', href: '/' },
    { icon: Users, label: 'Empleados', href: '/empleados' },
    { icon: DollarSign, label: 'Pagos', href: '/pagos' },
    { icon: FileText, label: 'Reportes', href: '/reportes' },
    { icon: Settings, label: 'Configuración', href: '/configuracion' },
  ]

  return (
    <div className="min-h-screen flex flex-col bg-gray-100">
      {/* Header */}
      <header
        className={`h-16 flex items-center justify-between px-6 shadow-lg z-20 transition-all duration-300 ${sidebarOpen ? 'ml-64' : 'ml-20'}`}
        style={{ backgroundColor: 'rgba(13, 48, 72, 0.9)' }}
      >
        <div className="flex items-center gap-4">
          <h1 className="text-white text-xl font-bold">Sistema de Nómina</h1>
        </div>

        <div className="flex items-center gap-4">
          <div className="text-right hidden md:block">
            <p className="text-white font-medium">Admin Usuario</p>
            <p className="text-gray-300 text-sm">admin@payroll.com</p>
          </div>
          <div className="w-10 h-10 rounded-full bg-white/20 flex items-center justify-center text-white">
            <User size={20} />
          </div>
        </div>
      </header>

      <div className="flex flex-1 overflow-hidden">
        {/* Sidebar */}
        <aside
          className={`${sidebarOpen ? 'w-64' : 'w-20'} transition-all duration-300 flex flex-col fixed left-0 top-0 bottom-0 z-30`}
          style={{ backgroundColor: 'rgba(13, 48, 72, 0.9)' }}
        >
          {/* Logo Section */}
          <div className="h-32 flex items-center justify-center p-4">
            {sidebarOpen ? (
              <div className="w-full">
                {/* SVG Logo Placeholder - Reemplaza con tu SVG */}
                <svg
                  viewBox="0 0 200 80"
                  className="w-full h-auto"
                  xmlns="http://www.w3.org/2000/svg"
                >
                  {/* Icono de edificio corporativo */}
                  <rect x="70" y="20" width="60" height="50" fill="white" opacity="0.9" />
                  <rect x="75" y="25" width="10" height="10" fill="rgba(13, 48, 72, 0.9)" />
                  <rect x="90" y="25" width="10" height="10" fill="rgba(13, 48, 72, 0.9)" />
                  <rect x="105" y="25" width="10" height="10" fill="rgba(13, 48, 72, 0.9)" />
                  <rect x="75" y="40" width="10" height="10" fill="rgba(13, 48, 72, 0.9)" />
                  <rect x="90" y="40" width="10" height="10" fill="rgba(13, 48, 72, 0.9)" />
                  <rect x="105" y="40" width="10" height="10" fill="rgba(13, 48, 72, 0.9)" />
                  <rect x="85" y="55" width="30" height="15" fill="rgba(13, 48, 72, 0.9)" />
                  <polygon points="100,10 70,20 130,20" fill="white" opacity="0.9" />

                  {/* Texto */}
                  <text x="100" y="82" fontFamily="Arial, sans-serif" fontSize="10" fill="white" textAnchor="middle" fontWeight="bold">
                    MI EMPRESA
                  </text>
                </svg>
              </div>
            ) : (
              <div className="w-10 h-10 bg-white/20 rounded-lg flex items-center justify-center">
                <svg viewBox="0 0 24 24" className="w-6 h-6" fill="white">
                  <rect x="3" y="3" width="18" height="18" />
                </svg>
              </div>
            )}
          </div>

          {/* Navigation */}
          <nav className="flex-1 py-6 overflow-y-auto border-t border-white/10">
            <ul className="space-y-2 px-3">
              {menuItems.map((item, index) => (
                <li key={index}>
                  <a
                    href={item.href}
                    className="flex items-center gap-3 px-4 py-3 text-gray-200 hover:bg-white/10 rounded-lg transition-all group"
                  >
                    <item.icon size={22} className="flex-shrink-0" />
                    {sidebarOpen && (
                      <span className="font-medium">{item.label}</span>
                    )}
                  </a>
                </li>
              ))}
            </ul>
          </nav>

          {/* Sidebar Footer */}
          <div className="border-t border-white/10 p-4">
            <button className="flex items-center gap-3 px-4 py-3 text-gray-200 hover:bg-white/10 rounded-lg transition-all w-full">
              <LogOut size={22} className="flex-shrink-0" />
              {sidebarOpen && <span className="font-medium">Cerrar Sesión</span>}
            </button>
          </div>

          {/* Toggle Button */}
          <button
            onClick={() => setSidebarOpen(!sidebarOpen)}
            className="absolute -right-3 top-36 bg-white shadow-lg rounded-full p-1.5 hover:bg-gray-100 transition-colors z-40"
            style={{ color: 'rgba(13, 48, 72, 0.9)' }}
          >
            {sidebarOpen ? <ChevronLeft size={20} /> : <ChevronRight size={20} />}
          </button>
        </aside>

        {/* Main Content */}
        <main className={`flex-1 overflow-y-auto transition-all duration-300 ${sidebarOpen ? 'ml-64' : 'ml-20'}`}>
          <div className="p-8">
            {/* Page Header */}
            <div className="mb-8">
              <h2 className="text-3xl font-bold text-gray-800 mb-2">Dashboard</h2>
              <p className="text-gray-600">Bienvenido al sistema de gestión de nómina</p>
            </div>

            {/* Stats Cards */}
            <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-4 gap-6 mb-8">
              <div className="bg-white rounded-lg shadow-md p-6 border-l-4 border-blue-500">
                <div className="flex items-center justify-between">
                  <div>
                    <p className="text-gray-600 text-sm font-medium">Total Empleados</p>
                    <p className="text-3xl font-bold text-gray-800 mt-1">156</p>
                  </div>
                  <Users className="text-blue-500" size={40} />
                </div>
              </div>

              <div className="bg-white rounded-lg shadow-md p-6 border-l-4 border-green-500">
                <div className="flex items-center justify-between">
                  <div>
                    <p className="text-gray-600 text-sm font-medium">Empleados Activos</p>
                    <p className="text-3xl font-bold text-gray-800 mt-1">142</p>
                  </div>
                  <Users className="text-green-500" size={40} />
                </div>
              </div>

              <div className="bg-white rounded-lg shadow-md p-6 border-l-4 border-yellow-500">
                <div className="flex items-center justify-between">
                  <div>
                    <p className="text-gray-600 text-sm font-medium">Nómina Mensual</p>
                    <p className="text-3xl font-bold text-gray-800 mt-1">$85K</p>
                  </div>
                  <DollarSign className="text-yellow-500" size={40} />
                </div>
              </div>

              <div className="bg-white rounded-lg shadow-md p-6 border-l-4 border-purple-500">
                <div className="flex items-center justify-between">
                  <div>
                    <p className="text-gray-600 text-sm font-medium">Pagos Procesados</p>
                    <p className="text-3xl font-bold text-gray-800 mt-1">12</p>
                  </div>
                  <FileText className="text-purple-500" size={40} />
                </div>
              </div>
            </div>

            {/* Content Area */}
            <div className="grid grid-cols-1 lg:grid-cols-2 gap-6">
              {/* Recent Employees */}
              <div className="bg-white rounded-lg shadow-md p-6">
                <h3 className="text-xl font-bold text-gray-800 mb-4">Empleados Recientes</h3>
                <div className="space-y-3">
                  {[
                    { name: 'Juan Pérez', dept: 'Ventas', status: 'Activo' },
                    { name: 'María García', dept: 'Marketing', status: 'Activo' },
                    { name: 'Carlos López', dept: 'IT', status: 'Activo' },
                    { name: 'Ana Martínez', dept: 'Recursos Humanos', status: 'Activo' },
                  ].map((emp, idx) => (
                    <div key={idx} className="flex items-center justify-between p-3 bg-gray-50 rounded-lg hover:bg-gray-100 transition-colors">
                      <div className="flex items-center gap-3">
                        <div className="w-10 h-10 rounded-full bg-blue-100 flex items-center justify-center">
                          <User size={20} className="text-blue-600" />
                        </div>
                        <div>
                          <p className="font-medium text-gray-800">{emp.name}</p>
                          <p className="text-sm text-gray-600">{emp.dept}</p>
                        </div>
                      </div>
                      <span className="px-3 py-1 bg-green-100 text-green-700 rounded-full text-sm font-medium">
                        {emp.status}
                      </span>
                    </div>
                  ))}
                </div>
              </div>

              {/* Recent Payments */}
              <div className="bg-white rounded-lg shadow-md p-6">
                <h3 className="text-xl font-bold text-gray-800 mb-4">Pagos Recientes</h3>
                <div className="space-y-3">
                  {[
                    { name: 'Juan Pérez', amount: '$1,500', date: '15/11/2024' },
                    { name: 'María García', amount: '$1,800', date: '15/11/2024' },
                    { name: 'Carlos López', amount: '$2,200', date: '15/11/2024' },
                    { name: 'Ana Martínez', amount: '$1,600', date: '15/11/2024' },
                  ].map((payment, idx) => (
                    <div key={idx} className="flex items-center justify-between p-3 bg-gray-50 rounded-lg hover:bg-gray-100 transition-colors">
                      <div className="flex items-center gap-3">
                        <DollarSign size={20} className="text-green-600" />
                        <div>
                          <p className="font-medium text-gray-800">{payment.name}</p>
                          <p className="text-sm text-gray-600">{payment.date}</p>
                        </div>
                      </div>
                      <span className="font-bold text-gray-800">
                        {payment.amount}
                      </span>
                    </div>
                  ))}
                </div>
              </div>
            </div>
          </div>
        </main>
      </div>

      {/* Footer */}
      <Footer />
    </div>
  )
}