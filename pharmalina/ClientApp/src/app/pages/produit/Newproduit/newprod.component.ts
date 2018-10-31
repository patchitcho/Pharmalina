import { ChangeDetectionStrategy, Component } from '@angular/core';
import { Repository } from "../../models/repository";
import { Produit } from "../../models/produit.model";

@Component({
  selector: 'app-newprod',
  templateUrl: './newprod.component.html',
})
export class NewprodComponent {
  constructor(private repo: Repository) { }

    get produit(): Produit {
        return this.repo.produit;
    }

    get products(): Product[] {
      return this.repo.products;
  }
}
