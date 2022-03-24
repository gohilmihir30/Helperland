$(document).ready(function () {
	// PopOvers
	var popoverTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="popover"]'));
	var popoverList = popoverTriggerList.map(function (popoverTriggerEl) {
		return new bootstrap.Popover(popoverTriggerEl);
	});
	// Data Table
	var table = $("#user").DataTable({
		dom: "t<'d-flex justify-content-between align-items-center'lip>",
		columnDefs: [
			{ orderable: false, targets: [6, 7] },
			{ type: "serviceDate", targets: 1 },
		],
		responsive: true,
		language: {
			paginate: {
				previous: '<img src="/Image/Polygon 1 copy 5.png" alt="">',
				next: '<img src="/Image/Polygon 1 copy 5.png" style="transform:rotate(180deg)" alt="">',
			},
			info: "Total Record: _MAX_",
			lengthMenu: "Show_MENU_Entries",
			emptyTable: "No User Found",
		},
	});

	$("#search").click(() => {
		$.fn.dataTableExt.afnFiltering.length = 0;

		var userName = $("#username").val();
		var userRole = $("#userrole").val();
		var mobile = $("#mobile").val();
		var zipcode = $("#zipcode").val();
		var fromDate = $("#fromdate").val();
		var toDate = $("#todate").val();

		$.fn.dataTable.ext.search.push((settings, data, dataIndex) => {
			var splitDate = data[1].trim().split("/");
			var date = new Date(parseInt(splitDate[2]), parseInt(splitDate[1] - 1), parseInt(splitDate[0]));
			var isUserName = userName ? data[0].includes(userName) : true;
			var isUserRole = userRole ? data[2].includes(userRole) : true;
			var isMobile = mobile ? data[3].includes(mobile) : true;
			var isZipcode = zipcode ? data[4].includes(zipcode) : true;
			var isFromDate = fromDate ? new Date(fromDate) <= date : true;
			var isToDate = toDate ? new Date(toDate) >= date : true;

			return isUserName && isUserRole && isMobile && isZipcode && isFromDate && isToDate;
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
		$(".left ul").toggleClass("open");
		$("body").css("overflow", "hidden");
		$(".backblack").toggleClass("open");
		$(".navbar").toggleClass("toggle");
	});
	$(".backblack").click(() => {
		$(".left ul").toggleClass("open");
		$(".backblack").toggleClass("open");
		$(".navbar").toggleClass("toggle");
		$("body").css("overflow", "visible");
	});
	document.querySelector(".backblack").addEventListener("wheel", () => {
		$(".left ul").removeClass("open");
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

	$(".popoverTrigger").on("shown.bs.popover", ($event) => {
		$(".activation").click(($event) => {
			$("form#activationFrom input[type='hidden']").val($($event.target).attr("id"));
			$("form#activationFrom").submit();
		});
	});

	jQuery.extend(jQuery.fn.dataTableExt.oSort, {
		"serviceDate-pre": function (a) {
			a = a
				.match(/<strong>.*<\/strong>/)[0]
				.replace("<strong>", "")
				.replace("</strong>", "");
			console.log(a);
			let d = a.split("/");
			let day = d[0].length === 1 ? `0${d[0]}` : d[0];
			let month = d[1].length === 1 ? `0${d[1]}` : d[1];
			let year = d[2].length === 1 ? `0${d[2]}` : d[2];
			a = `${month}/${day}/${year}`;
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

	activationSuccess = (xhr) => {
		console.log(xhr);
		if (xhr.result) {
			location.reload();
		} else {
			alert(xhr.error);
		}
	};
	activationError = (xhr) => {
		alert(xhr.statusText);
	};
});
