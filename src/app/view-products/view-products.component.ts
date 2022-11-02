import { Component, OnInit, ViewChild } from '@angular/core';
import { ProductsService } from '../service/products.service';
import {MatListModule} from '@angular/material/list';
import { Products } from '../Models/Products';
import { BidsService } from '../service/bids.service';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-view-products',
  templateUrl: './view-products.component.html',
  styleUrls: ['./view-products.component.css']
})
export class ViewProductsComponent implements OnInit {

  typesOfShoes: string[] = ['Boots', 'Clogs', 'Loafers', 'Moccasins', 'Sneakers'];
  columnNames: Products[] = [
  //   {id:1, productName:'hjh', shortDescription: 'bbjb', detailedDescription: 'jnjn', category:'kjk', startingPrice:'jk',bidEndDate:'kk'},
  //   {id:2, productName:'jijjh', shortDescription: 'bbjb', detailedDescription: 'jnjn', category:'kjk', startingPrice:'jk',bidEndDate:'kk'}
   ];
   bidsColumns:string[] = ['id', 'productName', 'shortDescription', 'detailedDescription', 'category', 'startingPrice', 'bidEndDate', 'firstName', 'lastName', 'bidAmount'];

   selectedHero?: Products;
  posts:any;
  dataSource!:any;
  filterValue:any;
  @ViewChild(MatPaginator) paginator!:MatPaginator;
  @ViewChild(MatSort) sort!:MatSort;
  constructor(private productService:ProductsService, private service:BidsService ) { 
    this.productService.getProducts().subscribe(data=>{
      console.log(data);
      this.posts = data;
     // console.log('posts:',this.posts);
      this.columnNames = this.posts;
      console.log('this.columnNames', this.columnNames);
    
    });
}

  ngOnInit(): void {
  }

  
  onSelect(hero: Products): void {
    this.selectedHero = hero;

    this.service.getData(this.selectedHero.id).subscribe(data=>{
      console.log(data);
      this.posts = data;
      console.log('posts:',this.posts);
      this.dataSource = new MatTableDataSource(this.posts);

      this.dataSource.paginator = this.paginator;
       this.dataSource.sort = this.sort;
      
    });

  }
 
  
  applyFilter(event: Event)
  {
    this.filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = this.filterValue.trim().toLowerCase();

    if(this.dataSource.paginator)
    {
      this.dataSource.paginator.firstPage();
    }
  }



}
