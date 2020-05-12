import {Component, Inject, OnInit} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {IProduct} from '../../../models/iproduct';

@Component({
  selector: 'app-board-grid',
  templateUrl: './board-grid.component.html',
  styleUrls: ['./board-grid.component.scss']
})
export class BoardGridComponent implements OnInit {

  public products: IProduct[];

  constructor(http: HttpClient, @Inject('BASE_API_URL') baseUrl: string) {
    http.get<IProduct[]>(baseUrl + 'products').subscribe(result => {
      this.products = result;
    }, error => console.error(error));
  }

  ngOnInit(): void {
  }

}
