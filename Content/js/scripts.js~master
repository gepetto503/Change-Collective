//if possible, write some js that says if document=index.html, .addClass('fixed')

//also, if !document=index.html, add padding-top to main content area.


$(function(){

  if (!$('title').hasClass('home')) {
    $('.navbar').addClass('fixed');
  }
  // Sticky Header: makes a fixed navbar appear after you scroll down 100 units
    //.navbar has 0% opacity to start with
    //class 'sticky' gives the fixed navbar 100% opacity
    //this js dynamically applies 'sticky' class to navbar in certain circumstances
  if ($('.navbar').hasClass('fixed')) { //applies sticky right off the bat if navbar has a class called fixed in the initial html (so put class of fixed on navbar on html pages that you want the navbar to always be visible)
    $('.navbar').addClass('sticky');
  }
// show and hide carousel
  $('.input-bio1').click(function(){
    $('.donate-text').hide();
    $('.bio-1').show();
  });

  $('.input-bio2').click(function(){
    $('.donate-text').hide();
    $('.bio-2').show();
  });

  $('.input-bio3').click(function(){
    $('.donate-text').hide();
    $('.bio-3').show();
  });

  $('.input-bio4').click(function(){
    $('.donate-text').hide();
    $('.bio-4').show();
  });

  $('.input-bio5').click(function(){
    $('.donate-text').hide();
    $('.bio-5').show();
  });

  $('.input-bio6').click(function(){
    $('.donate-text').hide();
    $('.bio-6').show();
  });

  // display range of slider

  function modifyOffset() {
  	var el, newPoint, newPlace, offset, siblings, k;
  	width    = this.offsetWidth;
  	newPoint = (this.value - this.getAttribute("min")) / (this.getAttribute("max") - this.getAttribute("min"));
  	offset   = -1;
  	if (newPoint < 0) { newPlace = 0;  }
  	else if (newPoint > 1) { newPlace = width; }
  	else { newPlace = width * newPoint + offset; offset -= newPoint;}
  	siblings = this.parentNode.childNodes;
  	for (var i = 0; i < siblings.length; i++) {
  		sibling = siblings[i];
  		if (sibling.id == this.id) { k = true; }
  		if ((k == true) && (sibling.nodeName == "OUTPUT")) {
  			outputTag = sibling;
  		}
  	}
  	outputTag.style.left       = newPlace + "px";
  	outputTag.style.marginLeft = offset + "%";
  	outputTag.innerHTML        = this.value;
  }

  function modifyInputs() {

  	var inputs = document.getElementsByTagName("input");
  	for (var i = 0; i < inputs.length; i++) {
  		if (inputs[i].getAttribute("type") == "range") {
  			inputs[i].onchange = modifyOffset;

  			// the following taken from http://stackoverflow.com/questions/2856513/trigger-onchange-event-manually
  			if ("fireEvent" in inputs[i]) {
  			    inputs[i].fireEvent("onchange");
  			} else {
  			    var evt = document.createEvent("HTMLEvents");
  			    evt.initEvent("change", false, true);
  			    inputs[i].dispatchEvent(evt);
  			}
  		}
  	}
  }

  modifyInputs();


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
