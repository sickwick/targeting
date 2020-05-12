import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductCardComponent } from './components/product-card/product-card.component';
import { BoardGridComponent } from './components/board-grid/board-grid.component';
import {RouterModule} from '@angular/router';



@NgModule({
  declarations: [ProductCardComponent, BoardGridComponent],
    imports: [
        CommonModule,
        RouterModule
    ],
  exports: [BoardGridComponent]
})
export class BoardModule { }
