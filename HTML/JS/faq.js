$(document).ready(()=>{
    $('.hamburger').click(()=>{
        $('.hamburger').toggleClass('toggle');
        $('.navbar').toggleClass('vertical-navbar');
        $('body').toggleClass('overflow-hidden');
    })
    $('.down').click((e)=>{
        $e=e.target     
        $($e).parent().next().addClass('clicked');
        // $($e).parent().next().slideDown(500);
        $('.down').each((i,element) => {
            $element=element;
            if($($element).parent().next().css('display') == 'block'){
                
                $($element).parent().next().slideUp(500)        
                $($element).toggleClass('rotate-0');

            }else if($($element).parent().next().css('display') == 'none' & $($element).parent().next().is('.clicked')){
                
                $($e).parent().next().slideDown(500);
                $($element).toggleClass('rotate-0');

            }
        });
        $($e).parent().next().removeClass('clicked');
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