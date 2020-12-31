import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { Lesson } from 'src/app/_models/lesson/Lesson';
import { Sentence } from 'src/app/_models/sentence/Sentence';
import { LessonService } from 'src/app/_services/lesson.service';

@Component({
  selector: 'app-read-lesson',
  templateUrl: './read-lesson.component.html',
  styleUrls: ['./read-lesson.component.css']
})
export class ReadLessonComponent implements OnInit {
  lesson: Lesson;
  lessonId: number;
  sentences: Sentence[];

  constructor(private route: ActivatedRoute, private lessonService: LessonService) { }

  ngOnInit(): void {
    this.route.parent.params.subscribe((params: Params) => {
      this.lessonId = params.lessonId;
    });
    this.getLesson(this.lessonId);
  }

  getLesson(lessonId: number) {
    console.log("In getLesson()", lessonId)
    this.lessonService.getLessonWithSentences(lessonId).subscribe(response => {
      this.lesson = response.data
      this.sentences = response.data.sentences;
    });
  }

  // getTranslation(sentenceId: number) {
  //   this.sentences[sentenceId].translations
  // }

}
