import { Component, Input, OnInit } from '@angular/core';
import { Item } from 'src/app/models/Item';

@Component({
  selector: 'app-items',
  templateUrl: './items.component.html',
  styleUrls: ['./items.component.css']
})
export class ItemsComponent {
  constructor() { }
  @Input() items = new Array();

  deleteItem(item: Item) {
    this.items.splice(this.items.indexOf(item),1);
  }
}
