(function () {

    function validColorHex() {
        var result = Math.floor(Math.random() * 256).toString(16);
        if(result.length === 1) {
            result = result + "0";
        }
        return result;
    }

    function randomColor() {
        return "#" + validColorHex() + validColorHex() + validColorHex();
    }

    function getColors() {

        var result = [];

        for(i = 0; i < 5; i++) {
            var color = {};
            color.getId = function (){
				return i
            };
            color.hex = randomColor();
            result.push(color);
        }
        return result;

    }

    var colors = getColors();
    var offset = 0;
    var content = document.getElementById("content");

    for(var i = offset; i < colors.length + offset; i++) {
        var div = document.createElement("div");
        var c = colors[i - offset];
        div.setAttribute("style", "background-color:" + c.hex + ";padding:10px;");
        div.innerHTML = "ID: " + c.getId() + " COLOR: " + c.hex;
        content.appendChild(div);
    }
    
    for(var j = 0; j < colors.length; j++) {
        div = document.createElement("div");
        c = colors[j];
        div.setAttribute("style", "background-color:" + c.hex + ";padding:10px;");
        div.innerHTML = "ID: " + c.getId() + " COLOR: " + c.hex;
        content.appendChild(div);
    }

})();
