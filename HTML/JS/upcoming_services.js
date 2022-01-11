var tbody = document.querySelector('tbody');
for (i = 0; i <= 55; i++) {
    tbody.innerHTML += `<tr>
        <td>${Math.floor(Math.random() * 3000 * i)}</td>
        <td>
            <div class="d-flex align-items-center"> <img src="./Image/calculator.png" alt="">
                <strong>09/08/2021</strong>
            </div>
            <div class="d-flex align-items-center"> <img src="./Image/Layer 712.png" alt=""><span>12:00
                    - 18:00</span> </div>
        </td>
        <td>
            <span>David Bough</span>
            <div class="d-flex align-item-center"><img src="./Image/Layer 719.png" alt="">
                <span>Musterstrabe 5,12345 Bonn</span>
            </div>
        </td>
        <td class="text-center">${Math.floor(Math.random() * i * 10)} km</td>
        <td class="text-center"><button>Cancel</button></td>
    </tr>`;
}
$(document).ready(function () {

    jQuery.extend(jQuery.fn.dataTableExt.oSort, {
        "kmNum-pre": function (a) {
            a = a.replace(" km", "");
            return parseInt(a);
        },
        "kmNum-asc": function (a, b) {
            return a - b;
        },
        "kmNum-desc": function (a, b) {
            return b - a;
        },
    });
    var table = $('#example').DataTable({
        "dom": 't<"table-bottom d-flex justify-content-between align-items-center flex-column flex-md-row"<"table-bottom-inner d-flex flex-column flex-md-row"li>p>',
        "ordering": true,
        'columnDefs': [{ 'orderable': false, 'targets': 4 },
        { type: 'kmNum', targets: 3 }
        ],
        'pagingType': "full_numbers",
        'responsive': true,
        "language": {
            "paginate": {
                "first": '<img src="./Image/Group 36.png" alt="">',
                "last": '<img src="./Image/Group 36.png" style="transform:rotate(180deg)" alt="">',
                "previous": '<img src="./Image/keyboard-right-arrow-button copy.png" alt="">',
                "next": '<img src="./Image/keyboard-right-arrow-button copy.png" style="transform:rotate(180deg)" alt="">'
            },
            'info': "Total Record: _MAX_",
            'lengthMenu': "Show_MENU_Entries",
            "emptyTable": "No service History Found"
        }
    });

    $('.navbar .hamburger').click(() => {
        $('.main-nav').toggleClass('open')
        $('html').css("overflow", "hidden")
        $('.backblack').toggleClass('open')
        $('.navbar').toggleClass('toggle')
        $('.navbar').css('position', 'fixed')
    });
    $('.backblack').click(() => {
        $('.main-nav').toggleClass('open');
        $('.backblack').toggleClass('open');
        $('.navbar').toggleClass('toggle')
        $('.navbar').css('position', 'sticky')
        $('html').css("overflow", "visible")
    })
    document.querySelector('.backblack').addEventListener('wheel', (() => {
        $('.main-nav').removeClass('open');
        $('.backblack').removeClass('open');
        $('.navbar').removeClass('toggle')
        $('html').css("overflow", "visible")
        $('.navbar').css('position', 'sticky')
    }))

    var popoverTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="popover"]'))
    var popoverList = popoverTriggerList.map(function (popoverTriggerEl) {
        return new bootstrap.Popover(popoverTriggerEl, { sanitize: false })
    })

    document.querySelector('#sortData').addEventListener('click', () => {
        document.querySelectorAll('.form-check-input').forEach(element => {
            element.addEventListener('click', () => {
                table.order([element.getAttribute('data-dt-col'), element.getAttribute('data-dt-sort')]).draw()
            });
        })
    })
});
