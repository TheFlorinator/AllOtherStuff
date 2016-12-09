
var div = document.CreateElement("div")

(function (){
  document.getElementById("btn").addEventListener("click", document.getElementById('List').innerHTML = factorize())
});

function getInput(){
  var input = getElementById('txt');
  var number = parseToInt("input");
  return number;
}

function factorize(){
  var number = getInput();
  var arr = []
  for (var i = 0; i < number; i++) {
    if (number % i == 0) {
      arr[i]
    }
  }
}
