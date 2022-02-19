$(".navbar .logo img").attr("src", "/Image/white_logo_transparent_background.png")
$("header").addClass("position-fixed top-0");
$("#login").attr("href" , "");
$("#login").attr("data-bs-target" , "#loginModalToggle")
$("#login").attr("data-bs-toggle" , "modal");

$(document).ready(() => {
	$(".alert").delay(5000).fadeOut();
	// Nav Bar
	$(window).scroll((e) => {
		if (window.scrollY > 10) {
			$(".navbar").css("background-color", "#646464");
			$(".navbar .logo").css({ width: "73px", height: "54px" });
			$(".active").addClass("hover");
		} else {
			$(".navbar").css("background-color", "transparent");
			$(".navbar .logo").css({ width: "175px", height: "130px" });
			$(".active").removeClass("hover");
		}
	});

	$(".navbar .hamburger").click(() => {
		$(".nav").toggleClass("open");
		$("html").css("overflow", "hidden");
		$(".backblack").toggleClass("open");
		$(".hamburger").toggleClass("toggle");
	});
	$(".backblack").click(() => {
		$(".nav").toggleClass("open");
		$(".backblack").toggleClass("open");
		$(".hamburger").toggleClass("toggle");
		$("html").css("overflow", "visible");
	});
	document.querySelector(".backblack").addEventListener("wheel", () => {
		$(".nav").removeClass("open");
		$(".backblack").removeClass("open");
		$(".hamburger").removeClass("toggle");
		$("html").css("overflow", "visible");
	});

	// Scroll top button
	$(window).scroll(() => {
		if (window.scrollY < 132) {
			$(".scroll-top").fadeOut("fast");
		} else {
			$(".scroll-top").fadeIn("fast");
		}
	});
	$(".scroll-top").click(() => {
		$(window).scrollTop(0, 0);
	});

	//Policy button
	$("#policy_btn").click(() => {
		$(".footer-policy").fadeOut("fast");
	});

	//PopOvers
	var popoverTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="popover"]'));
	var popoverList = popoverTriggerList.map(function (popoverTriggerEl) {
		return new bootstrap.Popover(popoverTriggerEl, { sanitize: false });
	});

	//Modal
	var myModal = new bootstrap.Modal(document.getElementById("loginModalToggle"));
	const urlParams = new URLSearchParams(window.location.search);
	if (urlParams.get("modalRequest") === "true") {
		myModal.show();	
		if (window.history.pushState) {
			const newURL = new URL(window.location.href);
			newURL.search = "";
			window.history.pushState({ path: newURL.href }, "", newURL.href);
		}
	}

	$("#login").click(() => {
		if (window.innerWidth < 1120) {
			$(".nav").removeClass("open");
			$(".backblack").removeClass("open");
			$(".hamburger").removeClass("toggle");
			$("html").css("overflow", "visible");
        }
    })

	// Change display properties of arrows
	if (screen.availWidth < 767) {
		document.querySelectorAll(".arrow").forEach((arr) => {
			arr.style.display = "none";
		});
	} else {
		document.querySelectorAll(".arrow").forEach((arr) => {
			arr.style.display = "inline-block";
		});
	}
	window.addEventListener("resize", () => {
		if (screen.availWidth < 767) {
			document.querySelectorAll(".arrow").forEach((arr) => {
				arr.style.display = "none";
			});
		} else {
			document.querySelectorAll(".arrow").forEach((arr) => {
				arr.style.display = "inline-block";
			});
		}
	});
});
