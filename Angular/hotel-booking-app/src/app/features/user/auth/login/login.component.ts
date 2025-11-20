import { Component } from '@angular/core';
import {
  FormGroup,
  FormControl,
  Validators,
  FormsModule,
  ReactiveFormsModule,
} from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from '../../../../shared/services/auth.service';
import { Location } from '@angular/common';

@Component({
  selector: 'app-login',
  imports: [FormsModule, ReactiveFormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss',
})
export class LoginComponent {
  loginForm: FormGroup = new FormGroup({
    email: new FormControl('', [Validators.required, Validators.email]),
    password: new FormControl('', [Validators.required]),
  });
  returnUrl: string = '/hotels';
  constructor(
    private authService: AuthService,
    private router: Router,
    private location: Location,
    private route: ActivatedRoute
  ) {}

  ngOnInit() {
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/hotels';
  }

  onSubmit() {
    if (this.loginForm.invalid) return;
    this.authService.userLogin(this.loginForm.value).subscribe({
      next: (res) => {
        alert('Login successfully');
        this.router.navigateByUrl(this.returnUrl);
      },
      error: (err) => {
        console.error('Login failed:', err);
        alert('Invalid email or password.');
      },
    });
  }
  clickedRedirect() {
    this.router.navigate(['/register'], {
      queryParams: { returnUrl: this.returnUrl },
    });
  }
  home(){
    this.router.navigate(["/home"])
  }
}
