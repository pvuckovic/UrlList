import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot } from '@angular/router';
import { UrlListService } from '../services/urlList.service';
import { tap } from 'rxjs/operators';

@Injectable()
export class ListPageResolver {
  constructor(private urlListService: UrlListService) {}

  resolve(route: ActivatedRouteSnapshot) {
    const title = route.paramMap.get('title');
    return this.urlListService.getList(title!).pipe(
      tap((response) => {
        this.urlListService.selectedUrlList = response;
      })
    )
  }
}
