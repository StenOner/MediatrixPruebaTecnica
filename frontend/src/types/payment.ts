export type PaymentFormType = {
  empleadoId: string
  periodoInicio: string
  periodoFin: string
  deducciones: number
  observaciones: string
}

export interface PaymentDto {
  id: string
  empleadoId: string
  nombreEmpleado: string
  fechaPago: string
  periodoInicio: string
  periodoFin: string
  montoBruto: number
  deducciones: number
  montoNeto: number
  observaciones?: string
}

export interface CreatePaymentDto {
  empleadoId: string
  periodoInicio: string
  periodoFin: string
  deducciones: number
  observaciones: string
}

export interface UpdatePaymentDto {
  deducciones: number
  observaciones: string
}