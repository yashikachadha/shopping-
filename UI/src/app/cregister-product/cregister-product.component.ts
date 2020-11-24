import { prepareSyntheticPropertyName } from '@angular/compiler/src/render3/util';
import { Component, OnInit } from '@angular/core';
import { output } from '../Models/output';
import {product} from '../Models/product';
import {ReadUsersService} from '../read-users.service'

@Component({
  selector: 'app-cregister-product',
  templateUrl: './cregister-product.component.html',
  styleUrls: ['./cregister-product.component.css']
})
export class CregisterProductComponent implements OnInit {

  constructor(private userService:ReadUsersService) { }

  ngOnInit(): void {
  }

  newProduct :product;

  myresult:output;
  register(proId:number,proName:string,proPrice:number,proBrand:string,cate:string,qty:number):void
  {
    this.newProduct={} as product;
    this.newProduct.productId=proId;
    this.newProduct.productCategory=cate;
    this.newProduct.productName=proName;
    this.newProduct.productBrand=proBrand;
    this.newProduct.productPrice=proPrice;
    this.userService.regProduct(this.newProduct as product)
    .subscribe(myresult=>this.myresult=myresult)
  }
}
