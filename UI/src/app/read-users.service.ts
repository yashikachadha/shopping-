import { Injectable } from '@angular/core';
import { HttpClient, HttpClientModule, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { user } from './Models/user';
import {product} from './Models/product';
import { stringify } from 'querystring';
import { input } from './Models/input';

const httpOptions : any    = {
  headers: new HttpHeaders({
    //'Content-Type':  'application/json',
    //'Access-Control-Allow-Headers': 'Content-Type',
        //'Access-Control-Allow-Methods': 'GET',
        'Access-Control-Allow-Methods': 'GET, POST, PATCH, PUT, DELETE, OPTIONS',
    'Access-Control-Allow-Origin': '*',
'Access-Control-Allow-Headers': '*'
  })
};

//Header set Access-Control-Allow-Origin "*"
@Injectable({
  providedIn: 'root'
})
export class ReadUsersService {

  constructor(private http: HttpClient) { }

  
  private apiUrl:string="https://localhost:44354/api/LoginRegister";

  getUsers(): Observable<any>{
    return this.http.get<user[]>(this.apiUrl,httpOptions);
  }



  private loginUrl:string="https://localhost:44354/api/LoginRegister/PostLogin";


  check(username:string,passwd:string): Observable<any>{
    return this.http.post<any>(this.loginUrl,{username:  username, password: passwd},httpOptions);
  }

  private registerUrl:string="https://localhost:44354/api/LoginRegister/Register";

  reg(userId:number,username:string,psswd:string,cpass:string,gender:string,address:string,phone:string):Observable<any>{
    return this.http.post<any>(this.registerUrl,{userId:userId,userName:username, password:psswd, cpass: cpass, gender:gender, address:address,phone:phone});
  }


  private productRegisterUrl:string="https://localhost:44354/api/RegisterProduct/RegisterPro";
  regProduct(newPro: product):Observable<any>{
    return this.http.post<any>(this.productRegisterUrl,{productId:newPro.productId},httpOptions);
  }

  private displayAllProductsUrl:string ="https://localhost:44354/api/DisplayProducts/PrintAllProducts";
  printAllProducts():Observable<any>{
    return this.http.get<any>(this.displayAllProductsUrl,httpOptions)
  }

  private searchProductUrl:string="https://localhost:44354/api/DisplayProducts/Search";
  searchProduct(searckKey:input):Observable<any>{
    return this.http.post<product[]>(this.searchProductUrl, searckKey,httpOptions);
  }

}
