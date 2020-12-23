import { Course } from "../course/Course";

export interface User {
    id: number;
    userName: string;
    courses: Course[];
}