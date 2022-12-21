let canvas = document.getElementById("canvas");
let context = canvas.getContext("2d");
canvas.width = window.innerWidth - 300;
canvas.height = window.innerHeight - 200;

let canvas_width = canvas.width;
let canvas_height = canvas.height;
let offset_x;
let offset_Y;

let get_Offset = function() {
    let canvas_offsets = canvas.getBoundingClientRect();
    offset_x = canvas_offsets.left;
    offset_Y = canvas_offsets.top;
}
get_Offset();
window.onscroll = function() { get_Offset(); }
window.onresize = function() { get_Offset(); }
canvas.onresize = function() { get_Offset(); }

let pages = [];
let currentPage = 0;
let objects = [];
let emptyObjects = objects;
let current_object_index = null;
let is_dragging = false;
let startX;
let startY;

//objects.push({
//    type: 'rect',
//    x: 0,
//    y: 0,
//    width: 200,
//    height: 200,
//    color: 'red',
//    Text: 'This is text area',
//    fontColor: 'black',
//    fontSize: 12,
//    fontFamily: 'Georgia',
//    isBold: false,
//    isItalic: false
//});
//objects.push({
//    type: 'text',
//    x: 0,
//    y: 0,
//    width: 100,
//    height: 100,
//    color: 'blue',
//    Text: 'This is text area\nThis is text areaThis is text area',
//    fontColor: 'white',
//    fontSize: 12,
//    fontFamily: 'Georgia',
//    isBold: false,
//    isItalic: false
//});
//objects.push({
//    type: 'img',
//    img: document.getElementById("image1"),
//    x: 50,
//    y: 10,
//    width: 200,
//    height: 200
//});
function createPoster(path) {
    const video = document.createElement('video');
    video.src = path + "#t=1";
    video.autoplay = false;
    video.muted = true;
    var canvas_1 = document.createElement("canvas");
    canvas_1.style.backgroundColor = "white";
    canvas_1.width = 350;
    canvas_1.height = 200;
    canvas_1.getContext("2d").drawImage(video, 0, 0, canvas_1.width, canvas_1.height);
    return canvas_1.toDataURL("image/jpeg");;
}
let add_image_object = function(path) {
    var image = new Image();
    image.src = path;
    objects.push({
        type: "img",
        img: image,
        path: path,
        x: 50,
        y: 10,
        width: 200,
        height: 200
    });
    draw_objects();
}
let add_Video_object = function(path) {
    var image = new Image();
    image.src = createPoster(path);
    objects.push({
        type: "img",
        isVideo: true,
        img: image,
        path: path,
        x: 50,
        y: 10,
        width: 200,
        height: 200
    });
    draw_objects();
}
let add_rectangle_shape_object = function(shape) {
    objects.push({
        type: shape,
        x: 0,
        y: 0,
        width: 100,
        height: 50,
        color: 'rgb(224,215,31)',
    });
    draw_objects();
}
let add_square_shape_object = function(shape) {
    objects.push({
        type: shape,
        x: 0,
        y: 0,
        width: 100,
        height: 100,
        color: 'rgb(143,206,219)',
    });
    draw_objects();
}
let add_circle_shape_object = function(shape) {
    objects.push({
        type: shape,
        x: 50,
        y: 50,
        radius: 32,
        sAngle: 0,
        eAngle: 2,
        color: 'rgb(143,206,219)',
    });
    draw_objects();
}
let add_oval_shape_object = function(shape) {
    objects.push({
        type: shape,
        x: 50,
        y: 50,
        radius: 25,
        sAngle: 0,
        eAngle: 2,
        color: 'rgb(143,206,219)',
    });
    draw_objects();
}
let add_label_object = function() {
    objects.push({
        type: 'text',
        x: 0,
        y: 0,
        width: 100,
        height: 100,
        color: 'black',
        Text: 'This is your line 1\n This is your line2. This is your line2 \n This is your line3',
        fontColor: 'white',
        fontSize: 12,
        fontFamily: 'Georgia',
        isBold: false,
        isItalic: false
    });
    draw_objects();
}
let open_text_panel = function() {
    document.getElementById("text_panel").style.display = "block";
}
let hide_text_panel = function() {
    document.getElementById("text_panel").style.display = "none";
}
let default_form_open = function() {
    document.getElementById("templates_panel").style.display = "block";
}
default_form_open();
let is_mouse_in_object = function(x, y, object) {
    if (object.type == "circle" || object.type == "oval") {
        var areaX = x - object.x;
        var areaY = y - object.y;
        //return true if x^2 + y^2 <= radius squared.
        return areaX * areaX + areaY * areaY <= object.radius * object.radius;
    } else {
        let object_left = object.x;
        let object_right = object.x + object.width;
        let object_top = object.y;
        let object_bottom = object.y + object.height;
        if (x > object_left && x < object_right && y > object_top && y < object_bottom) {
            return true;
        }
        return false;
    }
}
let set_font_family = function() {
    if (current_object_index != null) {
        $('#fontfamily_text').val(objects[current_object_index].fontFamily);
    }
}

let fill_text = function() {
    if (current_object_index != null) {
        document.getElementById("label_text").value = objects[current_object_index].Text;
    }
}
let active_links = function(id) {
    document.getElementById(id).classList.add("active");
}
let show_elements = function(id) {
    document.getElementById(id).style.display = "block";
}
let hide_elements = function(id) {
    document.getElementById(id).style.display = "none";
};
let show_elements_for_label = function() {
    show_elements("text_els");
    show_elements("text_el_t");
    show_elements("text_el_fs");
    show_elements("text_el_ff");
    show_elements("text_el_fc");
}
let hide_elements_of_label = function() {
    hide_elements("text_els");
    hide_elements("text_el_t");
    hide_elements("text_el_fs");
    hide_elements("text_el_ff");
    hide_elements("text_el_fc");
}
let set_font_size = function() {
    document.getElementById("size_text").value = objects[current_object_index].fontSize;
}
let change_font_size = function() {
    if (current_object_index != null) {
        var object = objects[current_object_index];
        object.fontSize = parseInt(document.getElementById("size_text").value);
        objects[current_object_index] = object;
        draw_objects();
    }
}
let set_font_color = function() {
    document.getElementById("text_color").value = objects[current_object_index].fontColor;
}
let change_font_color = function() {
    var color = document.getElementById("text_color").value;
    if (current_object_index != null) {
        var object = objects[current_object_index];
        object.fontColor = color;
        objects[current_object_index] = object;
        draw_objects();
    }
}

function change_object_color(id) {

    var color = document.getElementById(id).value;
    if (current_object_index != null) {
        var object = objects[current_object_index];
        object.color = color;
        objects[current_object_index] = object;
        draw_objects();
    }
}

function bold_text() {
    if (current_object_index != null) {
        var object = objects[current_object_index];
        if (object.isBold) {
            object.isBold = false;
        } else {
            object.isBold = true;
        }
        objects[current_object_index] = object;
        draw_objects();
    }
}

function italic_text() {
    if (current_object_index != null) {
        var object = objects[current_object_index];
        if (object.isItalic) {
            object.isItalic = false;
        } else {
            object.isItalic = true;
        }
        objects[current_object_index] = object;
        draw_objects();
    }
}

function tolower_text() {
    if (current_object_index != null) {
        var object = objects[current_object_index];
        object.Text = object.Text.toLowerCase();
        objects[current_object_index] = object;
        draw_objects();
    }
}

function toupper_text() {
    if (current_object_index != null) {
        var object = objects[current_object_index];
        object.Text = object.Text.toUpperCase();
        objects[current_object_index] = object;
        draw_objects();
    }
}

function change_label_text() {
    var Text = document.getElementById("label_text").value;
    if (current_object_index != null) {
        var object = objects[current_object_index];
        object.Text = Text;
        objects[current_object_index] = object;
        draw_objects();
    }
}
let mouse_down = function(event) {
    event.preventDefault();
    hide_elements("background_color");
    hide_elements_of_label();
    startX = parseInt(event.clientX - offset_x);
    startY = parseInt(event.clientY - offset_Y);
    let index = 0;
    let isFound = false;
    for (let object of objects) {
        if (is_mouse_in_object(startX, startY, object)) {
            current_object_index = index;
            is_dragging = true;
            isFound = true;
            //show_elements("btn_delete_ob");
            if (object.type != "text") {
                //show_elements("resize_plus");
                //show_elements("resize_minus");
            }
            if (object.type != "img") {
                show_elements("background_color");
            }
            if (object.type == "text") {
                show_elements_for_label();
                fill_text();
                set_font_size();
                set_font_color();
                set_font_family();
                if (object.isBold) {
                    active_links("bold_text");
                }
                if (object.isItalic) {
                    active_links("italic_text");
                }
            }
            //return;
        }
        index++;
    }
    context.fillStyle = 'rgba(225,225,225,0.5)';
    context.fillRect(objects[current_object_index].x, objects[current_object_index].y, objects[current_object_index].width, objects[current_object_index].height);
    //let currentObject = objects[current_object_index];
    //let lastObject = objects[objects.length - 1];
    //objects[current_object_index] = lastObject;
    //objects[objects.length - 1] = currentObject;
    //current_object_index = objects.length - 1;
    //if (isFound) {
    //  objects.splice(current_object_index, current_object_index);
    //objects.push(currentObject);
    //current_object_index = objects.length - 1;
    //}
    isFound = false;
}


let mousedbl_click = function(event) {
    event.preventDefault();
    hide_elements("background_color");
    hide_elements_of_label();
    startX = parseInt(event.clientX - offset_x);
    startY = parseInt(event.clientY - offset_Y);
    let index = 0;
    for (let object of objects) {
        if (is_mouse_in_object(startX, startY, object)) {
            if (object.type == "img" && object.isVideo == true) {
                current_object_index = index;
                var video = document.createElement("video");
                //video.id = "id_1";
                video.src = object.path;
                video.play();
                update_Video(video);
            }
        }
        index++;
    }
}
let update_Video = function(video) {
    if (!video.ended) {
        let object = objects[current_object_index];
        context.drawImage(document.getElementById("video_1"), object.x, object.y, object.width, object.height);
        update_Video(video);
    }
}
let mouse_up = function(event) {
    if (!is_dragging) {
        return;
    }
    event.preventDefault();
    is_dragging = false;
}
let mouse_out = function(event) {
    if (!is_dragging) {
        return;
    }
    event.preventDefault();
    is_dragging = false;
}

let mouse_move = function(event) {

    if (!is_dragging) {
        return;
    } else {
        event.preventDefault();
        let mouseX = parseInt(event.clientX - offset_x);
        let mouseY = parseInt(event.clientY - offset_Y);

        let dx = mouseX - startX;
        let dy = mouseY - startY;

        //for (let object of objects) {
        let current_object = objects[current_object_index];
        current_object.x += dx;
        current_object.y += dy;
        draw_objects();
        startX = mouseX;
        startY = mouseY;
        //}
    }
}
canvas.ondblclick = mousedbl_click;
canvas.onmousedown = mouse_down;
canvas.onmouseup = mouse_up;
canvas.onmouseout = mouse_out
canvas.onmousemove = mouse_move;

let draw_objects = function() {
    context.clearRect(0, 0, canvas_width, canvas_height);
    load_objects();
    for (let object of objects) {
        //context.globalAlpha = 0.4;
        if (object.type == "rect") {
            context.fillStyle = object.color;
            context.fillRect(object.x, object.y, object.width, object.height);
            //context.fillStyle = object.fontColor;
            //context.font = "20px Georgia";
            //context.fillText(object.Text + object.Text + object.Text, object.x, object.y + (object.width) / 2, object.width);
        } else if (object.type == "text") {
            let lines = object.Text.split('\n');
            let space = 10;
            let padding = 5;
            context.fillStyle = object.color;
            object.width = space + find_max_width(lines);
            object.height = space + (lines.length * object.fontSize);
            context.fillRect(object.x, object.y, object.width, object.height);
            for (var i = 0; i < lines.length; i++) {

                let fillstr = "";
                if (object.isItalic) {
                    fillstr += "italic ";
                }
                if (object.isBold) {
                    fillstr += "bold ";
                }
                fillstr += object.fontSize + "px" + " " + object.fontFamily;
                context.fillStyle = object.fontColor;
                context.font = fillstr;
                context.fillText(lines[i], object.x + padding, object.y + ((i + 1) * object.fontSize), object.width);
            }
        } else if (object.type == "img") {
            context.drawImage(object.img, object.x, object.y, object.width, object.height);
        } else if (object.type == "circle" || object.type == "oval") {
            if (object.type == "oval") {
                context.scale(2, 1);
            }
            context.beginPath();
            context.fillStyle = object.color;
            context.arc(object.x, object.y, object.radius, object.sAngle, object.eAngle * Math.PI);
            context.fill();
        }
    }
    update_page();
}
let update_page = function() {
    if (currentPage >= 0) {
        var crntPage = "page" + currentPage;
        console.log(crntPage);
        document.getElementById(crntPage).src = document.getElementById('canvas').toDataURL();
    }
}
let load_objects = function() {
    if (pages.length < 1) {
        emptyObjects = [];
        pages.push(emptyObjects);
    }
    if (currentPage < 0) {
        currentPage = 0;
    }
    objects = pages[currentPage];
}
let find_max_width = function(lines) {
        let max_width = 0;
        for (var i = 0; i < lines.length; i++) {
            if (context.measureText(lines[i]).width > max_width) {
                max_width = context.measureText(lines[i]).width;
            }
        }
        return max_width;
    }
    //var _video = document.querySelectorAll("video");
    //_video.addEventListener('play', (event) => {
    //  if (this.custom == "yes") {
    //    console.log(_video);
    //  let object = objects[this.index];
    //context.drawImage(this, object.x, object.y, object.width, object.height);
    //}
    //});
draw_objects();