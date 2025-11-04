import { Component } from '@angular/core';

@Component({
  selector: 'app-alert-button-creation',
  imports: [],
  templateUrl: './alert-button-creation.html',
  styleUrl: './alert-button-creation.scss',
})
export class AlertButtonCreation {
  ButtonClicked(){
    alert("Hello World");
  }
}
