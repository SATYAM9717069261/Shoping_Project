import { Injectable } from "@angular/core";
import { mailstatus } from "../enums/userenum";
import { message } from "../interface/mail";
import { OwnerserviceService } from "../services/ownerservice.service";
@Injectable({
  providedIn: 'root'
})
export class Message {
  mapmessage: Array<message> = [];
  private messagearray: any;
  constructor(private Owner: OwnerserviceService) { }

  mapping(apidata: any) {
    for (var i of apidata) {
      i['ownerid']='232';
      i['status']=mailstatus.important;
      this.mapmessage.push(i);
    }
//   return this.mapmessage;
  }

  async getmessage(userid: string) {
    this.messagearray = await this.Owner.getmessagedata('1');
    this.mapping(this.messagearray);
    return this.mapmessage;
  }

}