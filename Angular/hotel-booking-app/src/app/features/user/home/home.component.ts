import { Component } from '@angular/core';
import {
  FormControl,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { Router } from '@angular/router';
import { dateCannotBeBeforeTodayValidator } from '../shared/validator/dateCannotBeBeforeTodayValidator';

@Component({
  selector: 'app-home',
  imports: [FormsModule, ReactiveFormsModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss',
})
export class HomeComponent {
  constructor(private router: Router) {}
  searchForm: FormGroup = new FormGroup({
    searchTerm: new FormControl(''),
    checkInDate: new FormControl('',[dateCannotBeBeforeTodayValidator()]),
    checkOutDate: new FormControl('',[dateCannotBeBeforeTodayValidator()]),
  });

  searchHotel() {

    if (this.searchForm.invalid) return;

    const searchTerm = this.searchForm.get('searchTerm')?.value;
    const checkInDate = this.searchForm.get('checkInDate')?.value;
    const checkOutDate = this.searchForm.get('checkOutDate')?.value;
    this.router.navigate(['/hotels'],{
      queryParams: {
        searchTerm: searchTerm,
        checkIn: checkInDate,
        checkOut: checkOutDate
      }
    })
  }
}
