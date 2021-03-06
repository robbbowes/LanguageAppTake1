import { Component, Input, OnInit } from '@angular/core';
import { Lesson } from 'src/app/_models/lesson/Lesson';

@Component({
  selector: 'app-lesson-tile',
  templateUrl: './lesson-tile.component.html',
  styleUrls: ['./lesson-tile.component.css']
})
export class LessonTileComponent implements OnInit {
  @Input() courseId: number;
  @Input() lesson: Lesson;

  constructor() { }

  ngOnInit(): void {
  }

}
