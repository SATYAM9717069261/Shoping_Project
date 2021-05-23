import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { DashboardComponent} from '../../dashboard/dashboard.component';
import { LoaderService } from 'src/app/common/loader/loader.service';
import { OwnerserviceService } from 'src/app/common/services/ownerservice.service';

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
    private router: Router, private dashboard:DashboardComponent) { 
    this.companylist();
  }

  ngOnInit(): void {
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
    if(this.product_list.has(id)){
      this.product_list.set(id,{'Product Name':name,'Total Count': 
                                          this.product_list.get(id)['Total Count']+1
                                        });
     }else{
       this.product_list.set(id,{'Product Name':name,'Total Count':1});
     } 
     this.dashboard.defaultdata['products']=++this.countproduct;
     console.log("data=> ",this.product_list);
   }

   delproduct(id:string,name:string){
    if(this.product_list.has(id)){
      this.product_list.set(id,{'Product Name':name,'Total Count': 
                                          this.product_list.get(id)['Total Count']-1
                                        });
      this.dashboard.defaultdata['products']=--this.countproduct;
      if(this.product_list.get(id)['Total Count']==0){this.product_list.delete(id);}
    }else{
      console.log("Eror Popup Can't Add Product");
      
    }
    
    console.log("data=> ",this.product_list);
   }

}