$(document).ready(function () {
    $('#example').DataTable({
        "dom": 'rtipl',
        "ordering": false,
        'pagingType': "full_numbers",
        'responsive': true,
        "language": {
            "paginate": {
                "first": '<img src="./Image/Group 36.png" alt="">',
                "last": '<img src="./Image/Group 36.png" style="transform:rotate(180deg)" alt="">',
              "previous": '<img src="./Image/keyboard-right-arrow-button copy.png" alt="">',
              "next":'<img src="./Image/keyboard-right-arrow-button copy.png" style="transform:rotate(180deg)" alt="">'
            }
        }
    });
    
    var popoverTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="popover"]'))
    var popoverList = popoverTriggerList.map(function (popoverTriggerEl) {
        return new bootstrap.Popover(popoverTriggerEl)
    })

    $('.navbar .hamburger').click(()=>{
        $('.main-nav').toggleClass('open')
        $('body').css("overflow","hidden")
        $('.backblack').toggleClass('open')
        $('.navbar').toggleClass('toggle')
    });
    $('.backblack').click(()=>{
        $('.main-nav').toggleClass('open');
        $('.backblack').toggleClass('open');
        $('.navbar').toggleClass('toggle')
        $('body').css("overflow","visible")
    })
    document.querySelector('.backblack').addEventListener('wheel',(()=>{
        $('.main-nav').removeClass('open');
        $('.backblack').removeClass('open');
        $('.navbar').removeClass('toggle')
        $('body').css("overflow","visible")
    }))
    // document.querySelector('.verticle-menu').style.height=`${document.querySelector('.container-fluid').innerHeight}px`
});