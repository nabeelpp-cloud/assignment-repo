import { Component } from '@angular/core';
import { CustomerService } from '../../../../shared/services/customer.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-customer-bookings',
  imports: [],
  templateUrl: './customer-bookings.component.html',
  styleUrl: './customer-bookings.component.scss'
})
export class CustomerBookingsComponent {
  customerWithBookings : any ;
  customerID !: number ; 
  constructor(private customerService : CustomerService,private route : ActivatedRoute){}
  
  ngOnInit(){
    this.route.parent?.paramMap.subscribe(params=>{
      const customerID = Number(params.get('id'));
      if(!isNaN(customerID)){
        this.loadCustomerWithBookings(customerID);
      }
    })
  }
  loadCustomerWithBookings(customerID : number){
    this.customerService.getCustomerWithBookings(customerID).subscribe({
      next: (data)=>{
        this.customerWithBookings = data as any ;
        console.log(this.customerWithBookings);
      },
      error : (err)=>{
        console.log("Erro",err);
      },
      complete:()=>{
        console.log("Api call completed");
      }

    })
  }
}
