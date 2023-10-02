import { Pipe, PipeTransform } from '@angular/core';
import { CurrencyService } from '../services/currency.service/currency.service';
import { Subscription } from 'rxjs';

@Pipe({
  name: 'convertCurrency',
  pure: false

})
export class ConvertCurrencyPipe implements PipeTransform
{
  public value: string = ''
  private listen$: Array<Subscription> = []

  constructor(private currencyService: CurrencyService) {

  }

  transform(price: number): any  {
    const observer$ = this.currencyService.currency$
    .subscribe((currency) => {
      this.value = `${this.currencyService.convert(price)} ${currency}`;

    })
    this.listen$ = [observer$];

    return this.value;
  }
  ngOnDestroy(): void {
    this.listen$.forEach(a => a.unsubscribe())
  }

}
