import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {BoardGridComponent} from './board/components/board-grid/board-grid.component';
import {InfoComponent} from './product/components/info/info.component';


const routes: Routes = [
  { path: '', component: BoardGridComponent },
  { path: 'product/:id', component: InfoComponent }
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
