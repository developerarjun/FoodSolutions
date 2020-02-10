import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  proxyurl = "https://cors-anywhere.herokuapp.com/";

  constructor(
    private http: HttpClient
  ) { }

  login(userName: string, password: string){
    return this.http.post<any>(this.proxyurl+'https://foodsolutions.azurewebsites.net/AdminLogin', {userName, password});
  }

  logout(){
    //remove user from local storage to log user out
    localStorage.removeItem('currentUser');
  }
}
