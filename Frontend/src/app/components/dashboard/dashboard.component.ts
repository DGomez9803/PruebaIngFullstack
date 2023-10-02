import { ApiService } from '../../services/api.service/api.service';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators, AbstractControl } from '@angular/forms';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})


export class DashboardComponent {
  origin: string = '';
  destination:string = '';
  journey: any;
  message: string = '';
  form: FormGroup;
  showError: boolean = false;
  isLoading: boolean = false;
  constructor(private apiService: ApiService,private formBuilder: FormBuilder) {
    this.form = this.formBuilder.group({
      origin: ['', [Validators.required]],
      destination: ['', Validators.required],
    }, { validator: this.originDestinationValidator });
  }
  originDestinationValidator(control: AbstractControl) {
    const origin = control.get('origin');
    const destination = control.get('destination');

    if (origin && destination && origin.value == destination.value) {
      return { originDestinationValidator: true };
    } else {

      return null;
    }
  }
  search() {
    if (this.form.valid) {
      this.isLoading = true;
        this.apiService.getJourney(this.origin,this.destination).subscribe((data) => {
          if (data === null) {
            this.journey = undefined;
            this.message="Flight not found with the selected parameters";
            } else {
              this.message="";
              this.journey = data;
            }
            this.isLoading = false;
      })
    }else{
      if(this.origin=="" || this.destination==""){
        this.showError = true;
      }
    }
  }
  fieldNotFull(campo: string): boolean {
    const control = this.form.get(campo);
    return  control !== null && control.invalid && (control.dirty || control.touched);
  }

  upperCase() {
    this.showError = false;
    this.origin = this.origin.toUpperCase();
    this.destination = this.destination.toUpperCase();

  }
}
