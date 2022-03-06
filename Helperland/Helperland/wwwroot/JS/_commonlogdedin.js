//Data table sorting function
function sort(col, order) {
	table.order([col, order]).draw();
}

// Nav Bar
$(".navbar .hamburger").click(() => {
	$(".main-nav").toggleClass("open");
	$("html").css("overflow", "hidden");
	$(".backblack").toggleClass("open");
	$(".navbar").toggleClass("toggle");
	$(".navbar").css("position", "fixed");
});
$(".backblack").click(() => {
	$(".main-nav").toggleClass("open");
	$(".backblack").toggleClass("open");
	$(".navbar").toggleClass("toggle");
	$(".navbar").css("position", "sticky");
	$("html").css("overflow", "visible");
});
document.querySelector(".backblack").addEventListener("wheel", () => {
	$(".main-nav").removeClass("open");
	$(".backblack").removeClass("open");
	$(".navbar").removeClass("toggle");
	$("html").css("overflow", "visible");
	$(".navbar").css("position", "sticky");
});

//PopOver
var popoverTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="popover"]'));
var popoverList = popoverTriggerList.map(function (popoverTriggerEl) {
	return new bootstrap.Popover(popoverTriggerEl, { sanitize: false });
});

$(document).ready(() => {
	$(".heading").insertAfter(".dt-button");
});
