import { Lesson } from "../lesson/Lesson";

export interface Course {
    id: number;
    name: string;
    language: string;
    lessons: Lesson[];
}