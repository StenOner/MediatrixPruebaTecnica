import { redirect, RedirectType } from 'next/navigation'

export default function PaymentsPage() {
  redirect('/payments/create', RedirectType.replace)
}