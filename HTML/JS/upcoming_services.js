$(document).ready(function () {
    $('#example').DataTable({
        "dom": 'rtip',
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
        // $('.navbar  .hamburger').toggleClass('toggle');
        $('.navbar').toggleClass('toggle')
        
    });
    $('.verticle-menu .hamburger').click(()=>{
        $('.verticle-menu').toggleClass('toggle');
    })
    document.querySelector('.verticle-menu').style.height=`${document.querySelector('.container-fluid').innerHeight}px`
});