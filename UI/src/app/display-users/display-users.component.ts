import { Component, OnInit } from '@angular/core';
//import { Console } from 'console';
import { from } from 'rxjs';
import {ReadUsersService} from '../read-users.service';
import {user} from '../Models/user';
@Component({
  selector: 'app-display-users',
  templateUrl: './display-users.component.html',
  styleUrls: ['./display-users.component.css']
})
export class DisplayUsersComponent implements OnInit {

  constructor(private usersServiceInstance : ReadUsersService) { }

  ngOnInit(): void {
    this.getUserList();
  }


  userList : user[];
  
  getUserList():void{
    console.log("req sent");
    this.usersServiceInstance.getUsers()
    .subscribe(userList=>this.userList=userList);
    //console.log(this.userList);
  }  
}
