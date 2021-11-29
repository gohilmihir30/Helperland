$(document).ready(()=>{
    $('.hamburger').click(()=>{
        $('.hamburger').toggleClass('toggle');
        $('.navbar').toggleClass('vertical-navbar');
        $('body').toggleClass('overflow-hidden');
    })
    $('.down').click((e)=>{
        $e=e.target     
        $($e).toggleClass('rotate-0');
        $($e).parent().next().slideToggle(500);
    })
    function current_section(){
        $('#left').toggleClass('current-section');
        $('#right').toggleClass('current-section');
        if($('#left').attr('class') == 'current-section'){
            $('.customer-box').delay(700).fadeToggle(700);
            $('.service-box').fadeToggle(700);
        }else{
            $('.customer-box').fadeToggle(700);
            $('.service-box').delay(700).fadeToggle(700);
        }
    }
    $('#left').click(current_section)
    $('#right').click(current_section)
})