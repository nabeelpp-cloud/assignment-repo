import { Component } from '@angular/core';
import { CustomerService } from '../../../shared/services/customer.service';
import { ActivatedRoute, RouterOutlet, RouterLinkWithHref, RouterLinkActive, RouterLink } from '@angular/router';
import { TitleCasePipe } from '@angular/common';

@Component({
  selector: 'app-customer-detail',
  imports: [TitleCasePipe, RouterOutlet, RouterLink, RouterLinkWithHref, RouterLinkActive],
  templateUrl: './customer-detail.component.html',
  styleUrl: './customer-detail.component.scss'
})
export class CustomerDetailComponent {
    customer : any ;
    customerId !: number;
    constructor(private customerService  :CustomerService ,private route : ActivatedRoute){}
    ngOnInit(){
      this.route.paramMap.subscribe(params=>{
        const customerId = Number(params.get('id'));
        console.log(customerId);
        if(!isNaN(customerId)){
          this.loadCustomerDetails(customerId);
        }
      })
    }
    loadCustomerDetails(customerId : number){
      this.customerService.getCustomerDetails(customerId).subscribe({
        next : (data)=> {
          this.customer = data as any ;
          console.log(this.customer);
        },
        error:(err)=>{
          console.log("Error :",err);
        },
        complete:()=>{
          console.log("Api call completed");
        }
      })
    }
}
