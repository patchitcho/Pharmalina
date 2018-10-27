import { Produit } from "./produit.model";
import { Injectable } from "@angular/core";
import { Http } from "@angular/http";

@Injectable()
export class Repository {
    constructor(private http: Http) {
        this.getProduct(1);
        }
        getProduct(id: number) {
        this.http.get("/api/produits/" + id)
        .subscribe(response => this.produit = response.json());
        }

    produit: Produit;
}

