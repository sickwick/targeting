import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SizeBlockComponent } from './size-block/size-block.component';
import { BigButtonComponent } from './big-button/big-button.component';
import {MatButtonModule} from '@angular/material/button';
import {MatIconModule} from '@angular/material/icon';


@NgModule({
  declarations: [SizeBlockComponent, BigButtonComponent],
  imports: [
    CommonModule,
    MatButtonModule,
    MatIconModule
  ],
  exports: [SizeBlockComponent, BigButtonComponent]
})
export class SharedModule { }
