import { Component, Input, OnInit } from '@angular/core';
import {IButton} from '../../models/ibutton';

@Component({
  selector: 'app-big-button',
  templateUrl: './big-button.component.html',
  styleUrls: ['./big-button.component.scss']
})
export class BigButtonComponent implements OnInit {

  @Input() button: IButton;

  constructor() { }

  ngOnInit(): void {
  }

}
