import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {BoardModule} from './board/board.module';
import {ProductModule} from './product/product.module';
import {HttpClientModule} from '@angular/common/http';
import {environment} from '../environments/environment';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    BoardModule,
    ProductModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [
    {provide: 'BASE_API_URL', useValue: environment.apiUrl}],
  bootstrap: [AppComponent]
})
export class AppModule { }
