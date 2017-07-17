function apaYangKalianAkanLakukan() {
    //PERINTAH ASYNC PERTAMA
    $.ajax({
        url: "http://api.jquery.com/jquery.ajax/",
        success: function (data) {
            //PERINTAH ASYNC KEDUA
            //...
        },
        data: {
            id: "1"
        }
    });
}