import { Component, OnInit } from '@angular/core';
import { LoaderService } from 'src/app/common/loader/loader.service';
import { OwnerserviceService } from 'src/app/common/services/ownerservice.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  login_container=true;
  registration_cointainer=false;
  constructor(public loaderService :LoaderService ,private Owner:OwnerserviceService){ }

  ngOnInit(): void {
  }
  displayReg(arg:string){
    console.log("Call sucessfull",arg);
    switch(arg){
      case"Signup_call": this.registration_cointainer =true; this.login_container=false;
      break;
      case"Login_call": this.registration_cointainer =false; this.login_container=true;
      break;
      default: console.log("Check your arg==> ",arg);
    }
  }
  check_login(){
    this.Owner.getPosts(1).subscribe( (result)=>{ 
      console.log("Sucessfull",result);
    } );
  }

  register_user(){
     this.Owner.getall().subscribe( (result) =>{ console.log(result)} );
  }
}
