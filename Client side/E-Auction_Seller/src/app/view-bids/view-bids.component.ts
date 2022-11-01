import { Component, OnInit, ViewChild } from '@angular/core';
import { BidsService } from '../service/bids.service';
import {MatPaginator, MatPaginatorModule} from '@angular/material/paginator';
import {MatSort, MatSortModule} from '@angular/material/sort';
import {MatTableDataSource} from '@angular/material/table';
import {MatInputModule} from '@angular/material/input';

export interface UserData{
  id:any;
  userId:any;
  title:any;
  body:any;
}

export interface BidData{
  id:any;
  productName:any;
  shortDescription:any;
  detailedDescription:any;
  category:any;
  startingPrice:any;
  bidEndDate:any;
  firstName:any;
  lastName:any;
  bidAmount:any;


}
@Component({
  selector: 'app-view-bids',
  templateUrl: './view-bids.component.html',
  styleUrls: ['./view-bids.component.css']
})
export class ViewBidsComponent implements OnInit {

  columnNames:string[] = ['id', 'userId', 'title', 'body'];
  bidsColumns:string[] = ['id', 'productName', 'shortDescription', 'detailedDescription', 'category', 'startingPrice', 'bidEndDate', 'firstName', 'lastName', 'bidAmount'];
  //dataSource!:MatTableDataSource<UserData>;
  dataSource!:any;
  @ViewChild(MatPaginator) paginator!:MatPaginator;
  @ViewChild(MatSort) sort!:MatSort;
  posts:any;
  filterValue:any;
  
  
  constructor(private service: BidsService) {
    // this.service.getData().subscribe(data=>{
    //   console.log(data);
    //   this.posts = data;
    //   console.log('posts:',this.posts);
    //   this.dataSource = new MatTableDataSource(this.posts);

    //   this.dataSource.paginator = this.paginator;
    //   this.dataSource.sort = this.sort;
    // });

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
  
  ngOnInit(): void {
  }

}
