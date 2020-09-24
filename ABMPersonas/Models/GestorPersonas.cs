using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace ABMPersonas.Models
{
    public class GestorPersonas
    {

        public void AgregarPersona(Persona nueva) {
            // 1: Crear la conexion
            SqlConnection conn = new SqlConnection(@"Server=172.16.140.13;Database=Personas;User Id=alumno1w1;Password=alumno1w1;");
            conn.Open();
            // 2: Crear un objeto command y 
            // establecer la sentencia SQL
            SqlCommand comm = conn.CreateCommand();
            comm.CommandText = "insert into Personas(nombre, apellido, edad, estadoCivilId) values (@Nombre, @Apellido, @Edad, @estadoCivilId)";
            // 2: Asignar los parámetros de la sentencia
            comm.Parameters.Add(new SqlParameter("@Nombre",nueva.Nombre));
            comm.Parameters.Add(new SqlParameter("@Apellido",nueva.Apellido));
            comm.Parameters.Add(new SqlParameter("@Edad", nueva.Edad));
            comm.Parameters.Add(new SqlParameter("@EstadoCivilId", nueva.IdEstadoCivil));
            // 3: Ejecutar la sentencia
            comm.ExecuteNonQuery();
            // 4: Cerrar todo
            conn.Close();
        }

        public List<PersonaConEstadoCivil> ObtenerPersonas() {
            List<PersonaConEstadoCivil> lista = new List<PersonaConEstadoCivil>();
            // 1: Crear la conexion
            SqlConnection conn = new SqlConnection(@"Server=172.16.140.13;Database=Personas;User Id=alumno1w1;Password=alumno1w1;");
            conn.Open();
            // 2: Crear un objeto command y 
            // establecer la sentencia SQL
            SqlCommand comm = conn.CreateCommand();
            comm.CommandText = "select * from Personas p JOIN EstadoCivil e ON p.estadoCivilId = e.id";
            // 3: Ejecutar la sentencia
            SqlDataReader dr = comm.ExecuteReader();
            // 4: Recorrer el conjunto de filas
            while(dr.Read())
            {
                // Da una vuelta por cada fila
                int id = dr.GetInt32(0);
                string nombre = dr.GetString(1);
                string apellido = dr.GetString(2);
                int edad = dr.GetInt32(3);
                string nombreEstadoCivil = dr.GetString(6);

                //Persona p = new Persona(id, nombre, apellido, edad);
                //lista.Add(p);
                PersonaConEstadoCivil p = new PersonaConEstadoCivil(id, nombre, apellido, edad, nombreEstadoCivil);
                lista.Add(p);
            }
            // 5: Cerrar todo
            dr.Close();
            conn.Close();
            // 6: Retornar la lista
            return lista;
        }

        public void Eliminar(int id)
        {
            SqlConnection conn = new SqlConnection(@"Server=172.16.140.13;Database=Personas;User Id=alumno1w1;Password=alumno1w1;");
            conn.Open();

            SqlCommand comm = new SqlCommand("DELETE from Personas WHERE IdPersona=@id;", conn);
            comm.Parameters.Add(new SqlParameter("@id", id));

            comm.ExecuteNonQuery();
            conn.Close();
        }

        public Persona ObtenerPersona(int id)
        {
            Persona p = null;

            SqlConnection conn = new SqlConnection(@"Server=172.16.140.13;Database=Personas;User Id=alumno1w1;Password=alumno1w1;");
            conn.Open();
            
            SqlCommand comm = conn.CreateCommand();
            comm.CommandText = "select * from Personas where IdPersona=@id;";
            comm.Parameters.Add(new SqlParameter("@id", id));

            SqlDataReader dr = comm.ExecuteReader();
            if (dr.Read())
            {
                int idp = dr.GetInt32(0);
                string nombre = dr.GetString(1);
                string apellido = dr.GetString(2);
                int edad = dr.GetInt32(3);

                p = new Persona(idp, nombre, apellido, edad);
            }
            // 5: Cerrar todo
            dr.Close();
            conn.Close();
            // 6: Retornar la lista
            return p;
        }

        public void Modificar(Persona p)
        {
            SqlConnection conn = new SqlConnection(@"Server=172.16.140.13;Database=Personas;User Id=alumno1w1;Password=alumno1w1;");
            conn.Open();

            SqlCommand comm = new SqlCommand("update Personas set nombre=@nombre, apellido=@apellido, edad=@edad WHERE IdPersona=@id;", conn);
            comm.Parameters.Add(new SqlParameter("@nombre", p.Nombre));
            comm.Parameters.Add(new SqlParameter("@apellido", p.Apellido));
            comm.Parameters.Add(new SqlParameter("@edad", p.Edad));
            comm.Parameters.Add(new SqlParameter("@id", p.Id));

            comm.ExecuteNonQuery();
            conn.Close();
        }

        public List<EstadoCivil> ObtenerEstadosCiviles()
        {
            List<EstadoCivil> lista = new List<EstadoCivil>();
            // 1: Crear la conexion
            SqlConnection conn = new SqlConnection(@"Server=172.16.140.13;Database=Personas;User Id=alumno1w1;Password=alumno1w1;");
            conn.Open();
            // 2: Crear un objeto command y 
            // establecer la sentencia SQL
            SqlCommand comm = conn.CreateCommand();
            comm.CommandText = "select * from EstadoCivil";
            // 3: Ejecutar la sentencia
            SqlDataReader dr = comm.ExecuteReader();
            // 4: Recorrer el conjunto de filas
            while (dr.Read())
            {
                // Da una vuelta por cada fila
                int id = dr.GetInt32(0);
                string nombre = dr.GetString(1);
                
                EstadoCivil ec = new EstadoCivil(id, nombre);
                lista.Add(ec);
            }
            // 5: Cerrar todo
            dr.Close();
            conn.Close();
            // 6: Retornar la lista
            return lista;
        }
    }
}