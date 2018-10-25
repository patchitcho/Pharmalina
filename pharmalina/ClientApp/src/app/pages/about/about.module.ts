import { NgModule } from '@angular/core';
import { AboutComponent } from './about.component';
import { NbThemeModule, NbCardModule } from '@nebular/theme';
import { AboutRoutingModule, routedComponents } from './about-routing.module';



@NgModule({
  imports: [
    NbCardModule,
    NbThemeModule,
    AboutRoutingModule
  ],
  declarations: [
    ...routedComponents,
  ],
  providers: [],
})
export class AboutModule { }
