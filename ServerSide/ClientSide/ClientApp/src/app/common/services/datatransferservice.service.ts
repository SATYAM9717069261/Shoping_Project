import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class DatatransferserviceService {
  product_list = new Map<string,any>();
  totalamount:number=0;
  constructor() { }

  setproduct(id:string,name:string){
   // console.log("Before set ==> ", this.product_list);
    if(this.product_list.has(id)){
      this.product_list.set(id,{'Product Name':name,'Total Count': 
                                          this.product_list.get(id)['Total Count']+1
                                          ,'Price':id,'id':id
                                        });
     }else{
       this.product_list.set(id,{'Product Name':name,'Total Count':1,'Price':id,'id':id});
     }
     //console.log("After set ==> ", this.product_list);
     return 1;
   }

   removeproduct(id:string,name:string){
    //console.log("Before Remove ==> ", this.product_list);
    if(this.product_list.has(id)){
      this.product_list.set(id,{'Product Name':name,'Total Count': 
                                          this.product_list.get(id)['Total Count']-1
                                          ,'Price':id,'id':id
                                        });
      if(this.product_list.get(id)['Total Count']==0){this.product_list.delete(id);}
     //console.log("After Remove ==> ", this.product_list);
      return 1; // for sucessfully delete
    }
    return 0; // 0 for unsucessfull delete
   }

   getproduct(){
    //console.log("set ==> ", this.product_list);
     return this.product_list;
   }
   payableamount(){
     this.totalamount=0;
    for(let i of this.product_list.values()){
      this.totalamount+= i['Total Count']*i['Price'];
   }
   return this.totalamount;
  }

}
