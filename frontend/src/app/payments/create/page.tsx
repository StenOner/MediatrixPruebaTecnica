'use client'

import PaymentForm from '@/components/payments/payment-form'
import { useApi } from '@/hooks/use-api'
import { CreatePaymentDto, PaymentFormType } from '@/types/payment'
import { useRouter } from 'next/navigation'
import { ChangeEvent, FormEvent, useState } from 'react'
import toast from 'react-hot-toast'

export default function CreatePaymentsPage() {
  const { post } = useApi()
  const router = useRouter()
  const [form, setForm] = useState<PaymentFormType>({
    empleadoId: '',
    periodoInicio: '',
    periodoFin: '',
    deducciones: 0,
    observaciones: '',
  })

  const handleChange = (e: ChangeEvent<HTMLInputElement | HTMLSelectElement | HTMLTextAreaElement>) => {
    const { name, value } = e.target
    setForm(prev => ({ ...prev, [name]: value }))
  }

  const handleSubmit = async (e: FormEvent<HTMLFormElement>) => {
    e.preventDefault()
    const url = '/pagos'
    const data: CreatePaymentDto = {
      empleadoId: form.empleadoId,
      periodoInicio: form.periodoInicio,
      periodoFin: form.periodoFin,
      deducciones: Number(form.deducciones),
      observaciones: form.observaciones,
    }

    handleCreate(url, data)
  }

  const handleCreate = async (url: string, data: unknown) => {
    await toast.promise(
      post(url, data),
      {
        loading: 'Creando pago...',
        success: 'Pago creado correctamente.',
        error: 'Error al crear el pago.',
      }
    )

    router.push('/payments')
  }

  return (
    <PaymentForm form={form} handleChange={handleChange} handleSubmit={handleSubmit} />
  )
}