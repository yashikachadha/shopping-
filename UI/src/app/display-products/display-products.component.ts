import { Component, OnInit } from '@angular/core';
import {product} from '../Models/product';
import {ReadUsersService} from '../read-users.service';
@Component({
  selector: 'app-display-products',
  templateUrl: './display-products.component.html',
  styleUrls: ['./display-products.component.css']
})
export class DisplayProductsComponent implements OnInit {

  constructor(private service:ReadUsersService) { }

  ngOnInit(): void {
    this.getProducts();
  }

  productList:product[]

  getProducts():void{
    this.service.printAllProducts()
    .subscribe(productList=>this.productList=productList);
  }
}
