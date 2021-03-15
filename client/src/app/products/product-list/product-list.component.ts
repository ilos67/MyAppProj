import { Component, OnInit } from '@angular/core';
// import { KeyValuePair } from ''

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.scss']
})
export class ProductListComponent implements OnInit {

  // private readonly PAGE_SIZE = 3; 

  // queryResult: any = {};
  // brands: KeyValuePair[];
  // query: any = {
  //   pageSize: this.PAGE_SIZE
  // };
  // columns = [
  //   { title: 'Id' },
  //   { title: 'Contact Name', key: 'contactName', isSortable: true },
  //   { title: 'Make', key: 'make', isSortable: true },
  //   { title: 'Model', key: 'model', isSortable: true },
  //   { }
  // ];
  constructor() { }

  ngOnInit(): void {
  }

}
