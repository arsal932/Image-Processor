let canvas = document.getElementById("canvas");
let context = canvas.getContext("2d");
canvas.width = window.innerWidth - 350;
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

let objects = [];
let current_object_index = null;
let is_dragging = false;
let startX;
let startY;

objects.push({ type: 'rect', x: 0, y: 0, width: 200, height: 200, color: 'red' });
objects.push({
    type: 'rect',
    x: 0,
    y: 0,
    width: 100,
    height: 100,
    color: 'blue'
});
objects.push({
    type: 'img',
    img: document.getElementById("image1"),
    x: 50,
    y: 10,
    width: 200,
    height: 200
});
let add_image_object = function(imgID) {
    objects.push({
        type: 'img',
        img: document.getElementById(imgID),
        x: 50,
        y: 10,
        width: 200,
        height: 200
    });
    draw_objects();
}
let add_shape_object = function(shape) {
    objects.push({
        type: shape,
        x: 0,
        y: 0,
        width: 100,
        height: 100,
        color: 'black'
    });
    draw_objects();
}
let default_form_open = function() {
    document.getElementById("templates_panel").style.display = "block";
}
default_form_open();
let is_mouse_in_object = function(x, y, object) {
    let object_left = object.x;
    let object_right = object.x + object.width;
    let object_top = object.y;
    let object_bottom = object.y + object.height;
    if (x > object_left && x < object_right && y > object_top && y < object_bottom) {
        return true;
    }
    return false;
}
let enable_elements = function(id) {
    document.getElementById(id).disabled = false;
}
let disable_elements = function(id) {
    document.getElementById(id).disabled = true;
}
let mouse_down = function(event) {
    event.preventDefault();
    disable_elements("_color");
    startX = parseInt(event.clientX - offset_x);
    startY = parseInt(event.clientY - offset_Y);
    let index = 0;
    for (let object of objects) {
        if (is_mouse_in_object(startX, startY, object)) {
            current_object_index = index;
            is_dragging = true;
            if (object.type != "img") {
                enable_elements("_color");
            }
            return;
        }
        index++;
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

        for (let object of objects) {
            let current_object = objects[current_object_index];
            current_object.x += dx;
            current_object.y += dy;
            draw_objects();
            startX = mouseX;
            startY = mouseY;
        }
    }
}

canvas.onmousedown = mouse_down;
canvas.onmouseup = mouse_up;
canvas.onmouseout = mouse_out
canvas.onmousemove = mouse_move;

let draw_objects = function() {
    context.clearRect(0, 0, canvas_width, canvas_height);
    for (let object of objects) {
        if (object.type == "rect") {
            context.fillStyle = object.color;
            context.fillRect(object.x, object.y, object.width, object.height);
        } else if (object.type == "img") {
            context.drawImage(object.img, object.x, object.y, object.width, object.height);
        }
    }
}
draw_objects();