$(document).ready(function () {
    $('#btnSubmit').click(function (event) {
        var isValid = true;

        // Validation for name
        var name = $('#name').val().trim();
        if (name.length == 0) {
            $('#nameError').text('Full Name is required.');
            $('#name').addClass('errorBorder');
            isValid = false;
            return false;

        } else {
            $('#nameError').text('');
            $('#name').removeClass('errorBorder');
        }

        // Other validations...
        var email = $('#email').val().trim();
        var emailregex = /^[\w-]+(\.[\w-]+)*@[a-zA-Z0-9-]+(\.[a-zA-Z0-9-]+)*(\.[a-zA-Z]{2,})$/
        if (email.length == 0) {
            $('#emailError').text('Email is required.');
            $('#email').addClass('errorBorder');
            isValid = false;
            return false;
        } else if (!emailregex.test(email)) {
            $('#emailError').text('Please enter a valid email address.');
            $('#email').addClass('errorBorder');
            isValid = false;
            return false;
        }
        if (email != null) {
            checkEmailAvailability(email, function (response) {
                if (response == "Found") {
                    $('#emailError').html('Email is already exist, please choose another.');
                    $('#email').addClass('errorBorder');
                    isValid = false;
                    event.preventDefault(); // Prevent form submission
                } else {
                    $('#emailError').text('');
                    $('#email').removeClass('errorBorder');
                    // Proceed with other validations or submit the form
                    var password = $('#pass').val().trim();
                    if (password.length == 0) {
                        $('#passError').text('Password is required.');
                        $('#pass').addClass('errorBorder')
                        isValid = false;
                        return false;
                    } else if (!/(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}/.test(password)) {
                        $('#passError').text('Password must contain at least 8 characters, including one uppercase letter, one lowercase letter, one digit, and one special character (@$!%*?&).');
                        $('#pass').addClass('errorBorder')
                        isValid = false;
                        return false;
                    }
                    else {
                        $('#passError').text('');
                        $('#pass').removeClass('errorBorder')
                    }

                    var conpassword = $('#conpass').val().trim();
                    if (conpassword.length == 0) {
                        $('#conpassError').text('Confirm Password is required.');
                        $('#conpass').addClass('errorBorder')
                        isValid = false;
                        return false;
                    }
                    else if (conpassword != password) {
                        $('#conpassError').text('Passwords do not match.');
                        $('#conpass').addClass('errorBorder');
                        isValid = false;
                        return false;
                    }
                    else {
                        $('#conpassError').text('');
                        $('#conpass').removeClass('errorBorder');
                    }

                    var age = $('#age').val().trim();
                    if (age.length === 0) {
                        $('#ageError').text('Age is required.');
                        $('#age').addClass('errorBorder');
                        isValid = false;
                        return false;
                    } else if (age < 18 || age > 59) {
                        $('#ageError').text('Age should be in the range of 18-59.');
                        $('#age').addClass('errorBorder');
                        isValid = false;
                        return false;
                    } else {
                        $('#ageError').text('');
                        $('#age').removeClass('errorBorder');
                    }
                    var phone = $('#phone').val().trim();
                    var phoneRegex = /^(\+?91|0)?[6789]\d{9}$/;
                    if (phone.length == 0) {
                        $('#phoneError').text('Phone is required.');
                        $('#phone').addClass('errorBorder');
                        isValid = false;
                        return false;
                    } else if (!phoneRegex.test(phone)) {
                        $('#phoneError').text('Invalid phone number.');
                        $('#phone').addClass('errorBorder');
                        isValid = false;
                        return false;
                    } else {
                        $('#phoneError').text('');
                        $('#phone').removeClass('errorBorder');
                    }

                    var address = $('#address').val().trim();
                    if (address.length == 0) {
                        $('#addressError').text('Address is required.');
                        $('#address').addClass('errorBorder');
                        isValid = false;
                        return false;
                    } else {
                        $('#addressError').text('');
                        $('#address').removeClass('errorBorder');
                    }

                    //var gender = $('input[name="gender"]:checked').val();
                    //if (!gender) {
                    //    $('#genderError').text('Gender is required.');
                    //    isValid = false;
                    //} else {
                    //    $('#genderError').text('');
                    //}

                    var bloodgroup = $('#bloodgrp').val();
                    if (bloodgroup == '0') {
                        $('#bloodgrpError').text('Please select a blood group.');
                        isValid = false;
                        return false;
                    } else {
                        $('#bloodgrpError').text('');

                    }

                    var designation = $('#designation').val().trim();
                    if (designation.length == 0) {
                        $('#designationError').text('Designation is required.');
                        $('#designation').addClass('errorBorder');
                        isValid = false;
                        return false;
                    } else {
                        $('#designationError').text('');
                        $('#designation').removeClass('errorBorder');
                    }

                    var dateofjoin = $('#dateofjoin').val().trim();
                    if (dateofjoin.length == 0) {
                        $('#dateofjoinError').text('Date of Join is required.');
                        $('#dateofjoin').addClass('errorBorder');

                        isValid = false;
                        return false;
                    } else {
                        $('#dateofjoinError').text('');
                        $('#dateofjoin').removeClass('errorBorder');
                    }
                    //var dateofjoin = $('#dateofjoin').val().trim();
                    //if (dateofjoin.length == 0) {
                    //    $('#dateofjoinError').text('Date of Join is required.');
                    //    $('#dateofjoin').addClass('errorBorder');
                    //    isValid = false;
                    //    return false;
                    //} else {
                    //    // Check if the selected date is valid
                    //    var selectedDate = $.datepicker.parseDate('yy-mm-dd', dateofjoin);
                    //    if (!selectedDate) {
                    //        $('#dateofjoinError').text('Please select a valid date.');
                    //        $('#dateofjoin').addClass('errorBorder');
                    //        isValid = false;
                    //        return false;
                    //    } else {
                    //        $('#dateofjoinError').text('');
                    //        $('#dateofjoin').removeClass('errorBorder');
                    //    }
                    //}

                    var salary = $('#salary').val().trim();
                    if (salary.length == 0) {
                        $('#salaryError').text('Salary is required.');
                        $('#salary').addClass('errorBorder');
                        isValid = false;
                        return false;
                    } else {
                        $('#salaryError').text('');
                        $('#salary').removeClass('errorBorder');
                    }

                    var departmentId = $('#deptno').val().trim();
                    if (departmentId == '0') {
                        $('#departmentError').text('Please select a department.');
                        $('#deptno').addClass('errorBorder');
                        isValid = false;
                        return false;
                    } else {
                        $('#departmentError').text('');
                        $('#deptno').removeClass('errorBorder');
                    }
                    if (isValid) {
                        AddEmployeefun();
                    }

                }
            });
        }
        else {
            $('#emailError').text('');
            $('#email').removeClass('errorBorder');
        }

        // Rest 

        if (!isValid) {
            event.preventDefault(); // Prevent form submission
        }
    });

    function checkEmailAvailability(email, callback) {
        $.ajax({
            url: '/Registration/IsEmailAvailable',
            type: 'Get',
            data: { email1: email },
            success: function (response) {
                callback(response);
            },
            error: function () {
                console.error('Error checking email availability.');
            }
        });
    }
});
