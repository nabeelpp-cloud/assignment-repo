import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'daysAgo'
})
export class DaysAgoPipe implements PipeTransform {

  transform(value: string): number {
    if (!value) return 0;
  
    const today = new Date().getTime();
    const inputDate = new Date(value).getTime();
  
    const diff = today - inputDate;
    const numberOfDaysAgo = Math.floor(diff / (1000 * 60 * 60 * 24));
    
    return numberOfDaysAgo;
  }
  

}
