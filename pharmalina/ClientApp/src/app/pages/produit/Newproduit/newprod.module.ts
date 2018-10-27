import { NgModule } from '@angular/core';
import { NewprodComponent } from './newprod.component';
import { NbThemeModule, NbCardModule } from '@nebular/theme';
import { ProduitRoutingModule, routedComponents } from '../produit-routing.module';
import { HttpModule } from '@angular/http';
import { ModelModule } from 'src/app/models/model.module';



@NgModule({
  imports: [
    NbCardModule,
    NbThemeModule,
    ProduitRoutingModule,
    HttpModule, 
    ModelModule,
  ],
  declarations: [
    ...routedComponents,
  ],
  providers: [],
})
export class NewprodModule { }
