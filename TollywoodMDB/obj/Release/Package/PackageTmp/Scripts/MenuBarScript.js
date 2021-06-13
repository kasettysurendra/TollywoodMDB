$(document).ready(function () {
    $(".LoginTempleteviewSupporter").hide();
    $("#Login").on("click", function () {
        $(".LoginTempleteviewSupporter").show();
        $("#LoginTempleteview").css("display", "block");

        $.ajax({
            //@*url: '@Url.Action("LoginTemplete", "Login")',*@
            url: '/Login/LoginTemplete',
            dataType: "html",
            cache: false,
            method: "get",
            success: function (data, statusText, jqXHR) {
                $("#LoginTempleteview").html(data);
                $("#LoginTempleteview").css("display", "block");
            },
            error: function (data) {
                alert(data.statusText);
            }
        })

    });

    //SignUp Click
    $("#SignUp").on("click", function () {
        window.location.href = '/Login/Register';

    });

    //logout call
    $("#Logout").on("click", function () {
        $("#LoginTempleteview").hide();
        if (confirm("Are you sure you want to logout?")) {
            $.ajax({
                //@*url: '@Url.Action("Logout", "Login")',*@
                url: '/Login/Logout',
                dataType: "html",
                cache: false,
                method: "post",
                success: function (data, statusText, jqXHR) {
                    if (data == "LoggedOut") {
                        alert("you are logged out successfully");
                        window.location.reload();
                    }
                },
                error: function (data) {
                    alert(data.statusText);
                }
            })
        }
        
    });

    //logout function
    //function logout() {
    //    if (confirm("Are you sure you want to logout")) {
    //        $.ajax({
    //            //@*url: '@Url.Action("Logout", "Login")',*@
    //            url: '/Login/Logout',
    //            dataType: "html",
    //            cache: false,
    //            method: "post",
    //            success: function (data, statusText, jqXHR) {
    //                if (data == "LoggedOut") {
    //                    alert("you are logged out successfully");
    //                    window.location.reload();
    //                }
    //            },
    //            error: function (data) {
    //                alert(data.statusText);
    //            }
    //        })
    //        return 1;
    //    }
    //    else {
    //        return 0;
    //    }
    //}

    //Search icon click

    $("#SearchIcon").click(function () {
        var searchvalue = $("#searchText").val();
        if (!searchvalue == '') {
            //@*location.href = '@Url.Action("MenuSearchMovie", "Search")' + "?searchText=" + searchvalue;*@
            location.href = '/Search/MenuSearchMovie' + "?searchText=" + searchvalue;

        }
        else {
            alert("Cannot perform search with empty input")
        }
    });

    //Search auto complete
    $("#searchText").autocomplete({
        source: function (request, response) {
            $.ajax({
                //@*url: '@Url.Action("AutoComplete", "Search")',*@
                url: '/Search/AutoComplete',
                dataType: "json",
                type: "POST",
                data: { searchText: request.term },
                success: function (data) {
                    response($.map(data, function (item) {
                        return { label: item.Movie_Name, value: item.Movie_Name };
                    }))

                },
                error: function (jqXHR) {
                    alert(jqXHR.responseText);
                },

            })
        }
    });


    });