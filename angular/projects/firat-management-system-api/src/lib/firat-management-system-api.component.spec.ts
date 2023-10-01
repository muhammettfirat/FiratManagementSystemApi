import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';
import { FiratManagementSystemApiComponent } from './components/firat-management-system-api.component';
import { FiratManagementSystemApiService } from '@firat-management-system-api';
import { of } from 'rxjs';

describe('FiratManagementSystemApiComponent', () => {
  let component: FiratManagementSystemApiComponent;
  let fixture: ComponentFixture<FiratManagementSystemApiComponent>;
  const mockFiratManagementSystemApiService = jasmine.createSpyObj('FiratManagementSystemApiService', {
    sample: of([]),
  });
  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [FiratManagementSystemApiComponent],
      providers: [
        {
          provide: FiratManagementSystemApiService,
          useValue: mockFiratManagementSystemApiService,
        },
      ],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FiratManagementSystemApiComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
