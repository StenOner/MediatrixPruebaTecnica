import { useApi } from '@/hooks/use-api'
import { PaymentDto } from '@/types/payment'
import { ReportDto } from '@/types/report'
import { CurrencyUtil } from '@/utility/currency'
import { DateUtil } from '@/utility/date'
import { RefreshCcw, Search, Trash2 } from 'lucide-react'
import toast from 'react-hot-toast'

export default function ReportTable({ reportData, setReportData }: { reportData?: ReportDto, setReportData: (data: ReportDto | undefined) => void }) {
  const { del, put } = useApi()

  const handleDelete = async (id: string) => {
    const confirmed = confirm('¿Estás seguro de que deseas eliminar este pago?')
    if (!confirmed) return

    await toast.promise(
      del(`/pagos/${id}`),
      {
        loading: 'Eliminando pago...',
        success: 'Pago eliminado correctamente.',
        error: 'Error al eliminar el pago.',
      }
    )

    const updatedReport = {
      ...reportData,
      pagos: reportData?.pagos.filter(payment => payment.id !== id) || [],
    } as ReportDto

    setReportData(reportData?.pagos.length ? {
      ...updatedReport,
      totalBruto: updatedReport.pagos.reduce((sum, p) => sum + p.montoBruto, 0),
      totalDeducciones: updatedReport.pagos.reduce((sum, p) => sum + p.deducciones, 0),
      totalNeto: updatedReport.pagos.reduce((sum, p) => sum + p.montoNeto, 0),
    } : undefined)
  }

  const handleUpdate = async (payment: PaymentDto) => {
    const confirmed = confirm('¿Estás seguro de que deseas actualizar este pago?')
    if (!confirmed) return

    const response = await toast.promise(
      put<PaymentDto>(`/pagos/${payment.id}`, { deducciones: payment.deducciones, observaciones: payment.observaciones }),
      {
        loading: 'Actualizando pago...',
        success: 'Pago actualizado correctamente.',
        error: 'Error al actualizar el pago.',
      }
    )

    const updatedReport = {
      ...reportData,
      pagos: reportData?.pagos.map(p => p.id === payment.id ? response.data! : p) || [],
    } as ReportDto

    setReportData(reportData?.pagos.length ? {
      ...updatedReport,
      totalBruto: updatedReport.pagos.reduce((sum, p) => sum + p.montoBruto, 0),
      totalDeducciones: updatedReport.pagos.reduce((sum, p) => sum + p.deducciones, 0),
      totalNeto: updatedReport.pagos.reduce((sum, p) => sum + p.montoNeto, 0),
    } : undefined)
  }

  return (
    <div className='bg-white rounded-lg shadow-md overflow-hidden'>
      <div className='overflow-x-auto'>
        <table className='w-full'>
          <thead style={{ backgroundColor: 'rgba(13, 48, 72, 0.9)' }}>
            <tr>
              <th
                className='px-6 py-4 text-left text-sm font-semibold text-white cursor-pointer hover:bg-white/10'
              >
                Empleado
              </th>
              <th
                className='px-6 py-4 text-left text-sm font-semibold text-white cursor-pointer hover:bg-white/10'
              >
                Fecha de Pago
              </th>
              <th
                className='px-6 py-4 text-left text-sm font-semibold text-white cursor-pointer hover:bg-white/10'
              >
                Periodo Inicio
              </th>
              <th
                className='px-6 py-4 text-left text-sm font-semibold text-white cursor-pointer hover:bg-white/10'
              >
                Periodo Fin
              </th>
              <th
                className='px-6 py-4 text-left text-sm font-semibold text-white cursor-pointer hover:bg-white/10'
              >
                Monto Bruto
              </th>
              <th
                className='px-6 py-4 text-left text-sm font-semibold text-white cursor-pointer hover:bg-white/10'
              >
                Deducciones
              </th>
              <th
                className='px-6 py-4 text-left text-sm font-semibold text-white cursor-pointer hover:bg-white/10'
              >
                Monto Neto
              </th>
              <th className='px-6 py-4 text-right text-sm font-semibold text-white'>
                Acciones
              </th>
            </tr>
          </thead>
          <tbody className='divide-y divide-gray-200'>
            {reportData?.pagos.length === 0 ? (
              <tr>
                <td colSpan={7} className='px-6 py-12 text-center text-gray-500'>
                  <div className='flex flex-col items-center gap-2'>
                    <Search size={48} className='text-gray-300' />
                    <p className='text-lg font-medium'>No se encontraron pagos</p>
                    <p className='text-sm'>Intenta ajustar los filtros de búsqueda</p>
                  </div>
                </td>
              </tr>
            ) : (
              reportData?.pagos.map((payment) => (
                <tr key={payment.id} className='hover:bg-gray-50 transition-colors'>
                  <td className='px-6 py-4'>
                    <div>
                      <p className='font-medium text-gray-900'>
                        {payment.nombreEmpleado}
                      </p>
                    </div>
                  </td>
                  <td className='px-6 py-4 text-sm text-gray-600'>
                    {DateUtil.formatDateToYYYYMMDD(payment.fechaPago)}
                  </td>
                  <td className='px-6 py-4 text-sm text-gray-600'>
                    {DateUtil.formatDateToYYYYMMDD(payment.periodoInicio)}
                  </td>
                  <td className='px-6 py-4 text-sm text-gray-600'>
                    {DateUtil.formatDateToYYYYMMDD(payment.periodoFin)}
                  </td>
                  <td className='px-6 py-4 text-sm font-semibold text-gray-900'>
                    {CurrencyUtil.formatCurrency(payment.montoBruto)}
                  </td>
                  <td className='px-6 py-4 text-sm font-semibold text-gray-900'>
                    {CurrencyUtil.formatCurrency(payment.deducciones)}
                  </td>
                  <td className='px-6 py-4 text-sm font-semibold text-gray-900'>
                    {CurrencyUtil.formatCurrency(payment.montoNeto)}
                  </td>
                  <td className='px-6 py-4'>
                    <div className='flex items-center justify-end gap-2'>
                      <button
                        className='p-2 text-green-600 hover:bg-green-50 hover:cursor-pointer rounded-lg transition-colors'
                        title='Editar'
                        onClick={() => handleUpdate(payment)}
                      >
                        <RefreshCcw size={18} />
                      </button>
                      <button
                        className='p-2 text-red-600 hover:bg-red-50 hover:cursor-pointer rounded-lg transition-colors'
                        title='Eliminar'
                        onClick={() => handleDelete(payment.id)}
                      >
                        <Trash2 size={18} />
                      </button>
                    </div>
                  </td>
                </tr>
              ))
            )}
          </tbody>
        </table>
      </div>
    </div>
  )
}