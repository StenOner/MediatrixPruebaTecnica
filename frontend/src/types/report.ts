import { PaymentDto } from './payment'

export interface ReportDto {
  fechaInicio: string
  fechaFin: string
  pagos: PaymentDto[]
  totalBruto: number
  totalDeducciones: number
  totalNeto: number
}
