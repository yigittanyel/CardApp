import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './comps/home/home.component';

const routes: Routes = [
  {
    path:'',
    component:HomeComponent
  },
  { path: 'cards', loadChildren: () => import('./cards/cards.module').then(m => m.CardsModule) }

];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
