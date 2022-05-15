$(function () {
    $("#UserRegistrationModal input[name = 'AcceptUserAgreement']").click(onAcceptUserAgreementClick);

    $("#UserRegistrationModal button[name = 'registration']").prop("disabled", true);

    function onAcceptUserAgreementClick() {
        if ($(this).is(":checked")) {
            $("#UserRegistrationModal button[name = 'registration']").prop("disabled", false);
        }
        else {
            $("#UserRegistrationModal button[name = 'registration']").prop("disabled", true);

        }

    }

    $("#UserRegistrationModal input[name = 'Email']").blur(function () {

        var email = $("#UserRegistrationModal input[name = 'Email']").val();

        var url = "/UserAuth/UserExists?userName=" + email;
        CloseAlert("#alert_placeholder_register");

        $.ajax({
            type: "GET",
            url: url,
            success: function (data) {
                if (data == true) {

                    PresentClosableBootstrapAlert("#alert_placeholder_register", "warning", "Invalid Email", "This email address has already been registered");

                }
                else {
                    CloseAlert("#alert_placeholder_register");
                }
            },
            error: function (xhr, ajaxOptions, thrownError) {


                console.error(thrownError + '\r\n' + xhr.statusText + '\r\n' + xhr.responseText);
            }
        });
    });

    var userRegisterButton = $("#UserRegistrationModal button[name='registration']").click(onUserRegisterClick);

    function onUserRegisterClick() {

        var url = $('#UserRegistrationForm').attr('action');

        var antiForgeryToken = $("#UserRegistrationModal input[name='__RequestVerificationToken']").val();

        var email = $("#UserRegistrationModal input[name = 'Email']").val();
        var password = $("#UserRegistrationModal input[name = 'Password']").val();
        var confirmPassword = $("#UserRegistrationModal input[name = 'ConfirmPassword']").val();
        var firstName = $("#UserRegistrationModal input[name = 'FirstName']").val();
        var lastName = $("#UserRegistrationModal input[name = 'LastName']").val();
        var phoneNumber = $("#UserRegistrationModal input[name = 'PhoneNumber']").val();


        var userInput = {
            __RequestVerificationToken: antiForgeryToken,
            Email: email,
            Password: password,
            ConfirmPassword: confirmPassword,
            FirstName: firstName,
            LastName: lastName,            
            PhoneNumber: phoneNumber
        };

        $.ajax({
            type: "POST",
            url: url,
            data: userInput,
            success: function (data) {

                var parsed = $.parseHTML(data);

                var hasErrors = $(parsed).find("input[name='RegistrationInValid']").val() == 'true';

                if (hasErrors == true) {
                    $("#UserRegistrationModal").html(data);

                    userLoginButton = $("#UserRegistrationModal button[name='registration']").click(onUserRegisterClick);

                    var form = $("#UserRegistrationForm");

                    $(form).removeData("validator");
                    $(form).removeData("unobtrusiveValidation");
                    $.validator.unobtrusive.parse(form);

                }
                else {
                    window.location.reload();

                }
            },
            error: function (xhr, ajaxOptions, thrownError) {

                console.error(thrownError + "\r\n" + xhr.statusText + "\r\n" + xhr.responseText);
            }
        });
    }
});