import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InfoComponent } from './components/info/info.component';
import {SharedModule} from '../shared/shared.module';



@NgModule({
  declarations: [InfoComponent],
  imports: [
    CommonModule,
    SharedModule
  ],
  exports: [InfoComponent]
})
export class ProductModule { }
