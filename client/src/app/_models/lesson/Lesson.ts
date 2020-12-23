import { Sentence } from "../sentence/Sentence";

export interface Lesson {
    id: number;
    name: string;
    number: number;
    lessonAudio: string;
    sentences: Sentence[];
}