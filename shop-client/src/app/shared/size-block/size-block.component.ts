import {Component, Input, OnInit} from '@angular/core';
import {ISizes} from '../../models/isizes';

@Component({
  selector: 'app-size-block',
  templateUrl: './size-block.component.html',
  styleUrls: ['./size-block.component.scss']
})
export class SizeBlockComponent implements OnInit {

  @Input() sizesList: ISizes[];

  constructor() {
  }

  ngOnInit(): void {
  }

}
