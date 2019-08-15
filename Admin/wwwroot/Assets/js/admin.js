// SLUG GENERATOR \\
$("#Name").keyup(function () {
    var text = window.$(this).val();

    var trMap = {
        çÇ: "c",
        ğĞ: "g",
        şŞ: "s",
        üÜ: "u",
        ıİ: "i",
        öÖ: "o"
    };
    for (var key in trMap) {
        if (trMap.hasOwnProperty(key)) {
            text = text.replace(new RegExp("[" + key + "]", "g"), trMap[key]);
        }
    }
    text = text
        .replace(/[^-a-zA-Z0-9\s]+/gi, "") // remove non-alphanumeric chars
        .replace(/\s/gi, "-") // convert spaces to dashes
        .replace(/[-]+/gi, "-") // trim repeated dashes
        .toLowerCase(); // lower all chars

    window.$("#Slug").val(text);
});

// CKEDITOR \\
$(document).ready(function () {

    if (document.querySelector("textarea[name='EditorContent']") && document.querySelector("textarea[name='EditorContent']").length !== 0) {
        window.CKEDITOR.replace(document.querySelector("textarea[name='EditorContent']"), {
            customConfig: '/Assets/libs/ckeditor/config.js'
        });
    }
});