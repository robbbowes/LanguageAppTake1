import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Lesson } from 'src/app/_models/lesson/Lesson';
import { LessonService } from 'src/app/_services/lesson.service';

@Component({
  selector: 'app-lesson-detail',
  templateUrl: './lesson-detail.component.html',
  styleUrls: ['./lesson-detail.component.css']
})
export class LessonDetailComponent implements OnInit {
  lesson: Lesson;
  lessonId: number;

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

  openRead() {
    console.log("Clicked")
    this.router.navigate(['read'], { relativeTo : this.route });
  }

}
