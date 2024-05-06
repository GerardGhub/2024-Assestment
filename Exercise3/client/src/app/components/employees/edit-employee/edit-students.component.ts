import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Employee} from 'src/app/models/employee';
import { EmployeesService } from 'src/app/services/employees.service';

@Component({
  selector: 'app-edit-students',
  templateUrl: './edit-students.component.html',
  styleUrls: ['./edit-students.component.scss']
})
export class EditEmployeeComponent implements OnInit {

  EmployeeDetails: Employee = {
    id: '',
    firstName: '',
    lastName: '',
    dateOfBirth: ''
  };

  constructor(private route: ActivatedRoute, 
    private employeeService: EmployeesService,
    private router: Router) {

  }

  ngOnInit(): void {
    this.route.paramMap.subscribe({
      next: (params) => {
        const id = params.get('id');

        if (id) {
          this.employeeService.getStudent(id)
            .subscribe({
              next: (response) => {
                this.EmployeeDetails = response;
              },
              error: (response) => {
                console.log(response);
              }
            });
        }
      }
    })
  }


  updateStudent() {
    this.employeeService.updateStudent(this.EmployeeDetails.id, this.EmployeeDetails).subscribe({
      next: (response) => {
        this.router.navigate(['employees']);
      },
      error: (response) => {
        console.log(response);
      }
    })
  }

  deleteStudent(id: string) {
    this.employeeService.deleteStudent(id)
      .subscribe({
        next: (response) => {
          this.router.navigate(['employees']);
        },
        error: (response) => {
          console.log(response);
        }
      })
  }

}
