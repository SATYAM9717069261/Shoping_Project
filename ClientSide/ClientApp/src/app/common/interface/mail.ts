
export interface message{
    from:string;
    to:string;
    header:string;
    message:any;
    ownerid:string; //loging portal
    userid:string; //who send this message
    date:Date; // which date this message invoke
    status:number; // is it important message add some keywords in database and check is it inside this mail if occure then mail is important
}
