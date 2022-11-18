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

function ViewCities() {

    let countryId = $("#country").val();
    let cityElement = $("#city");

    $.ajax({
        type: "POST",
        url: "/People/GetCitySelectList?id=" + countryId,
        success: function (response) {

            if (response.length > 0) {
                $(cityElement).removeAttr("disabled");
                cityElement.empty().append('<option selected="selected" value="0">Select City</option>');

                $.each(response, function () {
                    $(city).append($("<option></option>").val(this.value).html(this.text));

                });
            }
            else {
                cityElement.empty().append('<option selected="selected" value="0">No citites here</option>');
                $(cityElement).attr("disabled", "disabled");

            }
        },
    });
}