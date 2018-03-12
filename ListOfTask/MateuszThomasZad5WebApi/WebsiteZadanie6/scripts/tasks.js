// Format w jakim będą wyświtlane zadania
function FormatTask(task) {
    return 'ID: ' + task.id + ' Zadanie: ' + task.name + '    DEADLINE: ' + task.deadline + '  StudentID: ' + task.studentID;
}
// Wyświetlenie listy zadań w podanym jako argument miejscu
function GetTaskList(place) {
    $(place).text('');
    var request = $.ajax({
        url: API_LINK + '/tasks',
        method: "GET",
        dataType: "json",
        success: function (data) {
            $.each(data, function (key, task) {
                $(place).append('<li class="list-group-item">' + FormatTask(task) + '</li>');
            });
        }
    });
}
// Dodanie zadania do bazy danych
function PostTask() {
    var taskName = document.getElementById("taskName").value;
    var taskDeadline = document.getElementById("taskDeadline").value;
    var studentIDTask = document.getElementById("studentIDTask").value;
    if (taskName != "" && taskDeadline != "" && studentIDTask != "") {
        var request = $.ajax({
            url: API_LINK + '/Tasks',
            method: "POST",
            dataType: "json",
            data: {
                name: taskName,
                deadline: taskDeadline,
                studentID: studentIDTask
            },
            success: function (data) {
                showModalSuccessInputData();
                LoadTasks('#selectTaskRemove');
                CleanFormAddTask();
                CleanField('#tasksList');
            }
        });
    } else {
        showModalErrorInputData();
    }
}
// Załadowanie zadania do formularza usuwanai zadań
function LoadTask() {
    var id = document.getElementById("selectTaskRemove").value;
    var request = $.ajax({
        url: API_LINK + '/Tasks' + '/' + id,
        method: "GET",
        dataType: "json",
        success: function (data) {
            taskIDDelete.value = data.id;
            taskNameDelete.value = data.name;
            taskDeadlineDelete.value = data.deadline;
            studentIDTaskDelete.value = data.studentID;
        }
    });
}
// Usuniecie zadanai z bazy danych
function DeleteTask() {
    var id = $('#taskIDDelete').val();
    if (id != "") {
        var request = $.ajax({
            url: API_LINK + '/Tasks/' + id,
            method: "DELETE",
            dataType: "json",
            success: function (data) {
                CleanField('#tasksList');
                LoadTasks('#selectTaskRemove');
                CleanFormRemoveTask();
                showModalSuccessInputData();
            }
        });
    } else {
        showModalErrorInputData();
    }
}
// Załadowanie listy zadań do rozwijanej listy
function LoadTasks(place) {
    $(place).text('');
    var request = $.ajax({
        url: API_LINK + '/Tasks',
        method: "GET",
        dataType: "json",
        success: function (data) {
            $.each(data, function (key, student) {
                $(place).append('<option>' + student.id + '</option>');
            });
        }
    });
}
// Usunięcie tekstu z formularza usuwania zadania
function CleanFormRemoveTask() {
    taskIDDelete.value = "";
    taskNameDelete.value = "";
    taskDeadlineDelete.value = "";
    studentIDTaskDelete.value = "";
}
// Usuniecie tekstu z formularza dodawania zadania
function CleanFormAddTask() {
    taskName.value = "";
    taskDeadline.value = "";
    studentIDTask.value = "";
}
// Wyświetlenie komunikatu o błędzie podczas wrpowadzanai danych do formularza
function showModalErrorInputData() {
    $('#modalErrorTask').modal({ keyboard: false, backdrop: 'static', show: true })
}
// Wyświetlenie komunikatu o poprawnym wrpowadzeniu danych do formularza
function showModalSuccessInputData() {
    $('#modalSuccessTask').modal({ keyboard: false, backdrop: 'static', show: true })
}

