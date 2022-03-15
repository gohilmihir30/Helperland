var triggerDetails = $("#trigger-details");
var triggerPayment = $("#trigger-payment");
var confirmBooking = $("#confirm-booking");
var serviceDate = $("#ServiceStartDate");
var paymentServiceDate = $("#payment-service-date");
var serviceTime = $("#ServiceStartTime");
var paymentServiceTime = $("#payment-service-time");
var serviceDuration = $("#ServiceHours");
var paymentServiceDuration = $("#payment-service-duration");
var paymentTotalTime = $("#payment-service-totalTime");
var paymentTotalPayment = $("#totalPayment");
var paymentPerCleaning = $("#per-cleaning");
var extra = document.querySelectorAll('input[type="checkbox"].top-0');
var servicerequestform = $("#servicerequest");
var modalclsbtn = $("button[data-bs-dismiss='modal']");

const timevalidation = () => {
	if (parseFloat(serviceTime.val()) + parseFloat(serviceDuration.val()) > 21) {
		$("#withinTime").html("Could not completed the service request, because service booking request is must be completed within 21:00 time");
		triggerDetails.addClass("pe-none");
	} else {
		triggerDetails.removeClass("pe-none");
		$("#withinTime").html("");
	}
};
const checkhours = () => {
	var h = serviceTime.val();
	var hours = Math.floor(h);
	var min = Math.ceil((h - hours) * 60);

	var date = Date.parse($("#ServiceStartDate").val().split("/").reverse().join("/") + " " + hours + ":" + min + ":00");
	var currentDate = new Date().getTime();

	if (date < currentDate) {
		document.querySelector("#withinTime").innerHTML += "Selected time is passed";
		document.querySelector("#trigger-details").classList.add("pe-none");
		return false;
	} else {
		document.querySelector("#withinTime").innerHTML = document.querySelector("#withinTime").innerHTML.replace("Selected time is passed", " ");
		document.querySelector("#trigger-details").classList.remove("pe-none");
		return true;
	}
};

const extraservice = (element, paymentElement) => {
	if (element.is(":checked")) {
		$("#payment-extra").addClass("d-flex");
		paymentElement.addClass("d-flex");
		serviceDuration[0].value = parseFloat(serviceDuration[0].value) + 0.5;
		paymentTotalTime.html(parseFloat(serviceDuration[0].value));
		paymentTotalPayment.html(parseFloat(serviceDuration[0].value * 18).toFixed(2));
		paymentPerCleaning.html(parseFloat(serviceDuration[0].value * 18).toFixed(2));
	} else {
		var checked = false;
		extra.forEach((e) => {
			if (e.checked) {
				checked = true;
			}
		});
		if (!checked) {
			$("#payment-extra").removeClass("d-flex");
		}
		serviceDuration[0].value = parseFloat(serviceDuration[0].value) - 0.5;
		paymentTotalTime.html(parseFloat(serviceDuration[0].value));
		paymentTotalPayment.html(parseFloat(serviceDuration[0].value * 18).toFixed(2));
		paymentPerCleaning.html(parseFloat(serviceDuration[0].value * 18).toFixed(2));
		paymentElement.removeClass("d-flex");
	}
	timevalidation();
};

const resetPage = () => {
	paymentServiceDuration.html("0 Hrs");
	$("#payment-extra").removeClass("d-flex");
	$("#payment-service-cabinet").removeClass("d-flex");
	$("#payment-service-fridge").removeClass("d-flex");
	$("#payment-service-oven").removeClass("d-flex");
	$("#payment-service-laundry").removeClass("d-flex");
	$("#payment-service-window").removeClass("d-flex");
	paymentTotalTime.html("0");
	paymentPerCleaning.html("00.00");
	paymentTotalPayment.html("00.00");
	servicerequestform.trigger("reset");
};

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

	// Accordion
	$(".down").click((e) => {
		$e = e.target;
		$e = $($e).parent().children("img");
		$($e).parent().next().addClass("clicked");
		$(".down").each((i, element) => {
			$element = element;
			if ($($element).next().css("display") == "block") {
				$($element).next().slideUp(500);
				$($element).children("img").toggleClass("rotate-0");
			} else if (($($element).next().css("display") == "none") & $($element).next().is(".clicked")) {
				$($e).parent().next().slideDown(500);
				$($element).children("img").toggleClass("rotate-0");
			}
		});
		$($e).parent().next().removeClass("clicked");
	});

	//Add new address
	$(".add").click(() => {
		$(".add-new-address").show();
		$(".add").hide();
	});
	$(".address-close").click(() => {
		$(".add-new-address").hide();
		$(".add").show();
	});

	modalclsbtn.click(() => {
		var tab = new bootstrap.Tab($('#myTab button[data-bs-target="#Setup"]'));
		$("#Schedule-tab").removeClass("complete");
		$("#Schedule-tab").removeClass("pe-auto");
		$("#Details-tab").removeClass("pe-auto");
		$("#Details-tab").removeClass("complete");
		tab.show();
	});

	triggerDetails.click(() => {
		if (checkhours() && $("#servicerequest").validate().form()) {
			var tab = new bootstrap.Tab($('#myTab button[data-bs-target="#Details"]'));
			$("#Schedule-tab").addClass("complete");
			$("#Schedule-tab").addClass("pe-auto");
			servicerequestform.children("#TotalCost").val(paymentTotalPayment.html());
			var checkedCount = 0;
			var checked = "";
			extra.forEach((e) => {
				if (e.checked) {
					checkedCount++;
				}
			});
			servicerequestform.children("#ExtraHours").val(checkedCount * 0.5);
			$("div.address-container div.address")
				.html("Loading Address view...")
				.load(`/viewaddress?postlcode=${$("#Postalcode").val()}`, () => {
					$(".address label input")[0].checked = true;
				});
			$("#favSP")
				.html("Loading Favorite SP List....")
				.load("/getfavoritesp", () => {
					$(".fav-sp-btn").click(($event) => {
						$("#FavoriteSP").val($($event.target).next("input").val());
						var nexttab = new bootstrap.Tab($('#myTab button[data-bs-target="#Payment"]'));
						$("#Details-tab").addClass("complete");
						$("#Details-tab").addClass("pe-auto");
						servicerequestform.children("#AddressId").val($('input.form-check-input[name="AddressId"]:checked').val());
						nexttab.show();
					});
				});
			tab.show();
		}
	});

	triggerPayment.click(() => {
		var tab = new bootstrap.Tab($('#myTab button[data-bs-target="#Payment"]'));
		$("#Details-tab").addClass("complete");
		$("#Details-tab").addClass("pe-auto");
		servicerequestform.children("#AddressId").val($('input.form-check-input[name="AddressId"]:checked').val());
		tab.show();
	});

	$("#Setup-tab").click(() => {
		$("#Schedule-tab").removeClass("complete");
		$("#Schedule-tab").removeClass("pe-auto");
		$("#Details-tab").removeClass("pe-auto");
		$("#Details-tab").removeClass("complete");
	});

	$("#Schedule-tab").click(() => {
		$("#Details-tab").removeClass("pe-auto");
		$("#Details-tab").removeClass("complete");
	});

	//payment summary
	serviceDate.datepicker({
		changeMonth: true,
		changeYear: true,
		showButtonPanel: true,
		minDate: new Date(),
		showAnim: "slideDown",
		dateFormat: "dd/mm/yy",
	});
	serviceDate.datepicker("setDate", new Date());

	serviceDate.change(() => {
		paymentServiceDate.html(serviceDate[0].value);
		checkhours();
	});

	serviceTime.change(() => {
		var time = serviceTime[0].value.toString();
		var h = Math.floor(time).toLocaleString("en-US", { minimumIntegerDigits: 2, useGrouping: false });
		var m = Math.ceil((time - h) * 60).toLocaleString("en-US", { minimumIntegerDigits: 2, useGrouping: false });
		checkhours();
		timevalidation();
		paymentServiceTime.html(h + ":" + m);
	});

	serviceDuration.change(() => {
		var checkedCount = 0;
		extra.forEach((e) => {
			if (e.checked) {
				checkedCount++;
			}
		});
		var duration = serviceDuration.val() - checkedCount * 0.5;
		if (duration < 3) {
			alert("Booking time is less than recommended, we may not be able to finish the job.");
			extra.forEach((e) => {
				$e = e;
				if (e.checked) {
					$($e).click();
				}
			});
			duration = 3;
			serviceDuration.val(duration);
		}
		timevalidation();
		paymentServiceDuration.html("<span>" + duration + "</span> Hrs");
		paymentTotalTime.html(serviceDuration[0].value);
		paymentTotalPayment.html(parseFloat(serviceDuration[0].value * 18).toFixed(2));
		paymentPerCleaning.html(parseFloat(serviceDuration[0].value * 18).toFixed(2));
	});

	$("#Cabinet").click(() => {
		extraservice($("#Cabinet"), $("#payment-service-cabinet"));
	});

	$("#Fridge").click(() => {
		extraservice($("#Fridge"), $("#payment-service-fridge"));
	});

	$("#Oven").click(() => {
		extraservice($("#Oven"), $("#payment-service-oven"));
	});

	$("#Laundry").click(() => {
		extraservice($("#Laundry"), $("#payment-service-laundry"));
	});

	$("#Windows").click(() => {
		extraservice($("#Windows"), $("#payment-service-window"));
	});

	confirmBooking.click(() => {
		servicerequestform.submit();
	});

	checkAvilabilitySuccess = (res) => {
		if (!res) {
			$("span#checkError").html("");
			$("span#checkError").fadeIn();
			$("span#checkError")[0].innerText =
				"We are not providing service in this area. We’ll notify you if any helper would start working near your area.";
			$("span#checkError").delay(5000).fadeOut();
		} else {
			servicerequestform.children("#Postalcode").val($("#checkavilability #Postalcode").val());
			serviceDate.datepicker("setDate", new Date());
			var hour = new Date().getHours();
			var min = hour + new Date().getMinutes() / 60;
			if (min > 18) {
				serviceDate.datepicker("setDate", +1);
				serviceTime.val(8);
			} else {
				serviceTime.val(min - hour < 0.5 ? hour + 0.5 : hour + 1);
			}
			var time = serviceTime[0].value.toString();
			time = "0" + time + ":00";
			paymentServiceDate.html(serviceDate[0].value);
			paymentServiceTime.html(time);
			paymentServiceDuration.html("<span>" + serviceDuration[0].value + "</span> Hrs");
			paymentTotalTime.html(parseFloat(serviceDuration[0].value));
			paymentTotalPayment.html(parseFloat(serviceDuration[0].value * 18).toFixed(2));
			paymentPerCleaning.html(parseFloat(serviceDuration[0].value * 18).toFixed(2));
			$("#addAddressForm #Postalcode").val($("#checkavilability #Postalcode").val());
			$("#addAddressForm #City").val(res.cityName);
			var tab = new bootstrap.Tab($('#myTab button[data-bs-target="#Schedule"]'));
			$("#Setup-tab").addClass("complete");
			$("#Setup-tab").addClass("pe-auto");
			tab.show();
		}
	};

	addAddressSuccess = (res) => {
		if (res <= 0) {
			$("#addAddressForm div.col-md-6:first-child").before(
				`<div class="alert alert-danger alert-dismissible fade show" role="alert">
			<strong>Sorry!</strong>Somthing went wrong please try again.
			<button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
		  </div>`
			);
		} else {
			$(`div.address-container div.address`).load(`/viewaddress?postlcode=${$("#Postalcode").val()}`, () => {
				$(".address label input")[0].checked = true;
			});
			$(".address-close").click();
		}
		$("#addAddressForm").trigger("reset");
	};

	addAddressError = () => {
		$("#addAddressForm div.col-md-6:first-child").before(
			`<div class="alert alert-danger alert-dismissible fade show" role="alert">
			<strong>Sorry!</strong>Somthing went wrong please try again.
			<button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
			</div>`
		);
		$("#addAddressForm").trigger("reset");
	};

	serviceRequestSuccess = (res) => {
		if (res != 0) {
			var myModal = new bootstrap.Modal($("#successModal"));
			$("#ModalLabel").html("Booking has been successfully submitted");
			$("#serviceId").html("Service ID: " + res);
			myModal.show();
		} else {
			var myModal = new bootstrap.Modal($("#successModal"));
			$("#successModal img").attr("src", "/Image/closeBtn.png");
			$("#successModal img").css("background-color", "red");
			$("#ModalLabel").html("Opps!! Booking hasn't been submitted, Please try again");
			myModal.show();
		}
		resetPage();
		$("#checkavilability").trigger("reset");
	};

	serviceRequestError = (res) => {
		var myModal = new bootstrap.Modal($("#successModal"));
		$("#successModal img").attr("src", "/Image/closeBtn.png");
		$("#successModal img").css("background-color", "red");
		$("#ModalLabel").html("Opps!! Booking hasn't been submitted, Please try again");
		myModal.show();
		resetPage();
		$("#checkavilability").trigger("reset");
	};
});
