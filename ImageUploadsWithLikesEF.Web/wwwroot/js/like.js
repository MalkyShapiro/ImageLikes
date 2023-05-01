
$(() => {
    const id = $("#image-id").val();
    $("#like-button").on('click', function () {
        $.post('/home/likes', { id }, function () {
        });
        $("#like-button").prop('disabled', true)
    });

    setInterval(() => {
        $.get('/home/viewimage', { id }, image => {
            $("#likes-count").text(image.likes);
        })
    }, 1000);

});