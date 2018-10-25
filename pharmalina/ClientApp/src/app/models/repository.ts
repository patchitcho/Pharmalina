import { Produit } from "./produit.model";

export class Repository {
    constructor() {
        this.produit = JSON.parse(document.getElementById("data").textContent);
    }

    produit: Produit;
}