
var btnMenus = document.querySelectorAll(".menu__item")
btnMenus.forEach(btnMenu => {
    btnMenu.onclick = function () {
        document.querySelector('.menu__item.active').classList.remove('active')
        btnMenu.classList.add('active');
    }
})



if (window.location.href == "https://localhost:44370/NHANVIENS") {
    document.querySelector("#NHANVIEN").classList.add("active")
}
if (window.location.href == "https://localhost:44370/CHUCVUS") {

    document.querySelector("#CHUCVU").classList.add("active")
}
if (window.location.href == "https://localhost:44370/PHONGBANS") {

    document.querySelector("#PHONGBAN").classList.add("active")
}
    

