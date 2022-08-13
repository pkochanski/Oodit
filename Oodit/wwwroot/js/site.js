// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$("#submitButton").on("click", () => {
    $.post({
        url: "Home/CheckArray",
        data: { "inputString": $('#arrayInput').val().slice(1, -1) },
        success: (result) => {
            $('#resultLabel').text("[" + result.list + "]");
        },
        error: (result) => {
            console.log(result);
            $('#resultLabel').text(result.responseJSON.errorMessage);
        },
        contentType:"application/x-www-form-urlencoded; charset=UTF-8"
    })
})