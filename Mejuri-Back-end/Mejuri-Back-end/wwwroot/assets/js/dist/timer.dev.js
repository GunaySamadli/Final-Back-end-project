"use strict";

//Timer
var countdown = function countdown() {
  var countDate = new Date('November 26,2022 00:00:00').getTime();
  var now = new Date().getTime();
  var gap = countDate - now;
  var second = 1000;
  var minute = second * 60;
  var hour = minute * 60;
  var day = hour * 24; //Calculate

  var textDay = Math.floor(gap / day);
  var textHour = Math.floor(gap % day / hour);
  var textMinute = Math.floor(gap % hour / minute);
  var textSEcond = Math.floor(gap % minute / second);
  document.querySelector(".day").innerText = textDay;
  document.querySelector(".hour").innerText = textHour;
  document.querySelector(".minute").innerText = textMinute;
  document.querySelector(".second").innerText = textSEcond;
};

setInterval(countdown, 1000);