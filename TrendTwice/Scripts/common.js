$(document).ready(function () {

//    $("#file-1").fileinput();

    // with plugin options
    $("#file-1").fileinput({ 'showUpload': false, 'previewFileType': 'any' });

    $('#fine-uploader-manual-trigger').fineUploader({
        template: 'qq-template-manual-trigger',
        request: {
            endpoint: '/Dress'
        },
        thumbnails: {
            placeholders: {
                waitingPath: '/source/placeholders/waiting-generic.png',
                notAvailablePath: '/source/placeholders/not_available-generic.png'
            }
        },
        autoUpload: false
    }).on('error', function (event, id, name, reason) {
        // do something
    }).on('complete', function (event, id, name, responseJSON) {
       // alert(responseJSON);
    });

        $('#trigger-upload').click(function() {
            $('#fine-uploader-manual-trigger').fineUploader('uploadStoredFiles');
        });


});