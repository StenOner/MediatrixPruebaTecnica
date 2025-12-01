export interface ReportDto {
  fechaInicio: string
  fechaFin: string
  pagos: RegistroPagoDto[]
  totalBruto: number
  totalDeducciones: number
  totalNeto: number
}

export interface RegistroPagoDto {
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