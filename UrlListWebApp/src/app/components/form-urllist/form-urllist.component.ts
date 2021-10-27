import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { Router } from '@angular/router';
import { PostUrlListRequest } from 'src/app/models/PostUrlListRequest';

@Component({
  selector: 'app-form-urllist',
  templateUrl: './form-urllist.component.html',
  styleUrls: ['./form-urllist.component.css']
})
export class FormUrllistComponent implements OnInit {
  @Output() onPublishList: EventEmitter<PostUrlListRequest> = new EventEmitter();
  Title!: string;
  Description!: string;

  constructor(private router: Router) { }

  ngOnInit(): void {  }

  onSubmit() {
    if(!this.Title) {
      alert('Please add a title!');
      return;
    }
    if(!this.Description) {
      alert('Please add a description!');
      return;
    }
    
    const newList: PostUrlListRequest = {
      Title: this.Title, 
      Description: this.Description, 
      UrlItems: []
    };
    this.onPublishList.emit(newList);

    this.Title = '';
    this.Description = '';
  }
    
  hasRoute(route: string) {
    return this.router.url === route;
  }
}
