import {Component, Inject, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";

@Component({
  selector: 'app-item-board',
  templateUrl: './item-board.component.html',
  styleUrls: ['./item-board.component.scss']
})
export class ItemBoardComponent implements OnInit {

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<IProduct[]>(baseUrl + 'api/products').subscribe(result => {
      this.products = result;
    }, error => console.error(error));
  }

  private products: IProduct[];

  ngOnInit() {
  }

}
