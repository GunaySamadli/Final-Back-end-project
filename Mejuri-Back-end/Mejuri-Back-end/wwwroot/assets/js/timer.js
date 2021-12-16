

//Timer
const countdown = () => {
    const endDate = document.getElementById('datetime').value;
    console.log(endDate);
    const countDate = new Date(endDate).getTime();
    const now = new Date().getTime();
    const gap = countDate - now;


    const second = 1000;
    const minute = second * 60;
    const hour = minute * 60;
    const day = hour * 24;
    if (day == 0) {
        day.style.display = none;
    }

    //Calculate
    const textDay = Math.floor(gap / day);
    const textHour = Math.floor((gap % day) / hour);
    const textMinute = Math.floor((gap % hour) / minute);
    const textSEcond = Math.floor((gap % minute) / second);

    document.querySelector(".day").innerText = textDay;
    document.querySelector(".hour").innerText = textHour;
    document.querySelector(".minute").innerText = textMinute;
    document.querySelector(".second").innerText = textSEcond;

};
setInterval(countdown, 1000);