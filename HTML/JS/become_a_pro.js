$(document).ready(()=>{
    $(window).scroll((e)=>{
        if(window.scrollY>10){
            $('.navbar').css('background-color', '#646464')
            $('.navbar .logo').css({"width": "73px","height":"54px"})
            $('.active').addClass('hover')   
        }
        else{
            $('.navbar').css('background-color', 'transparent')
            $('.navbar .logo').css({'width': '175px','height':'130px'})
            $('.active').removeClass('hover')   
        }
    })

    $('.navbar .hamburger').click(()=>{
        $('.nav').toggleClass('open')
        $('html').css("overflow","hidden")
        $('.backblack').toggleClass('open')
        $('.hamburger').toggleClass('toggle')
    });
    $('.backblack').click(()=>{
        $('.nav').toggleClass('open');
        $('.backblack').toggleClass('open');
        $('.hamburger').toggleClass('toggle')
        $('html').css("overflow","visible")
    })
    document.querySelector('.backblack').addEventListener('wheel',(()=>{
        $('.nav').removeClass('open');
        $('.backblack').removeClass('open');
        $('.hamburger').removeClass('toggle')
        $('html').css("overflow","visible")
    }))

    var popoverTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="popover"]'))
    var popoverList = popoverTriggerList.map(function (popoverTriggerEl) {
        return new bootstrap.Popover(popoverTriggerEl, { sanitize: false })
    })
})