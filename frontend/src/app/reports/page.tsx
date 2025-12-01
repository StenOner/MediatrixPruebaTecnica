'use client'

import ReportForm from '@/components/reports/report-form'
import ReportTable from '@/components/reports/report-table'
import { useApi } from '@/hooks/use-api'
import { ReportDto } from '@/types/report'
import { CurrencyUtil } from '@/utility/currency'
import { DateUtil } from '@/utility/date'
import { CircleDollarSign, DollarSign, MinusCircle, Send } from 'lucide-react'
import { Activity, ChangeEvent, FormEvent, useState } from 'react'
import toast from 'react-hot-toast'

export default function ReportPage() {
  const { get } = useApi()
  const [form, setForm] = useState({
    inicio: DateUtil.formatDateToYYYYMMDD(DateUtil.getFirstDayOfMonth()),
    fin: DateUtil.formatDateToYYYYMMDD(DateUtil.getLastDayOfMonth()),
  })
  const [reportData, setReportData] = useState<ReportDto>()

  const handleChange = (e: ChangeEvent<HTMLInputElement | HTMLSelectElement>) => {
    const { name, value } = e.target
    setForm(prev => ({ ...prev, [name]: value }))
  }

  const handleSubmit = async (e: FormEvent<HTMLFormElement>) => {
    e.preventDefault()

    if (form.inicio > form.fin) {
      toast.error('La fecha de inicio no puede ser mayor que la fecha de fin.')
      return
    }

    const response = await get<ReportDto>(`/pagos/reporte?inicio=${form.inicio}&fin=${form.fin}`)
    setReportData(response.data)
  }

  return (
    <div className='p-6 space-y-6 bg-gray-50 min-h-screen rounded-xl'>
      <div className='max-w-7xl mx-auto'>
        <ReportForm form={form} handleChange={handleChange} handleSubmit={handleSubmit} />
      </div>

      <Activity mode={reportData ? 'visible' : 'hidden'}>
        <div className='max-w-7xl mx-auto'>
          <div className='grid grid-cols-1 md:grid-cols-4 gap-4 mb-6'>
            <div className='bg-white rounded-lg shadow p-4 border-l-4 border-yellow-500'>
              <div className='flex items-center justify-between'>
                <div>
                  <p className='text-gray-600 text-sm'>Pagos Realizados</p>
                  <p className='text-2xl font-bold text-gray-800'>{reportData?.pagos.length}</p>
                </div>
                <Send className='text-yellow-500' size={32} />
              </div>
            </div>

            <div className='bg-white rounded-lg shadow p-4 border-l-4 border-green-500'>
              <div className='flex items-center justify-between'>
                <div>
                  <p className='text-gray-600 text-sm'>Total Bruto</p>
                  <p className='text-2xl font-bold text-gray-800'>{CurrencyUtil.formatCurrency(reportData?.totalBruto ?? 0)}</p>
                </div>
                <CircleDollarSign className='text-green-500' size={32} />
              </div>
            </div>

            <div className='bg-white rounded-lg shadow p-4 border-l-4 border-red-500'>
              <div className='flex items-center justify-between'>
                <div>
                  <p className='text-gray-600 text-sm'>Total Deducciones</p>
                  <p className='text-2xl font-bold text-gray-800'>{CurrencyUtil.formatCurrency(reportData?.totalDeducciones ?? 0)}</p>
                </div>
                <MinusCircle className='text-red-500' size={32} />
              </div>
            </div>

            <div className='bg-white rounded-lg shadow p-4 border-l-4 border-blue-500'>
              <div className='flex items-center justify-between'>
                <div>
                  <p className='text-gray-600 text-sm'>Total Neto</p>
                  <p className='text-2xl font-bold text-gray-800'>{CurrencyUtil.formatCurrency(reportData?.totalNeto ?? 0)}</p>
                </div>
                <DollarSign className='text-blue-500' size={32} />
              </div>
            </div>
          </div>

          <ReportTable reportData={reportData} setReportData={setReportData} />
        </div>
      </Activity>
    </div>
  )
}