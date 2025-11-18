import { Component } from '@angular/core';
import {
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { EmployeeService } from '../../../../../shared/services/employee.service';

@Component({
  selector: 'app-edit-employee',
  imports: [ReactiveFormsModule],
  templateUrl: './edit-employee.component.html',
  styleUrl: './edit-employee.component.scss',
})
export class EditEmployeeComponent {
  constructor(
    private employeeService: EmployeeService,
    private router: Router,
    private route: ActivatedRoute
  ) {}

  updateEmployeeForm: FormGroup = new FormGroup({
    hotelId: new FormControl(),
    fullName: new FormControl('', [Validators.required]),
    role: new FormControl(''),
    email: new FormControl(''),
  });

  hotelId!: number;
  employeeId!: number;
  employeeDetails: any;

  ngOnInit() {
    this.route.parent?.parent?.paramMap.subscribe((params) => {
      this.updateEmployeeForm.patchValue({
        hotelId: Number(params.get('id')),
      });
      this.hotelId = Number(params.get('id'));
    });
    this.route.params.subscribe((params) => {
      this.employeeId = params['id'];
      if (this.employeeId) {
        this.loadEmployeeDetail();
      }
    });
  }
  loadEmployeeDetail() {
    this.employeeService.getEmployeeDetails(this.employeeId).subscribe({
      next: (data) => {
        this.employeeDetails = data as any;
        console.log(this.employeeDetails);
        this.updateEmployeeForm.patchValue({
          fullName: this.employeeDetails.fullName,
          role: this.employeeDetails.role,
          email: this.employeeDetails.email,
        });
      },
      error: (err) => {
        console.log('Error', err);
      },
    });
  }
  updateEmployee() {
    if (this.updateEmployeeForm.invalid) return;
    console.log(this.updateEmployeeForm.value);
    this.employeeService
      .updateEmployee(this.employeeId, this.updateEmployeeForm.value)
      .subscribe({
        next: (response) => {
          if (Number(response) > 0) {
            console.log('Room updated Succesfully');
            console.log(this.hotelId);
            this.router.navigate(['/admin/hotels/', this.hotelId, 'employees']);
          }
        },
        error: (err) => {
          console.log('Error', err);
        },
      });
  }
  goBack() {
    this.router.navigate(['/admin/hotels/', this.hotelId, 'employees']);
  }
}
