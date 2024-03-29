﻿$(function ()
{
    if ($("a.confimDeletion").length)
    {
        $("a.confimDeletion").click(() => {
            if (!confirm("Confirm deletion")) return false;
        });
    }

    if ($("div.alert.notification").length) {
        setTimeout(() => { $("div.alert.notification").fadeOut() }, 2000);
    }
})

function readURL(input)
{
    if (input.files && input.files[0])
    {
        let reader = new FileReader();

        reader.onload = (e) =>
        {
            $("img#imgpreview").attr("src", e.target.result).width(200).height(200);
        }

        reader.readAsDataURL(input.files[0]);
    }
}