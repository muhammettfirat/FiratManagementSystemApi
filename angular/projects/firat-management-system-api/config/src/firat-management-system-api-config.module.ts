import { ModuleWithProviders, NgModule } from '@angular/core';
import { FİRAT_MANAGEMENT_SYSTEM_APİ_ROUTE_PROVIDERS } from './providers/route.provider';

@NgModule()
export class FiratManagementSystemApiConfigModule {
  static forRoot(): ModuleWithProviders<FiratManagementSystemApiConfigModule> {
    return {
      ngModule: FiratManagementSystemApiConfigModule,
      providers: [FİRAT_MANAGEMENT_SYSTEM_APİ_ROUTE_PROVIDERS],
    };
  }
}
