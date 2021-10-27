import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { Item } from 'src/app/models/Item';
import { Router } from '@angular/router';

@Component({
  selector: 'app-form-urlitem',
  templateUrl: './form-urlitem.component.html',
  styleUrls: ['./form-urlitem.component.css']
})
export class FormUrlitemComponent implements OnInit {
  @Output() onAddItem: EventEmitter<Item> = new EventEmitter();
  title!: string;
  description!: string;
  url!: string;

  constructor(private router: Router) { }

  ngOnInit(): void {    }

  onSubmit() {
    if(!this.title) {
      alert('Please add a title!');
      return;
    }
    if(!this.description) {
      alert('Please add a description!');
      return;
    }
    if(!this.url) {
      alert('Please add a link!');
      return;
    }
    const newItem = {
      title: this.title, 
      description: this.description, 
      url: this.url,
    };
    this.onAddItem.emit(newItem);

    this.title = '';
    this.description = '';
    this.url = '';
  }

  hasRoute(route: string) {
    return this.router.url === route;
  }
}
