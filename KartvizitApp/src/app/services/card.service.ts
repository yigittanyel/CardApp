import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Card } from '../models/card';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CardService {

  constructor(
    @Inject('apiUrl') private apiUrl: string,
    private http:HttpClient) { }

cards:Card[];

  getCards():void{
     this.http.get<Card[]>(this.apiUrl + 'GetCards')
      .subscribe((res:Card[])=>{
        this.cards= res;
      }
    )};


  deleteCard(id:number):Observable<Card>{
    return this.http.delete<Card>(this.apiUrl + 'DeleteCard/' + id);
  }

  addCard(card:Card):Observable<Card>{
    return this.http.post<Card>(this.apiUrl + 'AddCard',card);
  }

  updateCard(card: Card,id: number, ): Observable<Card> {
    return this.http.put<Card>(this.apiUrl + 'UpdateCard/' + id, card);
  }
  

}
