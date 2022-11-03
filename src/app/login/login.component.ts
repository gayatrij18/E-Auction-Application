import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../service/auth.service';
import { MatIconModule } from '@angular/material/icon';
import { User } from '../Models/User';
import { Token } from '@angular/compiler';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  hide = true;
  loginForm!:FormGroup;
  user1!:User;
  cred:any;
  token:any;
  constructor(private formBuilder:FormBuilder, private auth:AuthService, private router:Router) { }


  ngOnInit(): void {
    this.loginForm=this.formBuilder.group({
      username:['', Validators.required],
      password:['', Validators.required]
    })

    if(localStorage.getItem('token') != null)
    {
      this.router.navigateByUrl('/home');
    }
  }

  onLogin()
  {
    if(this.loginForm.valid)
    {
      this.cred=this.loginForm.value;
      //let user1 = new User(id:0, FirstName:"string", LastName:"string", Username:this.auth.login(this.loginForm.controls['username']), Password:this.auth.login(this.loginForm.controls['password']), Token:"string", Role:"string", Email:"string");
      let user1 = new User();
     // this.user1 = {cred.username, cred.password};
        //this.auth.login(this.loginForm.controls['username'])
       // console.log('onLogin user1', this.cred)
        this.auth.login(this.cred)
        .subscribe({
          next:(res:any)=>{
          
            //alert(res);
           console.log('printing res inside login.c.ts=>',res);
           // console.log('printing res.JwtToken inside login.c.ts=>',res.jwtToken);
           // this.token = res.token;
            localStorage.setItem('token', res.jwtToken);
           // console.log('Printing token via localstorage inside login.c.ts',localStorage.getItem('token'));
            this.loginForm.reset();
            this.router.navigate(['view-products']);
          },
          error:(err:any)=>{

            if(err.status == 400)
            {
              console.log('Incorrect username or password');

            }
            alert(err);
            console.log(err);
            
          }
          
        })
       
    }
    else{

      this.validateAllFormFields(this.loginForm);
      //alert("your form is invalid");
    }
  }

  private validateAllFormFields(formGroup:FormGroup)
  {
    Object.keys(formGroup.controls).forEach(field=>{
      const control = formGroup.get(field);
      if(control instanceof FormControl)
      {
        control.markAsDirty({onlySelf:true});
      }
      else if(control instanceof FormGroup)
      {
        this.validateAllFormFields(control);

      }
    })
  }

}
