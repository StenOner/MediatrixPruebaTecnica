export interface ApiResponse<T = unknown> {
  content: {
    success: boolean
    data?: T
    errorMessage?: string
    errors?: string[]
  }
}