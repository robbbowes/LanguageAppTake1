import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { NgxTextDiffModule } from 'ngx-text-diff';


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { CourseListComponent } from './my-courses/course-list/course-list.component';
import { HomeComponent } from './home/home.component';
import { CourseTileComponent } from './my-courses/course-tile/course-tile.component';
import { CourseRoomComponent } from './my-courses/course-room/course-room.component';
import { LessonTileComponent } from './my-courses/course-room/lesson-tile/lesson-tile.component';
import { LessonDetailComponent } from './my-courses/lessons/lesson-detail/lesson-detail.component';
import { ReadLessonComponent } from './my-courses/lessons/lesson-detail/read-lesson/read-lesson.component';
import { TranslateLessonComponent } from './my-courses/lessons/lesson-detail/translate-lesson/translate-lesson.component';
import { LessonTypeTileComponent } from './my-courses/course-room/lesson-type-tile/lesson-type-tile.component';
import { LessonTypePipe } from './_pipes/lesson-type.pipe';
import { AuthComponent } from './auth/auth.component';
import { MaterialModule } from './_modules/material.module';
import { AddSentenceComponent } from './upload/add-sentence/add-sentence.component';

@NgModule({
  declarations: [
    AppComponent,
    NavBarComponent,
    CourseListComponent,
    HomeComponent,
    CourseTileComponent,
    CourseRoomComponent,
    LessonTileComponent,
    LessonDetailComponent,
    ReadLessonComponent,
    TranslateLessonComponent,
    LessonTypeTileComponent,
    LessonTypePipe,
    AuthComponent,
    AddSentenceComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    MaterialModule,
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule,
    NgxTextDiffModule,
    BsDropdownModule.forRoot()
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
