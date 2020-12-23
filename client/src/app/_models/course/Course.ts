import { Lesson } from "../lesson/Lesson";

export interface Course {
    id: number;
    name: string;
    languageId: number;
    lessons: Lesson[];
}