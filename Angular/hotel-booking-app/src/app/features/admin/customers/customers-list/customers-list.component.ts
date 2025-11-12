import { Component } from '@angular/core';
import { CustomerService } from '../../../../shared/services/customer.service';
import { RouterLink } from '@angular/router';


@Component({
  selector: 'app-customers-list',
  imports: [RouterLink],
  templateUrl: './customers-list.component.html',
  styleUrl: './customers-list.component.scss'
})
export class CustomersListComponent {
  customers : any[] = [];
  constructor(private customerService  : CustomerService){}
  ngOnInit(){
    this.loadcustomers();
  }
  loadcustomers(){
    this.customerService.getCustomerList().subscribe({
      next : (data)=>{
        this.customers = data as any [];
        console.log(this.customers);
      },
      error:(err)=>{
        console.log("Error ",err);
      },
      complete:()=> {
        console.log("api caling completed");
      },
    })
  }
}
