'use client'

import EmployeeForm from '@/components/employee/employee-form'
import { useApi } from '@/hooks/use-api'
import type { EmployeeFormType, UpdateEmpleadoAsalariadoDto, UpdateEmpleadoAsalariadoPorComisionDto, UpdateEmpleadoPorComisionDto, UpdateEmpleadoPorHorasDto } from '@/types/employee'
import { useParams, useRouter } from 'next/navigation'
import { ChangeEvent, FormEvent, useEffect, useState } from 'react'
import toast from 'react-hot-toast'

export default function UpdateEmployeePage() {
  const { id } = useParams()
  const { put, get } = useApi()
  const router = useRouter()
  const [form, setForm] = useState<EmployeeFormType>({
    tipoEmpleado: 'Asalariado',
    primerNombre: '',
    apellidoPaterno: '',
    numeroSeguroSocial: '',
    departamento: '',
    salarioSemanal: 0,
    salarioBase: 0,
    ventasBrutas: 0,
    tarifaComision: 0,
    sueldoPorHora: 0,
    horasTrabajadas: 0,
    activo: 'true',
    isUpdate: true,
  })

  useEffect(() => {
    let mounted = true
    async function loadEmployee() {
      try {
        const empleado = await get<EmployeeFormType>(`/empleados/${id}`)
        if (!mounted) return
        setForm({ ...empleado.data!, activo: empleado.data!.activo ? 'true' : 'false', isUpdate: true })
      } catch {
        toast.error('Error al cargar los datos del empleado.')
      }
    }
    loadEmployee()

    return () => { mounted = false }
  }, [get, id])

  const handleChange = (e: ChangeEvent<HTMLInputElement | HTMLSelectElement>) => {
    const { name, value } = e.target
    setForm(prev => ({ ...prev, [name]: value }))
  }

  const handleSubmit = async (e: FormEvent<HTMLFormElement>) => {
    e.preventDefault()
    let url = ''
    let data: unknown = {}
    switch (form.tipoEmpleado) {
      case 'Asalariado':
        url = `/empleados/asalariados/${id}`
        data = {
          primerNombre: form.primerNombre,
          apellidoPaterno: form.apellidoPaterno,
          departamento: form.departamento,
          salarioSemanal: Number(form.salarioSemanal),
          activo: form.activo === 'true',
        } as UpdateEmpleadoAsalariadoDto
        break
      case 'AsalariadoPorComision':
        url = `/empleados/asalariados-por-comision/${id}`
        data = {
          primerNombre: form.primerNombre,
          apellidoPaterno: form.apellidoPaterno,
          departamento: form.departamento,
          salarioBase: Number(form.salarioBase),
          ventasBrutas: Number(form.ventasBrutas),
          tarifaComision: Number(form.tarifaComision),
          activo: form.activo === 'true',
        } as UpdateEmpleadoAsalariadoPorComisionDto
        break
      case 'PorComision':
        url = `/empleados/por-comision/${id}`
        data = {
          primerNombre: form.primerNombre,
          apellidoPaterno: form.apellidoPaterno,
          departamento: form.departamento,
          ventasBrutas: Number(form.ventasBrutas),
          tarifaComision: Number(form.tarifaComision),
          activo: form.activo === 'true',
        } as UpdateEmpleadoPorComisionDto
        break
      case 'PorHoras':
        url = `/empleados/por-horas/${id}`
        data = {
          primerNombre: form.primerNombre,
          apellidoPaterno: form.apellidoPaterno,
          departamento: form.departamento,
          sueldoPorHora: Number(form.sueldoPorHora),
          horasTrabajadas: Number(form.horasTrabajadas),
          activo: form.activo === 'true',
        } as UpdateEmpleadoPorHorasDto
        break
    }

    handleUpdate(url, data)
  }

  const handleUpdate = async (url: string, data: unknown) => {
    await toast.promise(
      put(url, data),
      {
        loading: 'Actualizando empleado...',
        success: 'Empleado actualizado correctamente.',
        error: 'Error al actualizar el empleado.',
      }
    )

    router.push('/employees')
  }

  return (
    <EmployeeForm form={form} handleChange={handleChange} handleSubmit={handleSubmit} />
  )
}