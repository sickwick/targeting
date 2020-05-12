import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InfoComponent } from './components/info/info.component';



@NgModule({
  declarations: [InfoComponent],
  imports: [
    CommonModule
  ],
  exports: [InfoComponent]
})
export class ProductModule { }
