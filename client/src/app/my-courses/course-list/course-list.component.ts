import { Component, OnInit } from '@angular/core';
import { Course } from 'src/app/_models/course/Course';
import { CourseService } from 'src/app/_services/course.service';

@Component({
  selector: 'app-course-list',
  templateUrl: './course-list.component.html',
  styleUrls: ['./course-list.component.css']
})
export class CourseListComponent implements OnInit {
  userCourses: Course[]; 

  constructor(private courseService: CourseService) { }

  ngOnInit(): void {
    this.loadCourses();
  }

  loadCourses() {
    this.courseService.getCourses().subscribe(payload => {
      this.userCourses = payload.data.courses;
    }, error => {
      console.log(error);
    });
  }
}
