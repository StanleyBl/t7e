export interface NavigationItem {
    name: string;
    route?: string;
    action?: Function;
    icon?: string;
}

export interface NavigationBar {
    backAction?: string;
    items?: NavigationItem[];
}