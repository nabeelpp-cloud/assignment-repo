document.getElementById("predictOutput").addEventListener("click",function(){
    var num = 10;
    function test() {
    var num = 20;
    if (true) {
    let num = 30;
    console.log("Inside if:", num);
    }
    console.log("Inside function:", num);
    }
    test();
    console.log("Outside:", num);
    document.getElementById("output").style.display = "block";
    
});