'use client'

import { useState } from 'react'
import { User } from 'lucide-react'
import Footer from './footer'
import Sidebar from './sidebar'
import withAuth from '@/hocs/withAuth'

function MainLayout({ children, username, role }: { children: React.ReactNode, username?: string, role?: string }) {
  const [sidebarOpen, setSidebarOpen] = useState(false)

  return (
    <div className="min-h-screen flex flex-col" style={{ background: 'rgba(237, 240, 247)' }}>
      {/* Header */}
      <header
        className={`h-16 flex items-center justify-between px-6 shadow-lg z-20 transition-all duration-300 ${sidebarOpen ? 'ml-64' : 'ml-20'}`}
        style={{ backgroundColor: 'rgba(13, 48, 72, 0.9)' }}
      >
        <div className='flex'></div>

        <div className="flex items-center gap-4">
          <div className="text-right hidden md:block">
            <p className="text-white font-medium capitalize">{username}</p>
            <p className="text-gray-300 text-sm lowercase">{role}</p>
          </div>
          <div className="size-10 rounded-full bg-white/20 flex items-center justify-center text-white">
            <User size={20} />
          </div>
        </div>
      </header>

      <div className="flex flex-1 overflow-hidden">
        {/* Sidebar */}
        <Sidebar sidebarOpen={sidebarOpen} setSidebarOpen={setSidebarOpen} />

        {/* Main Content */}
        <main className={`flex-1 overflow-y-auto transition-all duration-300 ${sidebarOpen ? 'ml-64' : 'ml-20'}`}>
          <div className="p-8">
            {children}
          </div>
        </main>
      </div>

      <Footer sidebarOpen={sidebarOpen} />
    </div>
  )
}

export default withAuth(MainLayout)