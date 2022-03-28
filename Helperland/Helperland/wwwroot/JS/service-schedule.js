$(document).ready(() => {
	$(".verticle-menu ul li")[2].classList.add("current_section");
	var eventobj = [];
	$.post("/servieScheduleData", (data, status) => {
		data = JSON.parse(data);
		data.forEach((item) => {
			var temp = new Object();
			temp.title = item.ServiceStartTime + " - " + item.ServiceEndTime;
			temp.start = item.ServiceDate;
			temp.color = item.color;
			temp.id = item.ServiceId;
			temp.postalcode = item.Zipcode;
			eventobj.push(temp);
		});
		$("#Calender").fullCalendar({
			header: {
				left: "prev,next title",
				right: "",
			},
			viewRender: function (view) {
				$("#Calender").fullCalendar("removeEvents");
				$("#Calender").fullCalendar("addEventSource", eventobj);
			},
			eventRender: function (event, element) {
				element.attr("data-bs-toggle", "modal");
				element.attr("data-bs-target", "#ServiceDetail");
				element.attr("data-id", event.id);
				element.attr("data-PostalCode", event.postalcode);
			},
		});
		$(".fc-right").append(`<div class="d-flex">
        <div class="position-relative completed"> Completed</div>
        <div class="position-relative">Upcoming</div>
    </div> `);
	});

	$("#ServiceDetail").on("show.bs.modal", ($event) => {
		var postalcode = $($event.relatedTarget).attr("data-PostalCode");
		$("#ServiceDetail .modal-content").load(`/sp/getServiceDetail?page=0&serviceid=` + $($event.relatedTarget).attr("data-id"), () => {
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
});
