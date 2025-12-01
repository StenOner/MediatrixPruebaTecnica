'use client'

import { usePathname } from 'next/navigation'
import "./globals.css"
import MainLayout from '@/components/ui/main-layout'
import { Activity } from 'react'
import ToasterProvider from '@/providers/toaster-provider'

export default function RootLayout({
  children,
}: Readonly<{
  children: React.ReactNode
}>) {
  const pathname = usePathname() ?? ''
  const isAuthRoute = pathname.includes('auth')

  return (
    <html lang="en">
      <body>
        <ToasterProvider />
        <Activity mode={!isAuthRoute ? 'visible' : 'hidden'}>
          <MainLayout>
            {children}
          </MainLayout>
        </Activity>
        <Activity mode={isAuthRoute ? 'visible' : 'hidden'}>
          {children}
        </Activity>
      </body>
    </html>
  )
}
