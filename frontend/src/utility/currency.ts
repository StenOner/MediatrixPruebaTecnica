export class CurrencyUtil {
  static formatCurrency(amount: number, locale = 'es-US', currency = 'USD'): string {
    return new Intl.NumberFormat(locale, {
      style: 'currency',
      currency: currency,
    }).format(amount)
  }
}