



//read
function  consultarCliente()
{
    // var cedula = 111;

    var request = new Request('https://localhost:7178/api/Cliente/', {
        method: 'get',
    });

    fetch(request)
    .then(function(response) {
        return response.text();
    })
    .then(function(data) {
        // alert(data);
generarTablaCliente(data);



   
    })
    .catch(function(err) {
        console.error(err);
    });
}



//read
function  consultarMascota()
{
    // var cedula = 111;

    var request = new Request('https://localhost:7178/api/Mascota/', {
        method: 'get',
    });

    fetch(request)
    .then(function(response) {
        return response.text();
    })
    .then(function(data) {
        // alert(data);
generarTablaMascota(data);



   
    })
    .catch(function(err) {
        console.error(err);
    });
}


function generarTablaCliente(data){

    json1=JSON.parse(data);

    
    tabla=document.getElementById("tablaListarCliente");
    for (var clientes in json1) {
        tr=document.createElement("tr");

        
        texto = document.createTextNode(json1[clientes].cedula);
        td=document.createElement("td");
        td.setAttribute("class", "azulVerdePastel text-center text-xs font-weight-semibold");
        td.appendChild(texto);
        tr.appendChild(td);
        tabla.appendChild(tr);

        texto = document.createTextNode(json1[clientes].nombre);
        td=document.createElement("td");
        td.setAttribute("class", "azulVerdePastel text-center text-xs font-weight-semibold");
        td.appendChild(texto);
        tr.appendChild(td);
        tabla.appendChild(tr);

        
        texto = document.createTextNode(json1[clientes].apellido);
        td=document.createElement("td");
        td.setAttribute("class", "azulVerdePastel text-center text-xs font-weight-semibold");
        td.appendChild(texto);
        tr.appendChild(td);
        tabla.appendChild(tr);

        
        texto = document.createTextNode(json1[clientes].edad);
        td=document.createElement("td");
        td.setAttribute("class", "azulVerdePastel text-center text-xs font-weight-semibold");
        td.appendChild(texto);
        tr.appendChild(td);
        tabla.appendChild(tr);

        
        texto = document.createTextNode(json1[clientes].direccion);
        td=document.createElement("td");
        td.setAttribute("class", "azulVerdePastel text-center text-xs font-weight-semibold");
        td.appendChild(texto);
        tr.appendChild(td);
        tabla.appendChild(tr);

        
        texto = document.createTextNode(json1[clientes].telefono);
        td=document.createElement("td");
        td.setAttribute("class", "azulVerdePastel text-center text-xs font-weight-semibold");
        td.appendChild(texto);
        tr.appendChild(td);
        tabla.appendChild(tr);


        td=document.createElement("td");
        td.setAttribute("class", "text-center text-xs font-weight-semibold");

        aEdit=document.createElement("a")
        aEdit.setAttribute("href", "#")
        //aEdit.setAttribute("onclick", "abrirVentana('"+json1[clientes].cedula+"','"+json1[clientes].nombre+"','"+json1[clientes].apellido+"','"+json1[clientes].edad+"','"+json1[clientes].direccion+"','"+json1[clientes].telefono+"')")
        aEdit.setAttribute("onclick", "pasarDatos('"+json1[clientes].cedula+"')")
        aEdit.setAttribute("class", "text-primary font-weight-bold text-xs")
        aEdit.setAttribute("data-bs-toggle", "modal")
        aEdit.setAttribute("data-bs-target", "#modal-form")
        texto = document.createTextNode("Editar");
        aEdit.appendChild(texto)
        td.appendChild(aEdit);
        spanEdit=document.createElement("span")
        spanEdit.setAttribute("class", "text-primary material-symbols-outlined")
        texto1 = document.createTextNode("edit");
        spanEdit.appendChild(texto1)
        td.appendChild(spanEdit);

        aDelete=document.createElement("a")
        aDelete.setAttribute("href", "#")
        aDelete.setAttribute("onclick", "eliminarCliente('"+json1[clientes].cedula+"')")
        aDelete.setAttribute("class", "text-danger font-weight-bold text-xs")
        aDelete.setAttribute("data-bs-toggle", "tooltip")
        aDelete.setAttribute("data-bs-title", "Delete")
        texto = document.createTextNode("Eliminar");
        aDelete.appendChild(texto)
        td.appendChild(aDelete);
        spanDelete=document.createElement("span")
        spanDelete.setAttribute("class", "text-danger material-symbols-outlined")
        texto2 = document.createTextNode("restore_from_trash");
        spanDelete.appendChild(texto2)
        td.appendChild(spanDelete);


        tr.appendChild(td);
        tabla.appendChild(tr);
        




  }

}



function generarTablaMascota(data){

    json1=JSON.parse(data);

    
    tabla=document.getElementById("tablaListarMascota");
    for (var mascotas in json1) {
        tr=document.createElement("tr");

        
        texto = document.createTextNode(json1[mascotas].codigo);
        td=document.createElement("td");
        td.setAttribute("class", "azulVerdePastel text-center text-xs font-weight-semibold");
        td.appendChild(texto);
        tr.appendChild(td);
        tabla.appendChild(tr);

        texto = document.createTextNode(json1[mascotas].nombre);
        td=document.createElement("td");
        td.setAttribute("class", "azulVerdePastel text-center text-xs font-weight-semibold");
        td.appendChild(texto);
        tr.appendChild(td);
        tabla.appendChild(tr);

        
        texto = document.createTextNode(json1[mascotas].edad);
        td=document.createElement("td");
        td.setAttribute("class", "azulVerdePastel text-center text-xs font-weight-semibold");
        td.appendChild(texto);
        tr.appendChild(td);
        tabla.appendChild(tr);

        
        texto = document.createTextNode(json1[mascotas].tipo);
        td=document.createElement("td");
        td.setAttribute("class", "azulVerdePastel text-center text-xs font-weight-semibold");
        td.appendChild(texto);
        tr.appendChild(td);
        tabla.appendChild(tr);


        td=document.createElement("td");
        td.setAttribute("class", "text-center text-xs font-weight-semibold");

        aEdit=document.createElement("a")
        aEdit.setAttribute("href", "#")
        //aEdit.setAttribute("onclick", "abrirVentana('"+json1[clientes].cedula+"','"+json1[clientes].nombre+"','"+json1[clientes].apellido+"','"+json1[clientes].edad+"','"+json1[clientes].direccion+"','"+json1[clientes].telefono+"')")
        aEdit.setAttribute("onclick", "pasarDatos('"+json1[mascotas].codigo+"')")
        aEdit.setAttribute("class", "text-primary font-weight-bold text-xs")
        aEdit.setAttribute("data-bs-toggle", "modal")
        aEdit.setAttribute("data-bs-target", "#modal-form")
        texto = document.createTextNode("Editar");
        aEdit.appendChild(texto)
        td.appendChild(aEdit);
        spanEdit=document.createElement("span")
        spanEdit.setAttribute("class", "text-primary material-symbols-outlined")
        texto1 = document.createTextNode("edit");
        spanEdit.appendChild(texto1)
        td.appendChild(spanEdit);

        aDelete=document.createElement("a")
        aDelete.setAttribute("href", "#")
        aDelete.setAttribute("onclick", "eliminarMascota('"+json1[mascotas].codigo+"')")
        aDelete.setAttribute("class", "text-danger font-weight-bold text-xs")
        aDelete.setAttribute("data-bs-toggle", "tooltip")
        aDelete.setAttribute("data-bs-title", "Delete")
        texto = document.createTextNode("Eliminar");
        aDelete.appendChild(texto)
        td.appendChild(aDelete);
        spanDelete=document.createElement("span")
        spanDelete.setAttribute("class", "text-danger material-symbols-outlined")
        texto2 = document.createTextNode("restore_from_trash");
        spanDelete.appendChild(texto2)
        td.appendChild(spanDelete);


        tr.appendChild(td);
        tabla.appendChild(tr);
        




  }

}



//create
function guardarCliente()
{
    
var cedula=document.getElementById("cedulaC").value;
var nombre=document.getElementById("nombreC").value;
var apellido=document.getElementById("apellidoC").value;
var edad=document.getElementById("edadC").value;
var direccion=document.getElementById("direccionC").value;
var telefono=document.getElementById("telefonoC").value;
// var id = Integer.parseInt(jsonObj.get("id"));

// var cedula="1053";
// var nombre="yon";
// var edad=23;

var request = new Request('https://localhost:7178/api/Cliente/', {
        method: 'Post',
        headers: {
            'Content-Type': 'application/json'
          },
            body: JSON.stringify({
              ced: cedula,
              nom: nombre,
              ape: apellido,
              eda: parseInt(edad),
              dir: direccion,
              tel:telefono
          })
       
    });

    fetch(request)
    .then(function(response) {
        return response.text();
    })
   
    .then(function(data) {
        alert(data);
        limpiarGuardarCliente()

      
    })
    .catch(function(err) {
        console.error(err);
    });
}



//create
function guardarMascota()
{
    
var codigo=document.getElementById("codigoM").value;
var nombre=document.getElementById("nombreM").value;
var edad=document.getElementById("edadM").value;
var tipo=document.getElementById("tipoM").value;
// var id = Integer.parseInt(jsonObj.get("id"));

// var cedula="1053";
// var nombre="yon";
// var edad=23;

var request = new Request('https://localhost:7178/api/Mascota/', {
        method: 'Post',
        headers: {
            'Content-Type': 'application/json'
          },
            body: JSON.stringify({
              cod: codigo,
              nom: nombre,
              eda: parseInt(edad),
              tip: tipo
          })
       
    });

    fetch(request)
    .then(function(response) {
        return response.text();
    })
   
    .then(function(data) {
        alert(data);
        // limpiarGuardarMascota()
        window.location.reload()

      
    })
    .catch(function(err) {
        console.error(err);
    });
}




//delete
function eliminarCliente(cedula)
{
    // var cedula=document.getElementById("idDelete").value;
    // var cedula="1053";

var request = new Request('https://localhost:7178/api/Cliente/', {
        method: 'delete',
        headers: {
            'Content-Type': 'application/json'
          },
            body: JSON.stringify({
              ced: cedula
          })
       
    });

    fetch(request)
    .then(function(response) {
        return response.text();
    })
   
    .then(function(data) {
        alert(data);
        window.location.reload()
 
      
    })
    .catch(function(err) {
        console.error(err);
    });
}



//delete
function eliminarMascota(codigo)
{
    // var cedula=document.getElementById("idDelete").value;
    // var cedula="1053";

var request = new Request('https://localhost:7178/api/Mascota/', {
        method: 'delete',
        headers: {
            'Content-Type': 'application/json'
          },
            body: JSON.stringify({
              cod: codigo
          })
       
    });

    fetch(request)
    .then(function(response) {
        return response.text();
    })
   
    .then(function(data) {
        alert(data);
        window.location.reload()
 
      
    })
    .catch(function(err) {
        console.error(err);
    });
}



//update
function actualizarCliente()
{

    var cedula=document.getElementById("cedulaUpdateC").value;
    var nombre=document.getElementById("nombreUpdateC").value;
    var apellido=document.getElementById("apellidoUpdateC").value;
    var edad=document.getElementById("edadUpdateC").value;
    var direccion=document.getElementById("direccionUpdateC").value;
    var telefono=document.getElementById("telefonoUpdateC").value;

// var id="1";
// var cedula="1053";
// var titulo="la hoja";
// var descripcion="la hoja cayo del arbol";

var request = new Request('https://localhost:7178/api/Cliente/', {
        method: 'Put',
        headers: {
            'Content-Type': 'application/json'
          },
            body: JSON.stringify({
                ced: cedula,
                nom: nombre,
                ape: apellido,
                eda: parseInt(edad),
                dir: direccion,
                tel:telefono
          })
       
    });

    fetch(request)
    .then(function(response) {
        return response.text();
    })
   
    .then(function(data) {
        //alert(data);
        window.location.reload()
      
    })
    .catch(function(err) {
        console.error(err);
    });
}


//update
function actualizarMascota()
{

    var codigo=document.getElementById("codigoUpdateM").value;
    var nombre=document.getElementById("nombreUpdateM").value;
    var edad=document.getElementById("edadUpdateM").value;
    var tipo=document.getElementById("tipoUpdateM").value;

// var id="1";
// var cedula="1053";
// var titulo="la hoja";
// var descripcion="la hoja cayo del arbol";

var request = new Request('https://localhost:7178/api/Mascota/', {
        method: 'Put',
        headers: {
            'Content-Type': 'application/json'
          },
            body: JSON.stringify({
                cod: codigo,
                nom: nombre,
                eda: parseInt(edad),
                tip: tipo
          })
       
    });

    fetch(request)
    .then(function(response) {
        return response.text();
    })
   
    .then(function(data) {
        //alert(data);
        window.location.reload()
      
    })
    .catch(function(err) {
        console.error(err);
    });
}



function limpiarGuardarCliente() {
    var cedula=document.getElementById("cedulaC");
    var nombre=document.getElementById("nombreC");
    var apellido=document.getElementById("apellidoC");
    var edad=document.getElementById("edadC");
    var direccion=document.getElementById("direccionC");
    var telefono=document.getElementById("telefonoC");
if (cedula.value !="") {
    cedula.value="";
    nombre.value="";
    apellido.value="";
    edad.value="";
    direccion.value="";
    telefono.value="";
}

}



function limpiarGuardarMascota() {
    var codigo=document.getElementById("codigoM");
    var nombre=document.getElementById("nombreM");
    var edad=document.getElementById("edadM");
    var tipo=document.getElementById("tipoM");
if (codigo.value !="") {
    codigo.value="";
    nombre.value="";
    edad.value="";
    // tipo.value="0";
    ("#selM").val("0");
}

}





function pasarDatos(cedula){
    $('#cedulaUpdate').val(cedula)
    
           
    }
    
    
    function abrirVentana(cedula, nombre, apellido, edad, direccion, telefono){
        // window.open('clienteEdit.html?cedula='+cedula+"&&nombre="+nombre+"&&apellido="+apellido+"&&edad="+edad+"&&direccion="+direccion+"&&telefono="+telefono,'popup','width=1024,height=768')
    
        var w = 1024;
        var h = 500;
        var left = Number((screen.width/2)-(w/2));
        var tops = Number((screen.height/2)-(h/2));
    
    window.open("clienteEdit.html?"+cedula+"&&nombre="+nombre+"&&apellido="+apellido+"&&edad="+edad+"&&direccion="+direccion+"&&telefono="+telefono,'', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width='+w+', height='+h+', top='+tops+', left='+left);
    
    }