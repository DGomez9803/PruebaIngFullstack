import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CurrencyService {
  public selectedCurrency:string ="USD";
  private conversionRates: { [key: string]: number }= {
    "USD": 1.0,
    "EUR": 0.94,
    "COP": 4070
  };
  currency$: BehaviorSubject<any> = new BehaviorSubject<any>(this.selectedCurrency)

  setSelectedCurrency(currency: string): void {
    this.selectedCurrency=currency;
    this.currency$.next(this.selectedCurrency)

  }
  convert(amount: number): number {
    const fromRate = this.conversionRates[this.selectedCurrency];
    return amount * fromRate;
  }
}
