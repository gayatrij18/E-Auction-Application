import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

interface SideNavToggle{
  screenWidth:number;
  collapsed:boolean;

}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{

  title = 'my-proj';
  isSideNavCollapsed = false;
  screenWidth = 0;
  login:any;

  constructor(private router:Router) { }

  onToggleSideNav(data: SideNavToggle):void{
    this.screenWidth = data.screenWidth;
    this.isSideNavCollapsed = data.collapsed;

  }

  ngOnInit(): void{
    console.log('this.router.url', this.router.url);
    console.log(window.location.href);
    var href = window.location.href;
    console.log('href', href.includes('login'));
    if(href.includes('login'))
    {
      this.login = true;
    }
    console.log('this.login', this.login);
  }
}
