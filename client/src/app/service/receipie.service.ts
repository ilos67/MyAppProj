import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { IBranding } from '../_models/ingBrand';
import { ICateing } from '../_models/ingCate';
import { ingPagination } from '../_models/ingPagina';
import { ingShopParams } from '../_models/ingParams';
import { IPagination, Pagination } from '../_models/pagination';
import { IReceipie } from '../_models/receipie';

@Injectable({
  providedIn: 'root'
})
export class ReceipieService {
  baseUrl = environment.apiUrl;
  ingredients: IReceipie[] = [];
  cateing: ICateing[] = []
  branding: IBranding[] = []
  pagination = new ingPagination();
  shopParams = new ingShopParams();

  constructor(private http: HttpClient) { }

    getIngre(useCache: boolean) {
    if (useCache === false) {
      this.ingredients = [];
    }

    if (this.ingredients.length > 0 && useCache === true) {
      const pagesReceived = Math.ceil(this.ingredients.length / this.shopParams.pageSize);

      if (this.shopParams.pageNumber <= pagesReceived) {
        this.pagination.data =
          this.ingredients.slice((this.shopParams.pageNumber - 1) * this.shopParams.pageSize,
            this.shopParams.pageNumber * this.shopParams.pageSize);

        return of(this.pagination);
      }
    }

    let params = new HttpParams();

    if (this.shopParams.cateId !== 0) {
      params = params.append('cateId', this.shopParams.cateId.toString());
    }

    if (this.shopParams.brandId !== 0) {
      params = params.append('brandId', this.shopParams.brandId.toString());
    }

    if (this.shopParams.search) {
      params = params.append('search', this.shopParams.search);
    }

    params = params.append('sort', this.shopParams.sort);
    params = params.append('pageIndex', this.shopParams.pageNumber.toString());
    params = params.append('pageSize', this.shopParams.pageSize.toString());

    return this.http.get<IPagination>(this.baseUrl + 'ingredients', { observe: 'response', params })
      .pipe(
        map(response => {
          this.ingredients = [...this.ingredients, ...response.body.data];
          this.pagination = response.body;
          return this.pagination;
        })
      );
  }

  getShopParams() {
    return this.shopParams;
  }

  setShopParams(params: ingShopParams) {
    this.shopParams = params;
  }

  getProduct(id: number) {
    const ingredient = this.ingredients.find(p => p.id === id);

    if (ingredient) {
      return of(ingredient);
    }

    return this.http.get<IReceipie>(this.baseUrl + 'ingredients/' + id);
  }

  getBrands() {
    if (this.branding.length > 0) {
      return of(this.branding);
    }
    return this.http.get<IBranding[]>(this.baseUrl + 'ingredients/brands').pipe(
      map(response => {
        this.branding = response;
        return response;
      })
    );
  }

  getCates() {
    if (this.cateing.length > 0) {
      return of(this.cateing);
    }
    return this.http.get<ICateing[]>(this.baseUrl + 'ingredients/categories').pipe(
      map(response => {
        this.cateing = response;
        return response;
      })
    );
  }
}
