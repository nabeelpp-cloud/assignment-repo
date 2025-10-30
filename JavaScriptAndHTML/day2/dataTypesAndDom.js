document.getElementById("typeFinderButton").addEventListener("click", function() {
    let input = document.getElementById("userInput").value;
    let output = document.getElementById("typeOutput");

    if (input.trim() === "") {
        output.value = "Empty input";
    } else if (!isNaN(input)) {
        output.value = "Number";
    } else if (input.toLowerCase() === "true" || input.toLowerCase() === "false") {
        output.value = "Boolean";
    } else {
        output.value = "String";
    }
});

document.getElementById("findSumBtn").addEventListener("click",function(){
    let num1=document.getElementById("num1").value;
    let num2=document.getElementById("num2").value;
    let output=document.getElementById("sumOutput");
    output.value=Number(num1)+Number(num2);
});

document.getElementById("toggleBtn").addEventListener("click",function(){
    let message = document.getElementById("toggleMessage");
    if(message.innerHTML===""){
        message.innerHTML="Hello world";
        document.getElementById("toggleBtn").value="Hide";
    }
    else{
        message.innerHTML="";
        document.getElementById("toggleBtn").value="Show";
    }
    console.log(message.innerHTML)
    
});

document.getElementById("addColorBtn").addEventListener("click",function(){
    let input = document.getElementById("inputColor").value;
    let output = document.getElementById("outPutColor");
    output.innerHTML=output.innerHTML + input + ", ";
    document.getElementById("inputColor").value="";
    
});

document.getElementById("showDetailsBtn").addEventListener("click",function(){
    const a = {
        name:"Nabeel",
        age:"23",
        grade:"A+"
    }
    document.getElementById("name").innerHTML="Name : "+a.name;
    document.getElementById("age").innerHTML="Age : "+a.age;
    document.getElementById("grade").innerHTML="Grade : "+a.grade;
})

document.getElementById("changeBgColorBtn").addEventListener("click", function() {
    const colors = ["#f54291", "#33ccff", "#7dff3b", "#e4b321", "#a14ef0","#fff"];
    const randomIndex = Math.floor(Math.random() * colors.length);
    document.body.style.backgroundColor = colors[randomIndex];
});
