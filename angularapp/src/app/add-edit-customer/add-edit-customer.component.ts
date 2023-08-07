import { Component  } from '@angular/core';
import {FormControl,Validators} from '@angular/forms';
import { Customer } from '../../model/customer';
import{Router} from '@angular/router';
import { CustomerService } from '../../services/customerservice';
import { LowerCasePipe } from '@angular/common';

@Component({
  selector: 'app-add-edit-customer',
  templateUrl: './add-edit-customer.component.html',
  styleUrls: ['./add-edit-customer.component.css']
})
export class AddEditCustomerComponent  {
  public customerRequest= new Customer();
  private customerEdit=this.router.getCurrentNavigation()?.extras?.state?this.router.getCurrentNavigation()?.extras.state:null;
  private customerId=this.customerEdit?this.customerEdit['customer'].id:0;
  constructor(
    private router:Router,
    private customerService:CustomerService
  ){}
        salutation=new FormControl(this.customerEdit?this.customerEdit['customer'].salutation:'', Validators.required);
        firstName= new FormControl(this.customerEdit?this.customerEdit['customer'].firstname:'', Validators.required);
        lastName= new FormControl(this.customerEdit?this.customerEdit['customer'].lastname:'', Validators.required);
        phoneNumber= new FormControl(this.customerEdit?this.customerEdit['customer'].phone_Number:'', Validators.required);
        gender= new FormControl(this.customerEdit?this.customerEdit['customer'].gender:'', Validators.required);
        countryCode= new FormControl(this.customerEdit?this.customerEdit['customer'].country_code:'', Validators.required);
        email= new FormControl(this.customerEdit?this.customerEdit['customer'].email:'', [Validators.required, Validators.email]);
        balance= new FormControl(this.customerEdit?this.customerEdit['customer'].balance:'', Validators.required);

      getsalutaionErrorMessage() {
          if (this.salutation.hasError('required')) {
            return 'You must enter first name.';
          }
          else
          {
            return '';
          }
        }

  getfirstNameErrorMessage() {
    if (this.firstName.hasError('required')) {
      return 'You must enter first name.';
    }
    else
    {
      return '';
    }
  }

  getLastNameErrorMessage() {
    if (this.lastName.hasError('required')) {
      return 'You must enter last name.';
    }
    else
    {
      return '';
    }
  }

  getGenderErrorMessage() {
    if (this.gender.hasError('required')) {
      return 'You must enter gender.';
    }
    else
    {
      return '';
    }
  }

  getCountryCodeErrorMessage() {
    if (this.gender.hasError('required')) {
      return 'You must enter country code.';
    }
    else
    {
      return '';
    }
  }

  getPhoneNumberErrorMessage() {
    if (this.phoneNumber.hasError('required')) {
      return 'You must enter phone number.';
    }
    else
    {
      return '';
    }
  }

  getBalanceErrorMessage() {
    if (this.balance.hasError('required')) {
      return 'You must enter balance.';
    }
    else
    {
      return '';
    }
  }

  getEmailErrorMessage() {


    if (this.email.hasError('required')) {
      return 'You must enter an email.';
    }

    return this.email.hasError('email') ? 'Not a valid email' : '';
  }

  addUpdateCustomer()
  {
    this.customerRequest.salutation=this.salutation.value?this.salutation.value.toString():'';
    this.customerRequest.firstname=this.firstName.value?this.firstName.value.toString():'';
    this.customerRequest.lastname=this.lastName.value?this.lastName.value.toString():'';
    this.customerRequest.email=this.email.value?this.email.value.toString():'';
    this.customerRequest.gender=this.gender.value?this.gender.value.toString():'';
    this.customerRequest.phone_Number=this.phoneNumber.value?this.phoneNumber.value.toString():'';
    this.customerRequest.country_code=this.countryCode.value?this.countryCode.value.toString():'';
    this.customerRequest.balance=this.balance.value? parseFloat( this.balance.value):0;
    this.customerRequest.country_code_alpha='US';
    this.customerRequest.country_name='United State';
    this.customerRequest.firstname_country_frequency=(Math.floor(Math.random() * 1000) + 1).toString();
    this.customerRequest.lastname_country_frequency=(Math.floor(Math.random() * 1000) -1 ).toString();
    this.customerRequest.currency='USD';
    this.customerRequest.firstname_country_rank=(Math.floor(Math.random() * 100) + 1).toString();
    this.customerRequest.lastname_country_rank=(Math.floor(Math.random() * 100) - 1).toString();
    this.customerRequest.firstname_ascii=this.firstName.value?(this.firstName.value.toString().toLowerCase()):'';
    this.customerRequest.lastname_ascii=this.lastName.value?(this.lastName.value.toString().toLowerCase()):'';
    this.customerRequest.primary_language='English';
    this.customerRequest.primary_language_code='en';
    this.customerRequest.initials=this.firstName.value?(this.firstName.value[0].toString().toUpperCase()):'';
    if(this.email.valid)
    {
      if(this.customerId && this.customerId>0)
      {
        this.customerService.updateCustomer(this.customerId,this.customerRequest).subscribe(res=>{
          if(res?.id)
           this.router.navigate(["/customers"]);
        },error => console.error(error))
      }
      else
      {
      this.customerService.addCustomer(this.customerRequest).subscribe(res=>{
        if(res?.id)
         this.router.navigate(["/customers"]);
      },error => console.error(error))
    }
  }
  }

  cancel(){
   this.router.navigate(["/customers"]);
  }
}
