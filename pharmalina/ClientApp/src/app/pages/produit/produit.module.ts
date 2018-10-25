import { NgModule } from '@angular/core';
import { ProduitComponent } from './produit.component';
import { NbThemeModule, NbCardModule } from '@nebular/theme';
import { ProduitRoutingModule, routedComponents } from './produit-routing.module';



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
export class ProduitModule { }
