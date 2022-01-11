$(document).ready(() => {
    $(window).scroll((e) => {
        if (window.scrollY > 10) {
            $('.navbar').css('background-color', '#646464')
            $('.navbar .logo').css({ "width": "73px", "height": "54px" })
            $('.active').addClass('hover')
        }
        else {
            $('.navbar').css('background-color', 'transparent')
            $('.navbar .logo').css({ 'width': '175px', 'height': '130px' })
            $('.active').removeClass('hover')
        }
    })

    $('.navbar .hamburger').click(() => {
        $('.nav').toggleClass('open')
        $('html').css("overflow", "hidden")
        $('.backblack').toggleClass('open')
        $('.hamburger').toggleClass('toggle')
    });
    $('.backblack').click(() => {
        $('.nav').toggleClass('open');
        $('.backblack').toggleClass('open');
        $('.hamburger').toggleClass('toggle')
        $('html').css("overflow", "visible")
    })
    document.querySelector('.backblack').addEventListener('wheel', (() => {
        $('.nav').removeClass('open');
        $('.backblack').removeClass('open');
        $('.hamburger').removeClass('toggle')
        $('html').css("overflow", "visible")
    }))

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
        $('.drop-list').slideToggle('medium')
    })

    var popoverTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="popover"]'))
    var popoverList = popoverTriggerList.map(function (popoverTriggerEl) {
        return new bootstrap.Popover(popoverTriggerEl, { sanitize: false })
    })

    const urlParams = new URLSearchParams(window.location.search);
    var myModal = new bootstrap.Modal(document.getElementById('loginModalToggle'));
    window.addEventListener('load', () => {

        if (urlParams.get('modalRequest') === 'true') {
            myModal.show();
            if (window.history.pushState) {
                const newURL = new URL(window.location.href);
                newURL.search = '';
                window.history.pushState({ path: newURL.href }, '', newURL.href);
            }
        }

        if (screen.availWidth < 767) {
            document.querySelectorAll('.arrow').forEach(arr => {
                arr.style.display = 'none'
            });
        } else {
            document.querySelectorAll('.arrow').forEach(arr => {
                arr.style.display = 'inline-block'
            });
        }
    })
    window.addEventListener('resize', () => {
        if (screen.availWidth < 767) {
            document.querySelectorAll('.arrow').forEach(arr => {
                arr.style.display = 'none'
            });
        } else {
            document.querySelectorAll('.arrow').forEach(arr => {
                arr.style.display = 'inline-block'
            });
        }
    })
})
