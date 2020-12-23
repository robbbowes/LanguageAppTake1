import { Translation } from "../translation/Translation";

export interface Sentence {
    id: number;
    number: number;
    text: string;
    translations: Translation[];
    sentenceAudio: string;
    recordedAudio: string;
    lessonId: number;
}