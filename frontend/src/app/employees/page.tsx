'use client'

import { useApi } from '@/hooks/use-api'
import { Activity, useEffect, useState } from 'react'
import type { EmployeeDto } from '@/types/employee'
import EmployeeTable from '@/components/employees/employee-table'

export default function EmployeesPage() {
  const { get } = useApi()

  const [employees, setEmployees] = useState<EmployeeDto[]>([])
  const [, setError] = useState<string | null>(null)

  useEffect(() => {
    let mounted = true
    async function loadAll() {
      setError(null)
      try {
        const all = await get<EmployeeDto[]>('/empleados')
        if (!mounted) return

        setEmployees(all.data ?? [])
      } catch {
        setError('Error al cargar empleados')
      }
    }

    loadAll()

    return () => { mounted = false }
  }, [get])

  return (
    <Activity mode={employees.length > 0 ? 'visible' : 'hidden'}>
      <EmployeeTable employees={employees} setEmployees={setEmployees} />
    </Activity>
  )
}