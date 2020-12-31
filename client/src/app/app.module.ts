import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { CourseListComponent } from './my-courses/course-list/course-list.component';
import { HomeComponent } from './home/home.component';
import { CourseTileComponent } from './my-courses/course-tile/course-tile.component';
import { CourseRoomComponent } from './my-courses/course-room/course-room.component';
import { LessonTileComponent } from './my-courses/course-room/lesson-tile/lesson-tile.component';
import { AdminNavComponent } from './nav-bar/admin-nav/admin-nav.component';

@NgModule({
  declarations: [
    AppComponent,
    NavBarComponent,
    CourseListComponent,
    HomeComponent,
    CourseTileComponent,
    CourseRoomComponent,
    LessonTileComponent,
    AdminNavComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule,
    BsDropdownModule.forRoot()
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
