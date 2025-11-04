import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-leap-year-finder',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './leap-year-finder.html',
  styleUrl: './leap-year-finder.scss',
})
export class LeapYearFinder {
  Year: string = '';
  OutPut: string = '';
  findIsLeapYear() {
    if (this.Year.trim() == '') {
      this.OutPut = 'Enter a Year';
    } else if (+this.Year % 400 === 0) {
      this.OutPut = 'This is a leap year';
    } else if (+this.Year % 100 === 0) {
      this.OutPut = 'This is not a leap year';
    } else if (+this.Year % 4 === 0) {
      this.OutPut = 'This is a leap year';
    } else {
      this.OutPut = 'This is not a leap year';
    }
  }
}
