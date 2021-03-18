import { IReceipie } from './receipie';

export interface IPagination {
    pageIndex: number;
    pageSize: number;
    count: number;
    data: IReceipie[];
}

export class ingPagination implements IPagination {
    pageIndex: number;
    pageSize: number;
    count: number;
    data: IReceipie[] = [];
}