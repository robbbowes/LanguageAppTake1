import { Pipe, PipeTransform } from '@angular/core';
import { LessonType } from '../my-courses/lessons/lesson-detail/lesson-type';

@Pipe({
  name: 'lessonType'
})
export class LessonTypePipe implements PipeTransform {

  transform(value: LessonType): string {
    switch (value.number) {
      case 1:
        return "Listen & read the lesson text"
        break;
      case 2:
        return "Phonetic analysis of the lesson"
        break;
      case 3:
        return "Review & shadow the lesson"
        break;
      case 4:
        return "Translate the lesson text into your native language"
        break;
      case 5:
        return "Translate the lesson text into the target language orally"
        break;
      case 6:
        return "Translate the lesson text into the target language"
        break;
      case 7:
        return "Translate the lesson translations into your native language"
        break;
      case 8:
        return "Translate the lesson translations into the target language"
        break;
      default:
        break;
    }
    return null;
  }

}
