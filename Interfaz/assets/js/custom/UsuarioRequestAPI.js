
function performSignIn() {
    let headers = new Headers();

    headers.append('Content-Type', 'application/json');
    headers.append('Accept', 'application/json');
    headers.append('Authorization', 'Basic ' + base64.encode(username + ":" + password));
    headers.append('Origin', 'http://localhost:3000');

    fetch(sign_in, {
        mode: 'cors',
        credentials: 'include',
        method: 'POST',
        headers: headers
    })
        .then(response => response.json())
        .then(json => console.log(json))
        .catch(error => console.log('Authorization failed: ' + error.message));
}


//read
function consultarUsuario() {

    var request = new Request('https://localhost:44378/api/Usuario/obtenerUsuarios/', {
        method: 'get',
    });

    fetch(request)
        .then(function (response) {
            return response.text();

        })
        .then(function (data) {
            // alert(data);
            generarTablaUsuario(data);




        })
        .catch(function (err) {
            console.error(err);
        });
}





function generarTablaUsuario(data) {

    json1 = JSON.parse(data);


    tabla = document.getElementById("tablaListarUsuario");

    for (var i = 0; i < json1.data.length; i++) {

        tr = document.createElement("tr");


        texto = document.createTextNode(json1.data[i].id);
        td = document.createElement("td");
        td.setAttribute("class", "azulVerdePastel text-center text-xs font-weight-semibold");
        td.appendChild(texto);
        tr.appendChild(td);
        tabla.appendChild(tr);


        texto = document.createTextNode(json1.data[i].tipoDocUsuario);
        td = document.createElement("td");
        td.setAttribute("class", "azulVerdePastel text-center text-xs font-weight-semibold");
        td.appendChild(texto);
        tr.appendChild(td);
        tabla.appendChild(tr);


        texto = document.createTextNode(json1.data[i].numIdentificacionUsuario);
        td = document.createElement("td");
        td.setAttribute("class", "azulVerdePastel text-center text-xs font-weight-semibold");
        td.appendChild(texto);
        tr.appendChild(td);
        tabla.appendChild(tr);


        texto = document.createTextNode(json1.data[i].nombreUsuario);
        td = document.createElement("td");
        td.setAttribute("class", "azulVerdePastel text-center text-xs font-weight-semibold");
        td.appendChild(texto);
        tr.appendChild(td);
        tabla.appendChild(tr);


        texto = document.createTextNode(json1.data[i].apellidosUsuario);
        td = document.createElement("td");
        td.setAttribute("class", "azulVerdePastel text-center text-xs font-weight-semibold");
        td.appendChild(texto);
        tr.appendChild(td);
        tabla.appendChild(tr);


        texto = document.createTextNode(json1.data[i].loginUsuario);
        td = document.createElement("td");
        td.setAttribute("class", "azulVerdePastel text-center text-xs font-weight-semibold");
        td.appendChild(texto);
        tr.appendChild(td);
        tabla.appendChild(tr);


        texto = document.createTextNode(json1.data[i].passwordUsuario);
        td = document.createElement("td");
        td.setAttribute("class", "azulVerdePastel text-center text-xs font-weight-semibold");
        td.appendChild(texto);
        tr.appendChild(td);
        tabla.appendChild(tr);


        td = document.createElement("td");
        td.setAttribute("class", "text-center text-xs font-weight-semibold");

        aEdit = document.createElement("a")
        aEdit.setAttribute("href", "#")
        //aEdit.setAttribute("onclick", "abrirVentana('"+json1[clientes].cedula+"','"+json1[clientes].nombre+"','"+json1[clientes].apellido+"','"+json1[clientes].edad+"','"+json1[clientes].direccion+"','"+json1[clientes].telefono+"')")
        // aEdit.setAttribute("onclick", "pasarDatos('"+json1[paises].id+"')")
        aEdit.setAttribute("class", "text-primary font-weight-bold text-xs")
        aEdit.setAttribute("data-bs-toggle", "modal")
        aEdit.setAttribute("data-bs-target", "#modal-form-edit")
        texto = document.createTextNode("Editar");
        aEdit.appendChild(texto)
        td.appendChild(aEdit);
        spanEdit = document.createElement("span")
        spanEdit.setAttribute("class", "text-primary material-symbols-outlined")
        texto1 = document.createTextNode("edit");
        spanEdit.appendChild(texto1)
        td.appendChild(spanEdit);

        aDelete = document.createElement("a")
        aDelete.setAttribute("href", "#")
        aDelete.setAttribute("onclick", "eliminarUsuario('" + json1.data[i].id + "')")
        aDelete.setAttribute("class", "text-danger font-weight-bold text-xs")
        aDelete.setAttribute("data-bs-toggle", "tooltip")
        aDelete.setAttribute("data-bs-title", "Delete")
        texto = document.createTextNode("Eliminar");
        aDelete.appendChild(texto)
        td.appendChild(aDelete);
        spanDelete = document.createElement("span")
        spanDelete.setAttribute("class", "text-danger material-symbols-outlined")
        texto2 = document.createTextNode("restore_from_trash");
        spanDelete.appendChild(texto2)
        td.appendChild(spanDelete);


        tr.appendChild(td);
        tabla.appendChild(tr);
      } 


}




//create
function guardarUsuario() {

    var id = document.getElementById("id").value;
    var numIdentificacionUsuario=document.getElementById("numIdentificacionUsuario").value;
    var tipoDocUsuario = document.getElementById("tipoDocUsuario").value;
    var nombreUsuario = document.getElementById("nombreUsuario").value;
    var apellidosUsuario=document.getElementById("apellidosUsuario").value;
    var loginUsuario = document.getElementById("loginUsuario").value;
    var passwordUsuario = document.getElementById("passwordUsuario").value;

    var request = new Request('https://localhost:44378/api/Usuario/insertarUsuario/', {
        method: 'Post',
        headers: {
            // 'Authorization': 'Bearer <token>',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            id: id,
            numIdentificacionUsuario: numIdentificacionUsuario,
            tipoDocUsuario: tipoDocUsuario,
            nombreUsuario: nombreUsuario,
            apellidosUsuario: apellidosUsuario,
            loginUsuario: loginUsuario,
            passwordUsuario: passwordUsuario
        })

    });

    fetch(request)
        .then(function (response) {
            return response.text();
        })

        .then(function (data) {
            alert(data);
            window.location.reload()


        })
        .catch(function (err) {
            console.error(err);
        });
}




//delete
function eliminarUsuario(id) {

    var request = new Request('https://localhost:44378/api/Usuario/eliminarUsuario/'+id, {
        method: 'delete',


    });

    fetch(request)
        .then(function (response) {
            return response.text();
        })

        .then(function (data) {
            // alert(data);
            window.location.reload()


        })
        .catch(function (err) {
            console.error(err);
        });
}






//update
function actualizarUsuario() {

    var id = document.getElementById("idACT").value;
    var numIdentificacionUsuario=document.getElementById("numIdentificacionUsuarioACT").value;
    var tipoDocUsuario = document.getElementById("tipoDocUsuarioACT").value;
    var nombreUsuario = document.getElementById("nombreUsuarioACT").value;
    var apellidosUsuario=document.getElementById("apellidosUsuarioACT").value;
    var loginUsuario = document.getElementById("loginUsuarioACT").value;
    var passwordUsuario = document.getElementById("passwordUsuarioACT").value;

    var request = new Request('https://localhost:44378/api/Usuario/modificarUsuario/'+id, {
        method: 'Put',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            numIdentificacionUsuario: numIdentificacionUsuario,
            tipoDocUsuario: tipoDocUsuario,
            nombreUsuario: nombreUsuario,
            apellidosUsuario: apellidosUsuario,
            loginUsuario: loginUsuario,
            passwordUsuario: passwordUsuario
        })

    });

    fetch(request)
        .then(function (response) {
            return response.text();
        })

        .then(function (data) {
            alert(data);
            window.location.reload()

        })
        .catch(function (err) {
            console.error(err);
        });
}


