﻿// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

function likeVicc(id) {
    var xhr = new XMLHttpRequest();
    xhr.withCredentials = true;

    xhr.addEventListener("readystatechange", function () {
        if (this.readyState === 4) {
            console.log(this.responseText);
            var tetszikDbElement = document.getElementById("tetszikDb_" + id);
            if (tetszikDbElement) {
                tetszikDbElement.innerHTML = this.responseText;
            }
        }
    });

    xhr.open("PATCH", "https://localhost:7193/api/Vicc/" + id + "/like");

    xhr.send();
}

function dislikeVicc(id) {
    var xhr = new XMLHttpRequest();
    xhr.withCredentials = true;

    xhr.addEventListener("readystatechange", function () {
        if (this.readyState === 4) {
            console.log(this.responseText);
            var nemTetszikDbElement = document.getElementById("newTetszikDb_" + id);
            if (nemTetszikDbElement) {
                nemTetszikDbElement.innerHTML = this.responseText;
            }
        }
    });

    xhr.open("PATCH", "https://localhost:7193/api/Vicc/" + id + "/dislike");

    xhr.send();
}