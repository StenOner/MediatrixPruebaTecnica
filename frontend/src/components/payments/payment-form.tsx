'use client'

import { useApi } from '@/hooks/use-api'
import { EmployeeDto } from '@/types/employee'
import { PaymentFormType } from '@/types/payment'
import { useEffect, useState } from 'react'

export default function PaymentForm({ form, handleChange, handleSubmit }: {
  form: PaymentFormType
  handleChange: (e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement | HTMLTextAreaElement>) => void
  handleSubmit: (e: React.FormEvent<HTMLFormElement>) => void
}) {
  const { get } = useApi()
  const [employees, setEmployees] = useState<{ id: string; nombreCompleto: string }[]>([])

  useEffect(() => {
    let mounted = true
    async function loadEmployees() {
      try {
        const all = await get<EmployeeDto[]>('/empleados/filtro?activo=true')
        if (!mounted) return
        const employeeOptions = all.data?.map(emp => ({ id: emp.id, nombreCompleto: `${emp.primerNombre} ${emp.apellidoPaterno}` })) || []
        setEmployees(employeeOptions)
      } catch {
        setEmployees([])
      }
    }
    loadEmployees()

    return () => { mounted = false }
  })

  return (
    <form onSubmit={handleSubmit} className="mx-auto space-y-4 items-center max-w-md">

      <div className='text-black'>
        <label>Empleado</label>
        <select
          name="empleadoId"
          value={form.empleadoId}
          onChange={handleChange}
          className="block w-full text-lg text-black px-5 py-3 border border-y-gray-700 rounded-lg transition-colors"
          required
        >
          <option value="">Seleccione un empleado</option>
          {employees.map(emp => (
            <option key={emp.id} value={emp.id}>{emp.nombreCompleto}</option>
          ))}
        </select>
      </div>

      <div className='text-black'>
        <label>Periodo Inicio</label>
        <input
          type="date"
          name="periodoInicio"
          value={form.periodoInicio}
          onChange={handleChange}
          className="block w-full text-lg text-black px-5 py-3 border border-y-gray-700 rounded-lg transition-colors"
          required
        />
      </div>

      <div className='text-black'>
        <label>Periodo Fin</label>
        <input
          type="date"
          name="periodoFin"
          value={form.periodoFin}
          onChange={handleChange}
          className="block w-full text-lg text-black px-5 py-3 border border-y-gray-700 rounded-lg transition-colors"
          required
        />
      </div>

      <div className='text-black'>
        <label>Deducciones</label>
        <input
          type="number"
          name="deducciones"
          value={form.deducciones}
          onChange={handleChange}
          className="block w-full text-lg text-black px-5 py-3 border border-y-gray-700 rounded-lg transition-colors"
          required
        />
      </div>

      <div className='text-black'>
        <label>Observaciones</label>
        <textarea
          name="observaciones"
          onChange={handleChange}
          value={form.observaciones}
          className="block w-full text-lg text-black px-5 py-3 border border-y-gray-700 rounded-lg transition-colors"
        />
      </div>

      <button
        type="submit"
        className="w-full flex items-center justify-center gap-2 py-3 px-4 border border-transparent rounded-lg shadow-sm bg-blue-400 text-white font-medium transition-all hover:cursor-pointer"
      >
        Guardar
      </button>

    </form>
  )
}