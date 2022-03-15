$(document).ready(() => {
	$(".verticle-menu ul li")[0].classList.add("current_section");
	// $(".verticle-menu").addClass("col-2");
	$("#serviceDetail").on("show.bs.modal", ($event) => {
		var postalcode = $($event.relatedTarget).attr("data-PostalCode");
		$("#serviceDetail .modal-content")
			.html("Loading Service Details")
			.load(`/sp/getServiceDetail?page=1&serviceid=` + $($event.relatedTarget).attr("data-serviceid"), () => {
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

	acceptservice = ($event) => {
		$target = $event.target;
		var serviceid = $($target).attr("data-id");
		var record = $($target).attr("data-record");
		$.post("/acceptservice?serviceid=" + serviceid + "&record=" + record, (data) => {
			$("#serviceDetail .btn-close").click();
			if (data.result) {
				$(".alert").removeClass("alert-danger");
				$(".alert").addClass("alert-success");
				$(".alert").html("Request Accepted Successfuly");
				$(".alert").fadeIn();
				setTimeout(() => {
					location.reload();
					$(".alert").fadeOut();
				}, 3000);
			} else {
				$(".alert").removeClass("alert-success");
				$(".alert").addClass("alert-danger");
				$(".alert").html(data.error);
				$(".alert").fadeIn();
				$(".alert").delay(5000).fadeOut();
			}
		});
	};
	$(".acceptservice").click(acceptservice);

	$("#conflictservice").on("show.bs.modal", ($event) => {
		$($event.relatedTarget).attr("data-id");
		$.post("/conflictservice?serviceid=" + $($event.relatedTarget).attr("data-id"), (data) => {
			$("#conflictservice .conflictserviceid").css("display", "block");
			$("#conflictservice .conflictservicetime").css("display", "block");
			$("#conflictservice .errormsg").css("display", "none");
			console.log(data);
			if (data.result) {
				console.log(data.serviceid);
				$("#conflictservice .modal-body").removeClass("my-5");
				$("#conflictservice .modal-body").addClass("mb-3");
				$("#conflictservice .conflictserviceid>span").html(data.serviceid);
				var servicetime =
					data.servicestartDate.replaceAll("-", "/") +
					"  " +
					data.servicestarttime.replace("-", ":") +
					" - " +
					data.serviceendtime.replace("-", ":");
				console.log(servicetime);
				$("#conflictservice .conflictservicetime>span").html(servicetime);
			} else {
				$("#conflictservice .errormsg").css("display", "block");
				$("#conflictservice .modal-body").removeClass("mb-3");
				$("#conflictservice .modal-body").addClass("my-5");
				$("#conflictservice .conflictserviceid").css("display", "none");
				$("#conflictservice .conflictservicetime").css("display", "none");
				$("#conflictservice .errormsg").html(data.error);
			}
		});
	});
});
