$(document).ready(() => {
	$(".verticle-menu ul li")[0].classList.add("current_section");
	$("#newServiceDate").datepicker({
		changeMonth: true,
		changeYear: true,
		showButtonPanel: true,
		minDate: +1,
		showAnim: "slideDown",
		dateFormat: "dd/mm/yy",
	});
	$("#newServiceDate").datepicker("setDate", new Date());

	//Fetch service detail and show into modal
	$("#serviceDetail").on("show.bs.modal", ($event) => {
		$("#serviceDetail .modal-content")
			.html("Loading Service Details")
			.load(`/getServiceDetail?serviceid=` + $($event.relatedTarget).attr("data-serviceid"));
	});

	//Rescheduel modal
	$("#reschedule").on("show.bs.modal", ($event) => {
		$("#rescheduleServiceId").val($($event.relatedTarget).attr("data-id"));
		$("#serviceTime").val($($event.relatedTarget).attr("data-time"));
		$("#newServiceDate").val($($event.relatedTarget).attr("data-date"));
	});

	rescheduleSuccess = (xhr) => {
		$("#rescheduleError").fadeIn();
		if (xhr.result) {
			location.reload();
		} else {
			$("#rescheduleError").html(xhr.error);
			$("#rescheduleError").delay(8000).fadeOut();
		}
	};

	rescheduleFailure = (xhr) => {
		$("#rescheduleError").html(xhr.statusText);
	};

	$("#cancleRequest").on("show.bs.modal", ($event) => {
		$("#cancelServiceId").val($($event.relatedTarget).attr("data-id"));
	});

	const validator = $("#cancleRequestForm").validate({
		errorClass: "invalid",
		rules: {
			cancleReason: {
				required: true,
			},
		},
		messages: {
			cancleReason: "Reason field is required",
		},
	});

	cancleRequestSuccess = (xhr) => {
		if (xhr.result) {
			location.reload();
		} else {
			$("#cancleRequestError").html(xhr.error);
		}
	};
	cancleRequestFailure = (xhr) => {
		$("#cancleRequestError").html(xhr.statusText);
	};
});
