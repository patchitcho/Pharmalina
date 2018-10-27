import {Lot} from "./lot.model";

export class Produit {
        constructor(
            Cleproduit: number,
            Code: string,
            Reference: string,
            Designation: string,
            Remarque: string,
            Fulldesignation: string,
            Quantitealerte: number,
            Quantitemax: number,
            Unite: string,
            Pmp: number,
            Dernierprixdachat: number,
            Prixdachatmin: number,
            Prixdachatmax: number,
            Prixdevente: number,
            Prixdeventemin: number,
            Prixdeventemax: number,

            Lot: Lot[],
        ) {}
        
    }