import { NgModule } from '@angular/core';

import { PagesComponent } from './pages.component';
import { PagesRoutingModule } from './pages-routing.module';
import { NbThemeModule, NbMenuModule, NbLayoutModule, NbMenuService } from '@nebular/theme';
import { ThemeModule } from '../@theme/theme.module';
import { AboutComponent } from './about/about.component';

const PAGES_COMPONENTS = [
  PagesComponent,
];

@NgModule({
  imports: [
    PagesRoutingModule,
    NbMenuModule,
    NbThemeModule,
    ThemeModule,
    NbLayoutModule
  ],
  declarations: [
    ...PAGES_COMPONENTS,
  ],
  providers: []
})
export class PagesModule {
}
