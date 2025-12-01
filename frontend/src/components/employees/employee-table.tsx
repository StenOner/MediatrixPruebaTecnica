import { Search, Filter, ChevronUp, ChevronDown, Edit, Trash2, PlusIcon, X, DollarSign, User, Briefcase } from 'lucide-react'
import { useState, useMemo } from 'react'
import { EmployeeDto } from '@/types/employee'
import { useApi } from '@/hooks/use-api'
import { useRouter } from 'next/navigation'
import toast from 'react-hot-toast'
import { CurrencyUtil } from '@/utility/currency'

type SortField = keyof EmployeeDto
type SortDirection = 'asc' | 'desc'

export default function EmployeeTable({ employees, setEmployees }: { employees: EmployeeDto[], setEmployees: (employees: EmployeeDto[]) => void }) {
  const { del } = useApi()
  const router = useRouter()
  const [searchTerm, setSearchTerm] = useState('')
  const [departamentoFilter, setDepartamentoFilter] = useState('')
  const [tipoEmployeeFilter, setTipoEmployeeFilter] = useState('')
  const [estadoFilter, setEstadoFilter] = useState<'all' | 'activo' | 'inactivo'>('all')
  const [sortField, setSortField] = useState<SortField>('apellidoPaterno')
  const [sortDirection, setSortDirection] = useState<SortDirection>('asc')
  const [showFilters, setShowFilters] = useState(false)

  const departamentos = useMemo(() => {
    return Array.from(new Set(employees.map(e => e.departamento))).sort()
  }, [employees])

  const tipos = ['Asalariado', 'AsalariadoPorComision', 'PorComision', 'PorHoras']

  const employeesFiltrados = useMemo(() => {
    const filtered = employees.filter(employee => {
      // Filtro de búsqueda
      const searchLower = searchTerm.toLowerCase()
      const matchesSearch =
        employee.primerNombre.toLowerCase().includes(searchLower) ||
        employee.apellidoPaterno.toLowerCase().includes(searchLower) ||
        employee.numeroSeguroSocial.includes(searchTerm) ||
        employee.departamento.toLowerCase().includes(searchLower)

      // Filtro de departamento
      const matchesDepartamento = !departamentoFilter || employee.departamento === departamentoFilter

      // Filtro de tipo de empleado
      const matchesTipo = !tipoEmployeeFilter || employee.tipoEmpleado === tipoEmployeeFilter

      // Filtro de estado
      const matchesEstado =
        estadoFilter === 'all' ||
        (estadoFilter === 'activo' && employee.activo) ||
        (estadoFilter === 'inactivo' && !employee.activo)

      return matchesSearch && matchesDepartamento && matchesTipo && matchesEstado
    })

    // Ordenar
    filtered.sort((a, b) => {
      let aValue = a[sortField]
      let bValue = b[sortField]

      // Convertir a string para comparación
      if (typeof aValue === 'string') aValue = aValue.toLowerCase()
      if (typeof bValue === 'string') bValue = bValue.toLowerCase()

      if (aValue < bValue) return sortDirection === 'asc' ? -1 : 1
      if (aValue > bValue) return sortDirection === 'asc' ? 1 : -1
      return 0
    })

    return filtered
  }, [employees, searchTerm, departamentoFilter, tipoEmployeeFilter, estadoFilter, sortField, sortDirection])

  const handleSort = (field: SortField) => {
    if (sortField === field) {
      setSortDirection(sortDirection === 'asc' ? 'desc' : 'asc')
    } else {
      setSortField(field)
      setSortDirection('asc')
    }
  }

  const clearFilters = () => {
    setSearchTerm('')
    setDepartamentoFilter('')
    setTipoEmployeeFilter('')
    setEstadoFilter('all')
  }

  const getTipoEmployeeBadge = (tipo: string) => {
    const colors = {
      'Asalariado': 'bg-blue-100 text-blue-800',
      'AsalariadoPorComision': 'bg-purple-100 text-purple-800',
      'PorComision': 'bg-green-100 text-green-800',
      'PorHoras': 'bg-yellow-100 text-yellow-800',
    }
    return colors[tipo as keyof typeof colors] || 'bg-gray-100 text-gray-800'
  }

  const SortIcon = ({ field }: { field: SortField }) => {
    if (sortField !== field) return null
    return sortDirection === 'asc' ?
      <ChevronUp size={16} className='inline ml-1' /> :
      <ChevronDown size={16} className='inline ml-1' />
  }

  const handleDelete = async (employeeId: string) => {
    const confirmed = confirm('¿Estás seguro de que deseas eliminar este empleado?')
    if (!confirmed) return

    await toast.promise(
      del(`/empleados/${employeeId}`),
      {
        loading: 'Eliminando empleado...',
        success: 'Empleado eliminado correctamente.',
        error: 'Error al eliminar el empleado.',
      }
    )
    setEmployees(employees.filter(e => e.id !== employeeId))
  }

  const handleUpdate = async (employeeId: string) => {
    router.push(`/employees/${employeeId}/update`)
  }

  return (
    <div className='p-6 bg-gray-50 min-h-screen rounded-xl'>
      <div className='max-w-7xl mx-auto'>
        {/* Stats Cards */}
        <div className='grid grid-cols-1 md:grid-cols-4 gap-4 mb-6'>
          <div className='bg-white rounded-lg shadow p-4 border-l-4 border-blue-500'>
            <div className='flex items-center justify-between'>
              <div>
                <p className='text-gray-600 text-sm'>Total Empleados</p>
                <p className='text-2xl font-bold text-gray-800'>{employees.length}</p>
              </div>
              <User className='text-blue-500' size={32} />
            </div>
          </div>

          <div className='bg-white rounded-lg shadow p-4 border-l-4 border-green-500'>
            <div className='flex items-center justify-between'>
              <div>
                <p className='text-gray-600 text-sm'>Activos</p>
                <p className='text-2xl font-bold text-gray-800'>
                  {employees.filter(e => e.activo).length}
                </p>
              </div>
              <User className='text-green-500' size={32} />
            </div>
          </div>

          <div className='bg-white rounded-lg shadow p-4 border-l-4 border-purple-500'>
            <div className='flex items-center justify-between'>
              <div>
                <p className='text-gray-600 text-sm'>Departamentos</p>
                <p className='text-2xl font-bold text-gray-800'>{departamentos.length}</p>
              </div>
              <Briefcase className='text-purple-500' size={32} />
            </div>
          </div>

          <div className='bg-white rounded-lg shadow p-4 border-l-4 border-yellow-500'>
            <div className='flex items-center justify-between'>
              <div>
                <p className='text-gray-600 text-sm'>Nómina Total</p>
                <p className='text-2xl font-bold text-gray-800'>
                  {CurrencyUtil.formatCurrency(employees.reduce((sum, e) => sum + e.pagoSemanal, 0))}
                </p>
              </div>
              <DollarSign className='text-yellow-500' size={32} />
            </div>
          </div>
        </div>

        {/* Filters Section */}
        <div className='bg-white rounded-lg shadow-md mb-6 p-4'>
          <div className='flex flex-col lg:flex-row gap-4'>
            {/* Search Bar */}
            <div className='flex-1'>
              <div className='relative'>
                <Search className='absolute left-3 top-1/2 transform -translate-y-1/2 text-black' size={20} />
                <input
                  type='text'
                  placeholder='Buscar por nombre, apellido o NSS...'
                  value={searchTerm}
                  onChange={(e) => setSearchTerm(e.target.value)}
                  className='w-full text-black pl-10 pr-4 py-2 border border-gray-300 rounded-lg focus:ring-2 focus:ring-blue-500 focus:border-blue-500'
                />
              </div>
            </div>

            {/* Filter Toggle Button */}
            <button
              onClick={() => setShowFilters(!showFilters)}
              className='flex text-black items-center gap-2 px-4 py-2 bg-gray-100 hover:bg-gray-200 rounded-lg transition-colors'
            >
              <Filter size={20} />
              <span>Filtros</span>
              {(departamentoFilter || tipoEmployeeFilter || estadoFilter !== 'all') && (
                <span className='bg-blue-500 text-white text-xs rounded-full w-5 h-5 flex items-center justify-center'>
                  {[departamentoFilter, tipoEmployeeFilter, estadoFilter !== 'all' ? '1' : ''].filter(Boolean).length}
                </span>
              )}
            </button>
          </div>

          {/* Advanced Filters */}
          {showFilters && (
            <div className='mt-4 pt-4 border-t border-gray-200'>
              <div className='grid grid-cols-1 md:grid-cols-3 gap-4'>
                {/* Departamento Filter */}
                <div>
                  <label className='block text-sm font-medium text-gray-700 mb-2'>
                    Departamento
                  </label>
                  <select
                    value={departamentoFilter}
                    onChange={(e) => setDepartamentoFilter(e.target.value)}
                    className='w-full text-black px-3 py-2 border border-gray-300 rounded-lg focus:ring-2 focus:ring-blue-500 focus:border-blue-500'
                  >
                    <option value=''>Todos</option>
                    {departamentos.map(dept => (
                      <option key={dept} value={dept}>{dept}</option>
                    ))}
                  </select>
                </div>

                {/* Tipo Employee Filter */}
                <div>
                  <label className='block text-sm font-medium text-gray-700 mb-2'>
                    Tipo de Employee
                  </label>
                  <select
                    value={tipoEmployeeFilter}
                    onChange={(e) => setTipoEmployeeFilter(e.target.value)}
                    className='w-full text-black px-3 py-2 border border-gray-300 rounded-lg focus:ring-2 focus:ring-blue-500 focus:border-blue-500'
                  >
                    <option value=''>Todos</option>
                    {tipos.map(tipo => (
                      <option key={tipo} value={tipo}>{tipo}</option>
                    ))}
                  </select>
                </div>

                {/* Estado Filter */}
                <div>
                  <label className='block text-sm font-medium text-gray-700 mb-2'>
                    Estado
                  </label>
                  <select
                    value={estadoFilter}
                    onChange={(e) => setEstadoFilter(e.target.value as 'all' | 'activo' | 'inactivo')}
                    className='w-full text-black px-3 py-2 border border-gray-300 rounded-lg focus:ring-2 focus:ring-blue-500 focus:border-blue-500'
                  >
                    <option value='all'>Todos</option>
                    <option value='activo'>Activos</option>
                    <option value='inactivo'>Inactivos</option>
                  </select>
                </div>
              </div>

              {/* Clear Filters Button */}
              {(searchTerm || departamentoFilter || tipoEmployeeFilter || estadoFilter !== 'all') && (
                <div className='mt-4'>
                  <button
                    onClick={clearFilters}
                    className='flex items-center gap-2 px-4 py-2 text-sm text-red-600 hover:bg-red-50 rounded-lg transition-colors'
                  >
                    <X size={16} />
                    Limpiar todos los filtros
                  </button>
                </div>
              )}
            </div>
          )}
        </div>

        {/* Results Count */}
        <div className='flex mb-4'>
          <div className='flex flex-1 gap-1 text-gray-600'>
            <span>Mostrando</span>
            <strong>{employeesFiltrados.length}</strong>
            <span>de</span>
            <strong>{employees.length}</strong>
            <span>empleados</span>
          </div>
          <div className='text-black mr-2'>
            <button
              className='p-2 bg-blue-600 text-white hover:bg-blue-600/70 hover:cursor-pointer rounded-lg transition-colors'
              title='Agregar'
              onClick={() => router.push('/employees/create')}
            >
              <PlusIcon size={18} />
            </button>
          </div>
        </div>

        {/* Table */}
        <div className='bg-white rounded-lg shadow-md overflow-hidden'>
          <div className='overflow-x-auto'>
            <table className='w-full'>
              <thead style={{ backgroundColor: 'rgba(13, 48, 72, 0.9)' }}>
                <tr>
                  <th
                    className='px-6 py-4 text-left text-sm font-semibold text-white cursor-pointer hover:bg-white/10'
                    onClick={() => handleSort('apellidoPaterno')}
                  >
                    Nombre <SortIcon field='apellidoPaterno' />
                  </th>
                  <th
                    className='px-6 py-4 text-left text-sm font-semibold text-white cursor-pointer hover:bg-white/10'
                    onClick={() => handleSort('numeroSeguroSocial')}
                  >
                    NSS <SortIcon field='numeroSeguroSocial' />
                  </th>
                  <th
                    className='px-6 py-4 text-left text-sm font-semibold text-white cursor-pointer hover:bg-white/10'
                    onClick={() => handleSort('departamento')}
                  >
                    Departamento <SortIcon field='departamento' />
                  </th>
                  <th
                    className='px-6 py-4 text-left text-sm font-semibold text-white cursor-pointer hover:bg-white/10'
                    onClick={() => handleSort('tipoEmpleado')}
                  >
                    Tipo <SortIcon field='tipoEmpleado' />
                  </th>

                  <th
                    className='px-6 py-4 text-left text-sm font-semibold text-white cursor-pointer hover:bg-white/10'
                    onClick={() => handleSort('pagoSemanal')}
                  >
                    Pago Semanal <SortIcon field='pagoSemanal' />
                  </th>
                  <th
                    className='px-6 py-4 text-left text-sm font-semibold text-white cursor-pointer hover:bg-white/10'
                    onClick={() => handleSort('activo')}
                  >
                    Estado <SortIcon field='activo' />
                  </th>
                  <th className='px-6 py-4 text-right text-sm font-semibold text-white'>
                    Acciones
                  </th>
                </tr>
              </thead>
              <tbody className='divide-y divide-gray-200'>
                {employeesFiltrados.length === 0 ? (
                  <tr>
                    <td colSpan={7} className='px-6 py-12 text-center text-gray-500'>
                      <div className='flex flex-col items-center gap-2'>
                        <Search size={48} className='text-gray-300' />
                        <p className='text-lg font-medium'>No se encontraron empleados</p>
                        <p className='text-sm'>Intenta ajustar los filtros de búsqueda</p>
                      </div>
                    </td>
                  </tr>
                ) : (
                  employeesFiltrados.map((employee) => (
                    <tr key={employee.id} className='hover:bg-gray-50 transition-colors'>
                      <td className='px-6 py-4'>
                        <div>
                          <p className='font-medium text-gray-900'>
                            {employee.primerNombre} {employee.apellidoPaterno}
                          </p>
                        </div>
                      </td>
                      <td className='px-6 py-4 text-sm text-gray-600'>
                        {employee.numeroSeguroSocial}
                      </td>
                      <td className='px-6 py-4 text-sm text-gray-600'>
                        {employee.departamento}
                      </td>
                      <td className='px-6 py-4'>
                        <span className={`px-3 py-1 rounded-full text-xs font-medium ${getTipoEmployeeBadge(employee.tipoEmpleado)}`}>
                          {employee.tipoEmpleado}
                        </span>
                      </td>
                      <td className='px-6 py-4 text-sm font-semibold text-gray-900'>
                        {CurrencyUtil.formatCurrency(employee.pagoSemanal)}
                      </td>
                      <td className='px-6 py-4'>
                        <span className={`px-3 py-1 rounded-full text-xs font-medium ${employee.activo
                          ? 'bg-green-100 text-green-800'
                          : 'bg-red-100 text-red-800'
                          }`}>
                          {employee.activo ? 'Activo' : 'Inactivo'}
                        </span>
                      </td>
                      <td className='px-6 py-4'>
                        <div className='flex items-center justify-end gap-2'>
                          <button
                            className='p-2 text-green-600 hover:bg-green-50 hover:cursor-pointer rounded-lg transition-colors'
                            title='Editar'
                            onClick={() => handleUpdate(employee.id)}
                          >
                            <Edit size={18} />
                          </button>
                          <button
                            className='p-2 text-red-600 hover:bg-red-50 hover:cursor-pointer rounded-lg transition-colors'
                            title='Eliminar'
                            onClick={() => handleDelete(employee.id)}
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
      </div>
    </div>
  )
}