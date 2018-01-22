using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//importando librerias
using Clase_Videos;

namespace Aplica_Videos
{
    public partial class Frmvideos : Form
    {
        //Se genera un objeto objvideo de tipo Clase: Clase_videos
        Clase_Videos.Clsvideo objvideo = new Clase_Videos.Clsvideo();
        //se declarauna variable para la busqueda de videos
        string buscacodigo = "";
        
        //Se genera el metodo de listado videos
        //Variables
        string ycodformato, ycodgenero, ycodidioma, ycodpais;

        //Se genera un metodo para la busqueda de videos
        private void BusquedaVideo(){
        buscacodigo = Microsoft.VisualBasic.Interaction.InputBox("Ingrese Codigo de video","Pulse clic en aceptar");
            //Si el codigo si existe
            if (objvideo.MostrarCodigo(buscacodigo).Tables["selcodigo"].Rows.Count - 1>=0)
            {
                VideoEncontrado();
                MessageBox.Show("Codigo de Video encontrado", "Pulse clic en aceptar");
            btnactualizar.Enabled=true;
            ActivarObjetos();
            txtcodigo.Enabled = false;
            btncancelar.Enabled = true;
            txtvideo.Focus();
            }
            else
            {
                LimpiarObjetos();
                DesactivarObjetos();
                MessageBox.Show("Codigo de video no encontrado", "Pulse clic en aceptar");
                btncancelar.Enabled = false;
                btnactualizar.Enabled = false;
                btnbuscar.Focus();
             }
         }
        private void VideoEncontrado()
        {
            txtcodigo.Text = objvideo.BusquedaVideos(buscacodigo).Tables["buscavideos"].Rows[0][0].ToString();
            txtvideo.Text = objvideo.BusquedaVideos(buscacodigo).Tables["buscavideos"].Rows[0][1].ToString();
            txtprecio.Text = objvideo.BusquedaVideos(buscacodigo).Tables["buscavideos"].Rows[0][2].ToString();
            txtduracion.Text = objvideo.BusquedaVideos(buscacodigo).Tables["buscavideos"].Rows[0][3].ToString();
            txtstock.Text = objvideo.BusquedaVideos(buscacodigo).Tables["buscavideos"].Rows[0][4].ToString();
            cboformato.Text = objvideo.BusquedaVideos(buscacodigo).Tables["buscavideos"].Rows[0][5].ToString();
            cbogenero.Text = objvideo.BusquedaVideos(buscacodigo).Tables["buscavideos"].Rows[0][6].ToString();
            cboidioma.Text = objvideo.BusquedaVideos(buscacodigo).Tables["buscavideos"].Rows[0][7].ToString();
            cbopais.Text = objvideo.BusquedaVideos(buscacodigo).Tables["buscavideos"].Rows[0][8].ToString();
        }
        private void ListadoVideos()
        {
            dgvlista.DataSource = objvideo.ListaVideos().Tables["listavideos"];
        }
        private void anchocolumnas()
        {
            var x = dgvlista;
                x.Columns[0].Width=60;
                x.Columns[1].Width = 180;
                x.Columns[2].Width = 80;
                x.Columns[3].Width = 120;
                x.Columns[4].Width = 60;
                x.Columns[5].Width = 150;
                x.Columns[6].Width = 150;
                x.Columns[7].Width = 150;
                x.Columns[8].Width = 150;
        }
        private void DesactivarObjetos()
        {
            txtcodigo.Enabled = false;
            txtvideo.Enabled = false;
            txtprecio.Enabled = false;
            txtduracion.Enabled = false;
            txtstock.Enabled = false;
            cboformato.Enabled = false;
            cbogenero.Enabled = false;
            cboidioma.Enabled = false;
            cbopais.Enabled = false;
        }
        private void ActivarObjetos()
        {
            txtcodigo.Enabled = true;
            txtvideo.Enabled = true;
            txtprecio.Enabled = true;
            txtduracion.Enabled = true;
            txtstock.Enabled = true;
            cboformato.Enabled = true;
            cbogenero.Enabled = true;
            cboidioma.Enabled = true;
            cbopais.Enabled = true;
        }
        private void LimpiarObjetos()
        {
            txtcodigo.Text="";
            txtvideo.Text = "";
            txtprecio.Text = "";
            txtduracion.Text = "";
            txtstock.Text = "";
            cboformato.SelectedIndex = 0;
            cbogenero.SelectedIndex = 0;
            cboidioma.SelectedIndex = 0;
            cbopais.SelectedIndex = 0;
        }
        private void ListadoFormato()
        {
            cboformato.DataSource = objvideo.ListaFormato().Tables["listaformato"];
            //Lo que se muestra en el combobox
            cboformato.DisplayMember = "NOM_FORMATO";
            //El valor interno del elemento seleccionado
            cboformato.ValueMember = "COD_FORMATO";
        }
        private void ListadoGenero()
        {
            cbogenero.DataSource = objvideo.ListaGenero().Tables["listagenero"];
            //Lo que se muestra en el combobox
            cbogenero.DisplayMember = "NOM_GENERO";
            //El valor interno del elemento seleccionado
            cbogenero.ValueMember = "COD_GENERO";
        }
        private void ListadoIdioma()
        {
            cboidioma.DataSource = objvideo.ListaIdioma().Tables["listaidioma"];
            //Lo que se muestra en el combobox
            cboidioma.DisplayMember = "NOM_IDIOMA";
            //El valor interno del elemento seleccionado
            cboidioma.ValueMember = "COD_IDIOMA";
        }
        private void ListadoPais()
        {
            cbopais.DataSource = objvideo.ListaPais().Tables["listapais"];
            //Lo que se muestra en el combobox
            cbopais.DisplayMember = "NOM_PAIS";
            //El valor interno del elemento seleccionado
            cbopais.ValueMember = "COD_PAIS";
        }

        public Frmvideos()
        {
            InitializeComponent();
        }

        private void Frmvideos_Load(object sender, EventArgs e)
        {
            //Utilizando al metodo ListadoVideos
            ListadoVideos();
            anchocolumnas();
            //Utilizando el metodo DesactivarObjetos
            DesactivarObjetos();
            //Utilizando el metodo Listado Formato,Genero,Idioma y Pais
            ListadoFormato();
            ListadoGenero();
            ListadoIdioma();
            ListadoPais();

         }

        private void cboformato_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //Con el metodo Selected Value se captura el codigo
            //del elemento seleccionado
            ycodformato = cboformato.SelectedValue.ToString();
            //MessageBox.Show(ycodformato);

            //int numformato = cboformato.SelectedIndex;
           // MessageBox.Show(numformato.ToString());
        }

        private void cbogenero_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //Capturando el codigo seleccionado y se almacena  hacia la variable ycodgenero
            ycodgenero = cbogenero.SelectedValue.ToString();
        }
        private void cboidioma_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ycodidioma = cboidioma.SelectedValue.ToString();
        }
        private void cbopais_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ycodpais = cbopais.SelectedValue.ToString();
        }

        private void ActualizarVideos()
        {
            string mcodigo = txtcodigo.Text.ToUpper();
            string mvideo = txtvideo.Text.ToUpper();
            decimal mprecio = Decimal.Parse(txtprecio.Text);
            string mduracion = txtduracion.Text.ToUpper();
            int mstock = int.Parse(txtstock.Text);
            objvideo.ActualizarVideos(mcodigo, mvideo, mprecio, mduracion, mstock, ycodformato, ycodgenero, ycodidioma, ycodpais);
            ListadoVideos();
            MessageBox.Show("Video Actualizado", "Pulse clic en aceptar");
            LimpiarObjetos();
            DesactivarObjetos();
            btnnuevo.Enabled = true;
            btncancelar.Enabled = false;
            btnnuevo.Focus();
            btngrabar.Enabled = false;

            if (ycodformato == null)
            {
                MessageBox.Show("Seleccione Formato", "Pulse Clic En Aceptar");
                cboformato.Focus();
                //si la variable ycodgenero su valor es nulo entonces se envia un mensaje de error
                //significa que no seleccciono el ComboBox de Genero                             
            }
            else
            {
                if (ycodgenero == null)
                {
                    MessageBox.Show("Seleccione Genero", "Pulse Clic En Aceptar");
                    cbogenero.Focus();
                }
                else
                {
                    //si la variable ycodidioma su valor es nulo entonces se envia un mensaje de error
                    //significa que no seleccciono el ComboBox de Idioma
                    if (ycodidioma == null)
                    {
                        MessageBox.Show("Seleccione Idioma", "Pulse Clic En Aceptar");
                        cboidioma.Focus();
                    }
                    else
                    {
                        //si la variable ycodpais su valor es nulo entonces se envia un mensaje de error
                        //significa que no seleccciono el ComboBox de Pais
                        if (ycodpais == null)
                        {
                            MessageBox.Show("Seleccione Pais", "Pulse Clic En Aceptar");
                            cbopais.Focus();
                        }
                        else
                        {
                            //Si esta todo Ok se envia los datos a la tabla
                            string rcodigo = txtcodigo.Text.ToUpper();
                            string rvideo = txtvideo.Text.ToUpper();
                            decimal rprecio = Decimal.Parse(txtprecio.Text);
                            string rduracion = txtduracion.Text.ToUpper();
                            int rstock = int.Parse(txtstock.Text);
                            objvideo.ActualizarVideos(rcodigo, rvideo, rprecio, rduracion, rstock, ycodformato, ycodgenero, ycodidioma, ycodpais);
                            ListadoVideos();
                            MessageBox.Show("Video Registrado", "Pulse Clic En Aceptar");
                            LimpiarObjetos();
                            DesactivarObjetos();
                            btnnuevo.Enabled = true;
                            btncancelar.Enabled = false;
                            btngrabar.Enabled = false;
                            btnnuevo.Focus();
                        }
                    }
                }
            }              
        }

        private void GrabarVideos()
        {
            //Verificando si el codigo del Video Existe En La tabla
            //Si existe se muestra un mensaje que el Codigo de Video ya esta registgrado
            if(objvideo.MostrarCodigo(txtcodigo.Text.ToUpper()).Tables["selcodigo"].Rows.Count - 1>=0)
            {
                DetalleVideo();
                DesactivarObjetos();
                MessageBox.Show("Codigo del video ya registrado", "Pulse clic en Aceptar");
                ActivarObjetos();
                LimpiarObjetos();
                DesactivarObjetos();
                btnnuevo.Enabled = true;
                btncancelar.Enabled = false;
                btngrabar.Enabled = false;
                btnnuevo.Focus();
            }
            else
            {
                //Verificando si el cuadro de texto se encuentra vacio para ello se utiliza el metodo de comparacion Equals
                //que comparara el valor del cuadro de texto txtprecio con un valor vaciomes decir iguala el objeto txtprecio 
                //con el valor vacio si es asi envia un mensaje de error
                if (txtprecio.Text.Equals(""))
                {
                    MessageBox.Show("Ingrese Precio", "Pulse Clic En Aceptar");
                    txtprecio.Focus();
                }
                else
                {
                    //Es la misma idea del objeto txtprecio solo con el objeto stock
                    if (txtstock.Text.Equals(""))
                    {
                        MessageBox.Show("Ingrese Stock", "Pulse Clic En Aceptar");
                        txtstock.Focus();
                    }
                    else
                    {
                        //si la variable ycodformato su valor es nulo entonces se envia un mensaje de error
                        //significa que no seleccciono el ComboBox de Formato
                        if (ycodformato == null)
                        {
                            MessageBox.Show("Seleccione Formato", "Pulse Clic En Aceptar");
                            cboformato.Focus();
                            //si la variable ycodgenero su valor es nulo entonces se envia un mensaje de error
                            //significa que no seleccciono el ComboBox de Genero                             
                        }
                        else
                        {
                            if (ycodgenero == null)
                            {
                                MessageBox.Show("Seleccione Genero", "Pulse Clic En Aceptar");
                                cbogenero.Focus();
                            }
                            else
                            {
                                //si la variable ycodidioma su valor es nulo entonces se envia un mensaje de error
                                //significa que no seleccciono el ComboBox de Idioma
                                if (ycodidioma == null)
                                {
                                    MessageBox.Show("Seleccione Idioma", "Pulse Clic En Aceptar");
                                    cboidioma.Focus();
                                }
                                else
                                {
                                    //si la variable ycodpais su valor es nulo entonces se envia un mensaje de error
                                    //significa que no seleccciono el ComboBox de Pais
                                    if (ycodpais == null)
                                    {
                                        MessageBox.Show("Seleccione Pais", "Pulse Clic En Aceptar");
                                        cbopais.Focus();
                                    }
                                    else
                                    {
                                        //Si esta todo Ok se envia los datos a la tabla
                                        string mcodigo = txtcodigo.Text.ToUpper();
                                        string mvideo = txtvideo.Text.ToUpper();
                                        decimal mprecio = Decimal.Parse(txtprecio.Text);
                                        string mduracion = txtduracion.Text.ToUpper();
                                        int mstock = int.Parse(txtstock.Text);
                                        objvideo.IngresoVideos(mcodigo, mvideo, mprecio, mduracion, mstock, ycodformato, ycodgenero, ycodidioma, ycodpais);
                                        ListadoVideos();
                                        MessageBox.Show("Video Registrado", "Pulse Clic En Aceptar");
                                        LimpiarObjetos();
                                        DesactivarObjetos();
                                        btnnuevo.Enabled = true;
                                        btncancelar.Enabled = false;
                                        btngrabar.Enabled = false;
                                        btnnuevo.Focus();
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        private void DetalleVideo()
        {
            txtcodigo.Text = objvideo.BusquedaVideos(txtcodigo.Text.ToUpper()).Tables["buscavideos"].Rows[0][0].ToString();
            txtvideo.Text = objvideo.BusquedaVideos(txtcodigo.Text.ToUpper()).Tables["buscavideos"].Rows[0][1].ToString();
            txtprecio.Text = objvideo.BusquedaVideos(txtcodigo.Text.ToUpper()).Tables["buscavideos"].Rows[0][2].ToString();
            txtduracion.Text = objvideo.BusquedaVideos(txtcodigo.Text.ToUpper()).Tables["buscavideos"].Rows[0][3].ToString();
            txtstock.Text = objvideo.BusquedaVideos(txtcodigo.Text.ToUpper()).Tables["buscavideos"].Rows[0][4].ToString();
            cboformato.Text = objvideo.BusquedaVideos(txtcodigo.Text.ToUpper()).Tables["buscavideos"].Rows[0][5].ToString();
            cbogenero.Text = objvideo.BusquedaVideos(txtcodigo.Text.ToUpper()).Tables["buscavideos"].Rows[0][6].ToString();
            cboidioma.Text = objvideo.BusquedaVideos(txtcodigo.Text.ToUpper()).Tables["buscavideos"].Rows[0][7].ToString();
            cbopais.Text = objvideo.BusquedaVideos(txtcodigo.Text.ToUpper()).Tables["buscavideos"].Rows[0][8].ToString();
        }

        //Completando los botones
        private void btnnuevo_Click(object sender, EventArgs e)
        {
            ActivarObjetos();
            btnnuevo.Enabled = false;
            btncancelar.Enabled = true;
            btngrabar.Enabled = true;
            txtcodigo.Focus();
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            LimpiarObjetos();
            DesactivarObjetos();
            ListadoVideos();
            btnnuevo.Enabled = true;
            btncancelar.Enabled = false;
            btnactualizar.Enabled = false;
            btngrabar.Enabled = false;
            btnnuevo.Focus();

        }
        private void btngrabar_Click(object sender, EventArgs e)
        {
            GrabarVideos();
        }
        private void btnbuscar_Click(object sender, EventArgs e)
        {
            BusquedaVideo();
        }

        private void btnactualizar_Click(object sender, EventArgs e)
        {
            ActualizarVideos();
        }
        private void btnsalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
   }
}
