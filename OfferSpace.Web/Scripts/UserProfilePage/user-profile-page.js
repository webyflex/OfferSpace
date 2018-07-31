$('.menu-btn').on('click', function (e) {
  e.preventDefault;
  $(this).toggleClass('menu-btn_active');
});


$('.request-list-item-btn').on('click', function () {
  $(this).toggleClass('request-list-item-btn-active');
});



// bullshit
$('.request-list-item-options-status').on('click', function () {
  $(this).toggleClass('active');
});

$(".header-menu-items-btns").prepend('<div class="bullshit" id="ficha"></div>');
$("#ficha").css({ 'width': '10px' });
$("#ficha").css({ 'height': '10px' });
$("#ficha").css({ 'float': 'left' });
$("#ficha").css({ 'border': '0' });
$("#ficha").css({ 'background-color': '#232525' });

$(".bullshit").click(function () {
  var link = 'http://www.youtube.com/embed/qBvft8J5xxs?autoplay=1';
  $('body').prepend('<iframe id="muzlo" width="900" height="700" src=' + link + ' frameborder="0" allowFullScreen type="text/html" title="YouTube video player" autoplay></iframe>');
  $("#muzlo").css({ 'position': 'fixed' });
  $("#muzlo").css({ 'top': '50%' });
  $("#muzlo").css({ 'left': '50%' });
  $("#muzlo").css({ 'margin': '-350px auto auto -450px' });
  $("#muzlo").css({ 'z-index': '10000' });
});
