$(document).ready(function () {
	// PopOvers
	var popoverTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="popover"]'));
	var popoverList = popoverTriggerList.map(function (popoverTriggerEl) {
		return new bootstrap.Popover(popoverTriggerEl, { sanitize: false });
	});
	// Data Table
	var table = $("#request").DataTable({
		dom: "t<'d-flex justify-content-between align-items-center'lip>",
		columnDefs: [
			{ orderable: false, targets: [5, 6] },
			{ type: "serviceDate", targets: 1 },
		],
		language: {
			paginate: {
				previous: '<img src="/Image/Polygon 1 copy 5.png" alt="">',
				next: '<img src="/Image/Polygon 1 copy 5.png" style="transform:rotate(180deg)" alt="">',
			},
			info: "Total Record: _MAX_",
			lengthMenu: "Show_MENU_Entries",
			emptyTable: "No service request Found",
		},
	});
	jQuery.extend(jQuery.fn.dataTableExt.oSort, {
		"serviceDate-pre": function (a) {
			let time = a
				.match(/<span>.*<\/span>/)[0]
				.replace(`<span>`, "")
				.replace("</span>", "");
			time = time.split(" - ")[0] + ":00";
			a = a
				.match(/<strong>.*<\/strong>/)[0]
				.replace("<strong>", "")
				.replace("</strong>", "");
			console.log(a);
			let d = a.split("/");
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

	$("#search").click(() => {
		$.fn.dataTableExt.afnFiltering.length = 0;

		var customer = $("#customer").val();
		var serviceprovider = $("#serviceprovider").val();
		var serviceid = $("#serviceid").val();
		var status = $("#status").val();
		var fromDate = $("#fromdate").val();
		var toDate = $("#todate").val();

		$.fn.dataTable.ext.search.push((settings, data, dataIndex) => {
			var splitDate = data[1]
				.match(/<strong>.*<\/strong>/)[0]
				.replace("<strong>", "")
				.replace("</strong>", "")
				.split("/");
			console.log();
			var date = new Date(parseInt(splitDate[2]), parseInt(splitDate[1]) - 1, parseInt(splitDate[0]));
			var isServiceId = serviceid ? new RegExp("^" + serviceid + "+").test(data[0]) : true;
			var isCustomer = customer ? data[2].includes(customer) : true;
			var isServiceProvider = serviceprovider ? data[3].includes(serviceprovider) : true;
			var isStatus = status ? data[5].includes(status) : true;
			var isFromDate = fromDate ? new Date(fromDate) <= date : true;
			var isToDate = toDate ? new Date(toDate) >= date : true;

			return isCustomer && isServiceProvider && isServiceId && isStatus && isFromDate && isToDate;
		});
		table.draw();
	});

	$("#clear").click(() => {
		$.fn.dataTableExt.afnFiltering.length = 0;
		table.draw();
	});
	$(".btn.trigger").click((e) => {
		$element = e.target;
		$($element).next().toggleClass("rotate-0");
		$($element).next().next().slideToggle();
	});

	// Nav Bar
	$(".navbar .hamburger").click(() => {
		$(".left").toggleClass("open");
		$("body").css("overflow", "hidden");
		$(".backblack").toggleClass("open");
		$(".navbar").toggleClass("toggle");
	});
	$(".backblack").click(() => {
		$(".left").toggleClass("open");
		$(".backblack").toggleClass("open");
		$(".navbar").toggleClass("toggle");
		$("body").css("overflow", "visible");
	});
	document.querySelector(".backblack").addEventListener("wheel", () => {
		$(".left").removeClass("open");
		$(".backblack").removeClass("open");
		$(".navbar").removeClass("toggle");
		$("body").css("overflow", "visible");
	});

	$(".date").datepicker({
		changeMonth: true,
		changeYear: true,
		showButtonPanel: true,
		showAnim: "slideDown",
		dateFormat: "mm/dd/yy",
	});

	$("#ServiceStartDate").datepicker({
		changeMonth: true,
		changeYear: true,
		showButtonPanel: true,
		minDate: +1,
		showAnim: "slideDown",
		dateFormat: "dd/mm/yy",
	});

	setupForm = (serviceStart, serviceTime, add1, add2, postalCode, city, serviceid) => {
		$("#ServiceStartDate").val(serviceStart);
		$("#ServiceStartTime").val(serviceTime / 60);
		$("#AddressLine1").val(add1);
		$("#AddressLine2").val(add2);
		$("#PostalCode").val(postalCode);
		$("#City").val(city);
		$("#ServiceId").val(serviceid);
	};

	$("#PostalCode").blur(($event) => {
		var postalcode = $event.target.value;
		$.post("/findCity?postalcode=" + postalcode, (response) => {
			if (response) {
				$("#City").val(response.city);
			} else {
				$("#City").val("");
			}
		});
	});

	$(".popoverTrigger").on("shown.bs.popover", () => {
		$(".cancelrequest").click(($event) => {
			var id = $($event.target).attr("data-id");
			$("#loaderContainer").show();
			$.post("/admin/cancelrequest?id=" + id, (data, status) => {
				$("#loaderContainer").hide();
				$("html").scrollTop(0);
				if (status == "success" && data.result) {
					$(".alert").removeClass("alert-danger");
					$(".alert").addClass("alert-success");
					$(".alert .content").html("Your Service Request Successfully Cancelled");
					$(".alert").fadeIn();
					$(".alert").delay(5000).fadeOut();
					setTimeout(() => {
						location.reload();
					}, 5000);
				} else {
					$(".alert").removeClass("alert-success");
					$(".alert").addClass("alert-danger");
					$(".alert .content").html("We are unable to cancel service request");
					$(".alert").fadeIn();
					$(".alert").delay(5000).fadeOut();
				}
			});
		});
	});

	//Fetch service detail and show into modal
	$("#serviceDetail").on("show.bs.modal", ($event) => {
		$("#serviceDetail .modal-content").load(`/admin/getServiceDetail?serviceid=` + $($event.relatedTarget).attr("data-id"));
	});

	$("#refund").on("show.bs.modal", ($event) => {
		var paid = parseFloat($($event.relatedTarget).attr("data-amount"));
		var refund = parseFloat($($event.relatedTarget).attr("data-refund"));
		var serviceId = $($event.relatedTarget).attr("data-id");
		$(".refundAmountError").hide();
		$("#refundServiceId").val(serviceId);
		refund = refund ? parseFloat(refund) : parseFloat(0.0);
		var inBalanceAmount = paid - refund;
		$(".paidAmount").html(paid.toFixed(2) + " &#8364;");
		$(".refundedAmount").html(refund.toFixed(2) + " &#8364;");
		$(".inBalanceAmount").html(inBalanceAmount.toFixed(2) + " &#8364;");
		$("#refundvalue").val("");
		$("#AmountToRefund").val("");
		if (paid == refund) {
			$("#calculateRefund").addClass("pe-none");
			$("#refundForm button[type='submit']").prop("disabled", true);
		}
	});

	$("#calculateRefund").click(() => {
		var paid = parseFloat($(".paidAmount").html().substring(0, 5));
		var refunded = parseFloat($(".refundedAmount").html().substring(0, 4));
		var inBalanceAmount = parseFloat($(".inBalanceAmount").html().substring(0, 5));

		var refundvalue = parseFloat($("#refundvalue").val());
		refundvalue = refundvalue ? refundvalue : 0;
		var AmountToRefund = 0;
		if ($("#refundOption").val() == "0") {
			AmountToRefund = (inBalanceAmount * refundvalue) / 100;
		} else {
			AmountToRefund = refundvalue;
		}
		console.log(AmountToRefund);
		if (AmountToRefund <= inBalanceAmount) {
			$("#refundForm button[type='submit']").prop("disabled", false);
			$(".refundAmountError").fadeOut();
			$("#AmountToRefund").val(AmountToRefund.toFixed(2));
		} else {
			$("#refundForm button[type='submit']").prop("disabled", true);
			$(".refundAmountError").fadeIn();
		}
	});

	rescheduleAndEditSuccess = (xhr) => {
		$("button.btn-close").click();
		$("html").scrollTop(0);
		if (xhr.result) {
			$(".alert").removeClass("alert-danger");
			$(".alert").addClass("alert-success");
			$(".alert .content").html("Your Service Request Successfully Rescheduled");
			$(".alert").fadeIn();
			$(".alert").delay(5000).fadeOut();

			setTimeout(() => {
				location.reload();
			}, 5000);
		} else {
			$(".alert").removeClass("alert-success");
			$(".alert").addClass("alert-danger");
			$(".alert .content").html(xhr.error);
			$(".alert").fadeIn();
			$(".alert").delay(5000).fadeOut();
		}
	};
	rescheduleAndEditError = (xhr) => {
		$("button.btn-close").click();
		$("html").scrollTop(0);
		$(".alert").addClass("alert-danger");
		$(".alert .content").html(xhr.statusText);
		$(".alert").fadeIn();
		$(".alert").delay(5000).fadeOut();
	};

	refundSuccess = (xhr) => {
		$("button.btn-close").click();
		$("html").scrollTop(0);
		if (xhr.result) {
			$(".alert").removeClass("alert-danger");
			$(".alert").addClass("alert-success");
			$(".alert .content").html("Request for refund is Successfully completed");
			$(".alert").fadeIn();
			$(".alert").delay(5000).fadeOut();

			setTimeout(() => {
				location.reload();
			}, 5000);
		} else {
			$(".alert").removeClass("alert-success");
			$(".alert").addClass("alert-danger");
			$(".alert .content").html(xhr.error);
			$(".alert").fadeIn();
			$(".alert").delay(5000).fadeOut();
		}
	};
	refundError = (xhr) => {
		$("button.btn-close").click();
		$("html").scrollTop(0);
		$(".alert").addClass("alert-danger");
		$(".alert .content").html(xhr.statusText);
		$(".alert").fadeIn();
		$(".alert").delay(5000).fadeOut();
	};
});
