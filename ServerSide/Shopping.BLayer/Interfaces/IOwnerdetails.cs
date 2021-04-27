using Shopping.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.DataLayer.Interfaces
{
    interface IOwnerdetails
    {
        Ownerdetails savedetails(Ownerdetails data); //0 for error 1 for sucessfull
        Ownerdetails getdetails(int id);
        Ownerdetails updatedetailsbyid(int id);
        Ownerdetails disablebyid(int id);// delete user
        Ownerdetails activeuserbyid(int id); // activate users
        List<Ownerdetails> activeuserlist(); //get all active user
        List<Ownerdetails> disableduserlist(); //get all disable user
        Ownerdetails getdetailswithfilters(Ownerdetails filterdetails);// get details (filter)
        List<Ownerdetails> getlistdetailswithfilters(Ownerdetails filterdetails); // get list of details on filter bases
    }
}
