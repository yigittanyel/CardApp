import { Component, Input } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Card } from 'src/app/models/card';
import { CardService } from 'src/app/services/card.service';
import { CardModalComponent } from '../card-modal/card-modal.component';

@Component({
  selector: 'app-card-item',
  templateUrl: './card-item.component.html',
  styleUrls: ['./card-item.component.scss']
})
export class CardItemComponent {
@Input() card: Card;

constructor(
  private cardService:CardService,
  private dialog: MatDialog
  ) { }

  ngOnInit(): void {
    this.cardService.getCards();
  }

  cards:Card[];

  deleteCard(id:number):void{
    this.cardService.deleteCard(id)
    .subscribe((res:Card)=>{
      this.cards = this.cards.filter(x=>x.id != id);
    })};

  openUpdateCardModal(card):void{
    this.dialog.open(CardModalComponent,{
      width: '400px',
      height: '500px',
      data: card
    });

  }
}
