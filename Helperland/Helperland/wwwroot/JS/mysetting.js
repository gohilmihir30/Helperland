$(document).ready(() => {
	var date = [$("#Day"), $("#Month"), $("#Year")];
	var dateOfBirth;
	var isdobValid = true;
	date.forEach(($element) => {
		$($element).change(() => {
			dateOfBirth = $("#Month").val() + "/" + $("#Day").val() + "/" + $("#Year").val();
			var date = new Date(dateOfBirth);
			console.log(date);
			if (new Date().getTime() - date.getTime() < 18 * 365 * 24 * 60 * 60 * 1000) {
				$("#dateerror").html("Age Must Be greater than 18 !");
			} else if (date.getMonth() == $("#Month").val() - 1 && date.getFullYear() == $("#Year").val()) {
				$("#dateerror").html("");
				return (isdobValid = true);
			} else {
				$("#dateerror").html("Please Enter valid Date of Birth!");
			}
			return (isdobValid = false);
		});
	});

	$("#address-tab").click(() => {
		$(".address-container").html("").load("/customeraddress");
	});

	$("#mydetail button[type='submit']").click((event) => {
		if (!isdobValid) {
			event.preventDefault();
		}
	});

	$("#addressModal").on("show.bs.modal", ($event) => {
		$("#addressForm").trigger("reset");
		var target = $($event.relatedTarget).attr("data-target");
		$("#addressForm").trigger("reset");
		if (target == "add") {
			$("#modalheader").html("Add New Address");
			$("#addressForm").attr("data-ajax-url", "/customeraddress?todo=new");
		} else if (target == "edit") {
			$("#modalheader").html("Edit Address");
			$("#address_AddressId").val($($event.relatedTarget).attr("data-addid"));
			$("#address_AddressLine1").val($($event.relatedTarget).attr("data-add1"));
			$("#address_AddressLine2").val($($event.relatedTarget).attr("data-add2"));
			$("#address_PostalCode").val($($event.relatedTarget).attr("data-post"));
			$("#address_City").val($($event.relatedTarget).attr("data-city"));
			$("#address_Mobile").val($($event.relatedTarget).attr("data-mobile"));
			$("#addressForm").attr("data-ajax-url", "/customeraddress?todo=edit");
		}
	});

	$("#deleteAddressModal").on("show.bs.modal", ($event) => {
		$("#deleteAddressModal input[name='addressid']").val($($event.relatedTarget).attr("data-addid"));
	});

	$("#address_PostalCode").blur(($event) => {
		var postalcode = $event.target.value;
		$.post("/findCity?postalcode=" + postalcode, (response) => {
			if (response) {
				$("#address_City").val(response.city);
			} else {
				$("#address_City").val("");
			}
		});
	});

	myDetailSuccess = (xhr) => {
		if (xhr) {
			$("#details .alert").addClass("alert-success");
			$("#details .alert .content").html("Your Data Updated Successfully");
			$("#details .alert").fadeIn();
			$("#details .alert").delay(8000).fadeOut();
		} else {
			$("#details .alert").addClass("alert-danger");
			$("#details .alert .content").html(xhr.statusText);
			$("#details .alert").fadeIn();
			$("#details .alert").delay(8000).fadeOut();
		}
	};
	myDetailError = (xhr) => {
		$("#details .alert").addClass("alert-danger");
		$("#details .alert .content").html(xhr.statusText);
		$("#details .alert").delay(5000).fadeOut();
	};

	changePasswordSuccess = (xhr) => {
		console.log(xhr);
		if (xhr.result) {
			console.log("if");
			$("#changePassword .alert").addClass("alert-success");
			$("#changePassword .alert .content").html("Your Password changed Successfully");
			$("#changePassword .alert").fadeIn();
			$("#changePassword .alert").delay(5000).fadeOut();
			$("#changePassword").trigger("reset");
		} else {
			console.log("else");
			$("#changePassword .alert").addClass("alert-danger");
			$("#changePassword .alert .content").html(xhr.error);
			$("#changePassword .alert").fadeIn();
			$("#changePassword .alert").delay(5000).fadeOut();
		}
	};
	changePasswordError = (xhr) => {
		$("#changePassword .alert").addClass("alert-danger");
		$("#changePassword .alert .content").html(xhr.statusText);
		$("#changePassword .alert").fadeIn();
		$("#changePassword .alert").delay(5000).fadeOut();
	};

	customerAddressSuccess = (xhr) => {
		$("#addressModal button.btn-close").click();
		if (xhr.result) {
			$("#address .alert").addClass("alert-success");
			$("#address .alert .content").html("Your Request completed Successfully");
			$("#address .alert").fadeIn();
			$("#address .alert").delay(5000).fadeOut();
			$(".address-container").html("").load("/customeraddress");
		} else {
			$("#address .alert").addClass("alert-danger");
			$("#address .alert .content").html("Somthing went wrong please try after some time");
			$("#address .alert").fadeIn();
			$("#address .alert").delay(5000).fadeOut();
		}
	};

	customerAddressError = (xhr) => {
		$("#addressModal button.btn-close").click();
		$("#address .alert").addClass("alert-danger");
		$("#address .alert .content").html(xhr.statusText);
		$("#address .alert").fadeIn();
		$("#address .alert").delay(5000).fadeOut();
	};

	deleteAddressSuccess = (xhr) => {
		$("#deleteAddressModal button.btn-close").click();
		if (xhr.result) {
			$("#address .alert").addClass("alert-success");
			$("#address .alert .content").html("Your Address deleted Successfully");
			$("#address .alert").fadeIn();
			$("#address .alert").delay(5000).fadeOut();
			$(".address-container").html("").load("/customeraddress");
		} else {
			$("#address .alert").addClass("alert-danger");
			$("#address .alert .content").html("Somthing went wrong please try after some time");
			$("#address .alert").fadeIn();
			$("#address .alert").delay(5000).fadeOut();
		}
	};

	deleteAddressError = (xhr) => {
		$("#deleteAddressModal button.btn-close").click();
		$("#address .alert").addClass("alert-danger");
		$("#address .alert .content").html(xhr.statusText);
		$("#address .alert").fadeIn();
		$("#address .alert").delay(5000).fadeOut();
	};
});
