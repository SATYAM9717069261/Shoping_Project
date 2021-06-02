import { Component, OnInit, ViewContainerRef, ComponentFactoryResolver } from '@angular/core';
import { LoaderService } from 'src/app/common/loader/loader.service';
import { OwnerserviceService } from 'src/app/common/services/ownerservice.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  login_container = true;
  registration_cointainer = false;
  loginform = new FormGroup({
    userid: new FormControl('', Validators.required),
    password: new FormControl('', Validators.required)
  });
  constructor(public loaderService: LoaderService, private Owner: OwnerserviceService,
    private router: Router) { }

  ngOnInit(): void {
    console.log("Login Loaded");
  }
  displayReg(arg: string) {
    console.log("Call sucessfull", arg);
    switch (arg) {
      case "Signup_call": this.registration_cointainer = true; this.login_container = false;
        break;
      case "Login_call": this.registration_cointainer = false; this.login_container = true;
        break;
      default: console.log("Check your arg==> ", arg);
    }
  }
  async check_login() {
    if (this.loginform.value['userid'] != "" && this.loginform.value['password'] != "") {
      var formdata = this.loginform.value;
      //console.log("Form Data ", formdata);
      this.Owner.getPosts(formdata).subscribe(async (result) => {
        console.log("Sucess is true ", result);
        if (result.completed == false) { // change during link with back end
          localStorage.setItem("Userid", this.loginform.value['userid']);
          localStorage.setItem("Password", this.loginform.value['password']);
          /**  this.viewContainer.clear();
             const{DashboardComponent} =await import('../../dashboard/dashboard/dashboard.component');
            this.viewContainer.createComponent(
              this.cfr.resolveComponentFactory(DashboardComponent)
            ); */
          this.router.navigate(['/dashboard']);
        }
      }, (error) => { console.log("Invalid User id and Password") });
    }
  }

  register_user() {
    this.Owner.getall().subscribe((result) => { console.log(result) });
  }
}
