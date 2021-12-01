"use strict";

//Slider
$('.slider').slick({
  dots: false,
  arrows: true,
  infinite: false,
  speed: 300,
  slidesToShow: 4,
  slidesToScroll: 4,
  responsive: [{
    breakpoint: 1024,
    settings: {
      slidesToShow: 3,
      slidesToScroll: 3,
      infinite: true,
      dots: true
    }
  }, {
    breakpoint: 600,
    settings: {
      slidesToShow: 2,
      slidesToScroll: 2
    }
  }, {
    breakpoint: 480,
    settings: {
      slidesToShow: 1,
      slidesToScroll: 1
    }
  }]
});
$('.single-items').slick({
  dots: true,
  arrows: false,
  infinite: false
}); // barnd filter

var tabBrands = Array.from(document.querySelectorAll(" .tab-brand"));
var tabContents = Array.from(document.querySelectorAll(".content-brands .content-brand"));

var clearActives = function clearActives() {
  tabBrands.forEach(function (tabBrand) {
    tabBrand.classList.remove("active");
  });
  tabContents.forEach(function (tabContent) {
    tabContent.classList.remove("active");
  });
};

tabBrands.forEach(function (tabBrand) {
  tabBrand.onclick = function () {
    clearActives();
    var targetId = tabBrand.getAttribute("data-target");
    var targetContent = document.getElementById(targetId);
    tabBrand.classList.add("active");
    targetContent.classList.add("active");
  };
}); //Sidebar

var opens = document.querySelector("header .openMenu");
opens.addEventListener("click", function (e) {
  e.preventDefault();
  var customResponsiveNav = document.querySelector(".custom-responsive-nav");
  var navbar = document.querySelector("header .custom-nav");

  if (customResponsiveNav.style.left == null || customResponsiveNav.style.height == "" || customResponsiveNav.style.height == "0px") {
    customResponsiveNav.style.height = "100%";
    customResponsiveNav.style.left = "0";
    navbar.style.display = "none";
  }
});
var element = document.querySelector(".close-btn");
element.addEventListener("click", function (e) {
  e.preventDefault();
  var customResponsiveNav = document.querySelector(".custom-responsive-nav");
  var navbar = document.querySelector("header .custom-nav");

  if (customResponsiveNav.style.height == "100%") {
    customResponsiveNav.style.height = "0";
    navbar.style.display = "block";
  }
}); // Review And Question

var tabReviews = Array.from(document.querySelectorAll(" .tab-review"));
var tabRewContents = Array.from(document.querySelectorAll(".content-reviewes .content-review"));

var clearRewActives = function clearRewActives() {
  tabReviews.forEach(function (tabREw) {
    tabREw.classList.remove("active");
  });
  tabRewContents.forEach(function (tabRewContent) {
    tabRewContent.classList.remove("active");
  });
};

tabReviews.forEach(function (tabREw) {
  tabREw.onclick = function () {
    clearRewActives();
    var targetId = tabREw.getAttribute("data-target");
    var targetContent = document.getElementById(targetId);
    tabREw.classList.add("active");
    targetContent.classList.add("active");
  };
}); // Basket

var basketIcon = document.getElementById("basket-icon");
var BasketItemParent = document.querySelectorAll(".basket-item");
basketIcon.addEventListener("click", function (e) {
  e.preventDefault();
  var basket = document.getElementById("basket");
  basket.style.transform = "translateX(10px)";
});
var removeItemFromBasket = document.querySelectorAll('#removeitem');

var _loop = function _loop(i) {
  button = removeItemFromBasket[i];
  button.addEventListener("click", function (e) {
    e.preventDefault();
    BasketItemParent[i].remove();
    updateCartTotal();
  });
};

for (var i = 0; i < removeItemFromBasket.length; i++) {
  var button;

  _loop(i);
} // var quantityInputs = document.getElementsByClassName("card-count");
// for (let i = 0; i < quantityInputs.length; i++) {
//     var input = quantityInputs[i];
//     input.addEventListener("change", quantityChanged)
// }
// function quantityChanged(e) {
//     e.preventDefault();
//     var input = e.target
//     if (isNaN(input.value) || input.value <= 0) {
//         input.value = 1;
//     }
//     updateCartTotal()
// }
// var AddToCardButtons = document.querySelectorAll(".add-basket")
// for (var i = 0; i < AddToCardButtons.length; i++) {
//     var button = AddToCardButtons[i]
//     button.addEventListener('click', addToCard)
// }
// function addToCard(e) {
//     e.preventDefault();
//     var shopItem = document.querySelectorAll(".favs")
//     var title = document.querySelectorAll(".basket-head")[0].innerText
//     var price = document.querySelectorAll(".basket-price")[0].innerText
//     var imageSrc = document.querySelectorAll(".images")[0].src
//     addItemCart(title, price, imageSrc)
//     updateCartTotal()
// }
// function addItemCart(title, price, imageSrc) {
//     var CartRow = document.createElement('div');
//     CartRow.classList.add("basket-item-content")
//     CartRow.innerText = title
//     cartItems = document.getElementsByClassName('basket-item')[0]
//     var cartRowContents = `
//     <div class="col-md-3">
//         <img src="${imageSrc}" alt="">
//      </div>
//     <div class="col-md-9">
//         <div class="name-icon">
//              <h2>
//                 ${title}
//             </h2>
//             <button id="removeitem" type="button">
//                 <i class="fas fa-times"></i>
//             </button>
//         </div>
//         <div class="count-price">
//              <div class="count">
//                 <i class="fas fa-minus"></i>
//                     <input class="card-count" value="2"
//                      type="number">
//                  <i class="fas fa-plus"></i>
//             </div>
//             <div>
//                   <span class="price">${price}</span>
//             </div>
//           </div>
//      </div>
//     `
//     CartRow.innerHTML = cartRowContents
//     cartItems.append(CartRow)
//     CartRow.querySelectorAll('#removeitem')[0].addEventListener('click', removeItemFromBasket)
//     CartRow.getElementsByClassName('card-count')[0].addEventListener('change', quantityChanged)
// }
// function updateCartTotal() {
//     let cartItemContainer = document.getElementsByClassName("basket-body")[0]
//     var CartRows = cartItemContainer.getElementsByClassName("basket-item")
//     var total = 0
//     for (let i = 0; i < CartRows.length; i++) {
//         var CartRow = CartRows[i]
//         var priceElement = CartRow.getElementsByClassName("price")[0]
//         var quantityElement = CartRow.getElementsByClassName("card-count")[0]
//         var price = parseFloat(priceElement.innerText.replace('$', ''))
//         var quantity = quantityElement.value
//         total = total + (price * quantity);
//     }
//     document.getElementsByClassName("total")[0].innerText = total;
// }
//Dropdown


$(document).ready(function () {
  $('.company-category-head').on('click', function (e) {
    e.preventDefault();

    if ($(this).next('.drop-menu').css('display') == 'none') {
      $(this).find('img').css('transform', 'rotate(180deg)');
    } else {
      $(this).find('img').css('transform', 'rotate(0deg)');
    }

    $(this).next('.drop-menu').slideToggle();
  });
}); //Search

var SearchBar = document.querySelector(".search-bar");
SearchBar.addEventListener("click", function (e) {
  e.preventDefault();
  var search = document.getElementById("search");
  search.style.display = "block";
});
var SearchBarX = document.querySelector(".search-button");
SearchBarX.addEventListener("click", function (e) {
  e.preventDefault();
  var search = document.getElementById("search");
  search.style.display = "none";
});