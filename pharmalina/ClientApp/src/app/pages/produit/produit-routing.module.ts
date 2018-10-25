import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ProduitComponent } from './produit.component';
import { ListprodComponent } from './Listproduit/listprod.component';
import { NewprodComponent } from './Newproduit/newprod.component';
import { from } from 'rxjs';

const routes: Routes = [{
  path: '',
  component: ProduitComponent,
  children: [
    {
      path: 'Listproduit',
      component: ListprodComponent,
    },{
      path: 'Newproduit',
      component: NewprodComponent,
    }
  ],
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ProduitRoutingModule { }

export const routedComponents = [
  ListprodComponent, ProduitComponent, NewprodComponent,
];
