$(document).ready(()=>{
    $(window).scroll((e)=>{
        if(window.scrollY>10){
            $('.nav').css('background-color', '#646464')
            $('.active').css('background-color', '#29626D')
            $('.logo').css({"width": "73px","height":"54px"})
            
        }else{
            $('.nav').css('background-color', 'transparent')
            $('.active').css('background-color', 'transparent')
            $('.logo').css({'width': '175px','height':'130px'})
        }
    })

    $('.hamburger').click(()=>{
        $('.hamburger').toggleClass('toggle');
        $('.navbar').toggleClass('vertical-navbar');
    })
    $(window).scroll(() => {
        if (window.scrollY < 132) {
            $('.scroll-top').fadeOut('fast');
        }
        else {
            $('.scroll-top').fadeIn('fast');
        }
    })
    $('.scroll-top').click(() => {
        $(window).scrollTop(0, 0)
    })
    $('#policy_btn').click(() => {
        $('.footer-policy').fadeOut('fast');
    })
    $('.dropdown-btn').click(() => {
        $('.drop-list').slideToggle('slow')
    })
    window.addEventListener('load',()=>{
        if (window.outerWidth < 678) {
            document.querySelectorAll('.arrow').forEach(arr=>{
                arr.style.display='none'
            });  
        }else{
            document.querySelectorAll('.arrow').forEach(arr=>{
                arr.style.display='inline-block'
            });
        }
    })
    window.addEventListener('resize',()=>{
        if (window.outerWidth < 678) {
            document.querySelectorAll('.arrow').forEach(arr=>{
                arr.style.display='none'
            });   
        }else{
            document.querySelectorAll('.arrow').forEach(arr=>{
                arr.style.display='inline-block'
            });
        }
    })
})
