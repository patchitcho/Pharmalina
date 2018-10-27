import { ChangeDetectionStrategy, Component } from '@angular/core';
import { Repository } from "src/app/models/repository";
import { Produit } from "src/app/models/produit.model";

@Component({
  selector: 'app-newprod',
  templateUrl: './newprod.component.html',
})
export class NewprodComponent {
  constructor(private repo: Repository) { }

    get product(): Produit {
        return this.repo.produit;
    }
}
