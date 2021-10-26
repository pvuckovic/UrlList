import { Component, OnInit } from '@angular/core';
import { ActivatedRouteSnapshot, Router } from '@angular/router';
import { UrlListService } from 'src/app/services/urlList.service';

@Component({
  selector: 'app-list-page',
  templateUrl: './list-page.component.html',
  styleUrls: ['./list-page.component.css']
})
export class ListPageComponent implements OnInit {

  constructor(private router: Router, public urlListService: UrlListService) { }

  ngOnInit(): void {
    //console.log(this.urlListService.selectedUrlList)
  }
  
  hasRoute(route: string) {
    return this.router.url === route;
  }
}
