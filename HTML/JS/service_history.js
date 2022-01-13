//Feeding data to data table
var tbody = document.querySelector("tbody");
for (i = 0; i <= 55; i++) {
	if (i % 2 == 0) {
		tbody.innerHTML += `<tr>
            <td>
                <div class="text-nowrap">
                    <img src="./Image/calen 1.png" alt=""> <strong>31/12/2021</strong>
                </div>
                <span>12:00 - 18:00</span>
            </td>
            <td>
                <div class="d-flex">
                    <div class="d-flex align-items-center justify-content-center rounded-circle"><img
                            src="./Image/avtar.png" alt=""></div>
                    <div class="text-nowrap">
                        <p>Lyum Watson</p>
                        <img src="./Image/starFilled.png" alt="">
                        <img src="./Image/starFilled.png" alt="">
                        <img src="./Image/starFilled.png" alt="">
                        <img src="./Image/starFilled.png" alt="">
                        <img src="./Image/starUnfilled.png" alt="">
                        <span>4</span>
                    </div>
                </div>
            </td>
            <td class='text-center'>
                &#8364;<span>${Math.floor(Math.random() * i * 150)}</span>
            </td>
                <td class='text-center'><span class="complete">Completed</span></td>
                <td class='text-center'><button class="rounded-pill text-nowrap">Rate SP</button></td>
            </tr>`;
	} else {
		tbody.innerHTML += `<tr>
            <td>
                <div class="text-nowrap">
                    <img src="./Image/calen 1.png" alt=""> <strong>31/12/2021</strong>
                </div>
                <span>12:00 - 18:00</span>
            </td>
            <td>
                <div class="d-flex">
                    <div class="d-flex align-items-center justify-content-center rounded-circle"><img
                            src="./Image/avtar.png" alt=""></div>
                    <div class="text-nowrap">
                        <p>Lyum Watson</p>
                        <img src="./Image/starFilled.png" alt="">
                        <img src="./Image/starFilled.png" alt="">
                        <img src="./Image/starFilled.png" alt="">
                        <img src="./Image/starFilled.png" alt="">
                        <img src="./Image/starUnfilled.png" alt="">
                        <span>4</span>
                    </div>
                </div>
            </td>
            <td class='text-center'>
                &#8364;<span>${Math.floor(Math.random(500)) * i}</span>
            </td>
                <td class='text-center'><span class="cancelled">Cancelled</span></td>
                <td class='text-center'><button class="rounded-pill text-nowrap">Rate SP</button></td>
            </tr>`;
	}
}

//Datatable Configuration
var table = $("#example").DataTable({
	dom: 'Bt<"table-bottom d-flex justify-content-between align-items-center flex-column flex-md-row"<"table-bottom-inner d-flex flex-column flex-md-row"li>p>',
	pagingType: "full_numbers",
	columnDefs: [{ orderable: false, targets: 4 }],
	buttons: [
		{
			extend: "excel",
			text: "Export",
		},
	],
	language: {
		paginate: {
			first: '<img src="./Image/Group 36.png" alt="">',
			last: '<img src="./Image/Group 36.png" style="transform:rotate(180deg)" alt="">',
			previous: '<img src="./Image/keyboard-right-arrow-button copy.png" alt="">',
			next: '<img src="./Image/keyboard-right-arrow-button copy.png" style="transform:rotate(180deg)" alt="">',
		},
		info: "Total Record: _MAX_",
		lengthMenu: "Show_MENU_Entries",
		emptyTable: "No service History Found",
	},
});

//Data table sorting function
function sort(col, order) {
	table.order([col, order]).draw();
}

// Nav Bar
$(".navbar .hamburger").click(() => {
	$(".main-nav").toggleClass("open");
	$("html").css("overflow", "hidden");
	$(".backblack").toggleClass("open");
	$(".navbar").toggleClass("toggle");
	$(".navbar").css("position", "fixed");
});
$(".backblack").click(() => {
	$(".main-nav").toggleClass("open");
	$(".backblack").toggleClass("open");
	$(".navbar").toggleClass("toggle");
	$(".navbar").css("position", "sticky");
	$("html").css("overflow", "visible");
});
document.querySelector(".backblack").addEventListener("wheel", () => {
	$(".main-nav").removeClass("open");
	$(".backblack").removeClass("open");
	$(".navbar").removeClass("toggle");
	$("html").css("overflow", "visible");
	$(".navbar").css("position", "sticky");
});

//PopOver
var popoverTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="popover"]'));
var popoverList = popoverTriggerList.map(function (popoverTriggerEl) {
	return new bootstrap.Popover(popoverTriggerEl, { sanitize: false });
});
