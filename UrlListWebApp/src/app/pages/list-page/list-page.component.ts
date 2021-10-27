import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UrlListService } from 'src/app/services/urlList.service';
import { faBackward } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-list-page',
  templateUrl: './list-page.component.html',
  styleUrls: ['./list-page.component.css']
})
export class ListPageComponent implements OnInit {
  faBackward = faBackward;

  constructor(private router: Router, public urlListService: UrlListService) { }

  ngOnInit(): void {
  }
  
  hasRoute(route: string) {
    return this.router.url === route;
  }
}
