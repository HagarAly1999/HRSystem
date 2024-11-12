$(document).ready(function () {
    $('#empo').dataTable({
        "serverSide": true,
        "filter": true,
        "ajax": {
            "url": "api/Employee",
            "type": "Post",
            "dataType":"json"

        }

    })
})