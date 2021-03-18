import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { ReceipieService } from 'src/app/service/receipie.service';
import { IProduct } from 'src/app/_models';
import { IBranding } from 'src/app/_models/ingBrand';
import { ICateing } from 'src/app/_models/ingCate';
import { ingShopParams } from 'src/app/_models/ingParams';
import { IReceipie } from 'src/app/_models/receipie';

@Component({
  selector: 'app-receipies',
  templateUrl: './receipies.component.html',
  styleUrls: ['./receipies.component.scss']
})
export class ReceipiesComponent implements OnInit {
  @ViewChild('search') searchTerm: ElementRef;
  receipies: IReceipie[];
  cateing: ICateing[];
  branding: IBranding[];
  shopParams: ingShopParams;
  totalCount: number;
  sortOptions = [
    { name: 'Alphabetical', value: 'name' },
    { name: 'Price: Low to High', value: 'priceAsc' },
    { name: 'Price: High to Low', value: 'priceDesc' }
  ];

  constructor(private receipieService: ReceipieService) {
    this.shopParams = this.receipieService.getShopParams();
   }

  ngOnInit(): void {
    this.getProducts(true);
    this.getBrands();
    this.getTypes();
  }

  getProducts(useCache = false) {
    this.receipieService.getIngre(useCache).subscribe(response => {
      this.receipies = response.data;
      this.totalCount = response.count;
    }, error => {
      console.log(error);
    });
  }

  getBrands() {
    this.receipieService.getBrands().subscribe(response => {
      this.branding = [{ id: 0, name: 'All' }, ...response];
    }, error => {
      console.log(error);
    });
  }

  getTypes() {
    this.receipieService.getCates().subscribe(response => {
      this.cateing = [{ id: 0, name: 'All' }, ...response];
    }, error => {
      console.log(error);
    });
  }

  onBrandSelected(brandId: number) {
    const params = this.receipieService.getShopParams();
    params.brandId = brandId;
    params.pageNumber = 1;
    this.receipieService.setShopParams(params);
    this.getProducts();
  }

  onTypeSelected(typeId: number) {
    const params = this.receipieService.getShopParams();
    params.cateId = typeId;
    params.pageNumber = 1;
    this.receipieService.setShopParams(params);
    this.getProducts();
  }

  onSortSelected(sort: string) {
    const params = this.receipieService.getShopParams();
    params.sort = sort;
    this.receipieService.setShopParams(params);
    this.getProducts();
  }


  onPageChanged(event: any) {
    const params = this.receipieService.getShopParams();
    if (params.pageNumber !== event) {
      params.pageNumber = event;
      this.receipieService.setShopParams(params);
      this.getProducts(true);
    }
  }

  onSearch() {
    const params = this.receipieService.getShopParams();
    params.search = this.searchTerm.nativeElement.value;
    params.pageNumber = 1;
    this.receipieService.setShopParams(params);
    this.getProducts();
  }

  onReset() {
    this.searchTerm.nativeElement.value = '';
    this.shopParams = new ingShopParams();
    this.receipieService.setShopParams(this.shopParams);
    this.getProducts();
  }

}
