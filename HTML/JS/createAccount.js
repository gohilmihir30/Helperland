$(".navbar .hamburger").click(() => {
	// Nav Bar
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
