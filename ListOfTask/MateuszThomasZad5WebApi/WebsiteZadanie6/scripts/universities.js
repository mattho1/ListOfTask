// adres strony
const API_LINK = 'http://localhost:56765/api';
// Wyświetla studentów danej uczelni i wypisuje ich w miejscu wskazanym przez argument place
function SelectUniversityStudents(id, place) {
    $(place).text('');
    var request = $.ajax({
        url: API_LINK + '/Universities' + '/' + id, 
        method: "GET",
        dataType: "json",
        success: function (data) {
            $.each(data.students, function (key, student) {
                $(place).append('<li class="list-group-item">' + formatStudent(student) + '</li>');
                //$('<li>', { text: formatStudent(student) }).appendTo($(place));
            });
        },
        error: function (jqXHR, textStatus, err) {
            $(place).text('Error: ' + err);
        }
    });
}
// Format w jakim będą wyswietlane dane o studencie
function formatStudent(student) {
    return 'ID: ' + student.id + ' ' + student.name + ' ' + student.surname + ' email: ' + student.email + ' phone number: ' + student.phoneNumber + ' index: ' + student.indexNumber;
}
// Obsługa funkcjonalności przycisku ukryj
function CleanField(fieldName) {
    $(fieldName).text('');
}
// Wyświetla dane o uczelni
function showUniversities() {
    $('#universities').text('');
    var request = $.ajax({
        url: API_LINK + '/Universities',
        method: "GET",
        dataType: "json",
        success: function (data) {
            $.each(data, function (key, university) {
                $('<li>', { text: formatUniversity(university) }).appendTo($('#universities'));
            });
        },
        error: function (jqXHR, textStatus, err) {
            $('#universities').text('Error: ' + err);
        }
    });
}
// Format w jakim będą wyswietlane dane o uczelni
function formatUniversity(university) {
    return 'ID: ' + university.id + ' ' + university.name;
}
// Dodanie uczelni do bazy danych
function postUnivesritas() { 
    var universityName = document.getElementById("nameUniversity").value;
    if (universityName != "") {
        var request = $.ajax({
            url: API_LINK + '/Universities',
            method: "POST",
            dataType: "json",
            data: {
                name: universityName
            },
            success: function(data){
                $('<option>', { text: data.id }).appendTo($('#selectUniversity'));
                showModalSuccessInputDataUniversity();
            },
            error: function (jqXHR, textStatus, err) {
                $('#universities').text('Error: ' + err);
            }
        });
    } else {
        showModalErrorInputDataUniversity();
    }
}
// Modyfikacja danych uczelni w bazie danych
function putUnivesritas() {
    var universityName = document.getElementById("nameUniversity").value;
    var id = document.getElementById("idNumberUniversity").value;
    if (universityName != "") {
        var request = $.ajax({
            url: API_LINK + '/Universities/' + id,
            method: "PUT",
            dataType: "json",
            data: {
                name: universityName
            },
            success: function (data) {
                showModalSuccessInputDataUniversity();
            },
            error: function (jqXHR, textStatus, err) {
                $('#universities').text('Error: ' + err);
            }
        });
    } else {
        showModalErrorInputDataUniversity();
    }
}
// Usunięcie uczelni z bazy danych
function deleteUniversitas() {
    var id = $('#selectUniversity').val();
    if (id != "") {
        var request = $.ajax({
            url: API_LINK + '/Universities/' + id,
            method: "DELETE",
            dataType: "json",
            success: showUniversities(),
            error: function (jqXHR, textStatus, err) {
                $('#universities').text('Error: ' + err);
            }
        });
    }
}
// Wyświetlenie komunikatu o nie poprawnym wprowadzeniu danych
function showModalErrorInputDataUniversity() {
    $('#modalErrorInputData').modal({ keyboard: false, backdrop: 'static', show: true })
}
// Wyświetlenie komunikatu o poprawnym wprowadzeniu danych
function showModalSuccessInputDataUniversity() {
    $('#modalSuccessAdd').modal({ keyboard: false, backdrop: 'static', show: true })
}

