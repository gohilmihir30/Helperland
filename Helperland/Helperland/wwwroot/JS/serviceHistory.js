$(document).ready(() => {
	$(".verticle-menu ul li")[1].classList.add("current_section");

	//Fetch service detail and show into modal
	$("#serviceDetail").on("show.bs.modal", ($event) => {
		$("#serviceDetail .modal-content").load(`/getServiceDetail?serviceid=` + $($event.relatedTarget).attr("data-serviceid") + `&isHistory=true`);
	});

	$("#serviceRating").on("show.bs.modal", ($event) => {
		$("#ServiceId").val($($event.relatedTarget).attr("data-serviceid"));
		$("#ServiceProviderId").val($($event.relatedTarget).attr("data-spid"));
		$.ajax({
			url: "/servicerating?serviceid=" + $($event.relatedTarget).attr("data-serviceid") + "&spid=" + $($event.relatedTarget).attr("data-spid"),
			success: (data) => {
				$("#serviceRating .spprofile").attr("src", data.profile);
				$("#serviceRating .unfilled")[0].style.setProperty("--rating", data.avgRating);
				$("#serviceRating .spname").html(data.firstName + " " + data.lastName);
				$("#serviceRating .avgrating").html(data.avgRating.toFixed(2));
				console.log();
				if (data.alreadyRated) {
					$("#serviceRating .modal-body .individualrating").html(`<div class="position-relative rating">
						<span class="unfilled position-absolute top-0 end-0" style="--rating:"></span>
						<span class="filled position-relative top-0 start-0"></span>
						</div>`);

					$("#serviceRating .modal-body button").attr("disabled", true);
					$("#serviceDetailLabel").addClass("mb-2");
					var $msgEle = $("<span class='text-danger msg-rating'>You alread Rated this service</spna>").insertAfter("#serviceDetailLabel");
					$($msgEle).delay(8000).fadeOut();
					$("#serviceRating .modal-body .ontimearrival .unfilled")[0].style.setProperty("--rating", data.onTimeArrival);
					$("#serviceRating .modal-body .friendly .unfilled")[0].style.setProperty("--rating", data.friendly);
					$("#serviceRating .modal-body .qos .unfilled")[0].style.setProperty("--rating", data.qualityOfService);
				} else {
					$("#serviceRating .modal-body .individualrating")
						.html(`<img class="ratingstar" data-value=1 src="/Image/starUnfilled.png" alt="star">
						<img class="ratingstar" data-value=2 src="/Image/starUnfilled.png" alt="star">
					<img class="ratingstar" data-value=3 src="/Image/starUnfilled.png" alt="star">
					<img class="ratingstar" data-value=4 src="/Image/starUnfilled.png" alt="star">
					<img class="ratingstar" data-value=5 src="/Image/starUnfilled.png" alt="star">`);

					const individuleRating = [$(".ontimearrival .ratingstar"), $(".friendly .ratingstar"), $(".qos .ratingstar")];
					const inputs = [$("#OnTimeArrival"), $("#Friendly"), $("#QualityOfService")];

					individuleRating.forEach((element, index) => {
						element.mouseover(($event) => {
							$($event.target).attr("src", "/Image/starFilled.png").prevAll().attr("src", "/Image/starFilled.png");
							$(".ratingstar").css("cursor", "pointer");
						});
						element.mouseout(($event) => {
							$($event.target).attr("src", "/Image/starUnfilled.png").prevAll().attr("src", "/Image/starUnfilled.png");
							var prerating = parseInt(inputs[index].val());
							$(".ratingstar").css("cursor", "default");
						});
						element.click(($event) => {
							console.log($event);
							$($event.target).attr("src", "/Image/starFilled.png").nextAll().attr("src", "/Image/starUnfilled.png");
							$($event.target).attr("src", "/Image/starFilled.png").prevAll().attr("src", "/Image/starFilled.png");
							element.unbind("mouseover mouseout");
							inputs[index].val($($event.target).attr("data-value"));
						});
					});
				}
			},
		});
	});
	$("#serviceRating").on("hidden.bs.modal", ($event) => {
		$("#serviceDetailLabel").removeClass("mb-2");
		$("#serviceDetailLabel").next(".msg-rating").remove();

		$("#serviceRating .modal-body button").attr("disabled", false);
	});

	$("#ratingForm button[type='submit']").click(() => {
		var rating = parseFloat($("#OnTimeArrival").val()) + parseFloat($("#Friendly").val()) + parseFloat($("#QualityOfService").val());
		$("#AverageRating").val(rating / 3);
	});

	serviceRatingSuccess = (xhr) => {
		if (xhr.result) {
			$("#serviceDetailLabel").addClass("mb-2");
			var $msgEle = $("<span class='text-success msg-rating'>You Request successfully submited</spna>").insertAfter("#serviceDetailLabel");
			$($msgEle).delay(3000).fadeOut();
			setTimeout(() => {
				location.reload();
			}, 4000);
		} else {
			$("#serviceDetailLabel").addClass("mb-2");
			var $msgEle = $("<span class='text-success msg-rating'>" + xhr.Error + "</spna>").insertAfter("#serviceDetailLabel");
			$($msgEle).delay(8000).fadeOut();
			setTimeout(() => {
				$("#serviceRating button[data-bs-dismiss='modal']").click();
			}, 8000);
		}
	};
	serviceRatingFailure = (xhr) => {
		$("#serviceDetailLabel").addClass("mb-2");
		var $msgEle = $("<span class='text-danger msg-rating'>Somthing went wrong please try after some time</spna>").insertAfter(
			"#serviceDetailLabel"
		);
		$($msgEle).delay(8000).fadeOut();
	};
});
