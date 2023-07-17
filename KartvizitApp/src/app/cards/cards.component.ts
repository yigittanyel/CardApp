import { Component, Inject } from '@angular/core';
import { Card } from '../models/card';
import { CardModalComponent } from './card-modal/card-modal.component';
import { MatDialog } from '@angular/material/dialog';
import { CardService } from '../services/card.service';

@Component({
  selector: 'app-cards',
  templateUrl: './cards.component.html',
  styleUrls: ['./cards.component.scss']})
 
export class CardsComponent {

  cards:Card[];

  constructor(
    public cardService:CardService,
    public dialog: MatDialog) {}
    
ngOnInit(): void {
  this.cardService.getCards();
}

addCard(){
  const dialog=this.dialog.open(CardModalComponent,{
    width: '400px',
    height: '500px'
  });

  dialog.afterClosed().subscribe(res => {
    if(res){
      this.cardService.getCards();
    }
  });
}


updateCard(){
  this.dialog.open(CardModalComponent,{
    width: '400px',
    height: '500px'
  });
  this.cardService.getCards();
}

}