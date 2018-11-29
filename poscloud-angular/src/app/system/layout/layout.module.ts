import { HeaderLanguageswitch } from './default/header/components/languageswitch.component';
import { NgModule } from '@angular/core';

import { HeaderComponent } from '@app/system/layout/default/header/header.component';
import { SidebarComponent } from '@app/system/layout/default/sidebar/sidebar.component';
import { HeaderSearchComponent } from '@app/system/layout/default/header/components/search.component';
import { HeaderNotifyComponent } from '@app/system/layout/default/header/components/notify.component';
import { HeaderTaskComponent } from '@app/system/layout/default/header/components/task.component';
import { HeaderIconComponent } from '@app/system/layout/default/header/components/icon.component';
import { HeaderFullScreenComponent } from '@app/system/layout/default/header/components/fullscreen.component';
import { HeaderStorageComponent } from '@app/system/layout/default/header/components/storage.component';
import { HeaderUserComponent } from '@app/system/layout/default/header/components/user.component';

const COMPONENTS = [
  HeaderComponent,
  SidebarComponent,
  SideBarLogoComponent,
  SidebarUserComponent,
  ChangePasswordComponent
];

const HEADERCOMPONENTS = [
  HeaderSearchComponent,
  HeaderNotifyComponent,
  HeaderTaskComponent,
  HeaderIconComponent,
  HeaderFullScreenComponent,
  HeaderStorageComponent,
  HeaderUserComponent,
  HeaderLanguageswitch,
];

//
import { SharedModule } from '@shared/shared.module';
import { SideBarLogoComponent } from '@app/system/layout/default/sidebar/components/sidebar-logo.component';
import { SidebarUserComponent } from '@app/system/layout/default/sidebar/components/sidebar-user.component';
import { ChangePasswordComponent } from './default/change-password/change-password.component';

@NgModule({
  imports: [SharedModule],
  providers: [],
  declarations: [...COMPONENTS, ...HEADERCOMPONENTS],
  exports: [...COMPONENTS],
})
export class LayoutModule { }
