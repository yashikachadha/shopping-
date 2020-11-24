import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { user } from './Models/user';

@Injectable({
  providedIn: 'root'
})

export class UserService {
  
  

  constructor(private http: HttpClient) { }
  private url:string="/assets/data/users.json";

  getUsers(): Observable<user[]>{
    return this.http.get<user[]>(this.url);
  }
  
}
