function addNew(widgetId, value) {
    if (confirm("Are you sure?")) {
        $("#AddPlayer").val(value);
        $("players").val(0);
    }
}