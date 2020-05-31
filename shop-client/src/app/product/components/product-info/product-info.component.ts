import {Component, Input, OnInit} from '@angular/core';
import {IProduct} from '../../../models/iproduct';
import {IButton} from '../../../models/ibutton';

@Component({
  selector: 'app-product-info',
  templateUrl: './product-info.component.html',
  styleUrls: ['./product-info.component.scss']
})
export class ProductInfoComponent implements OnInit {

  @Input() product: IProduct;

  public favorite: IButton = {
    backgroundColor: '#ccc',
    text: 'Избранное',
    icon: 'favorite'
  };

  public addToCard: IButton = {
    backgroundColor: '#111',
    color: '#fff',
    text: 'Добавить в корзину',
  };
  constructor() {}

  ngOnInit(): void {
  }

}
