$(document).ready(()=>{
    $(window).scroll((e)=>{
        if(window.scrollY>10){
            $('.nav').css('background-color', '#646464')
            $('.active').css('background-color', '#29626D')
            $('.nav .logo').css({"width": "73px","height":"54px"})
            
        }else{
            $('.nav').css('background-color', 'transparent')
            $('.active').css('background-color', 'transparent')
            $('.nav .logo').css({'width': '175px','height':'130px'})
        }
    })

    $('.hamburger').click(()=>{
        $('.hamburger').toggleClass('toggle');
        $('.navbar').toggleClass('vertical-navbar');
    })
    $('.dropdown-btn').click(() => {
        $('.drop-list').slideToggle('medium')
    })
})