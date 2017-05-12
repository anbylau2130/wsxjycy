function mylayer(ms) {
    layer.open({
        type: 0,
        title: '提示信息',
        offset:"100px",
        border: [1, 0.5, '#999'], //去掉默认边框
        shadeClose: true,
        shade: [0.1, '#000'],
        //shade: [1], //去掉遮罩
        content: ms
    })
}
function layerAndLeave(ms, urls) {
    layer.open({
        type: 0,
        title: '提示信息',
        offset: "100px",
        border: [1, 0.5, '#999'], //去掉默认边框
        shadeClose: true,
        shade: [0.1, '#000'],
        //shade: [1], //去掉遮罩
        content: ms,
        end: function () {
            window.location.href = urls;
        }
    })
}
function openwins(url) {
    var a = document.createElement("a");
    a.setAttribute("href", url);
    a.setAttribute("target", "_blank");
    document.body.appendChild(a);
    a.click();
}

function sjmylayer(ms) {
   layer({
        type: 0,
        title: '提示信息!',
        border: [1, 0.5, '#999'], //去掉默认边框
        // shade: [0], //去掉遮罩
        dialog: {
            type: -1,
            msg: ms
        },
        yes: function () {
            layer.closeAll('dialog');
            $("#Reason").focus();
        },
        close: function () {
            layer.closeAll('dialog');
            $("#Reason").focus();
        }
    })
}