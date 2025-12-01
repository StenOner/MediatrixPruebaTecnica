'use client'

import { useApi } from '@/hooks/use-api'
import { Users, DollarSign, FileText, LogOut, ChevronLeft, ChevronRight } from 'lucide-react'
import Image from 'next/image'

export default function Sidebar({ sidebarOpen, setSidebarOpen }: { sidebarOpen: boolean, setSidebarOpen?: (open: boolean) => void }) {
  const { logout } = useApi()
  const menuItems = [
    { icon: Users, label: 'Empleados', href: '/employees' },
    { icon: DollarSign, label: 'Pagos', href: '/payments' },
    { icon: FileText, label: 'Reportes', href: '/reports' },
  ]

  return (
    <aside
      className={`${sidebarOpen ? 'w-64' : 'w-20'} transition-all duration-300 flex flex-col fixed left-0 top-0 bottom-0 z-30`}
      style={{ backgroundColor: 'rgba(13, 48, 72, 0.9)' }}
    >
      {/* Logo Section */}
      <div className="h-32 flex items-center justify-center p-4">
        {sidebarOpen ? (
          <div className="w-full">
            <Image src="../icons/logo.svg" alt="Logo" width={300} height={300} className="object-contain" />
          </div>
        ) : (
          <div className="w-10 h-10 bg-white/20 rounded-lg flex items-center justify-center">
            <svg viewBox="0 0 24 24" className="w-6 h-6" fill="white">
              <rect x="3" y="3" width="18" height="18" />
            </svg>
          </div>
        )}
      </div>

      {/* Navigation */}
      <nav className="flex-1 py-6 overflow-y-auto border-t border-white/10">
        <ul className="space-y-2 px-3">
          {menuItems.map((item, index) => (
            <li key={index}>
              <a
                href={item.href}
                className="flex items-center gap-3 px-4 py-3 text-gray-200 hover:bg-white/10 rounded-lg transition-all group"
              >
                <item.icon size={22} className="shrink-0" />
                {sidebarOpen && (
                  <span className="font-medium">{item.label}</span>
                )}
              </a>
            </li>
          ))}
        </ul>
      </nav>

      {/* Sidebar Footer */}
      <div className="border-t border-white/10 p-4">
        <button className="flex items-center gap-3 px-4 py-3 text-gray-200 hover:bg-white/10 hover:cursor-pointer rounded-lg transition-all w-full" onClick={logout}>
          <LogOut size={22} className="shrink-0" />
          {sidebarOpen && <span className="font-medium">Cerrar Sesión</span>}
        </button>
      </div>

      {/* Toggle Button */}
      <button
        onClick={() => setSidebarOpen!(!sidebarOpen)}
        className="absolute -right-3 top-36 bg-white shadow-lg rounded-full p-1.5 hover:bg-gray-100 transition-colors z-40"
        style={{ color: 'rgba(13, 48, 72, 0.9)' }}
      >
        {sidebarOpen ? <ChevronLeft size={20} /> : <ChevronRight size={20} />}
      </button>
    </aside>
  )
}