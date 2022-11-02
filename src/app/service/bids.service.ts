import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class BidsService {
  private baseURL = 'https://jsonplaceholder.typicode.com/posts';
  private getBidsURL = 'https://localhost:44332/e-auction/api/1/Seller/get-bids?productID=';
private tail = '&sellerId=5';

private bidsURL = 'https://localhost:44332/e-auction/api/1/Seller/get-bids?productID=';
  constructor(private http: HttpClient) { }

  getData(id:any)
  {
    return this.http.get(this.bidsURL+id);
  }
}
