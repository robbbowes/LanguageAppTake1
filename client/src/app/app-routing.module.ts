import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthComponent } from './auth/auth.component';
import { HomeComponent } from './home/home.component';
import { CourseListComponent } from './my-courses/course-list/course-list.component';
import { CourseRoomComponent } from './my-courses/course-room/course-room.component';
import { LessonDetailComponent } from './my-courses/lessons/lesson-detail/lesson-detail.component';
import { ReadLessonComponent } from './my-courses/lessons/lesson-detail/read-lesson/read-lesson.component';
import { TranslateLessonComponent } from './my-courses/lessons/lesson-detail/translate-lesson/translate-lesson.component';
import { AuthGuard } from './_guards/auth.guard';

const routes: Routes = [
  { path: 'auth', component: AuthComponent },
  {
    path: '',
    component: HomeComponent,
    runGuardsAndResolvers: 'always',
    canActivate: [AuthGuard],
    children: [

      { path: 'course-list', component: CourseListComponent },
      { path: 'course/:courseId', component: CourseRoomComponent },
      {
        path: 'course/:courseId/lesson/:lessonId', component: LessonDetailComponent, children: [
          { path: 'read', component: ReadLessonComponent },
          { path: 'translate', component: TranslateLessonComponent }
        ]
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
