import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LoaderService } from 'src/app/common/loader/loader.service';
import { OwnerserviceService } from 'src/app/common/services/ownerservice.service';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {
  number:any={};
  constructor(public loaderService: LoaderService, private Owner: OwnerserviceService,
  private router: Router) { 
    
    //for(let i=0;i<100;i++){ this.number.push(i);}
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
}