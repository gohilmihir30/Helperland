$(document).ready(function () {
    $('#request').DataTable({
        "dom": 'tlp',
        'columnDefs': [{ 'orderable': false, 'targets': [5] }],
        "language": {
            "paginate": {
                "previous": '<img src="./Image/Polygon 1 copy 5.png" alt="">',
                "next": '<img src="./Image/Polygon 1 copy 5.png" style="transform:rotate(180deg)" alt="">'
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
    $('.btn.trigger').click((e)=>{
        $element=e.target;
        $($element).next().toggleClass('rotate-0')
        $($element).next().next().slideToggle();
    })
    $('div.popover-menu>img').click((e)=>{
        $element=e.target;
        var status= $($element).parent().parent().prev().find("button").text();
        if(status=='Complete'){
            $($element).parent().toggleClass('popover-menu-bg');
            $('.popover-body').html("<a href='#' class='userInfoItem d-block'>Refund</a><a href='#' class='userInfoItem d-block'>Escalate</a><a href='#' class='userInfoItem d-block'>History Log</a><a href='#' class='userInfoItem d-block'>Donload Invoice</a>")
        }else if(status=='Pendding'){
            $($element).parent().toggleClass('popover-menu-bg');
            $('.popover-body').html("<a href='#' class='userInfoItem d-block'>Edit & Reschrdule</a><a href='#' class='userInfoItem d-block'>Refund</a><a href='#' class='userInfoItem d-block'>Calcle</a><a href='#' class='userInfoItem d-block'>Change SP</a> <a href='#' class='userInfoItem d-block'>Escalate</a><a href='#' class='userInfoItem d-block'>History Log</a><a href='#' class='userInfoItem d-block'>Download Invoicd</a>")
        }
        else{
            $('.popover').css("display","none")
        }
    })
    $('.navbar .hamburger').click(()=>{
        $('.left ul').toggleClass('open')
        $('body').css("overflow","hidden")
        $('.backblack').toggleClass('open')
        $('.navbar').toggleClass('toggle')
    });
    $('.backblack').click(()=>{
        $('.left ul').toggleClass('open');
        $('.backblack').toggleClass('open');
        $('.navbar').toggleClass('toggle')
        $('body').css("overflow","visible")
    })
    document.querySelector('.backblack').addEventListener('wheel',(()=>{
        $('.left ul').removeClass('open');
        $('.backblack').removeClass('open');
        $('.navbar').removeClass('toggle')
        $('body').css("overflow","visible")
    }))
});