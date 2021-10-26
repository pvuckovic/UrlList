import { Component, OnInit, Input, Output, EventEmitter, Inject } from '@angular/core';
import { Item } from 'src/app/models/Item';
import { faTimes } from '@fortawesome/free-solid-svg-icons';
import { DOCUMENT } from '@angular/common';

@Component({
  selector: 'app-urlitem-item',
  templateUrl: './urlitem-item.component.html',
  styleUrls: ['./urlitem-item.component.css']
})
export class UrlitemItemComponent implements OnInit {
  @Input() item!: Item;
  @Output() onDeleteItem: EventEmitter<Item> = new EventEmitter;
  faTimes = faTimes;

  constructor(@Inject(DOCUMENT) private document: Document) { }

  ngOnInit(): void {  }

    goToUrl(): void {
      this.document.location.href = this.item.url;
    }

    onDelete(item: any) {
      this.onDeleteItem.emit(item);
  }
}
