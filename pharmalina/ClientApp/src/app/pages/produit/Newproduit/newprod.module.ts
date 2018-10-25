import { NgModule } from '@angular/core';
import { NewprodComponent } from './newprod.component';
import { NbThemeModule, NbCardModule } from '@nebular/theme';
import { ProduitRoutingModule, routedComponents } from '../produit-routing.module';



@NgModule({
  imports: [
    NbCardModule,
    NbThemeModule,
    ProduitRoutingModule
  ],
  declarations: [
    ...routedComponents,
  ],
  providers: [],
})
export class NewprodModule { }
