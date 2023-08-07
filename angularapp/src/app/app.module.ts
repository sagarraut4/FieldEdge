import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatButtonModule } from '@angular/material/button';
import { MatTableModule } from '@angular/material/table';
import { FormsModule } from '@angular/forms';
import { MatPaginatorModule} from '@angular/material/paginator';
import { CustomerService } from '../services/customerservice';
import { AddEditCustomerComponent } from './add-edit-customer/add-edit-customer.component';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { CustomerComponent } from './customer/customer.component';
import {MatSelectModule} from '@angular/material/select';

@NgModule({
  declarations: [
    AppComponent,
    AddEditCustomerComponent,
    CustomerComponent
  ],
  imports: [
    BrowserModule, HttpClientModule,
    FormsModule,
    BrowserAnimationsModule,
    MatTableModule,
    MatButtonModule,
    MatPaginatorModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: 'customers', component: CustomerComponent },
      { path: 'addCustomer', component: AddEditCustomerComponent },
      { path: 'editCustomer', component: AddEditCustomerComponent },
      { path: '', component: CustomerComponent,pathMatch:"full" },
    ])
  ],
  providers: [CustomerService],
  bootstrap: [AppComponent]
})
export class AppModule { }
