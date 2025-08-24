// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.
// Write your Javascript code.

/*const { param } = require("jquery");*/

$(document).ready(function () {
    fnCenterDiv();
});

/**
 * ЦЕНТРИРОВАНИЕ ФОРМЫ
 * */
function fnCenterDiv() {
    var marginLeft = parseInt($("#fio").width() - $("#btnFio").width()) / 2;
    console.log($("#btnFio").css("margin-left"));
    console.log("ready!\t" + "\t" + marginLeft + "\t" + $("#fio").width() + "\t" + $("#btnFio").width());
    $("#btnFio").css("margin-left", marginLeft);
    $("#btnFirst").css("margin-left", marginLeft);
    $("#btnSecond").css("margin-left", marginLeft);
    $("#btnThird").css("margin-left", marginLeft);
}

/**
 * ПРОВЕРКА ПИНГА ДЛЯ ДАННОГО АЙПИ ИЛИ УРЛА
 * @param {any} url
 */
async function fnCheckPing(url) {
    const startTime = Date.now();
    try {
        const response = await fetch(url, {
            method: 'GET',
            mode: 'no-cors', // Use 'no-cors' for cross-origin requests where you don't need to read the response content
            cache: 'no-store' // Prevent caching for more accurate timing
        });
        const endTime = Date.now();
        const latency = endTime - startTime;
        console.log(`Successfully reached ${url}. Latency: ${latency}ms`);
        return { success: true, latency: latency };
    } catch (error) {
        const endTime = Date.now();
        const latency = endTime - startTime; // This will be the time until the error occurred
        console.error(`Failed to reach ${url}. Error: ${error.message}. Latency until error: ${latency}ms`);
        return { success: false, error: error, latency: latency };
    }
}

/**
 * ПОИСК ПОЛИСОВ ПО ID ФОРМЫ
 * @param {any} formID
 */
function fnFindPolis(formID) {
    $("#" + formID).submit(function (e) {
        e.preventDefault();
        var formData = new FormData(document.getElementById(e.target.id));

        if (fnValidate(formID)) {
            try {
                var zapros = {
                    FormID: `${formID}`,
                    FAM: formData.get('FAM'),
                    IM: formData.get('IM'),
                    OT: formData.get('OT'),
                    DR: formData.get('DR'),
                    ENP: formData.get('ENP'),
                    NPOL: formData.get('NPOL'),
                    SPOL: formData.get('SPOL')
                }

                $(`#${formID}_result`).removeClass('btn-info');
                $(`#${formID}_result`).html('');
                const modalLoadPolis = document.getElementById('modalLoadPolis');
                const ModalLoadPolis = new bootstrap.Modal(modalLoadPolis);
                ModalLoadPolis.show();
                let checkIP = '192.168.1.200';
                fnCheckPing(`http://${checkIP}`).then(result => {
                    if (result.success) {
                        ModalLoadPolis.hide();
                        $(`#${formID}_result`).addClass('btn-info');
                        //Если вовзращаемый JSON ответ от контроллера не содержит параметра result
                        $(`#${formID}_result`).html(`SUCCEES to ${checkIP}`);
                        console.log(`SUCCEES to ${checkIP}`);
                    }
                    else {
                        ModalLoadPolis.hide();
                        $(`#${formID}_result`).addClass('btn-info');
                        //Если вовзращаемый JSON ответ от контроллера не содержит параметра result
                        $(`#${formID}_result`).html(`FAILED to ${checkIP}`);
                        console.log(`FAILED to ${checkIP}`);
                    }
                });
                //console.log(res);

                    //.then(result => {
                    //    if (result.success) {
                    //        alert('SUCCESS to 192.168.1.200');

                    //        var xhr = new XMLHttpRequest();
                    //        var params = `FormID=${zapros.FormID}&FAM=${zapros.FAM}&IM=${zapros.IM}&OT=${zapros.OT}&DR=${zapros.DR}&ENP=${zapros.ENP}&NPOL=${zapros.NPOL}&SPOL=${zapros.SPOL}`;

                    //        $(`#${formID}_result`).removeClass('btn-info');
                    //        $(`#${formID}_result`).html('');

                    //        const modalLoadPolis = document.getElementById('modalLoadPolis');
                    //        const ModalLoadPolis = new bootstrap.Modal(modalLoadPolis);
                    //        ModalLoadPolis.show();

                    //        //xhr.open('GET', 'http://185.35.130.36:5000/api/polis/getpolis' + params, true);
                    //        //xhr.open('GET', '/api/polis/getpolis2?' + params, true);

                    //        //xhr.open('POST', '/api/polis/getpolis', true);
                    //        xhr.open('POST', 'http://192.168.1.38:50/api/polis/getpolis', true);
                    //        //xhr.open('POST', 'http://185.35.130.36:5000/api/polis/getpolis', true);

                    //        xhr.setRequestHeader("XSRF-TOKEN", $('input:hidden[name="__RequestVerificationToken"]').val());
                    //        xhr.setRequestHeader('Content-type', 'application/json');
                    //        //xhr.setRequestHeader('Content-type', 'multipart/form-data');

                    //        xhr.onreadystatechange = () => {
                    //            ModalLoadPolis.hide();

                    //            setTimeout(() => {
                    //                if (xhr.status == 200 && xhr.readyState == 4) {
                    //                    console.log(`Правильный запрос`);
                    //                    var response = JSON.parse(xhr.responseText);

                    //                    $(`#${formID}_result`).addClass('btn-info');
                    //                    //Если вовзращаемый JSON ответ от контроллера не содержит параметра result
                    //                    $(`#${formID}_result`).html(response);

                    //                    //Если вовзращаемый JSON ответ от контроллера содержит параметра result
                    //                    //$(`#${formID}_result`).html(response.result);
                    //                }
                    //                else
                    //                    console.log(`Неправильный запрос`);

                    //                //if (xhr.readyState == 4 && xhr.status == 200) {
                    //                //    alert(xhr.responseText);
                    //                //}
                    //            }, 500);

                    //        }
                    //        //Для POST запросов
                    //        xhr.send(JSON.stringify(zapros));
                    //        //xhr.send(zapros);

                    //        //Для GET запросов
                    //        //xhr.send(null);
                    //        //return false;

                    //    } else {
                    //        alert('FAILED to 192.168.1.200');
                    //    }
                    //});
            } catch (ex) {
                console.log(ex)
            }
        }
    });
}

/**
 * ВАЛИДАЦИЯ ВВОДИМЫХ СИМВОЛОВ, ТОЛЬКО ЦИФРЫ
 * @param {any} element
 */
function fnInputNumeric(element) {
    element.value = element.value.replace(/[^0-9.]/g, '').replace(/(\..*?)\..*/g, '$1');
    return element.value;
}

function fnValidate(formId) {
    var form = document.getElementById(formId);
    if (form.id === "SearchFio") {
        //label stop;
        if (form.FAM.value === "" || form.IM.value === "" || form.OT.value === "" || form.DR.value === "") {
            alert(`Нужно заполнить фамилию,имя,отчество и дату рождения`);
            if (form.FAM.value === "") {
                form.FAM.focus();
                return false;
            }
            if (form.IM.value === "") {
                form.IM.focus();
                return false;
            }
            if (form.OT.value === "") {
                form.OT.focus();
            }
            if (form.DR.value === "") {
                form.DR.focus();
                return false;
            }

        }
        return (true);
    }

    if (form.id === "SearchFirst") {
        if (form.SPOL.value === "") {
            alert(`Нужно заполнить серию полиса`);
            form.SPOL.focus();
            return false;
        }
        if (form.NPOL.value === "") {
            alert(`Нужно заполнить номер полиса`);
            form.NPOL.focus();
            return false;
        }
        if (form.FAM.value === "" && form.DR.value === "") {
            alert(`Нужно заполнить или фамилию или дату рождения`);
            form.FAM.focus();
            form.DR.focus();
            return false;
        }
        return (true);
    }

    if (form.id === "SearchSecond" || form.id === "SearchThird") {
        if (form.ENP.value === "") {
            alert(`Нужно заполнить номер полиса`);
            form.ENP.focus();
            return false;
        }

        if (form.FAM.value === "" && form.DR.value === "") {
            alert(`Нужно заполнить или фамилию или дату рождения`);
            form.FAM.focus();
            form.DR.focus();
            return false;
        }
        return (true);
    }


}

//function fnChangeSearch(newSearch) {
//    if (newSearch) {
//        document.getElementById("Search").style.display = "block";
//    } else {
//        document.getElementById("Search").style.display = "none";
//    }
//}


/**
 * ФУНКЦИЯ ДЛЯ РЕФРЕШИНГА СТРАНИЦЫ
 * */
function fnRefreshPage() {
    window.location.reload();
}


/**
 * Функция для выведения скрытого текста по нажатию кнопки илии ссылки Подробнее
 * */
function Podrobnee() {
    var persDan = document.getElementById("persdan");
    if (persDan.style.display == "none") {

        persDan.setAttribute("style", "display:show");
    }
    else {
        persDan.setAttribute("style", "display:none");

    }
}

