import { Component } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { HotelService } from '../../../../shared/services/hotel.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-hotel',
  imports: [ReactiveFormsModule],
  templateUrl: './add-hotel.component.html',
  styleUrl: './add-hotel.component.scss'
})
export class AddHotelComponent {
  constructor(private hotelservices : HotelService , private router : Router){}
  createHotelForm : FormGroup = new FormGroup({
    name : new FormControl("",[Validators.required,Validators.maxLength(25)]),
    address : new FormControl(""),
    city : new FormControl(""),
    country : new FormControl(""),
    phoneNumber : new FormControl(""),
  }) 


  addHotel() {
    const formValues = this.createHotelForm.value;
    console.log(formValues);
    this.hotelservices.addHotel(formValues).subscribe({
      next : (response) =>{
        if(Number(response) > 0){
          console.log("Hotel Added Succesfully",response);
          alert("Hotel Added Succesfully");
          this.router.navigate(["/admin/hotels"])
          this.createHotelForm.reset();
        }
      },
      error : (err)=>{
        console.log("Error ",err)
      },
      complete : ()=>{
        console.log("Api call completed");
      }
    })
  }
}