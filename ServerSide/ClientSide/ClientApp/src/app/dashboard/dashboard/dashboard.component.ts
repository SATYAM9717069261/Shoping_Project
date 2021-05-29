import { Component, OnInit  } from '@angular/core';
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
    'message': 10,
    'products':0
  }
  category: any = {};
  textsearch:any ={};
  toggle_menu = "";
  display="";
  textboxdisplay="";
  inputboxdata="";
  SelectCategory="Select Category";

  Component:any;  // use for load a component in single page
  
  constructor(public loaderService: LoaderService, private Owner: OwnerserviceService) { 
      this.categoryMenu(); this.searchtext("");this.loadComponent('productlist');
    }

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

  async loadComponent(data:string){
    switch(data){
      case'productlist':  const{ProductComponent}=await import ('../Product/product/product.component');
                          this.Component=ProductComponent;
                          break;
      case'store'      :  const{StoreComponent}=await import ('../store/store.component');
                          this.Component=StoreComponent;
                          break;
      case'addProduct' :  break;
      case'track'      :  break;
      case'status'     :  break;
      case'messages'   :  break;
      case'setting'    :  const{ConfigurationComponent}=await import('../Configuration/configuration/configuration.component');
                          this.Component=ConfigurationComponent;
                          break;
      case'logout'     :  break;
      default          :  console.log("Check Input");
    }
  }

}

