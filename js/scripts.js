$(function(){

  // Sticky Header: makes a fixed navbar appear after you scroll down 100 units
    //.navbar has 0% opacity to start with
    //class 'sticky' gives the fixed navbar 100% opacity
    //this js dynamically applies 'sticky' class to navbar in certain circumstances
  if ($('.navbar').hasClass('fixed')) { //applies sticky right off the bat if navbar has a class called fixed in the initial html (so put class of fixed on navbar on html pages that you want the navbar to always be visible)
    $('.navbar').addClass('sticky');
  }

  //scroll function causes navbar to appear and dissapear on pages that don't have the fixed class on navbar
  $(window).scroll(function() {
      if ($(window).scrollTop() > 100) {
        $('.navbar').addClass('sticky');
      } else if (!$('.navbar').hasClass('fixed')) {
        $('.navbar').removeClass('sticky');
      }


  });

  // Mobile Navigation: when you click the menu hamburger...
  $('.mobile-toggle').click(function() {
    //a) a class is applied to header that makes the burger rotate
      if ($('.navbar').hasClass('open-nav')) {
          $('.navbar').removeClass('open-nav');
      } else {
          $('.navbar').addClass('open-nav');
          //applies the open-nav class that makes the header (navbar) tall enough to show the ul links that are initially hidden due to overflow:hidden being present on the header.
      }
  });
  //b)
  $('.navbar li a').click(function() {
      if ($('.navbar').hasClass('open-nav')) {
          $('.navigation').removeClass('open-nav');//no idea what this line does, there is nothing in document with class called "navigation"?
          $('.navbar').removeClass('open-nav');
      }
  });

  // Navigation Scroll
  $('nav a').click(function(event) {
      var id = $(this).attr("href");
      var offset = 70;
      var target = $(id).offset().top - offset;
      $('html, body').animate({
          scrollTop: target
      }, 500);
      event.preventDefault();
  });


  //gallery hover effect
  $(".cause-box").hover(function(){
  	$(".cause-info", this).css("display", "block");
	},
  function(){
  	$(".cause-info", this).css("display", "none");
  });



});
