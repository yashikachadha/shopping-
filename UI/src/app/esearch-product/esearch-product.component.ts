import { Component, OnInit } from '@angular/core';
import { input } from '../Models/input';
import {product} from '../Models/product';
import {ReadUsersService} from '../read-users.service';

@Component({
  selector: 'app-esearch-product',
  templateUrl: './esearch-product.component.html',
  styleUrls: ['./esearch-product.component.css']
})
export class EsearchProductComponent implements OnInit {

  constructor(private service:ReadUsersService) { }

  ngOnInit(): void {
  }
  searchResults:product[];
  search:input;
  searchProduct(productId:number):void{
    this.search={} as input;
    this.search.getId=productId;

    this.service.searchProduct(this.search)
    .subscribe(searchResults=>this.searchResults=searchResults);
  }

}
