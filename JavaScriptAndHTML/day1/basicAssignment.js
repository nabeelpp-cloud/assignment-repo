function ButtonClicked() {
    alert("Hello World");
}
function isLeapYear() {
    var a = document.getElementById("year").value;
    if (a % 400 == 0) {
        console.log(a + " Is a leap year")
    }
    else if (a % 4 == 0) {
        if (a % 100 != 0)
            console.log(a + " Is a leap year")
        else {
            console.log(a + " Is not a leap year")

        }
    }
    else {
        console.log(a + " Is not a leap year")
    }
}