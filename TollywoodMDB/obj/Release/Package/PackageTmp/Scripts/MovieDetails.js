 $(document).ready(function () {
        $("#Reviews").on("click", function () {
            renderpartialview();
        })
        $("#Videos").on("click", function () {
            renderpartialview();
        })
    });

    function renderpartialview(MovieID){
         $("#loader,#loadersupport").css("display", "block");
         $("#Breif,#Cast,#Videos,#BoxOffice").css("background-color", "#383636");
            $("#Reviews").css("background-color", "crimson");
            $.ajax({
                url: '@Url.Action("Reviews","MovieDetails")',
                data: { id: MovieID},
                cache: false,
                type: "post",
                dataType: "html",
                success: function (data, textStatus, jqXHR) {
                    $("#RenderPartialview").html(data);
                    $("#loader,#loadersupport").css("display", "none");
                }
            })
    }
    var i = 0;
    function getSongs(id) {
        if (i == 0)
            {
        $.ajax({
            url: '@Url.Action("SongsView", "Songs")',
            data: { movieId: id },
            cache: false,
            dataType: "html",
            type: "post",
            success: function (data, statusText, jqXHR)
            {
                i = 1;
                $("#getSongsView").html(data).hide();
                $("#getSongsView").slideDown(500);
            },
            error: function (data)
            {
                alert(data.statusText);
            }
            })
        }
        if (i == 1) {
            i = 0;
            $("#getSongsView").slideUp(500);
        }
    }