import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-display-products',
  templateUrl: './display-products.component.html',
  styleUrls: ['./display-products.component.css']
})
export class DisplayProductsComponent implements OnInit {

  @Input() collapsed= false;
  @Input() screenWidth = 0;
  constructor() { }

  ngOnInit(): void {
  }
  getBodyClass():string{

    let styleClass = '';
    if(this.collapsed && this.screenWidth >768){
      styleClass = 'body-trimmed';
    }
    else if(this.collapsed && this.screenWidth <=768 && this.screenWidth > 0)
    {
      styleClass = 'body-md-screen';

    }
    return styleClass;
  }

}
