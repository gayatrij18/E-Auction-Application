import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ProductsComponent } from '../products/products.component';
import { Products } from '../Models/Products';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {

  private getMyProductsURL = 'https://localhost:44332/e-auction/api/1/Seller/get-my-products?email=gayaj';
  private addProductsURL = 'https://localhost:44332/e-auction/api/1/Seller/add-product';
  private deleteProductURL = 'https://localhost:44332/e-auction/api/1/Seller/delete-product/';

  
  constructor(private http: HttpClient) { }
  getProducts()
  {
    var tokenHeader = new HttpHeaders({'Authorization':'Bearer '+localStorage.getItem('token')});
    console.log('tokenHeader', tokenHeader);
    return this.http.get(this.getMyProductsURL, {headers:tokenHeader});
  }

  addProduct(productData:any)
  {
    console.log('inside service');
      return this.http.post(this.addProductsURL, productData,
        {

          headers:new HttpHeaders({
  
          'Content-Type':'application/json',
  
          'Access-Control-Allow-Origin':'*',
  
          'Access-Control-Allow-Method':'*',

          'Authorization':'Bearer '+localStorage.getItem("token")
  
        })
  
    });
      
  }

  deleteProduct(product:Products)
  {
    console.log('Product to be deleted inside console.log==>', product);
    return this.http.delete(this.deleteProductURL+product.id);
  }

}
