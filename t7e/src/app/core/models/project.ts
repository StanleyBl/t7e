import { Language } from "./language";

export interface Project {
    id?: string;
    name?: string;
    description?: string;
    logoUrl?: string;
    availableLanguages?: Language[];
}