import type { EmployeeFormType } from '@/types/employee'

export default function EmployeeForm({ form, handleChange, handleSubmit }: {
  form: EmployeeFormType
  handleChange: (e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>) => void
  handleSubmit: (e: React.FormEvent<HTMLFormElement>) => void
}) {
  return (
    <form onSubmit={handleSubmit} className="mx-auto space-y-4 items-center max-w-md">

      <div className='text-black'>
        <label>Tipo de Empleado</label>
        <select
          name="tipoEmpleado"
          value={form.tipoEmpleado}
          onChange={handleChange}
          className="block w-full text-lg text-black px-5 py-3 border border-y-gray-700 rounded-lg transition-colors"
        >
          <option value="Asalariado">Asalariado</option>
          <option value="AsalariadoPorComision">Asalariado por comisión</option>
          <option value="PorComision">Por comisión</option>
          <option value="PorHoras">Por horas</option>
        </select>
      </div>

      <div className='text-black'>
        <label>Primer Nombre</label>
        <input
          type="text"
          name="primerNombre"
          value={form.primerNombre}
          onChange={handleChange}
          className="block w-full text-lg text-black px-5 py-3 border border-y-gray-700 rounded-lg transition-colors"
          required
        />
      </div>

      <div className='text-black'>
        <label>Apellido Paterno</label>
        <input
          type="text"
          name="apellidoPaterno"
          value={form.apellidoPaterno}
          onChange={handleChange}
          className="block w-full text-lg text-black px-5 py-3 border border-y-gray-700 rounded-lg transition-colors"
          required
        />
      </div>

      <div className='text-black' hidden={form.isUpdate}>
        <label>Número Seguro Social</label>
        <input
          type="text"
          name="numeroSeguroSocial"
          value={form.numeroSeguroSocial}
          onChange={handleChange}
          className="block w-full text-lg text-black px-5 py-3 border border-y-gray-700 rounded-lg transition-colors"
          required={!form.isUpdate}
        />
      </div>

      <div className='text-black'>
        <label>Departamento</label>
        <input
          type="text"
          name="departamento"
          value={form.departamento}
          onChange={handleChange}
          className="block w-full text-lg text-black px-5 py-3 border border-y-gray-700 rounded-lg transition-colors"
          required
        />
      </div>

      <div className='text-black' hidden={!['Asalariado'].includes(form.tipoEmpleado)}>
        <label>Salario Semanal</label>
        <input
          type="number"
          name="salarioSemanal"
          value={form.salarioSemanal}
          onChange={handleChange}
          className="block w-full text-lg text-black px-5 py-3 border border-y-gray-700 rounded-lg transition-colors"
        />
      </div>

      <div className='text-black' hidden={!['AsalariadoPorComision'].includes(form.tipoEmpleado)}>
        <label>Salario Base</label>
        <input
          type="number"
          name="salarioBase"
          value={form.salarioBase}
          onChange={handleChange}
          className="block w-full text-lg text-black px-5 py-3 border border-y-gray-700 rounded-lg transition-colors"
        />
      </div>

      <div className='text-black' hidden={!['AsalariadoPorComision', 'PorComision'].includes(form.tipoEmpleado)}>
        <label>Ventas Brutas</label>
        <input
          type="number"
          name="ventasBrutas"
          value={form.ventasBrutas}
          onChange={handleChange}
          className="block w-full text-lg text-black px-5 py-3 border border-y-gray-700 rounded-lg transition-colors"
        />
      </div>

      <div className='text-black' hidden={!['AsalariadoPorComision', 'PorComision'].includes(form.tipoEmpleado)}>
        <label>Tarifa Comision</label>
        <input
          type="number"
          name="tarifaComision"
          value={form.tarifaComision}
          onChange={handleChange}
          className="block w-full text-lg text-black px-5 py-3 border border-y-gray-700 rounded-lg transition-colors"
        />
      </div>

      <div className='text-black' hidden={!['PorHoras'].includes(form.tipoEmpleado)}>
        <label>Sueldo por Hora</label>
        <input
          type="number"
          name="sueldoPorHora"
          value={form.sueldoPorHora}
          onChange={handleChange}
          className="block w-full text-lg text-black px-5 py-3 border border-y-gray-700 rounded-lg transition-colors"
        />
      </div>

      <div className='text-black' hidden={!['PorHoras'].includes(form.tipoEmpleado)}>
        <label>Horas Trabajadas</label>
        <input
          type="number"
          name="horasTrabajadas"
          value={form.horasTrabajadas}
          onChange={handleChange}
          className="block w-full text-lg text-black px-5 py-3 border border-y-gray-700 rounded-lg transition-colors"
        />
      </div>

      <div className='text-black'>
        <label>Activo</label>
        <select
          name="activo"
          value={form.activo}
          onChange={handleChange}
          className="block w-full text-lg text-black px-5 py-3 border border-y-gray-700 rounded-lg transition-colors"
        >
          <option value="true">Activo</option>
          <option value="false">Inactivo</option>
        </select>
      </div>

      <button
        type="submit"
        className="w-full flex items-center justify-center gap-2 py-3 px-4 border border-transparent rounded-lg shadow-sm bg-blue-400 text-white font-medium transition-all hover:cursor-pointer"
      >
        Guardar
      </button>

    </form>
  )
}