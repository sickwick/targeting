import { Injectable } from '@angular/core';
import {IProduct} from '../models/iproduct';
import {HttpClient} from '@angular/common/http';
import {environment} from '../../environments/environment';
import {Observable} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UtilityService {

  constructor(private http: HttpClient) { }


  public getProductByArticle(article): Observable<any> {
    return this.http.get<IProduct>(`${environment.apiUrl}` + 'products/product?article=' + article);
  }
}
