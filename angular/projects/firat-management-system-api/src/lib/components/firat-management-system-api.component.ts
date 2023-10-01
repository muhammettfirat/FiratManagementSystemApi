import { Component, OnInit } from '@angular/core';
import { FiratManagementSystemApiService } from '../services/firat-management-system-api.service';

@Component({
  selector: 'lib-firat-management-system-api',
  template: ` <p>firat-management-system-api works!</p> `,
  styles: [],
})
export class FiratManagementSystemApiComponent implements OnInit {
  constructor(private service: FiratManagementSystemApiService) {}

  ngOnInit(): void {
    this.service.sample().subscribe(console.log);
  }
}
