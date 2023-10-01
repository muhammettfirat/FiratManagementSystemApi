import { NgModule, NgModuleFactory, ModuleWithProviders } from '@angular/core';
import { CoreModule, LazyModuleFactory } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { FiratManagementSystemApiComponent } from './components/firat-management-system-api.component';
import { FiratManagementSystemApiRoutingModule } from './firat-management-system-api-routing.module';

@NgModule({
  declarations: [FiratManagementSystemApiComponent],
  imports: [CoreModule, ThemeSharedModule, FiratManagementSystemApiRoutingModule],
  exports: [FiratManagementSystemApiComponent],
})
export class FiratManagementSystemApiModule {
  static forChild(): ModuleWithProviders<FiratManagementSystemApiModule> {
    return {
      ngModule: FiratManagementSystemApiModule,
      providers: [],
    };
  }

  static forLazy(): NgModuleFactory<FiratManagementSystemApiModule> {
    return new LazyModuleFactory(FiratManagementSystemApiModule.forChild());
  }
}
