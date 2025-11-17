import { Component } from '@angular/core';
import { FormGroup, FormControl, Validators, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../../../../shared/services/auth.service';
import { Location } from '@angular/common';

@Component({
  selector: 'app-login',
  imports: [FormsModule, ReactiveFormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent {
  loginForm: FormGroup = new FormGroup({
    email: new FormControl('', [Validators.required, Validators.email]),
    password: new FormControl('', [Validators.required]),
  });


  constructor(private authService : AuthService,private router : Router,private location : Location){

  }

  onSubmit() {
    if (this.loginForm.invalid) return;
    this.authService.userLogin(this.loginForm.value).subscribe({
      next: (res) => {
        alert('Login successfully')
        console.log(res);
        console.log(this.authService.getRoleSnapshot);
        this.location.back(); 
      },
      error: (err) => {
        console.error('Login failed:', err);
        alert('Invalid email or password.');
      },
    });
  }
}
