import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { IProduct } from '../_models/product';
import { IReceipie } from '../_models/receipie';

@Injectable({
  providedIn: 'root'
})
export class ReceipieService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getProductsWithStocks() {
    return this.http.get<Partial<IReceipie[]>>(this.baseUrl + 'recepies');
  }

  getRecepiesStock() {
    return this.http.get<IReceipie[]>(this.baseUrl + 'recepies')
  }
}
