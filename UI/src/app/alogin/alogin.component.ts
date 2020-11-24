import { Component, OnInit } from '@angular/core';

import {user} from '../Models/user';
import {ReadUsersService} from '../read-users.service';

@Component({
  selector: 'app-alogin',
  templateUrl: './alogin.component.html',
  styleUrls: ['./alogin.component.css']
})
export class AloginComponent implements OnInit {

  constructor(private userService:ReadUsersService) { }

  ngOnInit(): void {
    this.getUserList();
  }

userList: user[];
usid:number;
pwdd:string;
result:string;
username:string;
/*
login(usrId:number,pswd:string):void{
  this.usid=usrId;
  this.pwdd=pswd;

  for(let a of this.userList)
  {
    if(this.usid==a.userId &&this.pwdd==a.password)
    {
      this.result="User valid: Welcome:: ";
      this.username=a.userName;
      break;
    }
    else{
      this.result="invalid user";
      this.username="try to register";
    }
  }
}
*/
  getUserList():void{
    this.userService.getUsers()
    .subscribe(userList=>this.userList=userList)
  }  
pass:string;
  returnval:string;
  checkLogin(usrname:string,pswd:string):void{
    this.username=usrname;
    this.pass=pswd;
    //console.log(this.username,this.pass);
    this.userService.check(this.username,this.pass)
    .subscribe(result=>this.result=result);
    //console.log("check");
    //console.log(this.result.userName);
    
  }
}
