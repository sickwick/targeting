import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {BoardGridComponent} from './board/components/board-grid/board-grid.component';
import {ProductContentComponent} from './product/components/product-content/product-content.component';


const routes: Routes = [
  { path: '', component: BoardGridComponent },
  { path: 'product/:id', component: ProductContentComponent }
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
