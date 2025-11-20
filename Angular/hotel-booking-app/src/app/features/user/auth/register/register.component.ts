import { Component } from '@angular/core';
import { FormGroup, FormControl, Validators, FormsModule, ReactiveFormsModule, AbstractControl, ValidationErrors } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from '../../../../shared/services/auth.service';

@Component({
  selector: 'app-register',
  imports: [FormsModule, ReactiveFormsModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.scss'
})
export class RegisterComponent {
  registerForm: FormGroup = new FormGroup({
    fullName: new FormControl('', Validators.required),
    email: new FormControl('', [Validators.required, Validators.email]),
    phoneNumber: new FormControl('', Validators.required),
    idProofNumber: new FormControl('', Validators.required),
    password: new FormControl('', Validators.required),
    confirmPassword: new FormControl('', Validators.required)
  }, { validators: this.passwordMatchValidator });
  returnUrl: string = '/hotels';
  constructor(private authService: AuthService, private router: Router , private route : ActivatedRoute) {}

  passwordMatchValidator(control: AbstractControl): ValidationErrors | null {
    const password = control.get('password')?.value;
    const confirmPassword = control.get('confirmPassword')?.value;
  
    if (password !== confirmPassword) {
      return { passwordMismatch: true };
    }
    return null;
  }
  ngOnInit(){
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/hotels';
  }
  
  onSubmit() {
    if (this.registerForm.invalid) {
      this.registerForm.markAllAsTouched();
      return;
    }

    this.authService.userRegister(this.registerForm.value).subscribe({
      next: () => {
        alert('Registration successful!');
        this.router.navigateByUrl(this.returnUrl);
      },
      error: (err) => {
        console.error('Registration failed:', err);
        alert('Something went wrong');
      },
    });
  }
  clickedRedirect(){
    this.router.navigate(['/login'], {
      queryParams: { returnUrl: this.returnUrl }
    });
  }
  home(){
    this.router.navigate(["/home"])
  }
}
