import { Component } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { EmployeeService } from '../../../../../shared/services/employee.service';

@Component({
  selector: 'app-delete-employee',
  imports: [],
  templateUrl: './delete-employee.component.html',
  styleUrl: './delete-employee.component.scss'
})
export class DeleteEmployeeComponent {
  constructor(
    private employeeService: EmployeeService,
    private router: Router,
    private route: ActivatedRoute
  ) {}
  hotelId!: number;
  employeeId!: number;
  employeeDetails: any;

  ngOnInit() {
    this.route.parent?.parent?.paramMap.subscribe((params) => {
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
      },
      error: (err) => {
        console.log('Error', err);
      },
    });
  }

  confirmDelete() {
    if (confirm('Are you sure you want to delete this room?')) {
      console.log(this.employeeId);
      this.employeeService.deleteHotel(this.employeeId).subscribe({
        next: (response) => {
          console.log(response);
          if(Number(response)>0){
            alert('Employee deleted successfully');
            this.router.navigate(['/admin/hotels/', this.hotelId, 'employees']);
          }
          else{
            alert('Error deleting employee');
          }

        },
        error: (err) => {
          console.log(err);
          alert('Error deleting employee');
        },
      });
    }
  }

  goBack() {
    this.router.navigate(['/admin/hotels/', this.hotelId, 'employees']);
  }
}
