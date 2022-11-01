import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {

  private getMyProductsURL = 'https://localhost:44332/e-auction/api/1/Seller/get-my-products?email=gayaj';

  constructor(private http: HttpClient) { }

  // getProducts()
  // {
  //   return this.http.get(this.getMyProductsURL);
  // }
  getProducts()
  {
    var tokenHeader = new HttpHeaders({'Authorization':'Bearer '+localStorage.getItem('token')});
    console.log('tokenHeader', tokenHeader);
    return this.http.get(this.getMyProductsURL, {headers:tokenHeader});
  }

}
