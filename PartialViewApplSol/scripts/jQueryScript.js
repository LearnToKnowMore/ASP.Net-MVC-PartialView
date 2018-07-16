$(document).ready(function () {
    let urltoAction = yourApp.Urls.editUserUrl;
    var token = $('input[name="__RequestVerificationToken"]').val();
    $('#DepartmentName').change(function () {
        let selectedVal = $('#DepartmentName').val();
        let selectedText = $('#DepartmentName :selected').text();
        if (selectedVal && selectedVal != '' && selectedText != '-- Select --') {
        $('#loadingDiv').show();
            $.ajax({
                type: 'POST',
                cache: false,
                url: urltoAction,
                data: {
                    deptId: selectedVal,
                    __RequestVerificationToken: token
                },
                success: function (result) {
                    $('#empDetails').html(result);
                    $('#loadingDiv').hide();
                },
                error: function () {
                    console.error('Error occured!!');
                    $('#loadingDiv').hide();
                }
            });
        }
    });
});
