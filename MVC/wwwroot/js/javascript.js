function GetAllPeople() {

    $.ajax({
        type: "POST",
        url: "/Ajax/ShowPeopleList",
        success: function (output) {
            document.getElementById("peopleList").innerHTML = output;
        }
    })
}

function GetDetails() {
    var inputId = $("#searchValue").val();

    $.ajax({
        type: "POST",
        url: "/Ajax/GetDetails?id=" + inputId,
        success: function (response) {
            $("#personDetail").html(response);
        },

    });
}

function DeletePerson() {

    var inputId = $("#searchValue").val();

    $.ajax({

        url: "/Ajax/DeletePerson?id=" + inputId,
        success: function (output) {
            console.log(output);
            document.getElementById("peopleList").innerHTML = output;
            document.getElementById("personDetail").innerHTML = "";
        }
    })
};