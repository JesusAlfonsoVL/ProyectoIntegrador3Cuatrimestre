class ApiFetch {

    urlBase = "http://localhost:5000/"; //URL del proyecto

    Get = async (path) => {
        let url = this.urlBase + path;

        let requestInit ={
            method: "GET",
            headers: {
                "content-type": "application/json"
            }
        }

        let response = await fetch(url, requestInit);
        return response;

    }

    Post = async (path, data) => {
        let url = this.urlBase + path;
        //http://localhost:5000/User/CreateUser;
        console.log(url);
        //Fetch aplica el protocolo HTTP
        //Get  => Obtener o consultar información
        //Post => Guardar, Actualizar o Eliminar información

        let body ="{}";
        if(data)
             body = JSON.stringify(data);

        let requestInit ={
            method: "POST",
            body: body,
            headers: {
                "content-type": "application/json"
            }
        }

        let response = await fetch(url, requestInit);
        let json = await response.json();
        return json;
    }

    Update= async (path, data) => {
        let url = this.urlBase + path;

        let requestInit ={
            method: "POST",
            body: JSON.stringify(data),
            headers: {
                "content-type": "application/json"
            }
        }

        let response = await fetch(url, requestInit);
        let json = await response.json();
        return json;
    }

}