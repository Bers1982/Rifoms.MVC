function fnStartSummernote(id) {
    $(`#${id}`).summernote({
        imageAttributes: {
            icon: '<i class="note-icon-pencil"/>',
            figureClass: 'figureClass',
            figcaptionClass: 'captionClass',
            captionText: 'Caption Goes Here.',
            manageAspectRatio: true // true = Lock the Image Width/Height, Default to true
        },
        lang: 'ru-RU',
        popover: {
            image: [
                ['imagesize', ['resizeFull', 'resizeHalf', 'resizeQuarter']],
                ['float', ['floatLeft', 'floatRight', 'floatNone']],
                ['remove', ['removeMedia']],
                ['custom', ['imageAttributes']],
            ],
        },
        placeholder: 'Анонс статьи (необязательно)',
        tabsize: 2,
        height: 120,
        maxwidth: 1000,
        fontNames: ['Arial', 'summernote', 'Comic Sans MS', 'Courier New', 'Helvetica', 'Impact', 'Lucida Grande', 'Tahoma', 'Times New Roman', 'Verdana', 'CustomWebFont'],
        fontSizes: ['11', '12', '13', '14', '15', '16', '17', '18', '19', '20', '21', '22', '23', '24'],
        toolbar: [
            ['style', ['style']],
            ['font', ['bold', 'underline', 'strikethrough', 'clear', 'fontname', 'fontsize']],
            ['color', ['color']],
            ['para', ['ul', 'ol', 'paragraph']],
            ['insertHr', ['hr']],
            ['table', ['table']],
            ['insertLink', ['link', 'unlink']],
            ['insertImage', ['picture']],
            ['insertVideo', ['video']],
            ['insertFile', ['file']],
            ['hist', ['history', 'undo', 'redo']],
            ['view', ['fullscreen', 'codeview', 'help']]
        ]
    });
}