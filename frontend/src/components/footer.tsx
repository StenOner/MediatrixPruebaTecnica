export default function Footer() {
  return (
    <footer className="h-16 flex items-center justify-between px-8 shadow-lg mt-auto"
      style={{ backgroundColor: 'rgba(13, 48, 72, 0.9)' }}>
      <p className="text-gray-300 text-sm">
        © 2024 Sistema de Nómina. Todos los derechos reservados.
      </p>
      <p className="text-gray-300 text-sm">
        Versión 1.0.0
      </p>
    </footer>
  )
}