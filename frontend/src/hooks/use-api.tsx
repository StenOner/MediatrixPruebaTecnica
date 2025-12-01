'use client'

import { ApiResponse } from '@/types/response'
import axios, { AxiosInstance, AxiosRequestConfig } from 'axios'
import { useRouter } from 'next/navigation'
import { useCallback, useMemo, useState } from 'react'

const API_BASE_URL = process.env.NEXT_PUBLIC_API_BASE_URL || 'https://localhost:5000/api'
const TOKEN_KEY = process.env.TOKEN_KEY || 'bearer_token'

export function useApi() {
  const [token, setToken] = useState<string | null>(() => {
    try {
      return localStorage.getItem(TOKEN_KEY)
    } catch {
      return null
    }
  })
  const router = useRouter()

  const axiosInstance: AxiosInstance = useMemo(() => {
    return axios.create({ baseURL: API_BASE_URL })
  }, [])

  const attachAuth = useCallback((config?: AxiosRequestConfig) => {
    const cfg: AxiosRequestConfig = { ...(config ?? {}) }
    const existing = cfg.headers as Record<string, string> | undefined
    const headers: Record<string, string> = { ...(existing ?? {}) }
    if (token) headers['Authorization'] = `Bearer ${token}`
    cfg.headers = headers
    return cfg
  }, [token])

  const get = useCallback(async <T = unknown>(url: string, config?: AxiosRequestConfig) => {
    const res = await axiosInstance.get<ApiResponse<T>>(url, attachAuth(config))
    return res.data.content
  }, [axiosInstance, attachAuth])

  const post = useCallback(async <T = unknown>(url: string, data?: unknown, config?: AxiosRequestConfig) => {
    const res = await axiosInstance.post<ApiResponse<T>>(url, data, attachAuth(config))
    return res.data.content
  }, [axiosInstance, attachAuth])

  const put = useCallback(async <T = unknown>(url: string, data?: unknown, config?: AxiosRequestConfig) => {
    const res = await axiosInstance.put<ApiResponse<T>>(url, data, attachAuth(config))
    return res.data.content
  }, [axiosInstance, attachAuth])

  const patch = useCallback(async <T = unknown>(url: string, data?: unknown, config?: AxiosRequestConfig) => {
    const res = await axiosInstance.patch<ApiResponse<T>>(url, data, attachAuth(config))
    return res.data.content
  }, [axiosInstance, attachAuth])

  const del = useCallback(async <T = unknown>(url: string, config?: AxiosRequestConfig) => {
    const res = await axiosInstance.delete<ApiResponse<T>>(url, attachAuth(config))
    return res.data.content
  }, [axiosInstance, attachAuth])

  const login = useCallback(async (nombreUsuario: string, password: string) => {
    const payload = { nombreUsuario, password }
    const res = await axiosInstance.post<ApiResponse<{ token: string }>>('/login', payload)
    const content = res.data.content
    const token = content.data?.token ?? ''
    localStorage.setItem(TOKEN_KEY, token)
    setToken(token)

    return content
  }, [axiosInstance])

  const logout = useCallback(() => {
    localStorage.removeItem(TOKEN_KEY)
    setToken(null)
    router.push('/auth/login')
  }, [router])

  return {
    get,
    post,
    put,
    patch,
    del,
    login,
    logout,
  }
}

export type UseApiHook = ReturnType<typeof useApi>