using System.Data.Common;
using System.Data;
using System;
using System.Data.SqlClient;
using Dapper;
using Domain;

namespace DataAccess
{
    public class UserDAO //Data Access Object
    {
       // private readonly string connectionString;

        public UserDAO()
        {

        }
        
        public User Login(User user)
        {
            using (var connection = new DbConnection().GetConnection())
            {
                var query = "select * from Teacher where Email=@Email and Password=@Password;";
                
                user = connection.QueryFirstOrDefault<User>(query, user);

                connection.Close();
                return user;
            }
        }

        public User CreateUser(User user)
        {
            //1.-Obtener la conexion a la BD
            using(SqlConnection connection = new DbConnection().GetConnection())
            {

                //2.- Generar un script insert
                //Buscar el Email, si no existe lo registro, si existe no lo registro 
                var query = @"
                    insert into Maestros values (@Nombre, @Direccion, @Correo, @Telefono, @Contraseña, @NoCubiculo);
                    select @@identity;
                ";

                 //3.- Enviar el script a ejecutar en la BD
                 //3.1 Query => Scripts que retomen información
                 //3.2 Execute => Nos interesa el numero de filas afectadas
                 int id = connection.QueryFirst<int>(query, user);
                 user.Id = id;
            //11:06--------------------------------------------------------------------------------
                 //4.- Cerrar la conexión
                 connection.Close();

                  //5.- Regresar el valor
                 return user;
            }
        }

        
        public bool UpdateUser(User user)
        {
            using (var connection = new DbConnection().GetConnection())
            {
                string query = @"
                    update Users set Name = @Name, Address = @Address, Phone = @Phone,
                         UserName = @UserName, Password = @Password
                    Where Id = @Id
                ";


                int rows = connection.Execute(query, user); //Ejecutar cuando no importa lo que devuelva pero diga que registros se afectaron
                //connection.Query(query);  Esta ligado a un select por lo que cuando se use un select se utiliza el Query
                connection.Close();

                if(rows >0)
                    return true;
                return false;
            }
        }

        public bool DeleteUser(int id){

            using (SqlConnection connection = new DbConnection().GetConnection())
            {
                string query = @"
                     delete Users where Id = @Id
                ";
                //Para primera opcion
                // int rows = connection.Execute(query, new {Id = id});

                query = "delete Users where Id = " + id;
                query = $"delete Users where Id = {id}";
                //Para segunda y tercera opción
                int rows = connection.Execute(query);

                if(rows > 0)
                   return true;
                return false;
            }
        }
    }
}
