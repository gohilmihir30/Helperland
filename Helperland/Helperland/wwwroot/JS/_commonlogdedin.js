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

jQuery.extend(jQuery.fn.dataTableExt.oSort, {
	"serviceDate-pre": function (a) {
		let time = a
			.match(/<span class="text-nowrap">.*<\/span>/)[0]
			.replace(`<span>`, "")
			.replace("</span>", "");
		console.log();
		time = time.split(" - ")[0] + ":00";
		a = a
			.match(/<strong>.*<\/strong>/)[0]
			.replace("<strong>", "")
			.replace("</strong>", "");
		let d = a.split("-");
		let day = d[0].length === 1 ? `0${d[0]}` : d[0];
		let month = d[1].length === 1 ? `0${d[1]}` : d[1];
		let year = d[2].length === 1 ? `0${d[2]}` : d[2];
		a = `${month}/${day}/${year} ${time}`;
		return a.toString();
	},
	"serviceDate-asc": function (a, b) {
		const dateA = new Date(a);
		const dateB = new Date(b);
		return dateA < dateB;
	},
	"serviceDate-desc": function (a, b) {
		const dateA = new Date(a);
		const dateB = new Date(b);
		return dateB > dateA;
	},
});
