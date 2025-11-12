import { AbstractControl, ValidationErrors, ValidatorFn } from '@angular/forms';

export function dateCannotBeBeforeTodayValidator(): ValidatorFn {
  return (control: AbstractControl): ValidationErrors | null => {
    const selectedDate = new Date(control.value);
    const today = new Date();

    today.setHours(0, 0, 0, 0);
    selectedDate.setHours(0, 0, 0, 0);

    if (selectedDate < today) {
      return { dateCannotBeBeforeToday: true };
    }
    return null;
  };
}
