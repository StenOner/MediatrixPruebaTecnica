export class DateUtil {
  static getFirstDayOfMonth(date?: Date): Date {
    const d = date ? new Date(date) : new Date()
    return new Date(d.getFullYear(), d.getMonth(), 1)
  }

  static getLastDayOfMonth(date?: Date): Date {
    const d = date ? new Date(date) : new Date()
    return new Date(d.getFullYear(), d.getMonth() + 1, 0)
  }

  static formatDateToYYYYMMDD(date: Date | string): string {
    const d = typeof date === 'string' ? new Date(date) : date
    const year = d.getFullYear()
    const month = (d.getMonth() + 1).toString().padStart(2, '0')
    const day = d.getDate().toString().padStart(2, '0')
    return `${year}-${month}-${day}`
  }

  static formatDateToYYYYMMDDHHMMSS(date: Date | string): string {
    const d = typeof date === 'string' ? new Date(date) : date
    const year = d.getFullYear()
    const month = (d.getMonth() + 1).toString().padStart(2, '0')
    const day = d.getDate().toString().padStart(2, '0')
    const hours = d.getHours().toString().padStart(2, '0')
    const minutes = d.getMinutes().toString().padStart(2, '0')
    const seconds = d.getSeconds().toString().padStart(2, '0')
    return `${year}-${month}-${day} ${hours}:${minutes}:${seconds}`
  }
}