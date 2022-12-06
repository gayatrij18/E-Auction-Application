import { Component, OnInit, ViewChild } from '@angular/core';
import { ProductsService } from '../service/products.service';
import {MatListModule} from '@angular/material/list'; 
import { Products } from '../Models/Products';
import { BidsService } from '../service/bids.service';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { MatSnackBar, MatSnackBarHorizontalPosition, MatSnackBarVerticalPosition, } from '@angular/material/snack-bar';

import {MatDialog, MatDialogRef} from '@angular/material/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { DialogBoxComponent } from '../dialog-box/dialog-box.component';
import { BehaviorSubject } from 'rxjs';

@Component({
  selector: 'app-view-products',
  templateUrl: './view-products.component.html',
  styleUrls: ['./view-products.component.css']
})
export class ViewProductsComponent implements OnInit {

  horizontalPosition: MatSnackBarHorizontalPosition = 'end';
  verticalPosition: MatSnackBarVerticalPosition = 'top';


  typesOfShoes: string[] = ['Boots', 'Clogs', 'Loafers', 'Moccasins', 'Sneakers'];
  columnNames: Products[] = [
  ];
   bidsColumns:string[] = ['id', 'productName', 'shortDescription', 'detailedDescription', 'category', 'startingPrice', 'bidEndDate', 'firstName', 'lastName', 'bidAmount'];

  selectedHero?: Products;
  posts:any;
  dataSource!:any;
  filterValue:any;
  @ViewChild(MatPaginator) paginator!:MatPaginator;
  @ViewChild(MatSort) sort!:MatSort;
  durationInSeconds = 4000;

  constructor(private productService:ProductsService, private service:BidsService,
    private _snackbar:MatSnackBar, 
    public dialog: MatDialog,
    private router:ActivatedRoute,
    private route:Router) { 
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

  public openDialog(product:Products){


    this.dialog.open(DialogBoxComponent, {
      width:'350px',
      height:'180px',
      data:"right click"
    })
    .afterClosed().subscribe(res=>{
      console.log(res);
      if(res)
      {
        this.onDelete(product);
      }

    });
  }
 
  public onDelete(product:Products)
  {
        console.log('selected product is ==>', product);

        
        // this.dialog.open(SnackbarComponent)
        this.productService.deleteProduct(product)
        .subscribe({
          next:(res:any)=>{
      
          console.log('Product deleted successfully');
          // alert('Product deleted successfully!');
          
          this._snackbar.open('❌Product deleted successfully', '✕', {
            horizontalPosition: this.horizontalPosition,
            verticalPosition: this.verticalPosition,
            panelClass:"snackbar",
            duration:5*this.durationInSeconds
          });
          this.reloadCurrentRoute();
          console.log(res);
      },
      error:(err:any)=>{
        console.log(err.error);
      
      }

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

  reloadCurrentRoute() {
    let currentUrl = this.router.url;
    this.route.navigateByUrl('/', {skipLocationChange: true}).then(() => {
        this.route.navigate(['view-products']);
    });
}





}
