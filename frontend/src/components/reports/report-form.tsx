export default function ReportForm({ form, handleChange, handleSubmit }: {
  form: { inicio: string, fin: string }
  handleChange: (e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>) => void
  handleSubmit: (e: React.FormEvent<HTMLFormElement>) => void
}) {
  return (
    <form onSubmit={handleSubmit} className='flex flex-col gap-y-3 justify-self-center'>
      <div className='flex gap-x-6 items-center'>
        <div className='text-black'>
          <label>Fecha Inicio</label>
          <input
            type='date'
            name='inicio'
            value={form.inicio}
            onChange={handleChange}
            className='block w-full text-lg text-black px-5 py-3 border border-y-gray-700 rounded-lg transition-colors'
            required
          />
        </div>

        <div className='text-black'>
          <label>Fecha Fin</label>
          <input
            type='date'
            name='fin'
            value={form.fin}
            onChange={handleChange}
            className='block w-full text-lg text-black px-5 py-3 border border-y-gray-700 rounded-lg transition-colors'
            required
          />
        </div>
      </div>
      <div className='flex items-end text-black'>
        <button
          type="submit"
          className="w-full flex items-center justify-center gap-2 py-3 px-4 border border-transparent rounded-lg shadow-sm bg-blue-400 text-white font-medium transition-all hover:cursor-pointer"
        >
          Ver Reporte
        </button>
      </div>
    </form>
  )
}