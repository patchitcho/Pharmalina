import {Produit} from "./produit.model";

export class Lot {
        constructor(
            Clelot: number,
            Cleproduit: number,
            Codelot: string,
            Nlot: string,
            Dateexp: Date | string,
            Quantite: number,
            Prixdachat: number,
            Prixvente: number,
            Prixgros: number,
            Ppa: number,
            Shp: number,

            CleproduitNavigation: Produit,
        ){}
    }