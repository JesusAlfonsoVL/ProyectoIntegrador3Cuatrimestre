
let user = localStorage.getItem("user");
let apiFetch = new ApiFetch();
load = () => {
    if (!user)
          window.location = "http://" + window.location.host;
        user = JSON.parse(user);
        
        let tagNames = document.getElementsByClassName("lblName");
        for (let index = 0; index < tagNames.length; index++) {
            const element = tagNames[index];
            element.innerHTML = user.Name;
            
        }
        console.log(tagNames);


        txtName.value =  user.Name;
        txtAddress.value = user.Address;
        txtPhone.value = user.Phone;
        txtEmail.value = user.Email;
        txtUserName.value = user.UserName;
        txtPassword.value = user.Password;

}
updateUser = async (event) => {
    event.preventDefault();
    let form = event.target;
    user = new User(user.Id, form.txtName.value, user.Email, form.txtPhone.value,
        form.txtEmail.value, form.txtUserName.value, form.txtPassword.value);

    //let apiFetch = new ApiFetch();
    let response = await apiFetch.Post("User/UpdateUser", user);
    if(response.IsUpdated){
         alert("Usuario actualizado");
         localStorage.setItem("user", JSON.stringify(user));
    }
    else
         alert("No se pudo actualizar el usuario, intentelo mas tarde");
    

}

deleteUser = async () => {

   // let apiFetch = new ApiFetch();
    let response = await apiFetch.Post("User/DeleteUser/" + user.Id);

    if(response.IsDeleted)
        window.location = "http://"+ window.location.host;
        
    else
    {
      //Cerrar modal desde js
    $("#myModal").modal("hide");
    $(".modal-backdrop").hide();

     //Abrir modal desde js
    $("#myModalAlert").modal("show");
    $(".modal-backdrop").show();

    //abrir modal de error
    }
}