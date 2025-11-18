import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class EmployeeService {
  constructor(private http: HttpClient) {}

  private baseUrl = `${environment.apiBaseUrl}/api/employee`;

  addEmployee(employee: any) {
    return this.http.post(`${this.baseUrl}`, employee);
  }
  getEmployeeDetails(employeeId: number) {
    return this.http.get(`${this.baseUrl}/${employeeId}`);
  }
  updateEmployee(employeeId: number, employee: any) {
    return this.http.patch(`${this.baseUrl}/${employeeId}`, employee);
  }
  deleteHotel(employeeId: number) {
    return this.http.delete(`${this.baseUrl}/${employeeId}`);
  }
}
