import { Component, OnInit } from '@angular/core';
import { user } from '../Models/user';
import {ReadUsersService} from '../read-users.service';
import { output } from '../Models/output';


@Component({
  selector: 'app-bregister',
  templateUrl: './bregister.component.html',
  styleUrls: ['./bregister.component.css']
})

export class BregisterComponent implements OnInit {

 
  constructor(private userService:ReadUsersService) { }

  ngOnInit(): void {
    this.getUserList();
  }

  gender : string;

  radioGender(g:string):void{

    this.gender=g;
  }

  
  userList: user[];
  print:output;

  cpswd:string;
  newUser:user;
result:string;
  register(uname:string,pwd:string,cpwd:string,add:string,phn:string):void{
  this.newUser={} as user;
  //this.newUser.userId=uid;
  this.newUser.userName=uname;
  this.newUser.password=pwd.trim();
  this.newUser.cpass=cpwd.trim();
  this.newUser.address=add;
  this.newUser.gender=this.gender;
  this.newUser.phone=phn;
  this.userService.reg(this.newUser.userId,this.newUser.userName,this.newUser.password,this.newUser.cpass,this.newUser.gender,this.newUser.address,this.newUser.phone)
    .subscribe(print=>this.print=print)
}

    

    getUserList():void{
      this.userService.getUsers()
      .subscribe(userList=>this.userList=userList)
    }
}

