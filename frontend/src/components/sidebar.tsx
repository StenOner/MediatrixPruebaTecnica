import { Home, Users, DollarSign, FileText, LogOut, ChevronLeft, ChevronRight } from 'lucide-react'

export default function Sidebar({ sidebarOpen, setSidebarOpen }: { sidebarOpen: boolean, setSidebarOpen?: (open: boolean) => void }) {
  const menuItems = [
    { icon: Home, label: 'Dashboard', href: '/' },
    { icon: Users, label: 'Empleados', href: '/empleados' },
    { icon: DollarSign, label: 'Pagos', href: '/pagos' },
    { icon: FileText, label: 'Reportes', href: '/reportes' },
    // { icon: Settings, label: 'Configuración', href: '/configuracion' },
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
            {/* SVG Logo Placeholder - Reemplaza con tu SVG */}
            <svg
              viewBox="0 0 200 80"
              className="w-full h-auto"
              xmlns="http://www.w3.org/2000/svg"
            >
              {/* Icono de edificio corporativo */}
              <rect x="70" y="20" width="60" height="50" fill="white" opacity="0.9" />
              <rect x="75" y="25" width="10" height="10" fill="rgba(13, 48, 72, 0.9)" />
              <rect x="90" y="25" width="10" height="10" fill="rgba(13, 48, 72, 0.9)" />
              <rect x="105" y="25" width="10" height="10" fill="rgba(13, 48, 72, 0.9)" />
              <rect x="75" y="40" width="10" height="10" fill="rgba(13, 48, 72, 0.9)" />
              <rect x="90" y="40" width="10" height="10" fill="rgba(13, 48, 72, 0.9)" />
              <rect x="105" y="40" width="10" height="10" fill="rgba(13, 48, 72, 0.9)" />
              <rect x="85" y="55" width="30" height="15" fill="rgba(13, 48, 72, 0.9)" />
              <polygon points="100,10 70,20 130,20" fill="white" opacity="0.9" />

              {/* Texto */}
              <text x="100" y="82" fontFamily="Arial, sans-serif" fontSize="10" fill="white" textAnchor="middle" fontWeight="bold">
                MI EMPRESA
              </text>
            </svg>
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
        <button className="flex items-center gap-3 px-4 py-3 text-gray-200 hover:bg-white/10 rounded-lg transition-all w-full">
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