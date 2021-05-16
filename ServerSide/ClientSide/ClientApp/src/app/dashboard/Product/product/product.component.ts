import { Component, OnInit } from '@angular/core';
import { interval } from 'rxjs';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
    const slider=interval(1000);
    slider.subscribe((d)=>{
      console.log(d);
    })
   }
  slidedata(){
    console.log("Sucessfull");
  }

}


/** 
  var swiper = new Swiper('.swiper-container', {
      slidesPerView: 5.2,
      spaceBetween: 30,
      pagination: {
        el: '.swiper-pagination',
        clickable: true,
      },
    });
 */