import { TestBed } from '@angular/core/testing';
import { UrlListService } from './urlList.service';

describe('ItemService', () => {
  let service: UrlListService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(UrlListService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
