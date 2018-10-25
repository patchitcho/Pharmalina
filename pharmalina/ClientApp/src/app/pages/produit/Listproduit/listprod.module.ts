import { NgModule } from '@angular/core';
import { ListprodComponent } from './listprod.component';
import { NbThemeModule, NbCardModule } from '@nebular/theme';
// import { ProduitRoutingModule, routedComponents } from '../produit-routing.module';



@NgModule({
  imports: [
    NbCardModule,
    NbThemeModule,
    // ProduitRoutingModule
  ],
  declarations: [
    ListprodComponent,
  ],
  providers: [],
})
export class ListprodModule { }
