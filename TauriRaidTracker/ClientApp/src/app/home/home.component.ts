import { Component, OnInit } from '@angular/core';
import { CharacterService } from '../core/services/character.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit{
  constructor(characterService: CharacterService) { 
    this.characterService = characterService;
  }

  characters$: Observable<any>;
  characterService: CharacterService;

  ngOnInit(): void {
    this.characters$ = this.characterService.getCharacters();
  }
}
