import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { timeStamp } from 'console';
import { User } from '../Models/User';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

 baseURL1 = "https://localhost:44332/e-auction/api/1/Seller/authenticate-seller?email=";
 authAPIURL = "https://localhost:44343/api/User/Authenticate";

headers = {headers:new HttpHeaders({'Content-Type':'application/json'})};

  constructor(private http:HttpClient) { }

  login(loginObj:User)
  {
    console.log('username is',loginObj);
    console.log('type', typeof loginObj);
    console.log('this.authAPIURL+loginObj',this.authAPIURL+loginObj);
    //console.log(loginObj.value.toString());
   
  //return this.http.post(this.baseURL1+loginObj.value,null,this.headers);
    return this.http.post(this.authAPIURL,loginObj);
    
  }
}
