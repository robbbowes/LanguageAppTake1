import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Lesson } from 'src/app/_models/lesson/Lesson';
import { LessonType } from '../../lessons/lesson-detail/lesson-type';

@Component({
  selector: 'app-lesson-type-tile',
  templateUrl: './lesson-type-tile.component.html',
  styleUrls: ['./lesson-type-tile.component.css']
})
export class LessonTypeTileComponent implements OnInit {
  @Input() lesson: Lesson;
  @Input() type: LessonType;
  @Output() hideTiles = new EventEmitter<boolean>();

  constructor() { }

  ngOnInit(): void {
  }

  onHideTiles() {
    console.log("clicked")
    this.hideTiles.emit(true);
  }

}
