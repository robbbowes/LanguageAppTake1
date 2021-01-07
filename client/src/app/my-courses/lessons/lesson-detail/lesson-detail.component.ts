import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Lesson } from 'src/app/_models/lesson/Lesson';
import { LessonService } from 'src/app/_services/lesson.service';
import { LessonType } from './lesson-type';

@Component({
  selector: 'app-lesson-detail',
  templateUrl: './lesson-detail.component.html',
  styleUrls: ['./lesson-detail.component.css']
})
export class LessonDetailComponent implements OnInit {
  lesson: Lesson;
  lessonId: number;
  hideLessons: boolean;
  lessonTypes: LessonType[] = [
    { number: 1, lessonType: 'read', translation: false },
    { number: 2, lessonType: 'analysis', translation: false },
    { number: 3, lessonType: 'shadow', translation: false },
    { number: 4, lessonType: 'translate', translation: true, writtenTranslation: true, translateIntoL1: true },
    { number: 5, lessonType: 'translate', translation: true, writtenTranslation: false, translateIntoL1: false },
    { number: 6, lessonType: 'translate', translation: true, writtenTranslation: true, translateIntoL1: false },
    { number: 7, lessonType: 'translate', translation: true, writtenTranslation: true, translateIntoL1: true },
    { number: 8, lessonType: 'translate', translation: true, writtenTranslation: true, translateIntoL1: false }
  ]

  constructor(private route: ActivatedRoute, private router: Router, private lessonService: LessonService) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.lessonId = params.lessonId
    });
    this.getLesson(this.lessonId);
  }

  getLesson(lessonId: number) {
    this.lessonService.getLesson(lessonId).subscribe(response => {
      this.lesson = response.data
    });
  }

  onLessonsHidden() {
    this.hideLessons = true;
  }

}
