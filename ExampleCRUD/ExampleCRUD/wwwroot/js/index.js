let apiFetch = new ApiFetch();
createUser = async (event) => {
    event.preventDefault(); //No recarga la pagina

    // 0.- Validar la información
    // 1.- Crear el objeto que voy a guardar
    let form = event.target;
    let user = new User(0, form.txtName.value, form.txtAddress.value, form.txtPhone.value,
        form.txtEmail.value, form.txtUserName.value, form.txtPassword.value);
    console.log("Objeto", user);
    
    // 2.- Enviar el objeto (user) creado al back-end

    user = await apiFetch.Post("User/CreateUser", user);
    if(user.Id > 0){
        alert("Usuario registrado");
        $("#myModal").modal("hide");
        $(".modal-backdrop").hide();
    }
    else{
        alert("Usuario no registrado");
    }
         //2.1 Obtener la información en el back-end
         //2.2 Enviar la información a la base de datos
         //2.3 Regresar la información
    // 3.- Validar la respuesta del back-end
}



login = async (event) => {

    event.preventDefault();

    let user = new User()
    user.Email = event.target.txtEmailLogin.value;
    user.Password = event.target.txtPasswordLogin.value;

    let response = await apiFetch.Get(`User/Login/${user.Email}/${user.Password}`);//Alt Gr + } = ``
    let json = await response.json();
    switch (response.status) {
        case 200:
            //Redirecciono
            localStorage.setItem("user", JSON.stringify(json));
            window.location = "http://" + window.location.host + "/html/User.html";
            break;
        case 404:
            alert(json.Message);
            break;
        default:
            break;
    }
}