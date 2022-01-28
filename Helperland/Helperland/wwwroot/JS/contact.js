$(document).ready(() => {
	// Nav Bar
	$(".navbar .hamburger").click(() => {
		$(".nav").toggleClass("open");
		$("body").css("overflow", "hidden");
		$(".backblack").toggleClass("open");
		$(".hamburger").toggleClass("toggle");
	});
	$(".backblack").click(() => {
		$(".nav").toggleClass("open");
		$(".backblack").toggleClass("open");
		$(".hamburger").toggleClass("toggle");
		$("body").css("overflow", "auto");
	});
	document.querySelector(".backblack").addEventListener("wheel", () => {
		$(".nav").removeClass("open");
		$(".backblack").removeClass("open");
		$(".hamburger").removeClass("toggle");
		$("body").css("overflow", "auto");
	});

	// PopOvers
	var popoverTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="popover"]'));
	var popoverList = popoverTriggerList.map(function (popoverTriggerEl) {
		return new bootstrap.Popover(popoverTriggerEl, { sanitize: false });
	});
});
