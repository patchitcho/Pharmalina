import { RouterModule, Routes } from '@angular/router';
import { NgModule } from '@angular/core';
import { NbCardModule, NbThemeModule, NbSidebarService } from '@nebular/theme';

import { PagesComponent } from './pages.component';
import { AboutComponent } from './about/about.component';


const routes: Routes = [{
  path: '',
  component: PagesComponent,
  children: [
    {
      path: 'produit',
      loadChildren: './produit/produit.module#ProduitModule',
    }
  ],
}];

@NgModule({
  imports: [
    RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class PagesRoutingModule {
}
