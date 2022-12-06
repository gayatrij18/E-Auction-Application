import { Component, OnInit, ViewChild } from '@angular/core';
import { ProductsService } from '../service/products.service';
import  {NgForm} from '@angular/forms';
import { LoaderService } from '../loader/loader.service';
//import { ToastrService } from 'ngx-toastr';
//import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.css']
})
export class AddProductComponent implements OnInit {


  productname:string = '';
  // email:string;
  // phoneNo:number;
  // password:string;
  // confirmPassword:string;

  constructor(private productService:ProductsService, public loaderService:LoaderService) { }

  ngOnInit(): void {

    // this.toast.success({detail:"SUCCESS",summary:'Your Success Message',duration:5000});
    // console.log('token in add products',localStorage.getItem('token'));
    
  }

  onClickSubmit(data:NgForm)
  {
    console.log('inside onclicksubmit');
    console.log(data);
    this.productService.addProduct(data.value)
    .subscribe({
      next:(res:any)=>{
   
      console.log('res adter subscribe', res);
      // this.toastr.success({detail:'Success Message', summary:"Product added successfully for E-Auction", duration:5000});
      // this.toastr.success({detail:"SUCCESS",summary:'Your Success Message',duration:5000});
      //this.toastr.success('Hello world!', 'Toastr fun!');
      alert("Product added successfully!");
      data.reset();
      console.log(res);
  },
  error:(err:any)=>{
    console.log(err.error);
  
    alert("Please try again!");
    // this.toastr.error('everything is broken', 'Major Error', {
    //   timeOut: 3000,
    // });
    //this.toastr.error({detail:'Error Message', summary:"Something went wrong. Please try again", duration:15000});
      }

  });
    
      
    

  }
}
