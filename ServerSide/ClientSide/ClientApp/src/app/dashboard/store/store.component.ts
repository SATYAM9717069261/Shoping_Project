import { Component, OnInit } from '@angular/core';
import { DatatransferserviceService} from '../../common/services/datatransferservice.service';
import { DashboardComponent} from '../dashboard/dashboard.component';

@Component({
  selector: 'app-store',
  templateUrl: './store.component.html',
  styleUrls: ['./store.component.css']
})
export class StoreComponent implements OnInit {

  selectedProduct:any;
  count=0;
  productdetailshow:boolean=false; // default collapse < true: expend >
  rotate:string='';
  totalamount=0;
  countproduct=0;
  constructor(private datatransfer:DatatransferserviceService,private dashboard:DashboardComponent) { 
    
    console.log("Total=>",this.totalamount);
    /**
     for(let i of this.selectedProduct.values()){
      console.log('Values=> ',i['Total Count']);
    }
    
     * <li *ngFor="let recipient of this.selectedProduct | keyvalue">
        {{recipient.key}} --> {{recipient.value}}
      </li>
     */
    //console.log("Product List== >", datatransfer.getproduct());
  }

  ngOnInit(): void {
    this.countproduct=this.dashboard.defaultdata['products']; 
    this.selectedProduct=this.datatransfer.getproduct();
    this.totalamount=this.datatransfer.payableamount();

  }

  expendproductdetails(){ // not working properly
    if(this.productdetailshow==false) { this.productdetailshow=true; 
                                        console.log('Show : => ',this.productdetailshow ); 
                                        this.rotate='productlistshow-upword';
                                      }
    else{
      this.productdetailshow=false; 
      console.log('Show : => ',this.productdetailshow );
      this.rotate='productlistshow-downword';
    }
  }
  autoincrement(){
    return this.count++;
  }
  addproduct(id:string,name:string){
    if(this.datatransfer.setproduct(id,name) ==1){ this.dashboard.defaultdata['products']=++this.countproduct;}
    this.count=0;
    this.totalamount=this.datatransfer.payableamount();
    
   }

   delproduct(id:string,name:string){
    if(this.datatransfer.removeproduct(id,name) ==1){ this.dashboard.defaultdata['products']=--this.countproduct;}
    this.count=0;
    this.totalamount=this.datatransfer.payableamount();
    }
}
