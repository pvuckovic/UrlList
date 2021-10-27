import { Component, Input, OnInit } from '@angular/core';
import { PostUrlListRequest } from 'src/app/models/PostUrlListRequest';
import { UrlListService } from 'src/app/services/urlList.service';

@Component({
  selector: 'app-list-content',
  templateUrl: './list-content.component.html',
  styleUrls: ['./list-content.component.css']
})
export class ListContentComponent implements OnInit {
  @Input() object!: PostUrlListRequest;

  constructor(public urlListService: UrlListService) { }

  ngOnInit(): void {
  }

}
