import {AbstractControl} from '@angular/forms'

export class CustomValidators {

  static MatchPassword(firstControlName, secondControlName) {
    return (AC: AbstractControl) => {
      let firstControlValue = AC.get(firstControlName).value; // to get value in input tag
      let secondControlValue = AC.get(secondControlName).value; // to get value in input tag
      if (firstControlValue != secondControlValue) {
        AC.get(secondControlName).setErrors({MatchFields: true});
        console.log(false);
      } else {
        console.log(true);
        return null
      }
    };
  }
}
