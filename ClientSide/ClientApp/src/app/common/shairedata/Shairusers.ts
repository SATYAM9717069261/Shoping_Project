import { message } from "../interface/mail";
import {OwnerserviceService} from "../services/ownerservice.service";
export class Message{
  /**
   * Store data for common use
   * any module can change that data 
   * first call service for authentication then change it 
   *message={
    from:'',
    to:'',
    header:'',
    message:'',
    ownerid:'101', 
    userid:'102',
    date:new Date('10-12-2012'),
    status:mailstatus.important
  }
   */
   
  //constructor(private Owner:OwnerserviceService){}
  mapping(apidata:any,response:message){
    response.from=apidata['from'];
  }
   getmessage(userid:string){
     return "Sucessfull";
     /** 
    await this.Owner.getmessage('1').subscribe( (result:any) => {
      return result;
    })*/
  }
    
}