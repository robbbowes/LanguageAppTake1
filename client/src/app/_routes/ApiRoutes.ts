export const ApiRoutes = {
    //Auth
    REGISTER: 'auth/register',
    LOGIN: 'auth/login',

    //Course
    COURSE: 'course',
    COURSE_ID: 'course/:id',
    COURSE_ID_LESSON: 'course/:id/lesson',

    //Language
    LANGUAGE: 'language',
    LANGUAGE_ID: 'language/:id',
    LANGUAGE_ID_SENTENCE: 'language/:id/sentence',

    //Lesson
    LESSON: 'lesson',
    LESSON_ID: 'lesson/:id',
    LESSON_ID_SENTENCE: 'lesson/:id/sentence',
    LESSON_ID_SENTENCE_ID: 'lesson/:id/sentence/:id'

}