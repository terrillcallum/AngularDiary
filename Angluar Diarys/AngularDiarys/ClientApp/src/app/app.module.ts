import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { AuthenticationService } from './Authentication/authentication.service';
import { LoginComponent } from './Authentication/login.component';
import { DiaryEntryListComponent } from './app-diary/diary-entry-list.component';
import { DiaryEntryService } from './app-diary/diary-entry.service';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    LoginComponent,
    DiaryEntryListComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: DiaryEntryListComponent, pathMatch: 'full' },
      { path: 'login', component: LoginComponent },
      { path: 'diary', component: DiaryEntryListComponent },
    ])
  ],
  providers: [AuthenticationService, DiaryEntryService],
  bootstrap: [AppComponent]
})
export class AppModule { }
