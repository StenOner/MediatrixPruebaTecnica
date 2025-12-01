export default function Footer({ sidebarOpen }: { sidebarOpen?: boolean }) {
  return (
    <footer className={`h-16 flex items-center justify-between px-8 shadow-lg transition-all duration-300 ${sidebarOpen ? 'ml-64' : 'ml-20'}`}
      style={{ backgroundColor: 'rgba(13, 48, 72, 0.9)' }}>
      <p className="text-gray-300 text-sm">
        © 2025 Prueba Tecnica.
      </p>
      <p className="text-gray-300 text-sm">
        Versión 1.0.0
      </p>
    </footer>
  )
}