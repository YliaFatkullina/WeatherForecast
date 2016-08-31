jQuery.validator.addMethod("lettersonly", function (value, element) {
    return this.optional(element) || /^[- A-Яа-я\s]+$/i.test(value);
}, "Некорретные символы в названии");


$().ready(function () {
    $("#formCity").validate(({
        onkeyup: false,
        rules: {
            cityName: {
                required: true,
                minlength: 3,
                lettersonly: true
            }
        },
        messages: {
            cityName: {
                required: "Введите название города",
                minlength: "Название города должно содержать не меньше 3 символов"
            }
        }
    }));
});
