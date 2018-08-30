﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


$(function() {


    var list = $('li.deliveryMethods');

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

});
