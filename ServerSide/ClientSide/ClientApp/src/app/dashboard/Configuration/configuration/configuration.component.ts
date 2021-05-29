import { Component, OnInit } from '@angular/core';
import { Defaultimage } from 'src/app/common/interface/Interfaces';
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
  menuTopLeftPosition =  {x: '0', y: '0'} 
  rightmenu='none';

  imageProperty: Defaultimage ={
      imagePath:'',
      imgURL:'https://bootdey.com/img/Content/avatar/avatar7.png',
      height:'200px',
      width:'200px',
      display:"block",
      opacity:1
    }
    displayMenu='none';
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
    this.imageProperty.display='block';
  }
  save() {
    console.log("Save changes  ",this.imageProperty) // save data 
  }
  rightclick(event:any){
    event.preventDefault(); // use for disable default right click menu (System Function)
    this.menuTopLeftPosition.x = event.clientX + 'px'; 
    this.menuTopLeftPosition.y = event.clientY + 'px'; 
    this.rightmenu='block';
    console.log("Right Click  ",event);
  }
  closeimgmenu(){this.rightmenu='none'}

  onchangeImagemenu(data:string,value:any){
    switch(data){
      case'width':this.imageProperty.width=value+'px';
                  console.log('Width Change',value);
                  break;
      case'height':this.imageProperty.height=value+'px';
                  console.log('height change',value);
                  break;
      case'display':this.imageProperty.display=value+''; this.displaymenu();
                    console.log('display change',value);
                    break;
      case'opacity':this.imageProperty.opacity=value;
                    console.log('opacity change',value);
                    break;
      default:console.log('check data',data, 'and value ',value);
    }
  }
  displaymenu(){
    if(this.displayMenu=='none') this.displayMenu='contents';
    else this.displayMenu='none';
}
 
}
