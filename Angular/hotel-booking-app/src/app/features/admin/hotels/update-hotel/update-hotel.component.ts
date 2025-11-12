import { Component } from '@angular/core';
import { HotelService } from '../../../../shared/services/hotel.service';
import { ActivatedRoute, Router } from '@angular/router';
import {
  FormGroup,
  FormControl,
  Validators,
  ReactiveFormsModule,
} from '@angular/forms';

@Component({
  selector: 'app-update-hotel',
  imports: [ReactiveFormsModule],
  templateUrl: './update-hotel.component.html',
  styleUrl: './update-hotel.component.scss',
})
export class UpdateHotelComponent {
  hotel: any;
  hotelId!: number;

  updateHotelForm: FormGroup = new FormGroup({
    id :new FormControl(),
    name: new FormControl('', [Validators.required, Validators.maxLength(25)]),
    address: new FormControl(''),
    city: new FormControl(''),
    country: new FormControl(''),
    phoneNumber: new FormControl(''),
  });

  constructor(
    private hotelService: HotelService,
    private router: Router,
    private route: ActivatedRoute
  ) {}

  ngOnInit() {
    this.route.paramMap.subscribe(params => {
      this.hotelId = Number(params.get('id'));
      if (this.hotelId) {
        this.loadHotelDetail(this.hotelId);
      }
    });
  }
  loadHotelDetail(hotelId: number) {
    this.hotelService.getHotelById(hotelId).subscribe({
      next: (data) => {
        this.hotel = data as any;
        this.updateHotelForm.patchValue(this.hotel);
      },
      error: (erros) => {
        console.log('Err ', erros);
      },
      complete: () => {
        console.log('Api calling completed');
      },
    });
  }

  updateHotel() {
    const formValues = this.updateHotelForm.value;
    console.log(formValues);
    this.hotelService.updateHotel(this.hotelId,formValues).subscribe({
      next : (response) =>{
        if(Number(response) > 0){
          console.log("Hotel Added Succesfully",response);
          alert("Hotel Added Succesfully");
          this.router.navigate(["/hotels"])
          //this.updateHotelForm.id=this.hotelId;
          this.updateHotelForm.reset();
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
