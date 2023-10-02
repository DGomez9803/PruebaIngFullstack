import { Component } from '@angular/core';
import { CurrencyService } from '../../services/currency.service/currency.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent {
  selectedCurrency: string = 'USD';

  constructor(private currencyService: CurrencyService) {}

  updateCurrency() {
    this.currencyService.setSelectedCurrency(this.selectedCurrency);
  }

}
