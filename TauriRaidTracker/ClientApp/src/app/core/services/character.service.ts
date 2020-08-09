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
        console.log(this._baseUrl);
        let url = `${this._baseUrl}sheets`

        return this.http.get<any>(url);
    }
}