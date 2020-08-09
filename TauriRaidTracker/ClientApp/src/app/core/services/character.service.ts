import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { HttpClient } from "@angular/common/http";

@Injectable({
    providedIn: 'root'
})
export class CharacterService {
    private _baseUrl: string;
    private http: HttpClient;

    constructor(http: HttpClient) {
        this.http = http;
        this._baseUrl = "https://localhost:44303/api/character/";
    }

    getCharacters(): Observable<any[]> {
        let url = `${this._baseUrl}`

        let characterNames: string[] = [
            "Brasri",
            "Crucia",
            "Dispersed",
            "Eyeconic",
            "Flavortown",
            "Getscared",
            "Haas",
            "Hoodie",
            "Manao",
            "Meme",
            "Mirido",
            "Momentine",
            "Quant",
            "Remic",
            "Sevarax",
            "Sinn",
            "Spitcannon"
        ]

        return this.http.post<any>(url, characterNames);
    }
}