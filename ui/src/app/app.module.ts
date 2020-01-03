import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule, Routes } from '@angular/router';

import { AppComponent } from './app.component';
import { DataService } from './data/data.service';
import { MemesComponent } from './memes/memes.component';
import { UsersComponent } from './users/users.component';
import { AddEditUserComponent } from './users/add-edit-user/add-edit-user.component';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { User } from './types/user';
import { HomeComponent } from './home/home.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'memes', component: MemesComponent },
  { path: 'users', component: UsersComponent },
  { path: 'users/new', component: AddEditUserComponent },
  { path: 'users/edit/:id', component: AddEditUserComponent }
];

@NgModule({
  declarations: [
    AppComponent,
    MemesComponent,
    UsersComponent,
    AddEditUserComponent,
    HomeComponent
  ],
  imports: [
    RouterModule.forRoot(routes),
    BrowserModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule
  ],
  providers: [
    DataService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
