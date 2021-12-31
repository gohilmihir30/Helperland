$(document).ready(function () {
    $('#example').DataTable({
        "dom": 'Bt<"table-bottom d-flex justify-content-between"<"table-bottom-inner d-flex"li>p>',
        'pagingType': "full_numbers",
        'columnDefs': [{ 'orderable': false, 'targets': 4 }],
        'responsive': true,
        'buttons': [{
            extend:'excel',
            text:'Export'
        }],
        "language": {
            "paginate": {
                "first": '<img src="./Image/Group 36.png" alt="">',
                "last": '<img src="./Image/Group 36.png" style="transform:rotate(180deg)" alt="">',
              "previous": '<img src="./Image/keyboard-right-arrow-button copy.png" alt="">',
              "next":'<img src="./Image/keyboard-right-arrow-button copy.png" style="transform:rotate(180deg)" alt="">'
            },
            'info': "Total Record: _MAX_",
            'lengthMenu': "Show_MENU_Entries",
            "emptyTable": "No service History Found"
        }
    });
    
    var popoverTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="popover"]'))
    var popoverList = popoverTriggerList.map(function (popoverTriggerEl) {
        return new bootstrap.Popover(popoverTriggerEl)
    })

    $('.navbar .hamburger').click(()=>{
        $('.navbar').toggleClass('toggle')
        
    });
    $('.verticle-menu .hamburger').click(()=>{
        $('.verticle-menu').toggleClass('toggle');
    })
    // document.querySelector('.verticle-menu').style.height=`${document.querySelector('.container-fluid').innerHeight}px`
});