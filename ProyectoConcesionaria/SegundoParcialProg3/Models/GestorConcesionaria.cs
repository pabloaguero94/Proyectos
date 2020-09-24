using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SegundoParcialProg3.Models
{
    public class GestorConcesionaria
    {

        public void AgregarAuto(Auto nuevo)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=PABLITO\SQLDESARROLLO;Initial Catalog=Concesionaria;Integrated Security=True");
            conn.Open();
            SqlCommand comm = conn.CreateCommand();
            comm.CommandText = "insert into Autos(patente, idMarca, km, promocion, precio) values (@Patente, @IdMarca, @Km, @Promocion, @Precio)";
            comm.Parameters.Add(new SqlParameter("@Patente", nuevo.Patente));
            comm.Parameters.Add(new SqlParameter("@IdMarca", nuevo.IdMarca));
            comm.Parameters.Add(new SqlParameter("@Km", nuevo.Km));
            comm.Parameters.Add(new SqlParameter("@Promocion", nuevo.Promocion));
            comm.Parameters.Add(new SqlParameter("@Precio", nuevo.Precio));
            comm.ExecuteNonQuery();
            conn.Close();
        }


        public List<AutoMarca> ObtenerAutos()
        {
            List<AutoMarca> lista = new List<AutoMarca>();
            
            SqlConnection conn = new SqlConnection(@"Data Source=PABLITO\SQLDESARROLLO;Initial Catalog=Concesionaria;Integrated Security=True;");
            conn.Open();

            SqlCommand comm = conn.CreateCommand();
            comm.CommandText = "select idAuto,patente,nombre,km,promocion,precio from Autos a join Marcas m on a.idMarca=m.idMarca";

            SqlDataReader dr = comm.ExecuteReader();
            while (dr.Read())
            {
                int idAuto = dr.GetInt32(0);
                string patente = dr.GetString(1);
                string marca = dr.GetString(2);
                int km = dr.GetInt32(3);
                bool promocion = dr.GetBoolean(4);
                float precio = dr.GetFloat(5);


                AutoMarca autoM = new AutoMarca(idAuto, patente, marca, km, promocion, precio);
                lista.Add(autoM);
            }
            dr.Close();
            conn.Close();
            return lista;
        }

        public List<Marca> ObtenerMarcas()
        {
            List<Marca> lista = new List<Marca>();
            SqlConnection conn = new SqlConnection(@"Data Source=PABLITO\SQLDESARROLLO;Initial Catalog=Concesionaria;Integrated Security=True;");
            conn.Open();
            SqlCommand comm = conn.CreateCommand();
            comm.CommandText = "select * from Marcas";
            SqlDataReader dr = comm.ExecuteReader();
            while (dr.Read())
            {
                int id = dr.GetInt32(0);
                string nombre = dr.GetString(1);

                Marca m = new Marca(id, nombre);
                lista.Add(m);
            }
            dr.Close();
            conn.Close();
            return lista;
        }

        public List<AutoMarca> ObtenerAutosOfertados()
        {
            List<AutoMarca> lista = new List<AutoMarca>();
            SqlConnection conn = new SqlConnection(@"Data Source=PABLITO\SQLDESARROLLO;Initial Catalog=Concesionaria;Integrated Security=True;");
            conn.Open();

            SqlCommand comm = conn.CreateCommand();
            comm.CommandText = "select idAuto,patente,nombre,km,promocion,precio from Autos a join Marcas m on a.idMarca=m.idMarca where promocion=1";

            SqlDataReader dr = comm.ExecuteReader();
            while (dr.Read())
            {
                int idAuto = dr.GetInt32(0);
                string patente = dr.GetString(1);
                string marca = dr.GetString(2);
                int km = dr.GetInt32(3);
                bool promocion = dr.GetBoolean(4);
                float precio = dr.GetFloat(5);


                AutoMarca autoM = new AutoMarca(idAuto, patente, marca, km, promocion, precio);
                lista.Add(autoM);
            }
            dr.Close();
            conn.Close();
            return lista;
        }

        public AutoMarca ObtenerAutoUsado()
        {
            AutoMarca a = null;
            SqlConnection conn = new SqlConnection(@"Data Source=PABLITO\SQLDESARROLLO;Initial Catalog=Concesionaria;Integrated Security=True;");
            conn.Open();

            SqlCommand comm = conn.CreateCommand();
            comm.CommandText = "select idAuto,patente,nombre,km,promocion,precio from Autos a join Marcas m on a.idMarca=m.idMarca where km=(select min(km) from Autos);";

            SqlDataReader dr = comm.ExecuteReader();
            if (dr.Read())
            {
                int idAuto = dr.GetInt32(0);
                string patente = dr.GetString(1);
                string marca = dr.GetString(2);
                int km = dr.GetInt32(3);
                bool promocion = dr.GetBoolean(4);
                float precio = dr.GetFloat(5);

                a = new AutoMarca(idAuto, patente, marca, km, promocion, precio);
            }
            dr.Close();
            conn.Close();
            return a;
        }

    }
}