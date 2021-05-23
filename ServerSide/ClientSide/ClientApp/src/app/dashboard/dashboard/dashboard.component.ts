import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LoaderService } from 'src/app/common/loader/loader.service';
import { OwnerserviceService } from 'src/app/common/services/ownerservice.service';

@Component({
  selector: 'app-dashboard',
  styleUrls: ['./dashboard.component.css'],
  templateUrl: './dashboard.component.html'

})
export class DashboardComponent implements OnInit {

  defaultdata = {
    'profileimage': 'assets/images/user.jpg',
    'username': 'Satyam',
    'userlastname': 'Mandal',
    'role': 'Administrator',
    'status': 'Active',
    'status_enum': true,
    'notification': 10,
    'message': 10
  }
  category: any = {};
  textsearch:any ={};
  toggle_menu = "";
  display="";
  textboxdisplay="";
  inputboxdata="";
  SelectCategory="Select Category";
  
  constructor(public loaderService: LoaderService, private Owner: OwnerserviceService,
    private router: Router) { this.categoryMenu(); this.searchtext("");}

  ngOnInit(): void {
    console.log("Deshboad loaded");
  }
  sidemenushow() {
    this.toggle_menu = "toggled";
  }
  sidemenudiable() {
    this.toggle_menu = "";
  }

  async categoryMenu() {
    await this.Owner.getall().subscribe((result) => {
      this.category = result;
    });
  }
  async searchtext(data:string){
    await this.Owner.getall().subscribe((result) => {
      this.textsearch = result;
    });
  }
  showcategory(){if(this.display==""){this.display="block";}else{this.display=""} }

  selectedcategory(data:string){this.SelectCategory=data;this.display=""}
  selectedtext(data:string){this.inputboxdata=data; this.textboxdisplay="";}
  showtext(data:string){
    if(data!=""){
      this.textboxdisplay="block";
      this.searchtext(data);
      console.log("TEXT++> ",data);
    }else{
      this.textboxdisplay="";
      //call api and search for data and update list     

    }

  }

  searchquery(){
    //call here data and show only those data which we want
    console.log("Category selected==> ",this.SelectCategory);
    console.log(" Text Input == >",this.inputboxdata);
  }
}

