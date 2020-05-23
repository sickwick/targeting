import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SizeBlockComponent } from './size-block/size-block.component';



@NgModule({
  declarations: [SizeBlockComponent],
  imports: [
    CommonModule
  ],
  exports: [SizeBlockComponent]
})
export class SharedModule { }
