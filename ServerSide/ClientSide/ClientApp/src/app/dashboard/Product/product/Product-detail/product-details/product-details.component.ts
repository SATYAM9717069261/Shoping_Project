import { Component, OnInit } from '@angular/core';
import {ProductComponent} from '../../product.component';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css']
})
export class ProductDetailsComponent implements OnInit {
    product_data:any[];
    colorScheme={domain:['red','red','red','red','red','red','red','red','red','red','red','red']};
    gradient=false;
    constructor(private disablepopup:ProductComponent ) {
      this.product_data=[
          {"Name":"Jan","Value":10},
          {"Name":"Feb","Value":13},
          {"Name":"Mar","Value":15},
          {"Name":"Apr","Value":12},
          {"Name":"May","Value":14},
          {"Name":"Jun","Value":1},
          {"Name":"Jul","Value":18},
          {"Name":"Aug","Value":13},
          {"Name":"Sep","Value":0},
          {"Name":"Oct","Value":19},
          {"Name":"Nov","Value":10},
          {"Name":"Dec","Value":17}
        ];
   }

  ngOnInit(): void {
  }
  close(){
    this.disablepopup.product_details_show="none";
  }

}
