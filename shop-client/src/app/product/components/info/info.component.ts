import {Component, Input, OnInit} from '@angular/core';
import {IProduct} from '../../../models/iproduct';

@Component({
  selector: 'app-info',
  templateUrl: './info.component.html',
  styleUrls: ['./info.component.scss']
})
export class InfoComponent implements OnInit {

  @Input() product: IProduct;

  constructor() { }

  ngOnInit(): void {
  }

}
