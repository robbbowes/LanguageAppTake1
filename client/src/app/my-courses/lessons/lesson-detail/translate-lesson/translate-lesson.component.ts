import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { DiffResults } from 'ngx-text-diff/lib/ngx-text-diff.model';
import { Lesson } from 'src/app/_models/lesson/Lesson';
import { Sentence } from 'src/app/_models/sentence/Sentence';
import { Translation } from 'src/app/_models/translation/Translation';
import { LessonService } from 'src/app/_services/lesson.service';
// import { Diff } from 'diff';

@Component({
  selector: 'app-translate-lesson',
  templateUrl: './translate-lesson.component.html',
  styleUrls: ['./translate-lesson.component.css']
})
export class TranslateLessonComponent implements OnInit {
  // left: string = 'Test test 123\nHello 345\n8727874'
  // right: string = 'Testy test 123\nHello 345\n91249093'
  showTranslation = false;
  things: string[] = [];
  translatations: Translation[];

  constructor(private lessonService: LessonService, private route: ActivatedRoute) { }
  lesson: Lesson;
  lessonId: number;
  sentences: Sentence[];

  ngOnInit(): void {
    this.route.params.subscribe((params: Params) => {
      this.getLesson(params.lessonId);
    });
  }

  getLesson(lessonId: number) {
    this.lessonService.getLessonWithSentences(lessonId).subscribe(response => {
      this.lesson = response.data
      this.sentences = response.data.sentences;
      console.log(this.sentences)
    });
  }

  onCompareResults(diffResults: DiffResults) {
    console.log('diffResults', diffResults);
  }

  onShowDifferences() {
    this.showTranslation = !this.showTranslation;
  }

  // @Input()
  // ngClass: string = "bloooopp"

  // onShowDifferences2() {
  //   const one = 'beep boop\nhello!\noaisnias';
  //   const other = 'beep boob blah\nhello!\nabsdfkjbas';

  //   const Diff = require('diff');
  //   const diff = Diff.diffChars(one, other);

  //   diff.forEach((part, index) => {
  //     const color = part.added ? 'green' : part.removed ? 'red' : 'grey';
  //     this.things.push(part.value + ' ' + color + ' ' + index)
  //   })
  //   console.log(this.things)
  // }

}
