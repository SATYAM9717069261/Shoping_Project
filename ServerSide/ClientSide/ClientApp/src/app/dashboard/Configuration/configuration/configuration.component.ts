import { Component, OnInit } from '@angular/core';
import { Defaultimage, Defautheader, Allmenu } from 'src/app/common/interface/Interfaces';
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
      },
    }];
  defaultpage_setting = [{
    'Receipt': {
      'Receipt': 'block'
    },
    'Accountdetail': {
      'Accountdetail': 'none',
      'general': 'none',
      'pas': 'none',
      'info': 'none',
      'social': 'none',
      'notice': 'none'
    }
  }
  ];
  imageLabel = 'none';
  menuTopLeftPosition = { x: '0', y: '0' }

  imageProperty: Defaultimage = {
    imagePath: '',
    imgURL: 'https://bootdey.com/img/Content/avatar/avatar7.png',
    height: '200px',
    width: '200px',
    display: "block",
    opacity: 1
  }
  headerProperty: Defautheader = {
    font: '20px',
    text: 'Dash LLC 2500 Ridgepoint Dr, Suite 105-C Austin TX 78754 VAT Number EU826113958',
    bgcolor: 'white',
    color: 'black',
    float: 'right',
    height: '150px',
    width: '150px',
    display: 'inline-table'
  }
  displayMenu = 'none';
  constructor() {
    this.defaultpage_setting[0]['Receipt']['Receipt'] = 'block';
    console.log("Data ++> ", this.defaultpage_setting);
  }

  AlldisplayMenu: Allmenu = {
    photomenu: 'none',
    headermenu: 'none',
    photomenu_display: 'none',
    header_display: 'none',
    header_float: 'none',
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
        'info': 'none',
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
      case 'info': this.disableblock();
        this.defaultpage_setting[0]['Accountdetail']['Accountdetail'] = 'block';
        this.defaultpage_setting[0]['Accountdetail']['info'] = 'block';
        break;
      default: console.log('Check Input String');
    }
  }

  clickhandler(data: string) { }

  hoverhandler(data: string) {
    if (data == 'upload_show') this.imageLabel = 'block';
    if (data == 'upload_hide') this.imageLabel = 'none';
  }



  imageupload(file: any) {
    if (file.length === 0)
      return;
    var mimeType = file[0].type;
    if (mimeType.match(/image\/*/) == null) {
      return;
    }

    var reader = new FileReader();
    this.imageProperty.imagePath = file;
    reader.readAsDataURL(file[0]);
    reader.onload = (_event) => {
      this.imageProperty.imgURL = reader.result;
    }
    this.imageProperty.display = 'block';
  }

  rightclick(event: any, data: string) {
    event.preventDefault(); // use for disable default right click menu (System Function)
    this.menuTopLeftPosition.x = event.clientX + 'px';
    this.menuTopLeftPosition.y = event.clientY + 'px';
    switch (data) {
      case 'img': this.AlldisplayMenu.photomenu = 'block';
        break;
      case 'header': this.AlldisplayMenu.headermenu = 'block';
        break;
      default: console.log("Check argument");
    }
  }


  displaymenu(data: string) {
    /**  
     * pass which menu you want to display
    */
    switch (data) {
      case 'imgdisplay': this.AlldisplayMenu.photomenu_display = 'contents';
        break;
      case 'header_display': this.AlldisplayMenu.header_display = 'contents';
        break;
      case 'header_float': this.AlldisplayMenu.header_float = 'contents';
        break;
      default: console.log("Check argument");
    }
  }

  onchangeImagemenu(data: string, value: any) {
    switch (data) {
      case 'width': this.imageProperty.width = value + 'px';
        break;
      case 'height': this.imageProperty.height = value + 'px';
        break;
      case 'display': this.imageProperty.display = value + ''; this.closeimgmenu('imgdisplay');
        break;
      case 'opacity': this.imageProperty.opacity = value;
        break;
      default: console.log('check data', data, 'and value ', value);
    }
  }
  headeronchange(data: string, value: any) {
    switch (data) {
      case 'width': this.headerProperty.width = value + 'px';
        console.log('Width Change', value);
        break;
      case 'height': this.headerProperty.height = value + 'px';
        console.log('height change', value);
        break;
      case 'display': this.headerProperty.display = value + '';
        this.closeimgmenu('header_display');
        console.log('display change', value);
        break;
      case 'font': this.headerProperty.font = value + 'px';
        console.log('Font change', value);
        break;
      case 'text':
        console.log('Before change', this.headerProperty.text);
        this.headerProperty.text = this.headerProperty.text + (value + '');
        console.log('After change', this.headerProperty.text);
        break;
      case 'bgcolor': this.headerProperty.bgcolor = value;
        console.log('bgcolor change', value);
        break;
      case 'color': this.headerProperty.color = value;
        console.log('color change', value);
        break;
      case 'float': this.headerProperty.float = value;
        this.closeimgmenu('header_float');
        console.log('float change', value);
        break;
      default: console.log('check data', data, 'and value ', value);
    }
  }
  closeimgmenu(data: string) {
    switch (data) {
      case 'imgdisplay': this.AlldisplayMenu.photomenu_display = 'none';
        break;
      case 'header_display': this.AlldisplayMenu.header_display = 'none';
        break;
      case 'header_float': this.AlldisplayMenu.header_float = 'none';
        break;
      case 'img': this.AlldisplayMenu.photomenu = 'none';
        break;
      case 'header': this.AlldisplayMenu.headermenu = 'none';
        break;
      default: console.log("Check argument");
    }
  }

  save() {
    console.log("Save changes  ", this.imageProperty) // save data 
  }
}
