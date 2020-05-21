import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InfoComponent } from './components/info/info.component';
import {SharedModule} from '../shared/shared.module';
import {MatCardModule} from '@angular/material/card';
import {MatChipsModule} from '@angular/material/chips';
import {MatButtonModule} from '@angular/material/button';



@NgModule({
  declarations: [InfoComponent],
  imports: [
    CommonModule,
    SharedModule,
    MatCardModule,
    MatChipsModule,
    MatButtonModule
  ],
  exports: [InfoComponent]
})
export class ProductModule { }
