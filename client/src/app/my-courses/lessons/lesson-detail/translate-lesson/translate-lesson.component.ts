import { Component, Input, OnInit } from '@angular/core';
import { DiffResults } from 'ngx-text-diff/lib/ngx-text-diff.model';
// import { Diff } from 'diff';

@Component({
  selector: 'app-translate-lesson',
  templateUrl: './translate-lesson.component.html',
  styleUrls: ['./translate-lesson.component.css']
})
export class TranslateLessonComponent implements OnInit {
  left: string = 'Test test 123\nHello 345\n8727874'
  right: string = 'Testy test 123\nHello 345\n91249093'
  showTranslation = false;
  things: string[] = [];

  constructor() { }

  ngOnInit(): void {
    
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
