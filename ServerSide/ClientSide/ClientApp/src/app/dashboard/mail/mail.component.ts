import { Component, OnInit } from '@angular/core';
import { mailtop } from '../../common/interface/buttons';

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
}
