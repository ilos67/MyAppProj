import { HttpClient } from '@angular/common/http';
import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { IBrand, IType, ShopParams } from 'src/app/_models';
import { IProduct } from 'src/app/_models/product';
import { ProductService } from '../product.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.scss']
})
export class ProductsComponent implements OnInit {
  @ViewChild('search') searchTerm: ElementRef;
  products: IProduct[];
  brands: IBrand[];
  types: IType[];
  shopParams: ShopParams;
  totalCount: number;
  sortOptions = [
    { name: 'Alphabetical', value: 'name' },
    { name: 'Price: Low to High', value: 'priceAsc' },
    { name: 'Price: High to Low', value: 'priceDesc' }
  ];

  constructor(private productService: ProductService) {
    this.shopParams = this.productService.getShopParams();
  }

  ngOnInit() {
    this.getProducts(true);
    this.getBrands();
    this.getTypes();
  }

  getProducts(useCache = false) {
    this.productService.getProducts(useCache).subscribe(response => {
      this.products = response.data;
      this.totalCount = response.count;
    }, error => {
      console.log(error);
    });
  }

  getBrands() {
    this.productService.getBrands().subscribe(response => {
      this.brands = [{ id: 0, name: 'All' }, ...response];
    }, error => {
      console.log(error);
    });
  }

  getTypes() {
    this.productService.getTypes().subscribe(response => {
      this.types = [{ id: 0, name: 'All' }, ...response];
    }, error => {
      console.log(error);
    });
  }

  onBrandSelected(brandId: number) {
    const params = this.productService.getShopParams();
    params.brandId = brandId;
    params.pageNumber = 1;
    this.productService.setShopParams(params);
    this.getProducts();
  }

  onTypeSelected(typeId: number) {
    const params = this.productService.getShopParams();
    params.typeId = typeId;
    params.pageNumber = 1;
    this.productService.setShopParams(params);
    this.getProducts();
  }

  onSortSelected(sort: string) {
    const params = this.productService.getShopParams();
    params.sort = sort;
    this.productService.setShopParams(params);
    this.getProducts();
  }

  onPageChanged(event: any) {
    const params = this.productService.getShopParams();
    if (params.pageNumber !== event) {
      params.pageNumber = event;
      this.productService.setShopParams(params);
      this.getProducts(true);
    }
  }

  onSearch() {
    const params = this.productService.getShopParams();
    params.search = this.searchTerm.nativeElement.value;
    params.pageNumber = 1;
    this.productService.setShopParams(params);
    this.getProducts();
  }

  onReset() {
    this.searchTerm.nativeElement.value = '';
    this.shopParams = new ShopParams();
    this.productService.setShopParams(this.shopParams);
    this.getProducts();
  }
}
