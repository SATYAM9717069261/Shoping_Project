import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http'
import { Observable } from 'rxjs/internal/Observable';

@Injectable({
  providedIn: 'root'
})
export class OwnerserviceService {

  constructor(private http:HttpClient) { }
  getPosts(data:any):Observable<any>{
      return this.http.get("https://jsonplaceholder.typicode.com/todos/1"); 
  }

  getall(){
      return this.http.get("https://jsonplaceholder.typicode.com/todos/");  
  }
  
}
