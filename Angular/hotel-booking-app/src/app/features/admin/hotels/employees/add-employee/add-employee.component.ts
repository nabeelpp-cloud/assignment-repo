import { Component } from '@angular/core';
import { EmployeeService } from '../../../../../shared/services/employee.service';
import { Router, ActivatedRoute } from '@angular/router';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';

@Component({
  selector: 'app-add-employee',
  imports: [ReactiveFormsModule],
  templateUrl: './add-employee.component.html',
  styleUrl: './add-employee.component.scss',
})
export class AddEmployeeComponent {
  constructor(
    private employeeService: EmployeeService,
    private router: Router,
    private route: ActivatedRoute
  ) {}

  addEmployeeForm : FormGroup = new FormGroup({
    hotelId  : new FormControl(),
    fullName : new FormControl("",[Validators.required]),
    role : new FormControl(""),
    email : new FormControl ("")
  })

  hotelId!:number;

  ngOnInit(){
    this.route.parent?.parent?.paramMap.subscribe((params) => {
      this.addEmployeeForm.patchValue({
        hotelId: Number(params.get('id')),
      });
      this.hotelId=Number(params.get('id'));
    });
  }

  addEmployee(){
    if(this.addEmployeeForm.invalid)return
    console.log(this.addEmployeeForm.value);
    this.employeeService.addEmployee(this.addEmployeeForm.value).subscribe({
      next: (respose) => {
        if (Number(respose) > 0) {
          console.log('Employee added successfully');
          alert('Emploee added successfully');
          console.log(this.hotelId);
          this.router.navigate(['/admin/hotels/',this.hotelId,'employees']);
        }
      },
      error:(err)=>{
        console.log("Error",err);
      }
    })
  }
}
