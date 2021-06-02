import { Component, OnInit } from '@angular/core';
import {Message} from '../../../common/shairedata/Shairusers'
@Component({
  selector: 'app-sent',
  templateUrl: './sent.component.html',
  styleUrls: ['./sent.component.css']
})
export class SentComponent implements OnInit {

  constructor(private message:Message) {
    
   }
 
  ngOnInit(): void {
    console.log(this.message.getmessage('1'));
  }

}
