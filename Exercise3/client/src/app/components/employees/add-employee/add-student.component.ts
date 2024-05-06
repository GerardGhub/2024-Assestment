import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Employee} from 'src/app/models/employee';
import { EmployeesService } from 'src/app/services/employees.service';

@Component({
  selector: 'app-add-student',
  templateUrl: './add-student.component.html',
  styleUrls: ['./add-student.component.scss']
})
export class AddEmployeeComponent implements OnInit {

  addRequest: Employee = {
    id: '',
    firstName: '',
    lastName: '',
    dateOfBirth: '' 
  }

constructor (private employeeService: EmployeesService, private router: Router) {

}

ngOnInit(): void {
  
}

addStudent() {
 this.employeeService.addStudent(this.addRequest)
 .subscribe({
  next: (employee) => {
    this.router.navigate(['employees']);
  },
  error: (response) => {
    console.log(response);
  }
  
 });
}

}
