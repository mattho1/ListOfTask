// Pobranie listy studentów z bazy danych i wypisanie ich w polu result
function GetStudentList() {
    $('#result').text('');
    var request = $.ajax({
        url: API_LINK + '/students',
        method: "GET",
        dataType: "json",
        success: function (data) {
            $.each(data, function (key, student) {
                $('<li>', { text: formatStudent(student) }).appendTo($('#result'));
            });
        }
    });
}
// Format w jakim będą wyświetlane dane o studnecie. Pełny
function formatStudent(student) {
    return 'ID: ' + student.id + ' ' + student.name + ' ' + student.surname + ' email: ' + student.email + ' phone number: ' + student.phoneNumber + ' index: ' + student.indexNumber;
}
// Pobranie listy studentów z bazy danych i wypisanie skróconej informacji o studencie w miejscu wskazanym przez argument funkcji
function GetStudentListSmallInformation(place) {
    $(place).text('');
    var request = $.ajax({
        url: API_LINK + '/students', 
        method: "GET",
        dataType: "json",
        success: function (data) {
            $.each(data, function (key, student) {
                $(place).append('<li class="list-group-item">' + formatStudent(student) + '</li>');
            });
        }
    }); 
}
// Format w jakim będą wyświetlane dane o studencie. Skrócony 
function formatStudentSmallInformation(student) {
    return 'ID: ' + student.id + ' ' + student.name + ' ' + student.surname + ' University ID: ' + student.universityID;
}
// Dodanie studenta do bazy danych
function postStudent() {
    var studentName = document.getElementById("studentName").value;
    var studentSurname = document.getElementById("studentSurname").value;
    var studentEmail = document.getElementById("studentEmail").value;
    var studentPhoneNumber = document.getElementById("studentPhoneNumber").value;
    var studentIndexNumber = document.getElementById("studentIndexNumber").value;
    var studentUniversityID = document.getElementById("studentUniversityID").value;
    if (studentName != "" && studentSurname != "" && studentEmail != ""
        && studentPhoneNumber != "" && studentIndexNumber != "" && studentUniversityID != "") {
        var request = $.ajax({
            url: API_LINK + '/Students',
            method: "POST",
            dataType: "json",
            data: {  
                name: studentName,
                surname: studentSurname,
                email: studentEmail,
                phoneNumber: studentPhoneNumber,
                indexNumber: studentIndexNumber,
                universityID: studentUniversityID
            },
            success: function (data) {
                loadStudents('#selectStudentModifyOrRemove');
                showModalSuccessInputData();
                CleanFormAdd();
                CleanField('#studentsListModify');
            }
        });
    } else {
        showModalErrorInputData();
    }
}
// Załadowanie listy studentów do listy rozwijanej
function loadStudents(place) {    
    $(place).text('');
    var request = $.ajax({
        url: API_LINK + '/students',
        method: "GET",
        dataType: "json",
        success: function (data) {
            $.each(data, function (key, student) {
                $(place).append('<option>' + student.id + '</option>');
            });
        }
    });
}
// Załadowanie danych studenta do formularza Modyfikacji i usuwania studentów
function loadStudent() {
    var id = document.getElementById("selectStudentModifyOrRemove").value;
    var request = $.ajax({
        url: API_LINK + '/Students' + '/' + id,
        method: "GET",
        dataType: "json",
        success: function (data) {
            studentIDModify.value = data.id;
            studentNameModify.value = data.name;
            studentSurnameModify.value = data.surname;
            studentEmailModify.value = data.email;
            studentPhoneNumberModify.value = data.phoneNumber;
            studentIndexNumberModify.value = data.indexNumber;
            studentUniversityIDModify.value = data.universityID;
        }
    });
}
// Zmodyfikowanie danych studenta o wybranym numerze ID
function putStudent() {
    var studentName = document.getElementById("studentNameModify").value;
    var studentSurname = document.getElementById("studentSurnameModify").value;
    var studentEmail = document.getElementById("studentEmailModify").value;
    var studentPhoneNumber = document.getElementById("studentPhoneNumberModify").value;
    var studentIndexNumber = document.getElementById("studentIndexNumberModify").value;
    var studentUniversityID = document.getElementById("studentUniversityIDModify").value;
    var id = document.getElementById("studentIDModify").value;
    if (studentName != "" && studentSurname != "" && studentEmail != ""
        && studentPhoneNumber != "" && studentIndexNumber != "" && studentUniversityID != "" && studentIDModify != "") {
        var request = $.ajax({
            url: API_LINK + '/Students/' + id,
            method: "PUT",
            dataType: "json",
            data: {
                name: studentName, 
                surname: studentSurname,
                email: studentEmail,
                phoneNumber: studentPhoneNumber,
                indexNumber: studentIndexNumber,
                universityID: studentUniversityID
            },
            success: function (data) {
                CleanField('#studentsListModify');
                CleanFormModify();
                showModalSuccessInputData();
            }
        });
    } else {
        showModalErrorInputData();
    }
}
// Usunięcie studenta o podanym numerze ID
function deleteStudent() {
    var id = $('#studentIDModify').val();
    if (id != "") {
        var request = $.ajax({
            url: API_LINK + '/Students/' + id,
            method: "DELETE",
            dataType: "json",
            success: function (data) {
                CleanField('#studentsListModify');
                loadStudents('#selectStudentModifyOrRemove');
                CleanFormModify();
                showModalSuccessInputData();
            }
        });
    } else {
        showModalErrorInputData();
    }
}
// Usuniecie tekstu z formularza usuwania i modyfikacji studenta
function CleanFormModify() {
    studentIDModify.value = "";
    studentNameModify.value = "";
    studentSurnameModify.value = "";
    studentEmailModify.value = "";
    studentPhoneNumberModify.value = "";
    studentIndexNumberModify.value = "";
    studentUniversityIDModify.value = "";
}
// Usuniecie tekstu z formularza dodawania studenta
function CleanFormAdd() {
    studentName.value = "";
    studentSurname.value = "";
    studentEmail.value = "";
    studentPhoneNumber.value = "";
    studentIndexNumber.value = "";
    studentUniversityID.value = "";
}
// Załadowanie danych studenta o wybranym w liscie rozwijanej numerze ID do formularza
function LoadDataStudentAndStudentTasks() {
    var id = document.getElementById("selectStudentShowTask").value;
    var request = $.ajax({
        url: API_LINK + '/Students' + '/' + id,
        method: "GET",
        dataType: "json",
        success: function (data) {
            studentNameShow.value = data.name;
            studentSurnameShow.value = data.surname;
            studentEmailShow.value = data.email;
            studentPhoneNumberShow.value = data.phoneNumber;
            studentIndexNumberShow.value = data.indexNumber;
            idNumberUniversityStudentShow.value = data.universityID;
            GetStudentTasksList('#tasksStudentList');
        }
    });
}
// Format w jakim bedzie wyświetlane zadanie
function FormatTask(task) {
    return 'ID: ' + task.id + ' Zadanie: ' + task.name + '    DEADLINE: ' + task.deadline + '  StudentID: ' + task.studentID;
}
// Zwrócenie listy zadań studentao wybranym numerze ID i wyświetlenie otrzymanej listy w polu o podanej jako argument nazwie
function GetStudentTasksList(place) {
    $(place).text('');
    var id = document.getElementById("selectStudentShowTask").value;
    var request = $.ajax({
        url: API_LINK + '/Students/' + id,
        method: "GET",
        dataType: "json",
        success: function (data) {
            $.each(data.tasks, function (key, task) {
                $(place).append('<li class="list-group-item">' + FormatTask(task) + '</li>');
            });
        }
    });
}
// Wyświetlenie komunikatu o niepoprawnym wprowadzeniu danych
function showModalErrorInputData() {
    $('#modalErrorInputDataStudent').modal({ keyboard: false, backdrop: 'static', show: true })
}
// Wyświetlenie komunikatu o poprawnym wprowadzeniu danych
function showModalSuccessInputData() {
    $('#modalSuccessAddStudent').modal({ keyboard: false, backdrop: 'static', show: true })
}
// Obsługa funkcjonalności przycisku ukryj
function CleanField(fieldName) {
    $(fieldName).text('');
}