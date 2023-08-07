import { Injectable } from '@angular/core';
import { HttpClient, HttpEvent, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Customer, CustomerRequest } from 'src/model/customer';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {
  readonly apiUrl = 'https://localhost:7243/api/';

  constructor(private http: HttpClient) { }
  addCustomer(customer: Customer): Observable<Customer> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.post<Customer>(this.apiUrl + 'customer/AddCustomer', customer, httpOptions);
  }

  updateCustomer(customerId: string,customer: Customer): Observable<Customer> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.put<Customer>(this.apiUrl + 'customer/UpdateCustomer/'+ customerId, customer, httpOptions);
  }

  deleteCustomer(customerId: string): Observable<any> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.delete<any>(this.apiUrl + 'customer/DeleteCustomer/' + customerId, httpOptions);
  }

  getCustomerById(customerId: string): Observable<Customer> {
    return this.http.get<Customer>(this.apiUrl + 'customer/GetCustomerById/' + customerId);
  }

  getAllCustomers(): Observable<Customer[]> {
    return this.http.get<Customer[]>(this.apiUrl + 'customer/getListofCustomer');
  }

}
