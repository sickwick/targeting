import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductComponent } from './components/product/product.component';
import { ItemBoardComponent } from './components/item-board/item-board.component';



@NgModule({
  declarations: [ProductComponent, ItemBoardComponent],
  imports: [
    CommonModule
  ],
  exports: [
    ItemBoardComponent
  ]
})
export class BoardModule { }
