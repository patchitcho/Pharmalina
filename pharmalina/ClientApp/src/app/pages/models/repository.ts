import { Produit } from "./produit.model";
import { Injectable } from "@angular/core";
import { Http, RequestMethod, Request, Response } from "@angular/http";
import { Observable } from "rxjs/Observable";
import "rxjs/add/operator/map";
import { Filter } from "./configClasses.repository";

@Injectable()
export class Repository {
    constructor(private http: Http) {
        this.getProduit(1);
        this.getProduits();
        }
        getProduit(id: number) {
        this.http.get("/api/produits/" + id)
        .subscribe(response => this.Produit = response.json());
        }

        getProduits() {
            let url = ProduitsUrl +  "?related=" + this.filter.related;
    
            if (this.filter.category) {
                url += "&category=" + this.filter.category;
            }
            if (this.filter.search) {
                url += "&search=" + this.filter.search;
            }
    
            this.sendRequest(RequestMethod.Get, url)
                .subscribe(response => this.Produits = response);
        }

        private sendRequest(verb: RequestMethod, url: string, data?: any)
        : Observable<any> {

        return this.http.request(new Request({
            method: verb, url: url, body: data
        })).map(response => response.json());
        }

        Produit: Produit;
        Produits: Produit[];	

        get filter(): Filter {
            return this.filterObject;
        }
}

