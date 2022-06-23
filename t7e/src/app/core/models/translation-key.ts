import { Translation } from "./translation";

export interface TranslationKey {
    id?: string;
    key?: string;
    projectId?: string;
    description?: string;
    translations?: Translation[];
}