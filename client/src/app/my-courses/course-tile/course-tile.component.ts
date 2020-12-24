import { Component, Input, OnInit } from '@angular/core';
import { Course } from 'src/app/_models/course/Course';

@Component({
  selector: 'app-course-tile',
  templateUrl: './course-tile.component.html',
  styleUrls: ['./course-tile.component.css']
})
export class CourseTileComponent implements OnInit {
  @Input() course: Course;

  constructor() { }

  ngOnInit(): void {
  }

}
