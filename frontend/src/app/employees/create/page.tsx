'use client'

import EmployeeForm from '@/components/employees/employee-form'
import { useApi } from '@/hooks/use-api'
import { CreateEmpleadoAsalariadoDto, CreateEmpleadoAsalariadoPorComisionDto, CreateEmpleadoPorComisionDto, CreateEmpleadoPorHorasDto, EmployeeFormType } from '@/types/employee'
import { useRouter } from 'next/navigation'
import { ChangeEvent, FormEvent, useState } from 'react'
import toast from 'react-hot-toast'

export default function CreateEmployeePage() {
  const { post } = useApi()
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
    isUpdate: false,
  })

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
        url = `/empleados/asalariados`
        data = {
          primerNombre: form.primerNombre,
          apellidoPaterno: form.apellidoPaterno,
          numeroSeguroSocial: form.numeroSeguroSocial,
          departamento: form.departamento,
          salarioSemanal: Number(form.salarioSemanal),
        } as CreateEmpleadoAsalariadoDto
        break
      case 'AsalariadoPorComision':
        url = `/empleados/asalariados-por-comision`
        data = {
          primerNombre: form.primerNombre,
          apellidoPaterno: form.apellidoPaterno,
          numeroSeguroSocial: form.numeroSeguroSocial,
          departamento: form.departamento,
          salarioBase: Number(form.salarioBase),
          ventasBrutas: Number(form.ventasBrutas),
          tarifaComision: Number(form.tarifaComision),
        } as CreateEmpleadoAsalariadoPorComisionDto
        break
      case 'PorComision':
        url = `/empleados/por-comision`
        data = {
          primerNombre: form.primerNombre,
          apellidoPaterno: form.apellidoPaterno,
          numeroSeguroSocial: form.numeroSeguroSocial,
          departamento: form.departamento,
          ventasBrutas: Number(form.ventasBrutas),
          tarifaComision: Number(form.tarifaComision),
        } as CreateEmpleadoPorComisionDto
        break
      case 'PorHoras':
        url = `/empleados/por-horas`
        data = {
          primerNombre: form.primerNombre,
          apellidoPaterno: form.apellidoPaterno,
          numeroSeguroSocial: form.numeroSeguroSocial,
          departamento: form.departamento,
          sueldoPorHora: Number(form.sueldoPorHora),
          horasTrabajadas: Number(form.horasTrabajadas),
        } as CreateEmpleadoPorHorasDto
        break
    }

    handleCreate(url, data)
  }

  const handleCreate = async (url: string, data: unknown) => {
    await toast.promise(
      post(url, data),
      {
        loading: 'Creando empleado...',
        success: 'Empleado creado correctamente.',
        error: 'Error al crear el empleado.',
      }
    )

    router.push('/employees')
  }

  return (
    <EmployeeForm form={form} handleChange={handleChange} handleSubmit={handleSubmit} />
  )
}