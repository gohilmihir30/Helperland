$(document).ready(()=>{
    $('.hamburger').click(()=>{

        $('.hamburger').toggleClass('toggle');
        $('.navbar').toggleClass('vertical-navbar');
        $('body').toggleClass('overflow-hideen')
    })
})