$(document).ready(() => {
	$(".verticle-menu ul li")[1].classList.add("current_section");

	$("#serviceDetail").on("show.bs.modal", ($event) => {
		var postalcode = $($event.relatedTarget).attr("data-PostalCode");
		$("#serviceDetail .modal-content").load(`/sp/getServiceDetail?page=2&serviceid=` + $($event.relatedTarget).attr("data-serviceid"), () => {
			$.ajax({
				url:
					`https://api.mapbox.com/geocoding/v5/mapbox.places/` +
					postalcode +
					`.json?country=de&limit=1&types=postcode&access_token=pk.eyJ1IjoiY2hpbnRhbjgxNjkiLCJhIjoiY2tvZWNiaTdhMDljeDJwbGoxdTV6eW9ocyJ9.ZTVOwDvOJqnfEKpBWgUvbg`,
				success: (result) => {
					var coordinates = result.features[0].geometry.coordinates;
					$(".modal-body>div:last-child").html(
						`<iframe src="http://maps.google.com/maps?q=` +
							coordinates[1] +
							`,` +
							coordinates[0] +
							`&z=16&output=embed" height="100%" width="100%" style="border:0px; min-height:400px;"></iframe>`
					);
				},
			});
		});
	});

	cancelrequest = ($event) => {
		var serviceid = $($event.target).attr("data-id");
		$("#serviceDetail .btn-close").click();
		$.post("/cancelrequest?serviceid=" + serviceid, (data) => {
			if (data.result) {
				$(".alert").removeClass("alert-danger");
				$(".alert").addClass("alert-success");
				$(".alert").html("Request Cancelled Successfuly");
				$(".alert").fadeIn();
				setTimeout(() => {
					location.reload();
					$(".alert").fadeOut();
				}, 3000);
			} else {
				if (data.redirect) {
					window.location.href = data.returnUrl;
				}
				$(".alert").removeClass("alert-success");
				$(".alert").addClass("alert-danger");
				$(".alert").html(data.error);
				$(".alert").fadeIn();
				$(".alert").delay(5000).fadeOut();
			}
		});
	};
	$("button.cancle").click(cancelrequest);

	completerequest = ($event) => {
		var serviceid = $($event.target).attr("data-id");
		$("#serviceDetail .btn-close").click();
		$.post("/completeservice?serviceid=" + serviceid, (data) => {
			if (data.result) {
				$(".alert").removeClass("alert-danger");
				$(".alert").addClass("alert-success");
				$(".alert").html("Service Request Completed");
				$(".alert").fadeIn();
				setTimeout(() => {
					location.reload();
					$(".alert").fadeOut();
				}, 3000);
			} else {
				if (data.redirect) {
					window.location.href = data.returnUrl;
				}
				$(".alert").removeClass("alert-success");
				$(".alert").addClass("alert-danger");
				$(".alert").html(data.error);
				$(".alert").fadeIn();
				$(".alert").delay(5000).fadeOut();
			}
		});
	};
	$("button.complete").click(completerequest);
});
