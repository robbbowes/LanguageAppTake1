import { Component, Input, OnInit } from '@angular/core';
import { DiffContent, DiffResults } from 'ngx-text-diff/lib/ngx-text-diff.model';



@Component({
  selector: 'app-translate-lesson',
  templateUrl: './translate-lesson.component.html',
  styleUrls: ['./translate-lesson.component.css']
})
export class TranslateLessonComponent implements OnInit {
  left: string = 'Test test 123\nHello 345\n8727874'
  right: string = 'Testy test 123\nHello 345\n91249093'
  showTranslation = false;

  @Input()
  ngClass: string = "bloooopp"

  constructor() { }

  ngOnInit(): void {
    const Diff = require('diff');

    const one = 'beep boop\nhello!\noaisnias';
    const other = 'beep boob blah\nhello!\nabsdfkjbas';

    const diff = Diff.diffLines(one, other);

    let thing = [];
    diff.forEach((part, index) => {
      // green for additions, red for deletions
      // grey for common parts
      const color = part.added ? 'green' : part.removed ? 'red' : 'grey';
      thing.push(part.value + ' ' + color + ' ' + index)
    })
    console.log(thing)
  }

  onCompareResults(diffResults: DiffResults) {
    console.log('diffResults', diffResults);
  }
}
