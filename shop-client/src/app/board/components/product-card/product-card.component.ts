import {Component, Input, OnInit} from '@angular/core';
import {Router} from '@angular/router';
import {IProduct} from '../../../models/iproduct';

@Component({
  selector: 'app-product-card',
  templateUrl: './product-card.component.html',
  styleUrls: ['./product-card.component.scss']
})
export class ProductCardComponent implements OnInit {

  @Input() product: IProduct;

  constructor(private router: Router) { }

  ngOnInit(): void {
  }

}
