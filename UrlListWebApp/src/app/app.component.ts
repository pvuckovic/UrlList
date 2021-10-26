import { Component } from '@angular/core';
import { Item } from './models/Item';
import { UrlListService } from './services/urlList.service';
import { PostUrlListRequest } from './models/PostUrlListRequest';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent {
  public items: Item[] = [];
  postUrlListRequest: PostUrlListRequest = {Title: '',Description: '', UrlItems:[]};  
  Title: string = '';
  Description: string = '';
  currentTitle: string = '';  

  constructor(private urlListService: UrlListService, private router: Router) {
  }
 
  deleteItem(item: Item){
    this.items.push(item);
  }
  
  addItem(item: Item){
    this.items.push(item);
  }

  publishList(value: PostUrlListRequest) {
    value.UrlItems = this.items.map(item => (
      {
        Url : item.url, 
        UrlDescription : item.description, 
        UrlTitle : item.title
      }
    ));
    this.urlListService.publishList(value).subscribe((response) => {
      this.items = [];
      console.log(response);
      this.router.navigate([`list-page/${response.title}`]);
    });
    //console.log("PV_debug",value); 
  }

  hasRoute(route: string) {
    return this.router.url.includes(route);
  }
}
