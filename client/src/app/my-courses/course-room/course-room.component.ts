import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Course } from 'src/app/_models/course/Course';
import { CourseService } from 'src/app/_services/course.service';

@Component({
  selector: 'app-course-room',
  templateUrl: './course-room.component.html',
  styleUrls: ['./course-room.component.css']
})
export class CourseRoomComponent implements OnInit {
  course: Course;
  courseId: number;

  constructor(private courseService: CourseService, private route: ActivatedRoute) {
  }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.courseId = params.id
    });
    this.getCourse();
  }

  getCourse() {
    this.courseService.getCourse(this.courseId).subscribe(response => {
      console.log(response)
      this.course = response.data;
      console.log(this.course)
    });
  }

}
