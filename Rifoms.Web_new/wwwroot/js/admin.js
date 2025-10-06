/*
 * Функция для Загрузки формы для администрирования сайта по ID формы
 */
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
        fontSizes: ['12', '13', '14', '15','16', '17', '18', '19', '20', '21', '22', '23', '24'],
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

/*
 * Функция для адпдейта времени
 */
function fnUpdateClock() {
    const now = new Date();
    const hours = String(now.getHours()).padStart(2, '0');
    const minutes = String(now.getMinutes()).padStart(2, '0');
    const seconds = String(now.getSeconds()).padStart(2, '0');
    const timeString = `${hours}:${minutes}:${seconds}`;

    document.getElementById("currentTime").innerHTML = `<img src="/images/web/clock-3d.png"/>${timeString}`;
}

/*
 * Функция для адпдейта даты 
 */
function fnUpdateDate() {
    const months = [
        "января", "февраля", "марта", "апреля", "мая", "июня", "июля",
        "августа", "сентября", "октября", "ноября", "декабря"
    ];
    const today = new Date();
    const month = today.getMonth();
    const day = today.getDate().toString().padStart(2, "0");
    const currentDate = document.getElementById("currentDate");
    currentDate.innerHTML = currentDate.innerHTML + ` ${day} ${months[month]}`;
}

$(document).ready(function () {
    fnUpdateDate();
    fnUpdateClock();
    setInterval(fnUpdateClock, 1000);
});

