import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListContentComponent } from './components/list-content/list-content.component';
import { ListPageComponent } from './pages/list-page/list-page.component';
import { ListPageResolver } from './resolvers/list-page.resolver';

const routes: Routes = [
  {
    path: '',
    children: [
      {path: 'list-page/:title', component: ListPageComponent, resolve: {
        title: ListPageResolver
      }},  
      {path: 'list-content', component: ListContentComponent}
    ]
  }
  
]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
  providers: [ListPageResolver]
})
export class AppRoutingModule { }
