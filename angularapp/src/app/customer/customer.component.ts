import { AfterViewInit, Component, ViewChild } from '@angular/core';
import { Customer } from '../../../src/model/customer';
import { MatPaginator } from '@angular/material/paginator';
import {MatTableDataSource} from '@angular/material/table';
import {CustomerService} from '../../services/customerservice';
import { Router } from '@angular/router';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.css']
})
export class CustomerComponent implements AfterViewInit {
  displayedColumns: string[] = ['Firstname', 'Lastname', 'Email', 'Phone_Number','Country_code','Gender','Balance','action'];
  dataSource= new MatTableDataSource<Customer>();
  public customer!: Customer;
  @ViewChild(MatPaginator) paginator: MatPaginator;

  constructor( private customerService:CustomerService,private router:Router) {}

  ngOnInit(): void {
    this.getCustomers();
  }
  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }
  getCustomers(){
    this.customerService.getAllCustomers().subscribe(result=>{
      this.dataSource.data=result;
    }, error => console.error(error))
  }
  onAddbtnClick()
  {
    this.router.navigate(['/addCustomer']);
  }

  deleteCustomer(customer:Customer)
  {
    this.customerService.deleteCustomer(customer.id).subscribe(res=>{},error=>console.error(error))
  }
  EditCustomer(customer:Customer)
  {
    this.router.navigateByUrl('/editCustomer', {
      state: {customer: customer}
  });
  }
}
