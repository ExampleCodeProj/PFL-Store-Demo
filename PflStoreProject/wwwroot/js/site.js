// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


$().ready(function() {

    var list = $('li.deliveryMethods');
    $('.design-information').hide();

 
    $('#item-form').validate({
        rules: {
            quantity: {
                required: true,
                min: function() {
                    return parseInt($('#min').val());
                },
                max: function () {
                    if ($('#max').val() > 0) {
                        return parseInt($('#max').val());
                    } else {
                        return 1000000000
                    }},
                
                step: function () {
                    if ($('step').val() > 1) {
                        return parseInt($('#step').val());
                    } else {
                        return 1;
                    }
                }
            }
        }
    });

    function showMeths() {
        var list = $('li.deliveryMethods');
        list.each(function() {
            var defaultCountry = $('#countrySelector').val();
            var name = $(this).attr('name');
            if (name === defaultCountry) {
                $(this).show();
            } else {
                $(this).hide();
            }
        });
    }
    showMeths();
    $('#countrySelector').change(showMeths);


    

 
    $('input.design-radio').on('click',
        function () {
            $('.design-information').hide();
            $("input:checked").nextAll('div.design-information').show();
            
        }
    );



});
