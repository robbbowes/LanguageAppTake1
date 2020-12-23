import { Course } from "../course/Course";
import { Sentence } from "../sentence/Sentence";

export interface Language {
    id: number;
    name: string;
    courses: Course[];
    sentences: Sentence[];
}