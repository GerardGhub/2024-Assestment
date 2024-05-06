import { Component, OnInit } from '@angular/core';
import { Employee } from 'src/app/models/employee';
import { EmployeesService } from 'src/app/services/employees.service';

@Component({
  selector: 'app-employees-list',
  templateUrl: './students-list.component.html',
  styleUrls: ['./students-list.component.scss']
})
export class EmployeesListComponent implements OnInit {

  employees: Employee[] = [];
  constructor(private employeesService: EmployeesService) {

  }

  ngOnInit(): void {

    this.employeesService.getAllStudents()
      .subscribe({
        next: (employees) => {
          this.employees = employees;
        },
        error: (response) => {
          console.log(response);
        }
      })

  }


}
