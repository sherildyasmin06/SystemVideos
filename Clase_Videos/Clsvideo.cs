using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//importando librerias 
using System.Data;
using System.Data.SqlClient;

namespace Clase_Videos
{
    public class Clsvideo
    {
        //Generando el objeto cn tipo SqlConnecion
        SqlConnection cn = new SqlConnection("server=(local); initial catalog=SISTEMAVIDEOS;user id=sa;pwd=soporte@123");
        //Generando el objeto ds de tipo DataSet
        DataSet ds;
        //Generando el metodo ListaFomato
        public DataSet ListaFormato()
        {
            try
            {
                ds = new DataSet();
                SqlDataAdapter dalistaformato = new SqlDataAdapter();
                dalistaformato.SelectCommand = new SqlCommand();
                var x = dalistaformato.SelectCommand;
                x.Connection = cn;
                x.CommandType = CommandType.StoredProcedure;
                x.CommandText = "SP_LISTA_FORMATO";
                cn.Open();
                dalistaformato.Fill(ds, "listaformato");
                cn.Close();
            }
            catch (Exception e1)
            {
                
                e1.ToString();
            }
            return ds;
        }
        //Generando el metodo ListaGenero
        public DataSet ListaGenero()
        {
            try
            {
                ds = new DataSet();
                SqlDataAdapter dalistagenero = new SqlDataAdapter();
                dalistagenero.SelectCommand = new SqlCommand();
                var x = dalistagenero.SelectCommand;
                x.Connection = cn;
                x.CommandType = CommandType.StoredProcedure;
                x.CommandText = "SP_LISTA_GENERO";
                cn.Open();
                dalistagenero.Fill(ds, "listagenero");
                cn.Close();
            }
            catch (Exception e2)
            {

                e2.ToString();
            }
            return ds;
        }
        //Generendo el metodo ListaIdioma
        public DataSet ListaIdioma()
        {
            try
            {
                ds = new DataSet();
                SqlDataAdapter dalistaidioma = new SqlDataAdapter();
                dalistaidioma.SelectCommand = new SqlCommand();
                var x = dalistaidioma.SelectCommand;
                x.Connection = cn;
                x.CommandType = CommandType.StoredProcedure;
                x.CommandText = "SP_LISTA_IDIOMA";
                cn.Open();
                dalistaidioma.Fill(ds, "listaidioma");
                cn.Close();
            }
            catch (Exception e3)
            {

                e3.ToString();
            }
            return ds;
        }
        //Generando el metodo ListaPais
        public DataSet ListaPais()
        {
            try
            {
                ds = new DataSet();
                SqlDataAdapter dalistapais = new SqlDataAdapter();
                dalistapais.SelectCommand = new SqlCommand();
                var x = dalistapais.SelectCommand;
                x.Connection = cn;
                x.CommandType = CommandType.StoredProcedure;
                x.CommandText = "SP_LISTA_PAIS";
                cn.Open();
                dalistapais.Fill(ds, "listapais");
                cn.Close();
            }
            catch (Exception e4)
            {

                e4.ToString();
            }
            return ds;
        }
        //Generando el metod de ingreso de videos
        public void IngresoVideos(string vcod,string vnom,decimal vprecio,string vhoras,int vstock,string vcodformato,string vcodgenero,string vcodidioma,string vcodpais)
        {
            try
            {
                SqlDataAdapter daingreso = new SqlDataAdapter();
                daingreso.SelectCommand = new SqlCommand();
                var x = daingreso.SelectCommand;
                x.Connection = cn;
                x.CommandType = CommandType.StoredProcedure;
                x.CommandText = "SP_INGRESO_VIDEOS";
                x.Parameters.Add(new SqlParameter("@XCODVIDEO", SqlDbType.Char, 7)).Value = vcod;
                x.Parameters.Add(new SqlParameter("@XNOMVIDEO", SqlDbType.VarChar, 40)).Value = vnom;
                x.Parameters.Add(new SqlParameter("@XPRECVIDEO", SqlDbType.Decimal, 8)).Value = vprecio;
                x.Parameters.Add(new SqlParameter("@XHORASVIDEO", SqlDbType.VarChar, 20)).Value = vhoras;
                x.Parameters.Add(new SqlParameter("@XSTOCKVIDEO", SqlDbType.Int, 4)).Value = vstock;
                x.Parameters.Add(new SqlParameter("@XCODFORMATO", SqlDbType.VarChar, 7)).Value = vcodformato;
                x.Parameters.Add(new SqlParameter("@XCODGENERO", SqlDbType.Char, 7)).Value = vcodgenero;
                x.Parameters.Add(new SqlParameter("@XCODIDIOMA", SqlDbType.Char, 7)).Value = vcodidioma;
                x.Parameters.Add(new SqlParameter("@XCODPAIS", SqlDbType.Char, 7)).Value = vcodpais;

                cn.Open();
                daingreso.SelectCommand.ExecuteNonQuery();
                cn.Close();

            }
            catch (Exception e5)
            {

                e5.ToString();
            }
      }
        //Generando el Metodo ActualizarVideos
        public void ActualizarVideos(string vcod, string vnom, decimal vprecio, string vhoras, int vstock, string vcodformato, string vcodgenero, string vcodidioma, string vcodpais)
        {
            try
            {
                SqlDataAdapter daActualizaVideos = new SqlDataAdapter();
                daActualizaVideos.SelectCommand = new SqlCommand();
                var x = daActualizaVideos.SelectCommand;
                x.Connection = cn;
                x.CommandType = CommandType.StoredProcedure;
                x.CommandText = "SP_ACTUALIZAR_VIDEOS";
                x.Parameters.Add(new SqlParameter("@XCODVIDEO", SqlDbType.Char, 7)).Value = vcod;
                x.Parameters.Add(new SqlParameter("@XNOMVIDEO", SqlDbType.VarChar, 40)).Value = vnom;
                x.Parameters.Add(new SqlParameter("@XPRECVIDEO", SqlDbType.Decimal, 8)).Value = vprecio;
                x.Parameters.Add(new SqlParameter("@XHORASVIDEO", SqlDbType.VarChar, 20)).Value = vhoras;
                x.Parameters.Add(new SqlParameter("@XSTOCKVIDEO", SqlDbType.Int, 4)).Value = vstock;
                x.Parameters.Add(new SqlParameter("@XCODFORMATO", SqlDbType.VarChar, 7)).Value = vcodformato;
                x.Parameters.Add(new SqlParameter("@XCODGENERO", SqlDbType.Char, 7)).Value = vcodgenero;
                x.Parameters.Add(new SqlParameter("@XCODIDIOMA", SqlDbType.Char, 7)).Value = vcodidioma;
                x.Parameters.Add(new SqlParameter("@XCODPAIS", SqlDbType.Char, 7)).Value = vcodpais;

                cn.Open();
                daActualizaVideos.SelectCommand.ExecuteNonQuery();
                cn.Close();

            }
            catch (Exception e6)
            {

                e6.ToString();
            }
        }
        //GENERANDO EL METODO ListaVideos
        public DataSet ListaVideos()
        {
            try
            {
                ds = new DataSet();
                SqlDataAdapter dalistvideos = new SqlDataAdapter();
                dalistvideos.SelectCommand = new SqlCommand();
                var x = dalistvideos.SelectCommand;
                x.Connection = cn;
                x.CommandType = CommandType.StoredProcedure;
                x.CommandText = "SP_LISTA_VIDEOS";
                cn.Open();
                dalistvideos.Fill(ds, "listavideos");
                cn.Close();
            }
            catch (Exception e7)
            {

                e7.ToString();
            }
            return ds;
        }
        //Generando El Metodo BusquedaVideos
        public DataSet BusquedaVideos(string vcodvideo)
        {
            try
            {
                ds = new DataSet();
                SqlDataAdapter dabuscavideos = new SqlDataAdapter();
                dabuscavideos.SelectCommand = new SqlCommand();
                var x = dabuscavideos.SelectCommand;
                x.Connection = cn;
                x.CommandType = CommandType.StoredProcedure;
                x.CommandText = "SP_BUSQUEDA_VIDEOS";
                x.Parameters.Add(new SqlParameter("@XCODVIDEO", SqlDbType.Char, 7)).Value = vcodvideo;
                cn.Open();
                dabuscavideos.Fill(ds, "buscavideos");
                cn.Close();
            }
            catch (Exception e8)
            {

                e8.ToString();
            }
            return ds;
        }
        //Generando El Metodo MostrarCodigo
        public DataSet MostrarCodigo(string vcodvideo)
        {
            try
            {
                ds = new DataSet();
                SqlDataAdapter damostrarcodigo = new SqlDataAdapter();
                damostrarcodigo.SelectCommand = new SqlCommand();
                var x = damostrarcodigo.SelectCommand;
                x.Connection = cn;
                x.CommandType = CommandType.StoredProcedure;
                x.CommandText = "SP_MOSTRARCODIGOVIDEO";
                x.Parameters.Add(new SqlParameter("@XCODVIDEO", SqlDbType.Char, 7)).Value = vcodvideo;
                cn.Open();
                damostrarcodigo.Fill(ds, "selcodigo");
                cn.Close();
            }
            catch (Exception e9)
            {

                e9.ToString();
            }
            return ds;
        }

    }
}
