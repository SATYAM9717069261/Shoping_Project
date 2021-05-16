import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  defaultdata={
    'profileimage': 'assets/images/user.jpg',
    'username':'Satyam',
    'userlastname':'Mandal',
    'role':'Administrator',
    'status':'Active',
    'status_enum':true,
    'notification':0,
    'message':0
  }
  toggle_menu = "";
  constructor() { 
  }
  ngOnInit(): void {
  }
  sidemenushow(){
   this.toggle_menu="toggled";
  }
  sidemenudiable(){
   this.toggle_menu="";
  }
}


/**
 * jQuery(function ($) {

    $(".sidebar-dropdown > a").click(function() {
  $(".sidebar-submenu").slideUp(200);
  if (
    $(this)
      .parent()
      .hasClass("active")
  ) {
    $(".sidebar-dropdown").removeClass("active");
    $(this)
      .parent()
      .removeClass("active");
  } else {
    $(".sidebar-dropdown").removeClass("active");
    $(this)
      .next(".sidebar-submenu")
      .slideDown(200);
    $(this)
      .parent()
      .addClass("active");
  }
});

$("#close-sidebar").click(function() {
  $(".page-wrapper").removeClass("toggled");
});
$("#show-sidebar").click(function() {
  $(".page-wrapper").addClass("toggled");
});


   
   
});
 */