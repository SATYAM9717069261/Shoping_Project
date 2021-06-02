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
    this.storedmessage=message.getmessage('1');
    console.log(this.storedmessage);
   }
 
  ngOnInit(): void {
   
  }

}
