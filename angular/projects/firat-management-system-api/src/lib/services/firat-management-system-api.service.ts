import { Injectable } from '@angular/core';
import { RestService } from '@abp/ng.core';

@Injectable({
  providedIn: 'root',
})
export class FiratManagementSystemApiService {
  apiName = 'FiratManagementSystemApi';

  constructor(private restService: RestService) {}

  sample() {
    return this.restService.request<void, any>(
      { method: 'GET', url: '/api/FiratManagementSystemApi/sample' },
      { apiName: this.apiName }
    );
  }
}
