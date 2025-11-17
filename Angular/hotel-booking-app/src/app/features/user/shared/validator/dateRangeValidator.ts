import { AbstractControl, ValidationErrors, ValidatorFn } from '@angular/forms';

export function dateRangeValidator(): ValidatorFn {
  return (control: AbstractControl): ValidationErrors | null => {

    const checkIn = control.get('checkInDate')?.value;
    const checkOut = control.get('checkOutDate')?.value;

    if (!checkIn || !checkOut) return null; 

    const start = new Date(checkIn);
    const end = new Date(checkOut);

    if (isNaN(start.getTime()) || isNaN(end.getTime())) {
      return { invalidDate: true };
    }

    if (start >= end) {
      return { dateRangeInvalid: true };
    }

    return null;
  };
}
