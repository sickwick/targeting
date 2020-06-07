import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductContentComponent } from './components/product-content/product-content.component';
import {SharedModule} from '../shared/shared.module';
import {MatCardModule} from '@angular/material/card';
import {MatButtonModule} from '@angular/material/button';
import {MatIconModule} from '@angular/material/icon';
import { ProductInfoComponent } from './components/product-info/product-info.component';




@NgModule({
  declarations: [ProductContentComponent, ProductInfoComponent],
  imports: [
    CommonModule,
    SharedModule,
    MatCardModule,
    MatButtonModule,
    MatIconModule,
  ],
  exports: [ProductContentComponent]
})
export class ProductModule { }
