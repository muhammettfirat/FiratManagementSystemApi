import { TestBed } from '@angular/core/testing';
import { FiratManagementSystemApiService } from './services/firat-management-system-api.service';
import { RestService } from '@abp/ng.core';

describe('FiratManagementSystemApiService', () => {
  let service: FiratManagementSystemApiService;
  const mockRestService = jasmine.createSpyObj('RestService', ['request']);
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [
        {
          provide: RestService,
          useValue: mockRestService,
        },
      ],
    });
    service = TestBed.inject(FiratManagementSystemApiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
