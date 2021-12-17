

// barnd filter

const tabBrands = Array.from(document.querySelectorAll(" .tab-brand"));
const tabContents = Array.from(document.querySelectorAll(".content-brands .content-brand"));

const clearActives = function () {
    tabBrands.forEach(tabBrand => {
        tabBrand.classList.remove("active");
    });
    tabContents.forEach(tabContent => {
        tabContent.classList.remove("active");
    });
}



tabBrands.forEach(tabBrand => {
    tabBrand.onclick = function () {
        clearActives();
        const targetId = tabBrand.getAttribute("data-target");
        const targetContent = document.getElementById(targetId);
        tabBrand.classList.add("active");
        targetContent.classList.add("active")
    }
})


//Sidebar


let opens = document.querySelector("header .openMenu");
opens.addEventListener("click", function (e) {
    e.preventDefault();
    let customResponsiveNav = document.querySelector(".custom-responsive-nav");
    let navbar = document.querySelector("header .custom-nav");
    if (customResponsiveNav.style.left == null || customResponsiveNav.style.height == "" || customResponsiveNav.style.height == "0px") {
        customResponsiveNav.style.height = "100%";
        customResponsiveNav.style.left = "0";
        navbar.style.display = "none";
    }


});
let element = document.querySelector(".close-btn");
element.addEventListener("click", function (e) {
    e.preventDefault();
    let customResponsiveNav = document.querySelector(".custom-responsive-nav");
    let navbar = document.querySelector("header .custom-nav");
    if (customResponsiveNav.style.height == "100%") {
        customResponsiveNav.style.height = "0";
        navbar.style.display = "block";

    }

});


// Review And Question


const tabReviews = Array.from(document.querySelectorAll(" .tab-review"));
const tabRewContents = Array.from(document.querySelectorAll(".content-reviewes .content-review"));

const clearRewActives = function () {
    tabReviews.forEach(tabREw => {
        tabREw.classList.remove("active");
    });
    tabRewContents.forEach(tabRewContent => {
        tabRewContent.classList.remove("active");
    });
}



tabReviews.forEach(tabREw => {
    tabREw.onclick = function () {
        clearRewActives();
        const targetId = tabREw.getAttribute("data-target");
        const targetContent = document.getElementById(targetId);
        tabREw.classList.add("active");
        targetContent.classList.add("active")
    }
})


// Basket

const basketIcon = document.getElementById("basket-icon");
const BasketItemParent = document.querySelectorAll(".basket-item")
basketIcon.addEventListener("click", function (e) {
    e.preventDefault();
    const basket = document.getElementById("basket");
    basket.style.display = "block"
})

const CloseBasket = document.querySelector(".close-basket")
CloseBasket.addEventListener("click", function (e) {
    e.preventDefault();
    const basket = document.getElementById("basket");
    basket.style.display = "none"
})





//Dropdown

$(document).ready(function () {
    $('.company-category-head').on('click', function (e) {
        e.preventDefault();
        if ($(this).next('.drop-menu').css('display') == 'none') {
            $(this).find('img').css('transform', 'rotate(180deg)');
        }
        else {
            $(this).find('img').css('transform', 'rotate(0deg)');
        }

        $(this).next('.drop-menu').slideToggle();
    })
});


//Filter
$(document).ready(function () {
    $('.filter-open').on('click', function (e) {
        e.preventDefault();
        if ($('#filter').css('display') == 'none') {
            $(".filter-open").removeClass('.fas fa-plus').addClass('.fas fa-minus');
        }
        else {
            $(".filter-open").removeClass('.fas fa-minus').addClass('.fas fa-plus');
        }
        $('#filter').slideToggle();
    })
});

//Nav drop-down

$(document).ready(function () {
    $('.nav-link').on('click', function (e) {
        e.preventDefault();
        if ($(this).next('.nav-drop-menu').css('display') == 'none') {
            $(this).find('svg').css('transform', 'rotate(180deg)');
        }
        else {
            $(this).find('svg').css('transform', 'rotate(0deg)');
        }

        $(this).next('.nav-drop-menu').slideToggle();
    })
});

//Search
const SearchBar = document.querySelector(".search-bar");
SearchBar.addEventListener("click", function (e) {
    e.preventDefault();
    const search = document.getElementById("search");
    search.style.display = "block"
})

const SearchBarX = document.querySelector(".search-button");
SearchBarX.addEventListener("click", function (e) {
    e.preventDefault();
    const search = document.getElementById("search");
    search.style.display = "none"
})


// Filter Color


const tabColors = Array.from(document.querySelectorAll(".tab-color"));
const tabColorContents = Array.from(document.querySelectorAll(".card-image"));

const clearColorActives = function (dataId) {
    tabColors.forEach(tabREw => {
        if (tabREw.parentElement.parentElement.getAttribute('data-id') == dataId) {
            tabREw.classList.remove("active");
        }
    });
    tabColorContents.forEach(tabRewContent => {
        if (tabRewContent.parentElement.getAttribute('id') == dataId) {
            tabRewContent.classList.remove("active");
        }
    });
}



tabColors.forEach(tabREw => {
    tabREw.onclick = function () {
        let dataId = this.parentElement.parentElement.getAttribute('data-id');
        let contentColor = document.getElementById(dataId);
        clearColorActives(dataId);

        const targetId = tabREw.getAttribute("data-target");
        const targetContent = contentColor.querySelector('#' + targetId)
        tabREw.classList.add("active");
        targetContent.classList.add("active")
    }
})




// Filter Color Detail Page

const tabDetail = Array.from(document.querySelectorAll(" .tab-color-detail"));
const tabContentsColor = Array.from(document.querySelectorAll(".content-detail-colors .content-detail-color"));

const clearActivesFromDetail = function () {
    tabDetail.forEach(tabBrand => {
        tabBrand.classList.remove("active");
    });
    tabContentsColor.forEach(tabContent => {
        tabContent.classList.remove("active");
    });
}



tabDetail.forEach(tabBrand => {
    tabBrand.onclick = function () {
        clearActivesFromDetail();
        const targetId = tabBrand.getAttribute("data-target");
        const targetContent = document.getElementById(targetId);
        tabBrand.classList.add("active");
        targetContent.classList.add("active")
    }
})


//Timer
// const countdown = () => {
//     const countDate = new Date('November 26,2022 00:00:00').getTime();
//     const now = new Date().getTime();
//     const gap = countDate - now;


//     const second = 1000;
//     const minute = second * 60;
//     const hour = minute * 60;
//     const day = hour * 24;

//     //Calculate
//     const textDay = Math.floor(gap / day);
//     const textHour = Math.floor((gap % day) / hour);
//     const textMinute = Math.floor((gap % hour) / minute);
//     const textSEcond = Math.floor((gap % minute) / second);

//     document.querySelector(".day").innerText = textDay;
//     document.querySelector(".hour").innerText = textHour;
//     document.querySelector(".minute").innerText = textMinute;
//     document.querySelector(".second").innerText = textSEcond;

// };
// setInterval(countdown, 1000);