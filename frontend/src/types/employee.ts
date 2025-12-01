export type EmployeeType = 'Asalariado' | 'AsalariadoPorComision' | 'PorComision' | 'PorHoras'

export type EmployeeFormType = {
  tipoEmpleado: string
  primerNombre: string
  apellidoPaterno: string
  numeroSeguroSocial: string
  departamento: string
  salarioSemanal: number
  salarioBase: number
  ventasBrutas: number
  tarifaComision: number
  sueldoPorHora: number
  horasTrabajadas: number
  activo: string
  isUpdate?: boolean
}

export interface EmployeeDto {
  id: string
  primerNombre: string
  apellidoPaterno: string
  numeroSeguroSocial: string
  departamento: string
  fechaContratacion: string
  activo: boolean
  tipoEmpleado: EmployeeType
  pagoSemanal: number
}

export interface CreateEmpleadoAsalariadoDto {
  primerNombre: string
  apellidoPaterno: string
  numeroSeguroSocial: string
  departamento: string
  salarioSemanal: number
}

export interface UpdateEmpleadoAsalariadoDto extends Omit<CreateEmpleadoAsalariadoDto, 'numeroSeguroSocial'> {
  activo: boolean
}

export interface CreateEmpleadoAsalariadoPorComisionDto {
  primerNombre: string
  apellidoPaterno: string
  numeroSeguroSocial: string
  departamento: string
  salarioBase: number
  ventasBrutas: number
  tarifaComision: number
}

export interface UpdateEmpleadoAsalariadoPorComisionDto extends Omit<CreateEmpleadoAsalariadoPorComisionDto, 'numeroSeguroSocial'> {
  activo: boolean
}

export interface CreateEmpleadoPorComisionDto {
  primerNombre: string
  apellidoPaterno: string
  numeroSeguroSocial: string
  departamento: string
  ventasBrutas: number
  tarifaComision: number
}

export interface UpdateEmpleadoPorComisionDto extends Omit<CreateEmpleadoPorComisionDto, 'numeroSeguroSocial'> {
  activo: boolean
}

export interface CreateEmpleadoPorHorasDto {
  primerNombre: string
  apellidoPaterno: string
  numeroSeguroSocial: string
  departamento: string
  sueldoPorHora: number
  horasTrabajadas: number
}

export interface UpdateEmpleadoPorHorasDto extends Omit<CreateEmpleadoPorHorasDto, 'numeroSeguroSocial'> {
  activo: boolean
}
