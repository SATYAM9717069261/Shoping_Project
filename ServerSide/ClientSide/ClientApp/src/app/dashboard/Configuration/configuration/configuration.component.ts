import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-configuration',
  templateUrl: './configuration.component.html',
  styleUrls: ['./configuration.component.css']
})
export class ConfigurationComponent implements OnInit {

  defaultdata = [
    {
      'gen': {
        'Name': 'Satyam Mandal',
        'Email': 'satyam.mandal.77@gmail.com',
        'User Name': 'Satyam',
        'Company name': 'XYZ Company Name',
        'profileurl': 'assets/images/user.jpg'
      },
      'info': {
        'Note': 'Full Stack Developer',
        'DOB': ' Oct 2, 1998',
        'Country': 'India',
        'Phone': '9717069261',
        'Website': 'url'
      },
      'social': {
        'Twitter': 'aksdslakjdlad.com',
        'Facebook': 'Abcdefdfkd;f',
        'Google': 'ajdlajdlajdladj',
        'Linkdin': 'sdjhsldslhdlsd',
        'Instagram': 'sdhkshdksdkhsdk'
      },
      'notice': {
        'emailnotice': true, 'blockedmailbg': 'red', 'blockedmail': true, 'Prioritymailbg': 'green',
        'storenotice': true, 'storeminkg': 120, 'storeminquantity': 10
      }
    }];
  defaultpage_setting = [{
    'Receipt': {
      'Receipt': 'block'
    },
    'Accountdetail': {
      'Accountdetail': 'none',
      'general': 'none',
      'pas': 'none',
      'info':'none',
      'social': 'none',
      'notice': 'none'
    }
  }
  ];
  constructor() {
    this.defaultpage_setting[0]['Receipt']['Receipt'] = 'block';
    console.log("Data ++> ", this.defaultpage_setting);
  }

  ngOnInit(): void {
  }

  disableblock() {
    this.defaultpage_setting = [{
      'Receipt': {
        'Receipt': 'none'
      },
      'Accountdetail': {
        'Accountdetail': 'none',
        'general': 'none',
        'pas': 'none',
        'info':'none',
        'social': 'none',
        'notice': 'none'
      }
    }
    ];
  }
  accountdetail(data: string) {
    switch (data) {
      case 'Receipt': this.disableblock();
        this.defaultpage_setting[0]['Receipt']['Receipt'] = 'block';
        break;
      case 'Accountdetail': this.disableblock();
        this.defaultpage_setting[0]['Accountdetail']['general'] = 'block';
        this.defaultpage_setting[0]['Accountdetail']['Accountdetail'] = 'block';
        break;
      case 'general': this.disableblock();
        this.defaultpage_setting[0]['Accountdetail']['Accountdetail'] = 'block';
        this.defaultpage_setting[0]['Accountdetail']['general'] = 'block';
        break;
      case 'pas': this.disableblock();
        this.defaultpage_setting[0]['Accountdetail']['Accountdetail'] = 'block';
        this.defaultpage_setting[0]['Accountdetail']['pas'] = 'block';
        break;
      case 'social': this.disableblock();
        this.defaultpage_setting[0]['Accountdetail']['Accountdetail'] = 'block';
        this.defaultpage_setting[0]['Accountdetail']['social'] = 'block';
        break;
      case 'notice': this.disableblock();
        this.defaultpage_setting[0]['Accountdetail']['Accountdetail'] = 'block';
        this.defaultpage_setting[0]['Accountdetail']['notice'] = 'block';
        break;
        case 'info':this.disableblock(); 
        this.defaultpage_setting[0]['Accountdetail']['Accountdetail'] = 'block';
        this.defaultpage_setting[0]['Accountdetail']['info'] = 'block';
        break;
      default: console.log('Check Input String');
    }
  }
}
