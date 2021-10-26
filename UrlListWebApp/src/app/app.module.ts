import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http'

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './components/header/header.component';
import { FormUrllistComponent } from './components/form-urllist/form-urllist.component';
import { FormUrlitemComponent } from './components/form-urlitem/form-urlitem.component';
import { ItemsComponent } from './components/items/items.component';
import { UrlitemItemComponent } from './components/urlitem-item/urlitem-item.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { UrlListService } from './services/urlList.service';
import { ListPageComponent } from './pages/list-page/list-page.component';
import { ListContentComponent } from './components/list-content/list-content.component';
import { ListPageResolver } from './resolvers/list-page.resolver';
@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FormUrllistComponent,
    FormUrlitemComponent,
    ItemsComponent,
    UrlitemItemComponent,
    ListPageComponent,
    ListContentComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FontAwesomeModule, 
    FormsModule, 
    HttpClientModule,
    
  ],
  providers: [UrlListService],
  bootstrap: [AppComponent]
})
export class AppModule { }
