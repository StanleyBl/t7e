import { Language } from "./language";

export interface Project {
    id?: string;
    name?: string;
    description?: string;
    logoUrl?: string;
    availableLanguages?: Language[];
}

export interface ProjectInfo {
    name?: string;
    description?: string;
    logoUrl?: string;
    translations?: TranslationInfo[];
    completeCountPercent?: number;
    reviewedCountPercent?: number;
    translationCount?: number;
}

export interface TranslationInfo {
    languageIsoCode: string;
    languageName: string;
    completeCount: number;
    incompleteCount: number;
    reviewedCount: number;
    completeCountPercent?: number;
    reviewedCountPercent?: number;
}