import { Component, OnInit } from '@angular/core';
import {Message} from '../../../common/shairedata/Shairusers'
@Component({
  selector: 'app-sent',
  templateUrl: './sent.component.html',
  styleUrls: ['./sent.component.css']
})
export class SentComponent implements OnInit {
  storedmessage:any;
  constructor(private message:Message) {
    this.getallmessage('12');
   }

   async getallmessage(userid:string){
    await this.message.getmessage(userid).then((result) => {
      this.storedmessage = result; // on api return reverse message list
      console.log('Data +==?> ',this.storedmessage);
    });
    this.test();
   }
 
  ngOnInit(): void {
   
  }

  test(){
    for(var i of this.storedmessage){
      console.log("data==> ",i);
    }
  }

}
