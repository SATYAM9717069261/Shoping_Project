import { Component, OnInit} from '@angular/core';
import { Router } from '@angular/router';
import { DashboardComponent} from '../../dashboard/dashboard.component';
import { LoaderService } from '../../../common/loader/loader.service';
import { OwnerserviceService } from '../../../common/services/ownerservice.service';
import { DatatransferserviceService} from '../../../common/services/datatransferservice.service';

@Component({
  selector: 'products',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {
  number:any={};
  product_list = new Map<string,any>();
  product_details_show="none";
  countproduct=0;
  constructor(public loaderService: LoaderService, private Owner: OwnerserviceService,
    private router: Router, private dashboard:DashboardComponent, private datatransferservice:DatatransferserviceService ) { 
    this.companylist();
  }

  ngOnInit(): void {
    this.countproduct=this.dashboard.defaultdata['products']; 
   }

   async companylist(){
     await this.Owner.getall().subscribe((result) => { 
       this.number=result;
       });
     
    console.log("Type of ",this.number['title']);
   }
   Productdetails(id:Int16Array){
     console.log("Id Selected=> ",id);
     this.product_details_show="block";
   }
   addproduct(id:string,name:string){
    if(this.datatransferservice.setproduct(id,name) ==1){ this.dashboard.defaultdata['products']=++this.countproduct;}
   }

   delproduct(id:string,name:string){
    if(this.datatransferservice.removeproduct(id,name) ==1){ this.dashboard.defaultdata['products']=--this.countproduct;}
    }

}