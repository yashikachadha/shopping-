import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class MessageService {

  constructor() { }
  userId : string[]=[];
  
  storeId(user:string){
    this.userId.push(user);
  }
  clear()
  {
    this.userId=[];
  }
}
