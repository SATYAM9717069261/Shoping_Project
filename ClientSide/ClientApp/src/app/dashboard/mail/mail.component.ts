import { Component, OnInit } from '@angular/core';
import { mailtop } from '../../common/interface/buttons';
import { message} from '../../common/interface/mail';
@Component({
  selector: 'app-mail',
  templateUrl: './mail.component.html',
  styleUrls: ['./mail.component.css']
})
export class MailComponent implements OnInit {

  topbutton: mailtop = {
    inbox: true,
    sent: false,
    spam: false,
    delete: false,
  }
  
  messagepopup:any;
  constructor() {
    this.topbutton.current = 'inbox'; // use for set current active box
  }

  ngOnInit(): void {
  }

  changecontent(data: string) {
    switch (data) {
      case 'inbox': this.topbutton.inbox = true;
        this.topbutton[this.topbutton.current] = false;
        this.topbutton.current = 'inbox';
        break;
      case 'sent': this.topbutton.sent = true;
        this.topbutton[this.topbutton.current] = false;
        this.topbutton.current = 'sent';
        break;
      case 'spam': this.topbutton.spam = true;
        this.topbutton[this.topbutton.current] = false;
        this.topbutton.current = 'spam';
        break;
      case 'delete': this.topbutton.delete = true;
        this.topbutton[this.topbutton.current] = false;
        this.topbutton.current = 'delete';
        break;
    }
  }

  filterbox(data:string){ 
    /**
     * base on which data he want link all, deleted,spam
     * pass data for filter
     * ex. pass span -> filter query data if span is up or down
     */
  }

  async openmessage(userid:string){
    /**
     * load message according to userid
     * load in message 
     */
    if(this.messagepopup == null){ // be shure component is not load every time save bandwidth
      const {SentComponent} = await import('./sent/sent.component');
      this.messagepopup =SentComponent;
    }

  }
}
