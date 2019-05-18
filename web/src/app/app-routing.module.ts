import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';


import { ContentLayoutComponent } from './layouts/content-layout/content-layout.component';
import { CONTENT_ROUTES } from './shared';

const routes: Routes = [
    {
      path: '',
      component: ContentLayoutComponent,
      children: CONTENT_ROUTES
    },
   { path: '**', redirectTo: '', pathMatch: 'full' }
  ];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
