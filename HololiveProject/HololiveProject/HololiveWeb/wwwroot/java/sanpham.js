function showProductButtons() {
    var productButtons = document.getElementById("productButtons");
    productButtons.innerHTML = '<button class="btntest" type="button">set</button>';
    productButtons.classList.add("show");
}

function showMoreButtons() {
    var productButtons = document.getElementById("productButtons");
    productButtons.innerHTML = '<button class="btntest" type="button">sanpham</button><button class="btntest" type="button">test</button>';
    productButtons.classList.add("show");
}
function showProductRow(rowId) {
    var productRows = document.querySelectorAll('.product-row');
    productRows.forEach(function (row) {
        row.classList.remove('show');
    });

    var productRow = document.getElementById(rowId);
    productRow.classList.add("show");
}
function increase() {
    var number = document.getElementById("number");
    number.innerHTML = parseInt(number.innerHTML) + 1;
}

function decrease() {
    var number = document.getElementById("number");
    var currentNumber = parseInt(number.innerHTML);
    if (currentNumber > 0) {
        number.innerHTML = currentNumber - 1;
    }

}
function add() {
    var a = document.getElementById("button1");
    a.classList.remove("add");
    var b = document.getElementById("button2");
    b.classList.add("add");
}
function add1() {
    var a = document.getElementById("button1");
    a.classList.add("add");
    var b = document.getElementById("button2");
    b.classList.remove("add");
}
function add2() {
    var a = document.getElementById("sanpham1");
    a.classList.add("add2");
    var b = document.getElementById("sanpham2");
    b.classList.remove("add2");

}
function add3() {
    var a = document.getElementById("sanpham1");
    a.classList.remove("add2");
    var b = document.getElementById("sanpham2");
    b.classList.add("add2");

}
function add4() {
    var c = document.getElementById("sanpham3");
    c.classList.add("add2");
    var d = document.getElementById("sanpham4");
    d.classList.remove("add2");
}
function add5() {
    var c = document.getElementById("sanpham3");
    c.classList.remove("add2");
    var d = document.getElementById("sanpham4");
    d.classList.add("add2");
}
function validateForm() {
    var nameInput = document.getElementById("myName");
    var nameValue = nameInput.value.trim();

    var emailInput = document.getElementById("myPassword");
    var emailValue = emailInput.value.trim();

    if (nameValue === "") {
        alert("Vui lòng nhập tên");
        return;
    }

    if (emailValue === "") {
        alert("Vui lòng nhập Email");
        return;
    }

    var emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    if (!emailPattern.test(emailValue)) {
        alert("Email vừa nhập không chính xác");
        return;
    }

    // Nếu các kiểm tra đều thành công, hiển thị thông báo "Cảm ơn đã đóng góp ý kiến của bạn"
    alert("Cảm ơn đã đóng góp ý kiến của bạn");

    // Sau khi hiển thị thông báo, bạn có thể tiếp tục xử lý form ở đây
    // Ví dụ: gửi dữ liệu form lên máy chủ, chuyển hướng trang, v.v.
}