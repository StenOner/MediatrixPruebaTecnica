"use client"

import React, { useEffect, useState } from 'react'
import { useRouter } from 'next/navigation'
import { jwtDecode } from 'jwt-decode'

const TOKEN_KEY = process.env.TOKEN_KEY || 'bearer_token'

export default function withAuth<P extends Record<string, unknown>>(
  WrappedComponent: React.ComponentType<P>
) {
  const ComponentWithAuth: React.FC<P> = (props) => {
    const router = useRouter()
    const [checked, setChecked] = useState(false)
    const [username, setUsername] = useState<string>('')
    const [role, setRole] = useState<string>('')

    useEffect(() => {
      try {
        const token = localStorage.getItem(TOKEN_KEY)
        if (!token) {
          router.replace('/auth/login')
          return
        }

        const payload = jwtDecode<Record<string, unknown>>(token)
        const name = payload['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name'] as string ?? ''
        const role = payload['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'] as string ?? ''

        setUsername(name)
        setRole(role)
        setChecked(true)
      } catch {
        router.replace('/auth/login')
      }
    }, [router])

    if (!checked) return null

    return <WrappedComponent {...(props as P)} username={username} role={role} />
  }

  ComponentWithAuth.displayName = `withAuth(${WrappedComponent.displayName || WrappedComponent.name || 'Component'})`

  return ComponentWithAuth
}
