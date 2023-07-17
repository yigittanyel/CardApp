import { Component, Inject } from '@angular/core';
import {MatDialogModule, MatDialogRef,MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatButtonModule } from '@angular/material/button';
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';
import {FormBuilder, FormGroup, ReactiveFormsModule, Validators} from '@angular/forms';
import { CardService } from 'src/app/services/card.service';
import {MatSnackBar, MatSnackBarModule} from '@angular/material/snack-bar';
import { Card } from 'src/app/models/card';

@Component({
  selector: 'app-card-modal',
  templateUrl: './card-modal.component.html',
  styleUrls: ['./card-modal.component.scss'],
  standalone: true,
  imports: [MatDialogModule,MatButtonModule, MatFormFieldModule, MatInputModule,ReactiveFormsModule,MatSnackBarModule],
  providers:[
    {
      provide: 'MAT_DIALOG_DATA',
      useValue: {}
    }
  ]
})
export class CardModalComponent {

  cardForm:FormGroup;
  constructor(
    private _snackBar: MatSnackBar,
    private fb: FormBuilder,
    private dialogRef: MatDialogRef<CardModalComponent>,
    private cardService:CardService,
    @Inject(MAT_DIALOG_DATA) public data: Card
  ) { }

  ngOnInit(): void {
    if (this.data) {
      this.cardForm = this.fb.group({
        name: [this.data.name, Validators.required],
        phone: [this.data.phone],
        address: [this.data.address],
        title: [this.data.title, Validators.required],
      });
    } else {
      this.cardForm = this.fb.group({
        name: ["", Validators.required],
        phone: [""],
        address: [""],
        title: ["", Validators.required],
      });
    }
  }

  addCard():void{ 
    this.cardService.addCard(this.cardForm.value)
    .subscribe((res)=>{
      this._snackBar.open('Kartvizit başarıyla eklendi.','Kapat', {
        duration: 2000,
        panelClass: ['blue-snackbar']
      });
      this.dialogRef.close();
    })}

    
updateCard():void{
  this.cardService.updateCard(this.cardForm.value,this.data.id)
  .subscribe((res)=>{
    this._snackBar.open('Kartvizit başarıyla güncellendi.','Kapat', {
      duration: 2000,
      panelClass: ['blue-snackbar']
    });
    this.dialogRef.close();
  })};

}
