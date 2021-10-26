import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { PostUrlListRequest } from '../models/PostUrlListRequest';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UrlListService {
  private apiUrl = 'http://localhost:26922/api/urllist';
  public selectedUrlList: any;
  constructor(private http: HttpClient) { }

  publishList(postUrlListRequest: PostUrlListRequest): Observable<any> {
    return this.http.post<PostUrlListRequest>(this.apiUrl, postUrlListRequest);
}  

  getList(title: string): Observable<PostUrlListRequest> {
    return this.http.get<PostUrlListRequest>(`http://localhost:26922/api/urllist/${title}`);
  }
}
