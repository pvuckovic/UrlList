//import { Item } from "./Item";
export interface PostUrlListRequest {
    Title: string;
    Description: string;
    UrlItems: PostUrlItemRequest[];
}

export interface PostUrlItemRequest {
        Url: string;
        UrlDescription: string;
        UrlTitle: string;
}