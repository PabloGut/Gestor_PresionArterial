using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Web;
using Entidades.Clases;
using LogicaNegocio;

using Shiart_AppWeb.Reportes;
using Shiart_AppWeb.DatosDataset;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Web.Mvc;
using System.Diagnostics;
using iTextSharp.text.pdf.draw;

namespace Shiart_AppWeb.PaginasWeb
{
    public partial class HistoriaClinica : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Response.Cookies["Paciente"] == null)
            {
               // lblPacienteLogueado.Text = "Ingresar un usuario para ver su hitoria clínica";
            }
            else
            {
               // lblPacienteLogueado.Text = Request.Cookies["Paciente"]["Nombre"] + " " + Request.Cookies["Paciente"]["Apellido"];
            }
            
        }

        protected void btnGenerarInformeHistoriClinica_Click(object sender, EventArgs e)
        {

            //HttpCookie cookie = Request.Cookies["idHc"];
            //int idHc = Convert.ToInt32(cookie.Value);
            //DataSetHistoriaClinica ds = new DataSetHistoriaClinica();

            //ReportDocument rd = new ReportDocument();
            //rd.Load(Server.MapPath("~/Reportes/ReporteHistoriaClinica.rpt"));

            //rd.SetDataSource(PacienteLN.MostrarPacienteReporteHistoriaClinica(Convert.ToInt32(cookie.Value), ds));
            //crDatosHistoriaClinica.ReportSource = rd;
            //crDatosHistoriaClinica.RefreshReport();

            GenerarPDF();
            //agregarDatosTabla();

            //ReporteHistoriaClinica reporte = new ReporteHistoriaClinica();
            //PacienteLN.MostrarPacienteReporteHistoriaClinica(Convert.ToInt32(cookie.Value), ds);
            //reporte.SetDataSource(ds);
            //this.crDatosHistoriaClinica.ReportSource = reporte;
            //this.crDatosHistoriaClinica.RefreshReport();



            //Funciona!!!
            //Session["dataset"] = PacienteLN.MostrarPacienteReporteHistoriaClinica(Convert.ToInt32(cookie.Value), ds);
            //Response.Redirect("WebForm1.aspx");


        }
        public void PresentarReporteHistoriaClinica()
        {

            //HttpCookie cookie = Request.Cookies["idHc"];
            //int idHc = Convert.ToInt32(cookie.Value);
            //DataSetHistoriaClinica ds = new DataSetHistoriaClinica();

            //ReportDocument rd = new ReportDocument();
            //rd.Load(Server.MapPath("~/Reportes/ReporteHistoriaClinica.rpt"));

            //PacienteLN.MostrarPacienteReporteHistoriaClinica(idHc, ds);
            //rd.SetDataSource(PacienteLN.MostrarPacienteReporteHistoriaClinica(idHc, ds));
            //rd.Database.Tables["Paciente"].SetDataSource(ds.Tables["Paciente"]);
            //crDatosHistoriaClinica.ReportSource = rd;
            //crDatosHistoriaClinica.RefreshReport();

            //DataSetAntecedentesMorbidos am = new DataSetAntecedentesMorbidos();
            //ReportDocument rd2 = new ReportDocument();
            //rd2.Load(Server.MapPath("~/Reportes/AntecedentesMorbidos.rpt"));

            //rd2.SetDataSource(AntecedenteMorbidoLN.MostrarAntecedentesMorbidosEnfermedades(idHc, am));
            //am.Tables.Add(AntecedenteMorbidoLN.mostrarAntecedentesMorbidosEnfermedades(idHc));
            //rd2.Database.Tables["AntecedenteMorbido"].SetDataSource(am.Tables["AntecedentesMorbidosEnfermedades"]);
            //crDatosHistoriaClinica.ReportSource = rd2;
            //crDatosHistoriaClinica.RefreshReport();

         
            //if (cbAntecedentesMorbidos.Checked == true)
            //{
            //    DataSetAntecedentesMorbidos am = new DataSetAntecedentesMorbidos();
            //    AntecedenteMorbidoLN.MostrarAntecedentesMorbidosEnfermedades(idHc, am);

            //    am.Tables.Add(AntecedenteMorbidoLN.mostrarAntecedentesMorbidosEnfermedades(idHc));
            //    rd.Database.Tables["AntecedenteMorbido"].SetDataSource(am.Tables["AntecedentesMorbidosEnfermedades"]);
            //    crDatosHistoriaClinica.ReportSource = rd;
            //    crDatosHistoriaClinica.RefreshReport();
            //}

        }
        public void GenerarPDF()
        {
            HttpCookie cookie = Request.Cookies["idHc"];
            int idHc = Convert.ToInt32(cookie.Value);

            Paciente pacienteLogueado = PacienteLN.mostrarPacienteBuscado(idHc);

            Document document = new Document(iTextSharp.text.PageSize.A4, 50, 50, 50, 50);
            FileStream fs = new FileStream("C:/Users/usuario/HistoriaClinica.pdf", FileMode.Create);
            PdfWriter pw = PdfWriter.GetInstance(document,fs );

            document.Open();

            //Fuentes
            Font arialTitulo = new Font(FontFactory.GetFont("Arial", 28, Font.BOLD));
            Font arialSubtitulo = new Font(FontFactory.GetFont("Arial", 15, Font.BOLD));
            Font fuenteTexto = new Font(FontFactory.GetFont("Arial", 12, Font.NORMAL));
            Font fuenteTextoSubrayado = new Font(FontFactory.GetFont("Arial", 12, Font.UNDERLINE));

            //Agregar Titulo
            Paragraph titulo = new Paragraph("Historia Clínica", arialTitulo);
            titulo.Alignment = Element.ALIGN_CENTER;
            document.Add(titulo);
            document.Add(Chunk.NEWLINE);

            //Agregar Subtitulo
            Paragraph subtitulo = new Paragraph("Datos del Paciente",arialSubtitulo);
            subtitulo.Alignment = Element.ALIGN_LEFT;
            document.Add(subtitulo);
            document.Add(Chunk.NEWLINE);

            Paragraph parrafoDedatos = null;
            Phrase campo = null;
            Chunk chunk = null;

            String text = pacienteLogueado.nombre + ", " + pacienteLogueado.apellido;
            chunk = new Chunk("Nombre y apellido: ", fuenteTextoSubrayado);

            campo = new Phrase();
            campo.Font = fuenteTexto;
            campo.Add(chunk);
            campo.Add(text);

            parrafoDedatos = new Paragraph();
            parrafoDedatos.Add(campo);
            parrafoDedatos.Add(Chunk.TABBING);
            parrafoDedatos.Add(Chunk.TABBING);

            text = pacienteLogueado.fechaNacimiento.ToShortDateString();
            chunk = new Chunk("Fecha de Nacimiento: ", fuenteTextoSubrayado);

            campo = new Phrase();
            campo.Font = fuenteTexto;
            campo.Add(chunk);
            campo.Add(text);

            parrafoDedatos.Add(campo);
            document.Add(parrafoDedatos);

            document.Add(Chunk.NEWLINE);

            text = pacienteLogueado.tipoDoc.nombre;
            chunk = new Chunk("Tipo de Documento: ", fuenteTextoSubrayado);
            campo = new Phrase();

            campo = new Phrase();
            campo.Font = fuenteTexto;
            campo.Add(chunk);
            campo.Add(text);

            parrafoDedatos = new Paragraph();
            parrafoDedatos.Add(campo);
            parrafoDedatos.Add(Chunk.TABBING);
            parrafoDedatos.Add(Chunk.TABBING);
            parrafoDedatos.Add(Chunk.TABBING);

            text = Convert.ToString(pacienteLogueado.nroDoc);
            chunk = new Chunk("Número de documento: ", fuenteTextoSubrayado);
            campo = new Phrase();

            campo = new Phrase();
            campo.Font = fuenteTexto;
            campo.Add(chunk);
            campo.Add(text);

            parrafoDedatos.Add(campo);
            document.Add(parrafoDedatos);
            document.Add(Chunk.NEWLINE);
            
            text = Convert.ToString(pacienteLogueado.telefono);
            chunk = new Chunk("Teléfono: ", fuenteTextoSubrayado);
            campo = new Phrase();

            campo.Font = fuenteTexto;
            campo.Add(chunk);
            campo.Add(text);

            parrafoDedatos = new Paragraph();
            parrafoDedatos.Add(campo);

            parrafoDedatos.Add(Chunk.TABBING);
            parrafoDedatos.Add(Chunk.TABBING);
            parrafoDedatos.Add(Chunk.TABBING);
            parrafoDedatos.Add(Chunk.TABBING);

            text = Convert.ToString(pacienteLogueado.nroCelular);
            chunk = new Chunk("Celular: ", fuenteTextoSubrayado);
            campo = new Phrase();

            campo.Font = fuenteTexto;
            campo.Add(chunk);
            campo.Add(text);

            parrafoDedatos.Add(campo);

            document.Add(parrafoDedatos);

            document.Add(Chunk.NEWLINE);

            text = pacienteLogueado.mail;
            chunk = new Chunk("Email: ", fuenteTextoSubrayado);
            campo = new Phrase();

            campo.Font = fuenteTexto;
            campo.Add(chunk);
            campo.Add(text);

            parrafoDedatos = new Paragraph();
            parrafoDedatos.Add(campo);


            parrafoDedatos.Add(Chunk.TABBING);
            parrafoDedatos.Add(Chunk.TABBING);
            parrafoDedatos.Add(Chunk.TABBING);

            text = Convert.ToString(pacienteLogueado.altura);
            chunk = new Chunk("Altura: ", fuenteTextoSubrayado);
            campo = new Phrase();

            campo.Font = fuenteTexto;
            campo.Add(chunk);
            campo.Add(text + " cm");

            parrafoDedatos.Add(campo);


            parrafoDedatos.Add(Chunk.TABBING);
            parrafoDedatos.Add(Chunk.TABBING);

            text = Convert.ToString(pacienteLogueado.peso);
            chunk = new Chunk("  Peso: ", fuenteTextoSubrayado);
            campo = new Phrase();

            campo.Font = fuenteTexto;
            campo.Add(chunk);
            campo.Add(text + " Kgs");

            parrafoDedatos.Add(campo);

            document.Add(parrafoDedatos);
            document.Add(Chunk.NEWLINE);

            subtitulo = new Paragraph("Datos del Doctor a cargo del tratamiento", arialSubtitulo);
            subtitulo.Alignment = Element.ALIGN_LEFT;
            document.Add(subtitulo);
            document.Add(Chunk.NEWLINE);

            text = pacienteLogueado.medico.nombre + ", "+ pacienteLogueado.medico.apellido;
            chunk = new Chunk("Nombre y Apellido: ", fuenteTextoSubrayado);

            campo = new Phrase();
            campo.Font = fuenteTexto;
            campo.Add(chunk);
            campo.Add(text);

            parrafoDedatos = new Paragraph();
            parrafoDedatos.Add(campo);
            document.Add(parrafoDedatos);

            document.Add(Chunk.NEWLINE);
            document = generarLineaSeparacion(document,4f,100f);

            //AntecedentesMorbidos
            if (cbAntecedentesMorbidos.Checked == true)
            {
                document = generarTituloPDF("Antecedentes Mórbidos", document);
                document = generarDatosPDFAntecedentesMorbidosEnfermedades(document);
                document = generarDatosPDFAntecedentesMorbidosTraumatismos(document);
                document = generarDatosPDFAntecedentesMorbidosOperaciones(document);
            }
            //else
            //{
            //    document= generarLineaSinDatos(document, fuenteTexto);
            //}

            //AntecedentesGinecoObstetricos
            if (cbAntecedentesGinecoObstetricos.Checked == true)
            {
                document = generarTituloPDF("Antecedentes Gineco obstétricos", document);
                document = generarDatosPDFAntecedentesGinecoObstetricos(document);
            }
            //else
            //{
            //    document = generarLineaSinDatos(document, fuenteTexto);
            //    document = generarLineaSeparacion(document, 4f, 100f);
            //}


            //Antecedentes Patologicos Personales
           
            if(cbAntecedentesPersonales.Checked==true)
            {
                document = generarTituloPDF("Antecedentes Patológicos Personales", document);
                document = generarDatosPDFAntecedentesPatologicosPersonales(document);
            }
            //else
            //{
            //    document = generarLineaSinDatos(document, fuenteTexto);
            //    document = generarLineaSeparacion(document, 4f, 100f);
            //}

            //Antecedentes Patologicos Familiares
            if(cbAntecedentesPatologicosFamiliares.Checked==true)
            {
                document = generarTituloPDF("Antecedentes Patológicos Familiares", document);
                document = generarDatosPDFAntecedentesPatologicosFamiliares(document);
            }
            //else
            //{
            //    document = generarLineaSinDatos(document, fuenteTexto);
            //    document = generarLineaSeparacion(document, 4f, 100f);
            //}

            //Alergias
            if (cbAlergias.Checked == true)
            {
                document = generarTituloPDF("Alergias", document);
                document = generarDatosPDFAlergiasAlimentos(document);
                document = generarDatosPDFAlergiasSustanciaAmbiente(document);
                document = generarDatosPDFAlergiasSustanciaContactoPiel(document);
                document = generarDatosPDFAlergiasInsectos(document);
                document = generarDatosPDFAlergiasMedicamentos(document);
            }
            //else
            //{
            //    document = generarLineaSinDatos(document, fuenteTexto);
            //    document = generarLineaSeparacion(document, 4f, 100f);
            //}

            //Habitos
            if(cbHabitoTabaquismo.Checked==true || cbHabitoAlcoholismo.Checked == true || cbHabitoDrogasIlicitas.Checked == true || cbHabitoDrogasLicitas.Checked==true || cbHabitoActividadFisica.Checked == true)
            {
                document = generarTituloPDF("Hábitos", document);
            }

            if(cbHabitoTabaquismo.Checked==true)
            {
                document = generarDatosPDFHabitoTabaquismo(document);
            }

            if(cbHabitoAlcoholismo.Checked==true)
            {
 
                document = generarDatosPDFHabitoAlcoholismo(document);
            }
            if(cbHabitoDrogasIlicitas.Checked==true)
            {
                document = generarDatosPDFHabitoDrogasIlicitas(document);
            }
            if (cbHabitoDrogasLicitas.Checked == true)
            {
                document = generarDatosPDFHabitoMedicamento(document);
            }
            if(cbHabitoActividadFisica.Checked==true)
            {
                document = generarDatosPDFHabitoActividadFisica(document);
            }

            //Consultas
            if(cbConsultas.Checked==true)
            {
                document = generarTituloPDF("Atención en Consultorio", document);
                document = generarDatosPDFConsultas(document);
            }

            //Estudio diagnóstico por imagen
            if(cbEstudioDiagnosticoPorImagen.Checked==true)
            {
                document = generarTituloPDF("Información Prácticas y Estudios", document);
                document = generarDatosPDFMostrarEstudiosDiagnosticoPorImagen(document);
            }
            //Estudio Prácticas Complementarias
            if (cbPracticasComplementarias.Checked == true)
            {
                document = generarTituloPDF("Información Prácticas y Estudios", document);
                document = generarDatosPDFMostrarEstudiosPracticasComplementarias(document);
            }
            //Analisis Laboratorio
            if (cbAnalisisClinicos.Checked == true)
            {
                document = generarTituloPDF("Información Prácticas y Estudios", document);
                document = generarDatosPDFMostrarEstudiosAnalisisLaboratorio(document);
            }
            //Mostrar Tratamientos
            if (cbTratamientos.Checked == true)
            {
                document = generarTituloPDF("Tratamientos", document);
                document = generarDatosPDFMostrarTratamientos(document);
            }

            //Mostrar Tratamientos Medicamentos
            if (cbTratamientoMedicamento.Checked == true)
            {
                document = generarTituloPDF("Tratamiento Medicamentos", document);
                document = generarDatosPDFMostrarTratamientosMedicamento(document);
            }

            if(cbMedicionesPresionArterial.Checked== true)
            {
                document = generarTituloPDF("Mediciones de presión arterial", document);
                document = generarDatosPDFMostrarMedicionesPresionArterial(document);
            }

            if(cbExamenesGenerales.Checked==true)
            {
                document = generarTituloPDF("Resumen Exámenes Generales", document);
                document = GenerarDatosPDFExamenGeneral(document);
            }
            document.Close();
            Process.Start("C:/Users/usuario/HistoriaClinica.pdf");

        }
        public Document generarDatosPDFAntecedentesMorbidosEnfermedades(Document documento)
        {
            List<String> listaCampos = null;
            List<String> listaValores = null;
            String cadena1;
            String cadena2;
            String cadena3;
      
            Document resultado = null;

            HttpCookie cookie = Request.Cookies["idHc"];
            int idHc = Convert.ToInt32(cookie.Value);
            DataTable datosAntecedentesMorbidosEnfermedades = AntecedenteMorbidoLN.mostrarAntecedentesMorbidosEnfermedades(idHc);

            resultado = generarSubTituloPDF("Enfermedades", documento);
            if (datosAntecedentesMorbidosEnfermedades.Rows.Count == 0)
            {
                Font fuenteTexto = new Font(FontFactory.GetFont("Arial", 12, Font.NORMAL));
                resultado = generarLineaSinDatos(resultado, fuenteTexto);
                resultado = generarLineaSeparacion(resultado, 2f, 100f);
                return resultado;
            }

            for(int i=0;i< datosAntecedentesMorbidosEnfermedades.Rows.Count; i ++)
            {
                listaCampos = new List<string>();
                listaValores = new List<string>();

                cadena1 = "Fecha de registro: ";
                cadena2 = "Tipo de Antecedentes: ";
                
                listaCampos.Add(cadena1);
                listaCampos.Add(cadena2);

                DateTime fecha = Convert.ToDateTime(datosAntecedentesMorbidosEnfermedades.Rows[i]["Fecha de registro"]);

                listaValores.Add(fecha.ToShortDateString());
                listaValores.Add(Convert.ToString(datosAntecedentesMorbidosEnfermedades.Rows[i]["Tipo de Antecedente Mórbido"].ToString()));

                resultado = generarCampoPDF(listaCampos,listaValores,resultado,2);

                listaCampos = new List<string>();
                listaValores = new List<string>();

                cadena1 = "Nombre: ";
                cadena2 = "Evolucion: ";

                listaCampos.Add(cadena1);
                listaCampos.Add(cadena2);

                listaValores.Add(datosAntecedentesMorbidosEnfermedades.Rows[i]["Nombre"].ToString());
                listaValores.Add(datosAntecedentesMorbidosEnfermedades.Rows[i]["Evolución"].ToString());

                resultado = generarCampoPDF(listaCampos, listaValores, resultado,4);

                listaCampos = new List<string>();
                listaValores = new List<string>();

                cadena1 = "Tratamiento: ";
                cadena2 = "Tiempo transcurrido: ";

                listaCampos.Add(cadena1);
                listaCampos.Add(cadena2);
                listaValores.Add(datosAntecedentesMorbidosEnfermedades.Rows[i]["Tratamiento"].ToString());
                listaValores.Add(datosAntecedentesMorbidosEnfermedades.Rows[i]["Cantidad de tiempo en que ocurrió"].ToString());

                resultado = generarCampoPDF(listaCampos, listaValores, resultado,2);

                generarLineaSeparacion(resultado, 2f, 100f);
            }
            resultado.Add(Chunk.NEWLINE);
            return resultado;
        }
        public Document generarDatosPDFAntecedentesMorbidosTraumatismos(Document documento)
        {
            List<String> listaCampos = null;
            List<String> listaValores = null;
            String cadena1;
            String cadena2;
            String cadena3;

            Document resultado = null;

            HttpCookie cookie = Request.Cookies["idHc"];
            int idHc = Convert.ToInt32(cookie.Value);
            DataTable datosAntecedentesMorbidosTraumatismos = AntecedenteMorbidoLN.mostrarAntecedentesMorbidosTraumatismos(idHc);

            resultado = generarSubTituloPDF("Traumatismos", documento);
            if (datosAntecedentesMorbidosTraumatismos.Rows.Count == 0)
            {
                Font fuenteTexto = new Font(FontFactory.GetFont("Arial", 12, Font.NORMAL));
                resultado = generarLineaSinDatos(resultado, fuenteTexto);
                resultado = generarLineaSeparacion(resultado, 2f, 100f);
                return resultado;
            }
                

            for (int i = 0; i < datosAntecedentesMorbidosTraumatismos.Rows.Count; i++)
            {
                listaCampos = new List<string>();
                listaValores = new List<string>();

                cadena1 = "Fecha de registro: ";
                cadena2 = "Tipo de Antecedentes: ";

                listaCampos.Add(cadena1);
                listaCampos.Add(cadena2);

                DateTime fecha = Convert.ToDateTime(datosAntecedentesMorbidosTraumatismos.Rows[i]["Fecha de registro"]);

                listaValores.Add(fecha.ToShortDateString());
                listaValores.Add(Convert.ToString(datosAntecedentesMorbidosTraumatismos.Rows[i]["Tipo de Antecedente Mórbido"].ToString()));

                resultado = generarCampoPDF(listaCampos, listaValores, resultado, 2);

                listaCampos = new List<string>();
                listaValores = new List<string>();

                cadena1 = "Nombre: ";
                cadena2 = "Evolucion: ";

                listaCampos.Add(cadena1);
                listaCampos.Add(cadena2);

                listaValores.Add(datosAntecedentesMorbidosTraumatismos.Rows[i]["Nombre"].ToString());
                listaValores.Add(datosAntecedentesMorbidosTraumatismos.Rows[i]["Evolución"].ToString());

                resultado = generarCampoPDF(listaCampos, listaValores, resultado, 4);

                listaCampos = new List<string>();
                listaValores = new List<string>();

                cadena1 = "Tratamiento: ";
                cadena2 = "Tiempo transcurrido: ";

                listaCampos.Add(cadena1);
                listaCampos.Add(cadena2);
                listaValores.Add(datosAntecedentesMorbidosTraumatismos.Rows[i]["Tratamiento"].ToString());
                listaValores.Add(datosAntecedentesMorbidosTraumatismos.Rows[i]["Cantidad de tiempo en que ocurrió"].ToString());

                resultado = generarCampoPDF(listaCampos, listaValores, resultado, 2);

                generarLineaSeparacion(resultado, 2f, 100f);
            }
            resultado.Add(Chunk.NEWLINE);
            return resultado;


        }
        public Document generarDatosPDFAntecedentesMorbidosOperaciones(Document documento)
        {
            List<String> listaCampos = null;
            List<String> listaValores = null;
            String cadena1;
            String cadena2;
            String cadena3;

            Document resultado = null;

            HttpCookie cookie = Request.Cookies["idHc"];
            int idHc = Convert.ToInt32(cookie.Value);
            DataTable datosAntecedentesMorbidosOperaciones = AntecedenteMorbidoLN.mostrarAntecedentesMorbidosOperaciones(idHc);

            resultado = generarSubTituloPDF("Operaciones", documento);
            if (datosAntecedentesMorbidosOperaciones.Rows.Count == 0)
            {
                Font fuenteTexto = new Font(FontFactory.GetFont("Arial", 12, Font.NORMAL));
                resultado = generarLineaSinDatos(resultado, fuenteTexto);
                resultado = generarLineaSeparacion(resultado, 2f, 100f);
                return resultado;
            }

            for (int i = 0; i < datosAntecedentesMorbidosOperaciones.Rows.Count; i++)
            {
                listaCampos = new List<string>();
                listaValores = new List<string>();

                cadena1 = "Fecha de registro: ";
                cadena2 = "Tipo de Antecedentes: ";

                listaCampos.Add(cadena1);
                listaCampos.Add(cadena2);

                DateTime fecha = Convert.ToDateTime(datosAntecedentesMorbidosOperaciones.Rows[i]["Fecha de registro"]);

                listaValores.Add(fecha.ToShortDateString());
                listaValores.Add(Convert.ToString(datosAntecedentesMorbidosOperaciones.Rows[i]["Tipo de Antecedente Mórbido"].ToString()));

                resultado = generarCampoPDF(listaCampos, listaValores, resultado, 2);

                listaCampos = new List<string>();
                listaValores = new List<string>();

                cadena1 = "Nombre: ";
                cadena2 = "Evolucion: ";

                listaCampos.Add(cadena1);
                listaCampos.Add(cadena2);

                listaValores.Add(datosAntecedentesMorbidosOperaciones.Rows[i]["Nombre"].ToString());
                listaValores.Add(datosAntecedentesMorbidosOperaciones.Rows[i]["Evolución"].ToString());

                resultado = generarCampoPDF(listaCampos, listaValores, resultado, 4);

                listaCampos = new List<string>();
                listaValores = new List<string>();

                cadena1 = "Tratamiento: ";
                cadena2 = "Tiempo transcurrido: ";

                listaCampos.Add(cadena1);
                listaCampos.Add(cadena2);
                listaValores.Add(datosAntecedentesMorbidosOperaciones.Rows[i]["Tratamiento"].ToString());
                listaValores.Add(datosAntecedentesMorbidosOperaciones.Rows[i]["Cantidad de tiempo en que ocurrió"].ToString());

                resultado = generarCampoPDF(listaCampos, listaValores, resultado, 2);

                generarLineaSeparacion(resultado, 2f, 100f);
            }
            resultado.Add(Chunk.NEWLINE);
            return resultado;

        }
        public Document generarDatosPDFAntecedentesGinecoObstetricos(Document documento)
        {
            List<String> listaCampos = null;
            List<String> listaValores = null;
            String cadena1;
            String cadena2;
            String cadena3;

            Document resultado = null;

            HttpCookie cookie = Request.Cookies["idHc"];
            int idHc = Convert.ToInt32(cookie.Value);
            DataTable datosAntecedentesGinecoObstetricos = AntecedenteGinecoObstetricoLN.mostrarAntecedenteGinecoObtetrico(idHc);

            resultado = generarSubTituloPDF("Informacion Embarazos/Abortos", documento);
            if (datosAntecedentesGinecoObstetricos ==null || datosAntecedentesGinecoObstetricos.Rows.Count == 0)
            {
                Font fuenteTexto = new Font(FontFactory.GetFont("Arial", 12, Font.NORMAL));
                resultado = generarLineaSinDatos(resultado, fuenteTexto);
                resultado = generarLineaSeparacion(resultado, 2f, 100f);
                return resultado;
            }
            for (int i = 0; i < datosAntecedentesGinecoObstetricos.Rows.Count; i++)
            {
                listaCampos = new List<string>();
                listaValores = new List<string>();

                cadena1 = "Fecha de registro: ";
                cadena2 = "'Cantidad de embarazos: ";

                listaCampos.Add(cadena1);
                listaCampos.Add(cadena2);

                DateTime fecha = Convert.ToDateTime(datosAntecedentesGinecoObstetricos.Rows[i]["Fecha de registro"]);

                listaValores.Add(fecha.ToShortDateString());
                listaValores.Add(Convert.ToString(datosAntecedentesGinecoObstetricos.Rows[i]["Cantidad de embarazos"].ToString()));

                resultado = generarCampoPDF(listaCampos, listaValores, resultado, 2);

                listaCampos = new List<string>();
                listaValores = new List<string>();

                cadena1 = " Cantidad de embarazos prematuros: ";
                cadena2 = "Cantidad de embarazos a término: ";

                listaCampos.Add(cadena1);
                listaCampos.Add(cadena2);

                listaValores.Add(datosAntecedentesGinecoObstetricos.Rows[i]["Cantidad de embarazos prematuros"].ToString());
                listaValores.Add(datosAntecedentesGinecoObstetricos.Rows[i]["Cantidad de embarazos a término"].ToString());

                resultado = generarCampoPDF(listaCampos, listaValores, resultado, 4);

                listaCampos = new List<string>();
                listaValores = new List<string>();

                cadena1 = "Cantidad de embarazos postérmino: ";
                cadena2 = "Cantidad de abortos: ";

                listaCampos.Add(cadena1);
                listaCampos.Add(cadena2);
                listaValores.Add(datosAntecedentesGinecoObstetricos.Rows[i]["Cantidad de embarazos postérmino"].ToString());
                listaValores.Add(datosAntecedentesGinecoObstetricos.Rows[i]["Cantidad de abortos"].ToString());

                resultado = generarCampoPDF(listaCampos, listaValores, resultado, 2);

                listaCampos = new List<string>();
                listaValores = new List<string>();

                cadena1 = "Abortos provocados: ";
                cadena2 = "Abortos espontaneos: ";

                listaCampos.Add(cadena1);
                listaCampos.Add(cadena2);

                listaValores.Add(datosAntecedentesGinecoObstetricos.Rows[i]["Abortos provocados"].ToString());
                listaValores.Add(datosAntecedentesGinecoObstetricos.Rows[i]["Abortos espontaneos"].ToString());

                resultado = generarCampoPDF(listaCampos, listaValores, resultado, 4);

                listaCampos = new List<string>();
                listaValores = new List<string>();

                cadena1 = "Número de hijos vivos: ";
                cadena2 = "Problemas asociados al embarazo: ";

                listaCampos.Add(cadena1);
                listaCampos.Add(cadena2);

                listaValores.Add(datosAntecedentesGinecoObstetricos.Rows[i]["Número de hijos vivos"].ToString());
                listaValores.Add(datosAntecedentesGinecoObstetricos.Rows[i]["Problemas asociados al embarazo"].ToString());

                resultado = generarCampoPDF(listaCampos, listaValores, resultado, 4);

                generarLineaSeparacion(resultado, 2f, 100f);
            }
            resultado.Add(Chunk.NEWLINE);
            return resultado;
        }
        public Document generarDatosPDFAntecedentesPatologicosPersonales(Document documento)
        {
            List<String> listaCampos = null;
            List<String> listaValores = null;
            String cadena1;
            String cadena2;
            String cadena3;

            HttpCookie cookie = Request.Cookies["idHc"];
            int idHc = Convert.ToInt32(cookie.Value);
            DataTable datosAntecedentesPatologicosPersonales = AntecedentePatologicoPersonalLN.mostrarAntecedentesPatologicosPersonales(idHc);
            Document resultado = documento;
            //resultado = generarSubTituloPDF("Antecedentes Patológicos Personales", documento);
            if (datosAntecedentesPatologicosPersonales.Rows.Count == 0)
            {
                Font fuenteTexto = new Font(FontFactory.GetFont("Arial", 12, Font.NORMAL));
                resultado = generarLineaSinDatos(resultado, fuenteTexto);
                resultado = generarLineaSeparacion(resultado, 2f, 100f);
                return resultado;
            }

            for (int i = 0; i < datosAntecedentesPatologicosPersonales.Rows.Count; i++)
            {
                listaCampos = new List<string>();
                listaValores = new List<string>();

                cadena1 = "Fecha de registro: ";
                cadena2 = "Enfermedades: ";

                listaCampos.Add(cadena1);
                listaCampos.Add(cadena2);

                DateTime fecha = Convert.ToDateTime(datosAntecedentesPatologicosPersonales.Rows[i]["Fecha de registro"]);

                listaValores.Add(fecha.ToShortDateString());
                listaValores.Add(Convert.ToString(datosAntecedentesPatologicosPersonales.Rows[i]["Enfermedades"].ToString()));

                resultado = generarCampoPDF(listaCampos, listaValores, resultado, 3,true);

                listaCampos = new List<string>();
                listaValores = new List<string>();

                cadena1 = "Otras Enfermedades: ";

                listaCampos.Add(cadena1);

                if(string.IsNullOrEmpty(datosAntecedentesPatologicosPersonales.Rows[i]["Otras Enfermedades"].ToString()))
                {
                    Font fuenteTexto = new Font(FontFactory.GetFont("Arial", 12, Font.NORMAL));
                    listaValores.Add("N/A");
                    resultado = generarCampoPDF(listaCampos, listaValores, resultado,2);
                }
                else
                {
                   listaValores.Add(datosAntecedentesPatologicosPersonales.Rows[i]["Otras Enfermedades"].ToString());
                   resultado = generarCampoPDF(listaCampos, listaValores, resultado, 4);
                }

                listaCampos = new List<string>();
                listaValores = new List<string>();

                resultado=generarLineaSeparacion(resultado, 2f, 100f);
            }
            resultado.Add(Chunk.NEWLINE);
            return resultado;
        }
        public Document generarDatosPDFAntecedentesPatologicosFamiliares(Document documento)
        {
            List<String> listaCampos = null;
            List<String> listaValores = null;
            String cadena1;
            String cadena2;
            String cadena3;

            HttpCookie cookie = Request.Cookies["idHc"];
            int idHc = Convert.ToInt32(cookie.Value);
            DataTable datosAntecedentesPatologicosFamiliares = AntecedenteFamiliarLN.MostrarAntecedentesFamiliares(idHc);
            Document resultado = documento;
            if (datosAntecedentesPatologicosFamiliares.Rows.Count == 0)
            {
                Font fuenteTexto = new Font(FontFactory.GetFont("Arial", 12, Font.NORMAL));
                resultado = generarLineaSinDatos(resultado, fuenteTexto);
                resultado = generarLineaSeparacion(resultado, 2f, 100f);
                return resultado;
            }

            for (int i = 0; i < datosAntecedentesPatologicosFamiliares.Rows.Count; i++)
            {
                listaCampos = new List<string>();
                listaValores = new List<string>();

                cadena1 = "Fecha de registro: ";
                cadena2 = "Familiar: ";

                listaCampos.Add(cadena1);
                listaCampos.Add(cadena2);

                DateTime fecha = Convert.ToDateTime(datosAntecedentesPatologicosFamiliares.Rows[i]["Fecha de registro"]);
                listaValores.Add(fecha.ToShortDateString());

                listaValores.Add(Convert.ToString(datosAntecedentesPatologicosFamiliares.Rows[i]["Familiar"].ToString()));

                resultado = generarCampoPDF(listaCampos, listaValores, resultado, 2);

                listaCampos = new List<string>();
                listaValores = new List<string>();

                cadena1 = "Vive: ";
                cadena2 = "Enfermedades: ";

                listaCampos.Add(cadena1);
                listaCampos.Add(cadena2);

                listaValores.Add(datosAntecedentesPatologicosFamiliares.Rows[i]["Vive"].ToString());
                listaValores.Add(datosAntecedentesPatologicosFamiliares.Rows[i]["Enfermedades"].ToString());

                resultado = generarCampoPDF(listaCampos, listaValores, resultado, 2,true);

                listaCampos = new List<string>();
                listaValores = new List<string>();

                cadena1 = "Otras enfermedades: ";
                listaCampos.Add(cadena1);
                if (string.IsNullOrEmpty(datosAntecedentesPatologicosFamiliares.Rows[i]["Otras Enfermedades"].ToString()))
                {
                    Font fuenteTexto = new Font(FontFactory.GetFont("Arial", 12, Font.NORMAL));
                    listaValores.Add("N/A");
                    resultado = generarCampoPDF(listaCampos, listaValores, resultado, 2);
                }
                else
                {
                    listaValores.Add(datosAntecedentesPatologicosFamiliares.Rows[i]["Otras Enfermedades"].ToString());
                    resultado = generarCampoPDF(listaCampos, listaValores, resultado, 4);
                }
              
                listaCampos = new List<string>();
                listaValores = new List<string>();

                cadena1 = "Causa de muerte: ";
                listaCampos.Add(cadena1);
                if (string.IsNullOrEmpty(datosAntecedentesPatologicosFamiliares.Rows[i]["Causa de Muerte"].ToString()))
                {
                    Font fuenteTexto = new Font(FontFactory.GetFont("Arial", 12, Font.NORMAL));
                    listaValores.Add("N/A");
                    resultado = generarCampoPDF(listaCampos, listaValores, resultado, 2);
                }
                else
                {
                    listaValores.Add(datosAntecedentesPatologicosFamiliares.Rows[i]["Causa de Muerte"].ToString());
                    resultado = generarCampoPDF(listaCampos, listaValores, resultado, 4);
                }
 
                listaCampos = new List<string>();
                listaValores = new List<string>();

                cadena1 = "Observaciones: ";
                listaCampos.Add(cadena1);

                if (string.IsNullOrEmpty(datosAntecedentesPatologicosFamiliares.Rows[i]["Observaciones"].ToString()))
                {
                    Font fuenteTexto = new Font(FontFactory.GetFont("Arial", 12, Font.NORMAL));
                    listaValores.Add("N/A");
                    resultado = generarCampoPDF(listaCampos, listaValores, resultado, 2);
                }
                else
                {
                    listaValores.Add(datosAntecedentesPatologicosFamiliares.Rows[i]["Observaciones"].ToString());
                    resultado = generarCampoPDF(listaCampos, listaValores, resultado, 4);
                }

                listaCampos = new List<string>();
                listaValores = new List<string>();

                resultado = generarLineaSeparacion(resultado, 2f, 100f);
            }
            resultado.Add(Chunk.NEWLINE);
            return resultado;
        }
        public Document generarDatosPDFAlergiasAlimentos(Document documento)
        {
            List<String> listaCampos = null;
            List<String> listaValores = null;
            String cadena1;
            String cadena2;
            String cadena3;

            HttpCookie cookie = Request.Cookies["idHc"];
            int idHc = Convert.ToInt32(cookie.Value);
            DataTable datosAlergias = AlergiaAlimentoLN.mostrarAlergiasAlimentos(idHc);

            Document resultado = generarSubTituloPDF("Alergia Alimentos", documento); ;
            if (datosAlergias.Rows.Count == 0)
            {
                Font fuenteTexto = new Font(FontFactory.GetFont("Arial", 12, Font.NORMAL));
                resultado = generarLineaSinDatos(resultado, fuenteTexto);
                resultado = generarLineaSeparacion(resultado, 2f, 100f);
                return resultado;
            }

            for (int i = 0; i < datosAlergias.Rows.Count; i++)
            {
                listaCampos = new List<string>();
                listaValores = new List<string>();

                cadena1 = "Fecha de registro: ";
                cadena2 = "Nombre del alérgeno: ";

                listaCampos.Add(cadena1);
                listaCampos.Add(cadena2);

                DateTime fecha = Convert.ToDateTime(datosAlergias.Rows[i]["Fecha de registro"]);
                listaValores.Add(fecha.ToShortDateString());

                listaValores.Add(Convert.ToString(datosAlergias.Rows[i]["Nombre del alérgeno"].ToString()));

                resultado = generarCampoPDF(listaCampos, listaValores, resultado, 2);

                listaCampos = new List<string>();
                listaValores = new List<string>();

                cadena1 = "Efectos de la alergia: ";
                listaCampos.Add(cadena1);
                if (string.IsNullOrEmpty(datosAlergias.Rows[i]["Efectos de la alergia"].ToString()))
                {
                    Font fuenteTexto = new Font(FontFactory.GetFont("Arial", 12, Font.NORMAL));
                    listaValores.Add("N/A");
                    resultado = generarCampoPDF(listaCampos, listaValores, resultado, 2);
                }
                else
                {
                    listaValores.Add(datosAlergias.Rows[i]["Efectos de la alergia"].ToString());
                    resultado = generarCampoPDF(listaCampos, listaValores, resultado, 4);
                }

                resultado = generarLineaSeparacion(resultado, 2f, 100f);

                listaCampos = new List<string>();
                listaValores = new List<string>();

                resultado = generarLineaSeparacion(resultado, 2f, 100f);
            }
            resultado.Add(Chunk.NEWLINE);
            return resultado;
        }
        public Document generarDatosPDFAlergiasSustanciaAmbiente(Document documento)
        {
            List<String> listaCampos = null;
            List<String> listaValores = null;
            String cadena1;
            String cadena2;
            String cadena3;

            HttpCookie cookie = Request.Cookies["idHc"];
            int idHc = Convert.ToInt32(cookie.Value);
            DataTable datosAlergias = AlergiaSustanciaAmbienteLN.mostrarAlergiasSustanciaAmbiente(idHc);

            Document resultado = generarSubTituloPDF("Alergia Sustancia del ambiente", documento);
            if (datosAlergias.Rows.Count == 0)
            {
                Font fuenteTexto = new Font(FontFactory.GetFont("Arial", 12, Font.NORMAL));
                resultado = generarLineaSinDatos(resultado, fuenteTexto);
                resultado = generarLineaSeparacion(resultado, 2f, 100f);
                return resultado;
            }

            for (int i = 0; i < datosAlergias.Rows.Count; i++)
            {
                listaCampos = new List<string>();
                listaValores = new List<string>();

                cadena1 = "Fecha de registro: ";
                cadena2 = "Nombre del alérgeno: ";

                listaCampos.Add(cadena1);
                listaCampos.Add(cadena2);

                DateTime fecha = Convert.ToDateTime(datosAlergias.Rows[i]["Fecha de registro"]);
                listaValores.Add(fecha.ToShortDateString());

                listaValores.Add(Convert.ToString(datosAlergias.Rows[i]["Nombre del alérgeno"].ToString()));

                resultado = generarCampoPDF(listaCampos, listaValores, resultado, 2);

                listaCampos = new List<string>();
                listaValores = new List<string>();

                cadena1 = "Efectos de la alergia: ";
                listaCampos.Add(cadena1);
                if (string.IsNullOrEmpty(datosAlergias.Rows[i]["Efectos de la alergia"].ToString()))
                {
                    Font fuenteTexto = new Font(FontFactory.GetFont("Arial", 12, Font.NORMAL));
                    listaValores.Add("N/A");
                    resultado = generarCampoPDF(listaCampos, listaValores, resultado, 2);
                }
                else
                {
                    listaValores.Add(datosAlergias.Rows[i]["Efectos de la alergia"].ToString());
                    resultado = generarCampoPDF(listaCampos, listaValores, resultado, 4);
                }

                resultado = generarLineaSeparacion(resultado, 2f, 100f);

                listaCampos = new List<string>();
                listaValores = new List<string>();

                resultado = generarLineaSeparacion(resultado, 2f, 100f);
            }
            resultado.Add(Chunk.NEWLINE);
            return resultado;
        }
        public Document generarDatosPDFAlergiasSustanciaContactoPiel(Document documento)
        {
            List<String> listaCampos = null;
            List<String> listaValores = null;
            String cadena1;
            String cadena2;
            String cadena3;

            HttpCookie cookie = Request.Cookies["idHc"];
            int idHc = Convert.ToInt32(cookie.Value);
            DataTable datosAlergias = AlergiaSustanciaContactoPielLN.mostrarAlergiasSustanciaContactoPiel(idHc);
            Document resultado = generarSubTituloPDF("Alergia Sustancia en Contacto con la Piel", documento);
            if (datosAlergias.Rows.Count == 0)
            {
                Font fuenteTexto = new Font(FontFactory.GetFont("Arial", 12, Font.NORMAL));
                resultado = generarLineaSinDatos(resultado, fuenteTexto);
                resultado = generarLineaSeparacion(resultado, 2f, 100f);
                return resultado;
            }

            for (int i = 0; i < datosAlergias.Rows.Count; i++)
            {
                listaCampos = new List<string>();
                listaValores = new List<string>();

                cadena1 = "Fecha de registro: ";
                cadena2 = "Nombre del alérgeno: ";

                listaCampos.Add(cadena1);
                listaCampos.Add(cadena2);

                DateTime fecha = Convert.ToDateTime(datosAlergias.Rows[i]["Fecha de registro"]);
                listaValores.Add(fecha.ToShortDateString());

                listaValores.Add(Convert.ToString(datosAlergias.Rows[i]["Nombre del alérgeno"].ToString()));

                resultado = generarCampoPDF(listaCampos, listaValores, resultado, 2);

                listaCampos = new List<string>();
                listaValores = new List<string>();

                cadena1 = "Efectos de la alergia: ";
                listaCampos.Add(cadena1);
                if (string.IsNullOrEmpty(datosAlergias.Rows[i]["Efectos de la alergia"].ToString()))
                {
                    Font fuenteTexto = new Font(FontFactory.GetFont("Arial", 12, Font.NORMAL));
                    listaValores.Add("N/A");
                    resultado = generarCampoPDF(listaCampos, listaValores, resultado, 2);
                }
                else
                {
                    listaValores.Add(datosAlergias.Rows[i]["Efectos de la alergia"].ToString());
                    resultado = generarCampoPDF(listaCampos, listaValores, resultado, 4);
                }

                resultado = generarLineaSeparacion(resultado, 2f, 100f);

                listaCampos = new List<string>();
                listaValores = new List<string>();

                resultado = generarLineaSeparacion(resultado, 2f, 100f);
            }
            resultado.Add(Chunk.NEWLINE);
            return resultado;
        }
        public Document generarDatosPDFAlergiasInsectos(Document documento)
        {
            List<String> listaCampos = null;
            List<String> listaValores = null;
            String cadena1;
            String cadena2;
            String cadena3;

            HttpCookie cookie = Request.Cookies["idHc"];
            int idHc = Convert.ToInt32(cookie.Value);
            DataTable datosAlergias = AlergiaInsectoLN.mostrarAlergiasInsectos(idHc);
            Document resultado = generarSubTituloPDF("Alergia Insectos", documento);
            if (datosAlergias.Rows.Count == 0)
            {
                Font fuenteTexto = new Font(FontFactory.GetFont("Arial", 12, Font.NORMAL));
                resultado = generarLineaSinDatos(resultado, fuenteTexto);
                resultado = generarLineaSeparacion(resultado, 2f, 100f);
                return resultado;
            }

            for (int i = 0; i < datosAlergias.Rows.Count; i++)
            {
                listaCampos = new List<string>();
                listaValores = new List<string>();

                cadena1 = "Fecha de registro: ";
                cadena2 = "Nombre del alérgeno: ";

                listaCampos.Add(cadena1);
                listaCampos.Add(cadena2);

                DateTime fecha = Convert.ToDateTime(datosAlergias.Rows[i]["Fecha de registro"]);
                listaValores.Add(fecha.ToShortDateString());

                listaValores.Add(Convert.ToString(datosAlergias.Rows[i]["Nombre del alérgeno"].ToString()));

                resultado = generarCampoPDF(listaCampos, listaValores, resultado, 2);

                listaCampos = new List<string>();
                listaValores = new List<string>();

                cadena1 = "Efectos de la alergia: ";
                listaCampos.Add(cadena1);
                if (string.IsNullOrEmpty(datosAlergias.Rows[i]["Efectos de la alergia"].ToString()))
                {
                    Font fuenteTexto = new Font(FontFactory.GetFont("Arial", 12, Font.NORMAL));
                    listaValores.Add("N/A");
                    resultado = generarCampoPDF(listaCampos, listaValores, resultado, 2);
                }
                else
                {
                    listaValores.Add(datosAlergias.Rows[i]["Efectos de la alergia"].ToString());
                    resultado = generarCampoPDF(listaCampos, listaValores, resultado, 4);
                }

                resultado = generarLineaSeparacion(resultado, 2f, 100f);

                listaCampos = new List<string>();
                listaValores = new List<string>();

                resultado = generarLineaSeparacion(resultado, 2f, 100f);
            }
            resultado.Add(Chunk.NEWLINE);
            return resultado;
        }
        public Document generarDatosPDFAlergiasMedicamentos(Document documento)
        {
            List<String> listaCampos = null;
            List<String> listaValores = null;
            String cadena1;
            String cadena2;
            String cadena3;

            HttpCookie cookie = Request.Cookies["idHc"];
            int idHc = Convert.ToInt32(cookie.Value);
            DataTable datosAlergias = AlergiaMedicamentoLN.mostrarAlergiasMedicamentos(idHc);
            Document resultado = generarSubTituloPDF("Alergia Medicamentos", documento);
            if (datosAlergias.Rows.Count == 0)
            {
                Font fuenteTexto = new Font(FontFactory.GetFont("Arial", 12, Font.NORMAL));
                resultado = generarLineaSinDatos(resultado, fuenteTexto);
                resultado = generarLineaSeparacion(resultado, 2f, 100f);
                return resultado;
            }

            for (int i = 0; i < datosAlergias.Rows.Count; i++)
            {
                listaCampos = new List<string>();
                listaValores = new List<string>();

                cadena1 = "Fecha de registro: ";
                cadena2 = "Nombre del alérgeno: ";

                listaCampos.Add(cadena1);
                listaCampos.Add(cadena2);

                DateTime fecha = Convert.ToDateTime(datosAlergias.Rows[i]["Fecha de registro"]);
                listaValores.Add(fecha.ToShortDateString());

                listaValores.Add(Convert.ToString(datosAlergias.Rows[i]["Nombre del alérgeno"].ToString()));

                resultado = generarCampoPDF(listaCampos, listaValores, resultado, 2);

                listaCampos = new List<string>();
                listaValores = new List<string>();

                cadena1 = "Efectos de la alergia: ";
                listaCampos.Add(cadena1);
                if (string.IsNullOrEmpty(datosAlergias.Rows[i]["Efectos de la alergia"].ToString()))
                {
                    Font fuenteTexto = new Font(FontFactory.GetFont("Arial", 12, Font.NORMAL));
                    listaValores.Add("N/A");
                    resultado = generarCampoPDF(listaCampos, listaValores, resultado, 2);
                }
                else
                {
                    listaValores.Add(datosAlergias.Rows[i]["Efectos de la alergia"].ToString());
                    resultado = generarCampoPDF(listaCampos, listaValores, resultado, 4);
                }

                resultado = generarLineaSeparacion(resultado, 2f, 100f);

                listaCampos = new List<string>();
                listaValores = new List<string>();

                resultado = generarLineaSeparacion(resultado, 2f, 100f);
            }
            resultado.Add(Chunk.NEWLINE);
            return resultado;
        }
        public Document generarDatosPDFHabitoTabaquismo(Document documento)
        {
            List<String> listaCampos = null;
            List<String> listaValores = null;
            String cadena1;
            String cadena2;
            String cadena3;

            HttpCookie cookie = Request.Cookies["idHc"];
            int idHc = Convert.ToInt32(cookie.Value);
            DataTable datosHabitos = HabitoTabaquismoLN.MostrarHabitosTabaquismo(idHc);
            Document resultado = generarSubTituloPDF("Hábitos Tabaquismo", documento);
            if (datosHabitos.Rows.Count == 0)
            {
                Font fuenteTexto = new Font(FontFactory.GetFont("Arial", 12, Font.NORMAL));
                resultado = generarLineaSinDatos(resultado, fuenteTexto);
                resultado = generarLineaSeparacion(resultado, 2f, 100f);
                return resultado;
            }

            for (int i = 0; i < datosHabitos.Rows.Count; i++)
            {
                listaCampos = new List<string>();
                listaValores = new List<string>();

                cadena1 = "Fecha de registro: ";
                cadena2 = "Nombre: ";

                listaCampos.Add(cadena1);
                listaCampos.Add(cadena2);

                DateTime fecha = Convert.ToDateTime(datosHabitos.Rows[i]["fechaRegistro"]);
                listaValores.Add(fecha.ToShortDateString());

                listaValores.Add(Convert.ToString(datosHabitos.Rows[i]["Nombre"].ToString()));

                resultado = generarCampoPDF(listaCampos, listaValores, resultado, 2);

                listaCampos = new List<string>();
                listaValores = new List<string>();

                cadena1 = "Consumo: ";

                listaCampos.Add(cadena1);

                String descripcionConsumo= datosHabitos.Rows[i]["cantidad"].ToString() + " " + datosHabitos.Rows[i]["Nombre"].ToString() + " por " + datosHabitos.Rows[i]["Unidad de Tiempo"].ToString();
                listaValores.Add(descripcionConsumo);

                resultado = generarCampoPDF(listaCampos, listaValores, resultado, 2);

                listaCampos = new List<string>();
                listaValores = new List<string>();

                cadena1 = "Años Fumando: ";

                listaCampos.Add(cadena1);

                listaValores.Add(datosHabitos.Rows[i]["añosFumando"].ToString());

                resultado = generarCampoPDF(listaCampos, listaValores, resultado, 2);

                listaCampos = new List<string>();
                listaValores = new List<string>();

                resultado = generarLineaSeparacion(resultado, 2f, 100f);
            }
            resultado.Add(Chunk.NEWLINE);
            return resultado;
        }
        public Document generarDatosPDFHabitoAlcoholismo(Document documento)
        {
            List<String> listaCampos = null;
            List<String> listaValores = null;
            String cadena1;
            String cadena2;
            String cadena3;

            HttpCookie cookie = Request.Cookies["idHc"];
            int idHc = Convert.ToInt32(cookie.Value);
            DataTable datosHabitos = HabitoAlcoholismoLN.MostrarHabitosAlcoholismo(idHc);
            Document resultado = generarSubTituloPDF("Hábitos Alcoholismo", documento);
            if (datosHabitos.Rows.Count == 0)
            {
                Font fuenteTexto = new Font(FontFactory.GetFont("Arial", 12, Font.NORMAL));
                resultado = generarLineaSinDatos(resultado, fuenteTexto);
                resultado = generarLineaSeparacion(resultado, 2f, 100f);
                return resultado;
            }

            for (int i = 0; i < datosHabitos.Rows.Count; i++)
            {
                listaCampos = new List<string>();
                listaValores = new List<string>();

                cadena1 = "Fecha de registro: ";
                cadena2 = "Nombre bebida: ";

                listaCampos.Add(cadena1);
                listaCampos.Add(cadena2);

                DateTime fecha = Convert.ToDateTime(datosHabitos.Rows[i]["Fecha de Registro"]);
                listaValores.Add(fecha.ToShortDateString());

                listaValores.Add(Convert.ToString(datosHabitos.Rows[i]["Nombre Bebida"].ToString()));

                resultado = generarCampoPDF(listaCampos, listaValores, resultado, 2);


                listaCampos = new List<string>();
                listaValores = new List<string>();

                cadena1 = "Consumo: ";
                String consumo = datosHabitos.Rows[i]["cantidad"].ToString() + " "+ datosHabitos.Rows[i]["Medida"].ToString() + " por " + datosHabitos.Rows[i]["Componente del Tiempo"].ToString();

                listaCampos.Add(cadena1);
                listaValores.Add(consumo);

                resultado = generarCampoPDF(listaCampos, listaValores, resultado, 2);


                listaCampos = new List<string>();
                listaValores = new List<string>();

                cadena1 = "Descipción Medida: ";

                listaCampos.Add(cadena1);

                listaValores.Add(Convert.ToString(datosHabitos.Rows[i]["Descripcion"].ToString()));

                resultado = generarCampoPDF(listaCampos, listaValores, resultado, 2);


                listaCampos = new List<string>();
                listaValores = new List<string>();

                resultado = generarLineaSeparacion(resultado, 2f, 100f);
            }
            resultado.Add(Chunk.NEWLINE);
            return resultado;
        }
        public Document generarDatosPDFHabitoDrogasIlicitas(Document documento)
        {
            List<String> listaCampos = null;
            List<String> listaValores = null;
            String cadena1;
            String cadena2;
            String cadena3;

            HttpCookie cookie = Request.Cookies["idHc"];
            int idHc = Convert.ToInt32(cookie.Value);
            DataTable datosHabitos = HabitoDrogasIlicitasLN.MostrarHabitosDrogasIlicitas(idHc);
            Document resultado = generarSubTituloPDF("Hábitos Drogas Ilícitas", documento);
            if (datosHabitos.Rows.Count == 0)
            {
                Font fuenteTexto = new Font(FontFactory.GetFont("Arial", 12, Font.NORMAL));
                resultado = generarLineaSinDatos(resultado, fuenteTexto);
                resultado = generarLineaSeparacion(resultado, 2f, 100f);
                return resultado;
            }

            for (int i = 0; i < datosHabitos.Rows.Count; i++)
            {
                listaCampos = new List<string>();
                listaValores = new List<string>();

                cadena1 = "Fecha de registro: ";
                cadena2 = "Sustancia: ";

                listaCampos.Add(cadena1);
                listaCampos.Add(cadena2);

                DateTime fecha = Convert.ToDateTime(datosHabitos.Rows[i]["Fecha de registro"]);
                listaValores.Add(fecha.ToShortDateString());

                listaValores.Add(Convert.ToString(datosHabitos.Rows[i]["Sustancia"].ToString()));

                resultado = generarCampoPDF(listaCampos, listaValores, resultado, 2);


                listaCampos = new List<string>();
                listaValores = new List<string>();

                cadena1 = "Tiempo consumiendo: ";
                String consumo = datosHabitos.Rows[i]["Tiempo Consumiendo"].ToString() + " " + datosHabitos.Rows[i]["Unidad de tiempo"].ToString();

                listaCampos.Add(cadena1);
                listaValores.Add(consumo);

                resultado = generarCampoPDF(listaCampos, listaValores, resultado, 2);


                listaCampos = new List<string>();
                listaValores = new List<string>();

                listaCampos = new List<string>();
                listaValores = new List<string>();

                resultado = generarLineaSeparacion(resultado, 2f, 100f);
            }
            resultado.Add(Chunk.NEWLINE);
            return resultado;
        }
        public Document generarDatosPDFHabitoMedicamento(Document documento)
        {
            List<String> listaCampos = null;
            List<String> listaValores = null;
            String cadena1;
            String cadena2;
            String cadena3;

            HttpCookie cookie = Request.Cookies["idHc"];
            int idHc = Convert.ToInt32(cookie.Value);
            DataTable datosHabitos = HabitoMedicamentoLN.MostrarHabitosMedicamento(idHc);
            Document resultado = generarSubTituloPDF("Hábitos Drogas Lícitas", documento);
            if (datosHabitos.Rows.Count == 0)
            {
                Font fuenteTexto = new Font(FontFactory.GetFont("Arial", 12, Font.NORMAL));
                resultado = generarLineaSinDatos(resultado, fuenteTexto);
                resultado = generarLineaSeparacion(resultado, 2f, 100f);
                return resultado;
            }

            for (int i = 0; i < datosHabitos.Rows.Count; i++)
            {
                listaCampos = new List<string>();
                listaValores = new List<string>();

                cadena1 = "Fecha de registro: ";
                cadena2 = "Nombre Genérico: ";

                listaCampos.Add(cadena1);
                listaCampos.Add(cadena2);

                DateTime fecha = Convert.ToDateTime(datosHabitos.Rows[i]["Fecha de registro"]);
                listaValores.Add(fecha.ToShortDateString());

                listaValores.Add(Convert.ToString(datosHabitos.Rows[i]["Nombre generico"].ToString()));

                resultado = generarCampoPDF(listaCampos, listaValores, resultado, 2);


                listaCampos = new List<string>();
                listaValores = new List<string>();

                cadena1 = "Concentración: ";

                listaCampos.Add(cadena1);
                String concentracion = datosHabitos.Rows[i]["Concentracion"].ToString() + " " + datosHabitos.Rows[i]["Unidad de Medida"].ToString();

                listaValores.Add(concentracion);
                resultado = generarCampoPDF(listaCampos, listaValores, resultado, 2);


                listaCampos = new List<string>();
                listaValores = new List<string>();

                cadena1 = "Cantidad de Comprimidos: ";
                cadena2 = "Frecuencia: ";

                listaCampos.Add(cadena1);
                listaCampos.Add(cadena2);

                listaValores.Add(datosHabitos.Rows[i]["Cantidad de comprimidos"].ToString());
                listaValores.Add(Convert.ToString(datosHabitos.Rows[i]["Frecuencia"].ToString()));

                resultado = generarCampoPDF(listaCampos, listaValores, resultado, 2);

                listaCampos = new List<string>();
                listaValores = new List<string>();

                cadena1 = "Primera dosis: ";
                cadena2 = "Momento del dia: " + datosHabitos.Rows[i]["Momento del dia 1"].ToString() +" "+" Dosis: " + datosHabitos.Rows[i]["Dosis 1"].ToString() + " Presentación Medicamento: " + datosHabitos.Rows[i]["Presentacion Medicamento 1"].ToString() + " "+ " Hora: " + datosHabitos.Rows[i]["Hora 1"].ToString();

                listaCampos.Add(cadena1);
                listaValores.Add(cadena2);

                resultado = generarCampoPDF(listaCampos, listaValores, resultado, 2);


                listaCampos = new List<string>();
                listaValores = new List<string>();

                cadena1 = "Segunda dosis: ";
                cadena2 = "Momento del dia: " + datosHabitos.Rows[i]["Momento del dia 2"].ToString() + " " + " Dosis: " + datosHabitos.Rows[i]["Dosis 2"].ToString() + " Presentación Medicamento: " + datosHabitos.Rows[i]["Presentacion Medicamento 2"].ToString() + " " + " Hora: " + datosHabitos.Rows[i]["Hora 2"].ToString();

                listaCampos.Add(cadena1);
                listaValores.Add(cadena2);

                resultado = generarCampoPDF(listaCampos, listaValores, resultado, 2);


                listaCampos = new List<string>();
                listaValores = new List<string>();

                cadena1 = "Tercera dosis: ";
                cadena2 = "Momento del dia: " + datosHabitos.Rows[i]["Momento del dia 3"].ToString() + " " + " Dosis: " + datosHabitos.Rows[i]["Dosis 3"].ToString() + " Presentación Medicamento: " + datosHabitos.Rows[i]["Presentacion Medicamento 3"].ToString() + " " + " Hora: " + datosHabitos.Rows[i]["Hora 3"].ToString();

                listaCampos.Add(cadena1);
                listaValores.Add(cadena2);

                resultado = generarCampoPDF(listaCampos, listaValores, resultado, 2);

                listaCampos = new List<string>();
                listaValores = new List<string>();

                resultado = generarLineaSeparacion(resultado, 2f, 100f);
            }
            resultado.Add(Chunk.NEWLINE);
            return resultado;
        }

        public Document generarDatosPDFHabitoActividadFisica(Document documento)
        {
            List<String> listaCampos = null;
            List<String> listaValores = null;
            String cadena1;
            String cadena2;
            String cadena3;

            HttpCookie cookie = Request.Cookies["idHc"];
            int idHc = Convert.ToInt32(cookie.Value);
            DataTable datosHabitos = HabitoActividadFisicaLN.MostrarHabitoActividadFisica(idHc);
            Document resultado = generarSubTituloPDF("Hábitos Actividad Física", documento);
            if (datosHabitos.Rows.Count == 0)
            {
                Font fuenteTexto = new Font(FontFactory.GetFont("Arial", 12, Font.NORMAL));
                resultado = generarLineaSinDatos(resultado, fuenteTexto);
                resultado = generarLineaSeparacion(resultado, 2f, 100f);
                return resultado;
            }

            for (int i = 0; i < datosHabitos.Rows.Count; i++)
            {
                listaCampos = new List<string>();
                listaValores = new List<string>();

                cadena1 = "Fecha de registro: ";
                cadena2 = "Deporte / Actividad: ";

                listaCampos.Add(cadena1);
                listaCampos.Add(cadena2);

                DateTime fecha = Convert.ToDateTime(datosHabitos.Rows[i]["Fecha registro"]);
                listaValores.Add(fecha.ToShortDateString());

                listaValores.Add(Convert.ToString(datosHabitos.Rows[i]["Deporte/Actividad"].ToString()));

                resultado = generarCampoPDF(listaCampos, listaValores, resultado, 2,true);

                listaCampos = new List<string>();
                listaValores = new List<string>();

                cadena1 = "Grado Actividad: ";
                cadena2 = "Descripcion grado actividad: ";

                listaCampos.Add(cadena1);
                listaCampos.Add(cadena2);

                listaValores.Add(datosHabitos.Rows[i]["Grado Actividad"].ToString());

                listaValores.Add(Convert.ToString(datosHabitos.Rows[i]["Descripcion grado actividad"].ToString()));

                resultado = generarCampoPDF(listaCampos, listaValores, resultado, 2,true);

                listaCampos = new List<string>();
                listaValores = new List<string>();

                cadena1 = "Intesidad Actividad Física: ";

                listaCampos.Add(cadena1);

                listaValores.Add(datosHabitos.Rows[i]["Intensidad Actividad Física"].ToString());

                resultado = generarCampoPDF(listaCampos, listaValores, resultado, 2);

                listaCampos = new List<string>();
                listaValores = new List<string>();

                resultado = generarLineaSeparacion(resultado, 2f, 100f);
            }
            resultado.Add(Chunk.NEWLINE);
            return resultado;
        }
        public Document generarDatosPDFConsultas(Document documento)
        {
            List<String> listaCampos = null;
            List<String> listaValores = null;
            String cadena1;
            String cadena2;
            String cadena3;

            HttpCookie cookie = Request.Cookies["idHc"];
            int idHc = Convert.ToInt32(cookie.Value);
            DataTable datosHabitos = ConsultaLN.mostrarConsultasAnteriores(idHc);
            Document resultado = generarSubTituloPDF("Consultas", documento);
            if (datosHabitos.Rows.Count == 0)
            {
                Font fuenteTexto = new Font(FontFactory.GetFont("Arial", 12, Font.NORMAL));
                resultado = generarLineaSinDatos(resultado, fuenteTexto);
                resultado = generarLineaSeparacion(resultado, 2f, 100f);
                return resultado;
            }

            for (int i = 0; i < datosHabitos.Rows.Count; i++)
            {
                listaCampos = new List<string>();
                listaValores = new List<string>();

                cadena1 = "Número de consulta: ";
                cadena2 = "Fecha Consulta: ";
                

                listaCampos.Add(cadena1);
                listaCampos.Add(cadena2);
           

                listaValores.Add(datosHabitos.Rows[i]["nroConsulta"].ToString());

                DateTime fecha = Convert.ToDateTime(datosHabitos.Rows[i]["fechaConsulta"]);
                listaValores.Add(fecha.ToShortDateString());

                resultado = generarCampoPDF(listaCampos, listaValores, resultado, 2);

                listaCampos = new List<string>();
                listaValores = new List<string>();

                cadena1 = "Hora: ";
                cadena2 = "Motivo Consulta: ";

                listaCampos.Add(cadena1);
                listaCampos.Add(cadena2);

                DateTime hora = Convert.ToDateTime(datosHabitos.Rows[i]["horaConsulta"].ToString());
                listaValores.Add(hora.ToShortTimeString());

                listaValores.Add(datosHabitos.Rows[i]["motivoConsulta"].ToString());

                resultado = generarCampoPDF(listaCampos, listaValores, resultado, 2,true);

                listaCampos = new List<string>();
                listaValores = new List<string>();

                resultado = generarLineaSeparacion(resultado, 2f, 100f);
            }
            resultado.Add(Chunk.NEWLINE);
            return resultado;
        }
        public Document generarDatosPDFMostrarEstudiosDiagnosticoPorImagen(Document documento)
        {
            List<String> listaCampos = null;
            List<String> listaValores = null;
            String cadena1;
            String cadena2;
            String cadena3;

            HttpCookie cookie = Request.Cookies["idHc"];
            int idHc = Convert.ToInt32(cookie.Value);
            DataTable datosEstudios = EstudioDiagnosticoPorImagenLN.MostrarEstudiosDiagnosticosPorImagen(idHc);
            Document resultado = generarSubTituloPDF("Estudios Diagnóstico por Imagen", documento);
            if (datosEstudios.Rows.Count == 0)
            {
                Font fuenteTexto = new Font(FontFactory.GetFont("Arial", 12, Font.NORMAL));
                resultado = generarLineaSinDatos(resultado, fuenteTexto);
                resultado = generarLineaSeparacion(resultado, 2f, 100f);
                return resultado;
            }

            for (int i = 0; i < datosEstudios.Rows.Count; i++)
            {
                listaCampos = new List<string>();
                listaValores = new List<string>();

                cadena1 = "Estudio: ";
                listaCampos.Add(cadena1);

                listaValores.Add(datosEstudios.Rows[i]["Estudio"].ToString());

                resultado = generarCampoPDF(listaCampos, listaValores, resultado, 1);

                listaCampos = new List<string>();
                listaValores = new List<string>();

                cadena1 = "Fecha de Solicitud: ";
                cadena2 = "Fecha Realizacion: ";

                listaCampos.Add(cadena1);
                listaCampos.Add(cadena2);

                DateTime fecha = Convert.ToDateTime(datosEstudios.Rows[i]["Fecha de Solicitud"]);
                listaValores.Add(fecha.ToShortDateString());

                if (string.IsNullOrEmpty(datosEstudios.Rows[i]["Fecha de Realizacion"].ToString()))
                {
                    Font fuenteTexto = new Font(FontFactory.GetFont("Arial", 12, Font.NORMAL));
                    listaValores.Add("N/A");
                    resultado = generarCampoPDF(listaCampos, listaValores, resultado, 1);
                }
                else
                {
                    DateTime fecha2 = Convert.ToDateTime(datosEstudios.Rows[i]["Fecha de Realizacion"].ToString());
                    listaValores.Add(fecha2.ToShortDateString());
                    resultado = generarCampoPDF(listaCampos, listaValores, resultado, 4);
                }

                listaCampos = new List<string>();
                listaValores = new List<string>();

                cadena1 = "Informe: ";
                listaCampos.Add(cadena1);

                if (string.IsNullOrEmpty(datosEstudios.Rows[i]["Informe"].ToString()))
                {
                    Font fuenteTexto = new Font(FontFactory.GetFont("Arial", 12, Font.NORMAL));
                    listaValores.Add("N/A");
                    resultado = generarCampoPDF(listaCampos, listaValores, resultado, 2);
                }
                else
                {
                    listaValores.Add(datosEstudios.Rows[i]["Informe"].ToString());
                    resultado = generarCampoPDF(listaCampos, listaValores, resultado, 2);
                }
              
                listaCampos = new List<string>();
                listaValores = new List<string>();

                cadena1 = "Observaciones: ";
                listaCampos.Add(cadena1);

                if (string.IsNullOrEmpty(datosEstudios.Rows[i]["Observaciones"].ToString()))
                {
                    Font fuenteTexto = new Font(FontFactory.GetFont("Arial", 12, Font.NORMAL));
                    listaValores.Add("N/A");
                    resultado = generarCampoPDF(listaCampos, listaValores, resultado, 2);
                }
                else
                {
                    listaValores.Add(datosEstudios.Rows[i]["Observaciones"].ToString());
                    resultado = generarCampoPDF(listaCampos, listaValores, resultado, 2);
                }
                listaCampos = new List<string>();
                listaValores = new List<string>();

                resultado = generarLineaSeparacion(resultado, 2f, 100f);
            }
            resultado.Add(Chunk.NEWLINE);
            return resultado;
        }
        public Document generarDatosPDFMostrarEstudiosPracticasComplementarias(Document documento)
        {
            List<String> listaCampos = null;
            List<String> listaValores = null;
            String cadena1;
            String cadena2;
            String cadena3;

            HttpCookie cookie = Request.Cookies["idHc"];
            int idHc = Convert.ToInt32(cookie.Value);
            DataTable datosEstudios = PracticaComplementariaLN.MostrarEstudioPracticaComplentarias(idHc);
            Document resultado = generarSubTituloPDF("Estudios Prácticas Complemementarias", documento);
            if (datosEstudios.Rows.Count == 0)
            {
                Font fuenteTexto = new Font(FontFactory.GetFont("Arial", 12, Font.NORMAL));
                resultado = generarLineaSinDatos(resultado, fuenteTexto);
                resultado = generarLineaSeparacion(resultado, 2f, 100f);
                return resultado;
            }

            for (int i = 0; i < datosEstudios.Rows.Count; i++)
            {
                listaCampos = new List<string>();
                listaValores = new List<string>();

                cadena1 = "Estudio: ";
                listaCampos.Add(cadena1);

                listaValores.Add(datosEstudios.Rows[i]["Estudio"].ToString());

                resultado = generarCampoPDF(listaCampos, listaValores, resultado, 1);

                listaCampos = new List<string>();
                listaValores = new List<string>();

                cadena1 = "Fecha de Solicitud: ";
                cadena2 = "Fecha Realizacion: ";

                listaCampos.Add(cadena1);
                listaCampos.Add(cadena2);

                DateTime fecha = Convert.ToDateTime(datosEstudios.Rows[i]["Fecha de Solicitud"]);
                listaValores.Add(fecha.ToShortDateString());

                if (string.IsNullOrEmpty(datosEstudios.Rows[i]["Fecha Realización"].ToString()))
                {
                    Font fuenteTexto = new Font(FontFactory.GetFont("Arial", 12, Font.NORMAL));
                    listaValores.Add("N/A");
                    resultado = generarCampoPDF(listaCampos, listaValores, resultado, 3);
                }
                else
                {
                    DateTime fecha2 = Convert.ToDateTime(datosEstudios.Rows[i]["Fecha Realización"].ToString());
                    listaValores.Add(fecha2.ToShortDateString());
                    resultado = generarCampoPDF(listaCampos, listaValores, resultado, 3);
                }

                listaCampos = new List<string>();
                listaValores = new List<string>();

                cadena1 = "Informe: ";
                listaCampos.Add(cadena1);

                if (string.IsNullOrEmpty(datosEstudios.Rows[i]["Informe"].ToString()))
                {
                    Font fuenteTexto = new Font(FontFactory.GetFont("Arial", 12, Font.NORMAL));
                    listaValores.Add("N/A");
                    resultado = generarCampoPDF(listaCampos, listaValores, resultado, 2);
                }
                else
                {
                    listaValores.Add(datosEstudios.Rows[i]["Informe"].ToString());
                    resultado = generarCampoPDF(listaCampos, listaValores, resultado, 2);
                }

                listaCampos = new List<string>();
                listaValores = new List<string>();

                cadena1 = "Indicaciones: ";
                listaCampos.Add(cadena1);

                if (string.IsNullOrEmpty(datosEstudios.Rows[i]["Indicaciones"].ToString()))
                {
                    Font fuenteTexto = new Font(FontFactory.GetFont("Arial", 12, Font.NORMAL));
                    listaValores.Add("N/A");
                    resultado = generarCampoPDF(listaCampos, listaValores, resultado, 2);
                }
                else
                {
                    listaValores.Add(datosEstudios.Rows[i]["Indicaciones"].ToString());
                    resultado = generarCampoPDF(listaCampos, listaValores, resultado, 2);
                }
                listaCampos = new List<string>();
                listaValores = new List<string>();

                resultado = generarLineaSeparacion(resultado, 2f, 100f);
            }
            resultado.Add(Chunk.NEWLINE);
            return resultado;
        }
        public Document generarDatosPDFMostrarEstudiosAnalisisLaboratorio(Document documento)
        {
            List<String> listaCampos = null;
            List<String> listaValores = null;
            String cadena1;
            String cadena2;
            String cadena3;

            HttpCookie cookie = Request.Cookies["idHc"];
            int idHc = Convert.ToInt32(cookie.Value);
            DataTable datosEstudios = LaboratorioLN.MostrarEstudiosLaboratorio(idHc);
            Document resultado = generarSubTituloPDF("Estudios Análisis Laboratorio", documento);
            if (datosEstudios.Rows.Count == 0)
            {
                Font fuenteTexto = new Font(FontFactory.GetFont("Arial", 12, Font.NORMAL));
                resultado = generarLineaSinDatos(resultado, fuenteTexto);
                resultado = generarLineaSeparacion(resultado, 2f, 100f);
                return resultado;
            }

            for (int i = 0; i < datosEstudios.Rows.Count; i++)
            {
                listaCampos = new List<string>();
                listaValores = new List<string>();

                cadena1 = "Estudio: ";
                listaCampos.Add(cadena1);

                listaValores.Add(datosEstudios.Rows[i]["Estudio"].ToString());

                resultado = generarCampoPDF(listaCampos, listaValores, resultado, 1);

                listaCampos = new List<string>();
                listaValores = new List<string>();

                cadena1 = "Fecha de Solicitud: ";
                cadena2 = "Fecha Realizacion: ";

                listaCampos.Add(cadena1);
                listaCampos.Add(cadena2);

                DateTime fecha = Convert.ToDateTime(datosEstudios.Rows[i]["Fecha de Solicitud"]);
                listaValores.Add(fecha.ToShortDateString());

                if (string.IsNullOrEmpty(datosEstudios.Rows[i]["Fecha Realizacion"].ToString()))
                {
                    Font fuenteTexto = new Font(FontFactory.GetFont("Arial", 12, Font.NORMAL));
                    listaValores.Add("N/A");
                    resultado = generarCampoPDF(listaCampos, listaValores, resultado, 3);
                }
                else
                {
                    DateTime fecha2 = Convert.ToDateTime(datosEstudios.Rows[i]["Fecha Realizacion"].ToString());
                    listaValores.Add(fecha2.ToShortDateString());
                    resultado = generarCampoPDF(listaCampos, listaValores, resultado, 3);
                }

                listaCampos = new List<string>();
                listaValores = new List<string>();

                cadena1 = "indicaciones: ";
                listaCampos.Add(cadena1);

                if (string.IsNullOrEmpty(datosEstudios.Rows[i]["Indicaciones"].ToString()))
                {
                    Font fuenteTexto = new Font(FontFactory.GetFont("Arial", 12, Font.NORMAL));
                    listaValores.Add("N/A");
                    resultado = generarCampoPDF(listaCampos, listaValores, resultado, 2);
                }
                else
                {
                    listaValores.Add(datosEstudios.Rows[i]["Indicaciones"].ToString());
                    resultado = generarCampoPDF(listaCampos, listaValores, resultado, 2);
                }

                listaCampos = new List<string>();
                listaValores = new List<string>();

                cadena1 = "Observaciones: ";
                listaCampos.Add(cadena1);

                if (string.IsNullOrEmpty(datosEstudios.Rows[i]["Observaciones"].ToString()))
                {
                    Font fuenteTexto = new Font(FontFactory.GetFont("Arial", 12, Font.NORMAL));
                    listaValores.Add("N/A");
                    resultado = generarCampoPDF(listaCampos, listaValores, resultado, 2);
                }
                else
                {
                    listaValores.Add(datosEstudios.Rows[i]["Observaciones"].ToString());
                    resultado = generarCampoPDF(listaCampos, listaValores, resultado, 2);
                }
                listaCampos = new List<string>();
                listaValores = new List<string>();

                resultado = generarLineaSeparacion(resultado, 2f, 100f);
            }
            resultado.Add(Chunk.NEWLINE);
            return resultado;
        }
        public Document generarDatosPDFMostrarTratamientos(Document documento)
        {
            List<String> listaCampos = null;
            List<String> listaValores = null;
            String cadena1;
            String cadena2;
            String cadena3;

            HttpCookie cookie = Request.Cookies["idHc"];
            int idHc = Convert.ToInt32(cookie.Value);
            DataTable datosEstudios = TratamientoLN.MostrarTratamientos(idHc);
            Document resultado = generarSubTituloPDF("Tratamientos", documento);
            if (datosEstudios.Rows.Count == 0)
            {
                Font fuenteTexto = new Font(FontFactory.GetFont("Arial", 12, Font.NORMAL));
                resultado = generarLineaSinDatos(resultado, fuenteTexto);
                resultado = generarLineaSeparacion(resultado, 2f, 100f);
                return resultado;
            }

            for (int i = 0; i < datosEstudios.Rows.Count; i++)
            {
                listaCampos = new List<string>();
                listaValores = new List<string>();

                cadena1 = "Terapia: ";
                listaCampos.Add(cadena1);

                listaValores.Add(datosEstudios.Rows[i]["nombre"].ToString());

                resultado = generarCampoPDF(listaCampos, listaValores, resultado, 1);

                listaCampos = new List<string>();
                listaValores = new List<string>();

                cadena1 = "Diagnóstico: ";
                cadena2 = "Fecha de Inicio: ";

                listaCampos.Add(cadena1);
                listaCampos.Add(cadena2);

                listaValores.Add(datosEstudios.Rows[i]["diagnostico"].ToString());

                if (string.IsNullOrEmpty(datosEstudios.Rows[i]["fechaInicio"].ToString()))
                {
                    Font fuenteTexto = new Font(FontFactory.GetFont("Arial", 12, Font.NORMAL));
                    listaValores.Add("N/A");
                    resultado = generarCampoPDF(listaCampos, listaValores, resultado, 1);
                }
                else
                {
                    DateTime fecha2 = Convert.ToDateTime(datosEstudios.Rows[i]["fechaInicio"].ToString());
                    listaValores.Add(fecha2.ToShortDateString());
                    resultado = generarCampoPDF(listaCampos, listaValores, resultado, 4);
                }

                listaCampos = new List<string>();
                listaValores = new List<string>();

                cadena1 = "Motivo Inicio: ";
                listaCampos.Add(cadena1);

                listaValores.Add(datosEstudios.Rows[i]["motivoInicioTratamiento"].ToString());

                resultado = generarCampoPDF(listaCampos, listaValores, resultado, 1);


                listaCampos = new List<string>();
                listaValores = new List<string>();

                cadena1 = "Indicaciones: ";
                listaCampos.Add(cadena1);

                if (string.IsNullOrEmpty(datosEstudios.Rows[i]["indicaciones"].ToString()))
                {
                    Font fuenteTexto = new Font(FontFactory.GetFont("Arial", 12, Font.NORMAL));
                    listaValores.Add("N/A");
                    resultado = generarCampoPDF(listaCampos, listaValores, resultado, 2);
                }
                else
                {
                    listaValores.Add(datosEstudios.Rows[i]["indicaciones"].ToString());
                    resultado = generarCampoPDF(listaCampos, listaValores, resultado, 2);
                }

                listaCampos = new List<string>();
                listaValores = new List<string>();

                cadena1 = "Fecha de Fin: ";

                listaCampos.Add(cadena1);

                if (string.IsNullOrEmpty(datosEstudios.Rows[i]["fechaFin"].ToString()))
                {
                    Font fuenteTexto = new Font(FontFactory.GetFont("Arial", 12, Font.NORMAL));
                    listaValores.Add("N/A");
                    resultado = generarCampoPDF(listaCampos, listaValores, resultado, 1);
                }
                else
                {
                    listaValores.Add( Convert.ToDateTime(datosEstudios.Rows[i]["fechaFin"].ToString()).ToShortDateString()) ;
                    resultado = generarCampoPDF(listaCampos, listaValores, resultado, 4);
                }

                listaCampos = new List<string>();
                listaValores = new List<string>();

                cadena2 = "Motivo de Fin: ";
                listaCampos.Add(cadena2);

                if (string.IsNullOrEmpty(datosEstudios.Rows[i]["motivoFinTratamiento"].ToString()))
                {
                    Font fuenteTexto = new Font(FontFactory.GetFont("Arial", 12, Font.NORMAL));
                    listaValores.Add("N/A");
                    resultado = generarCampoPDF(listaCampos, listaValores, resultado, 1);
                }
                else
                {
                    cadena2 = datosEstudios.Rows[i]["motivoFinTratamiento"].ToString();
                    listaValores.Add(cadena2);
                    resultado = generarCampoPDF(listaCampos, listaValores, resultado, 4);
                }

                listaCampos = new List<string>();
                listaValores = new List<string>();

                resultado = generarLineaSeparacion(resultado, 2f, 100f);
            }
            resultado.Add(Chunk.NEWLINE);
            return resultado;
        }
        public Document generarDatosPDFMostrarTratamientosMedicamento(Document documento)
        {
            List<String> listaCampos = null;
            List<String> listaValores = null;
            String cadena1;
            String cadena2;
            String cadena3;
            String cadena4;

            HttpCookie cookie = Request.Cookies["idHc"];
            int idHc = Convert.ToInt32(cookie.Value);
            DataTable datosEstudios = TratamientoLN.MostrarTratamientoMedicamento(idHc);
            Document resultado = generarSubTituloPDF("Tratamientos", documento);
            Font fuenteTexto = new Font(FontFactory.GetFont("Arial", 12, Font.NORMAL));
            if (datosEstudios.Rows.Count == 0)
            {
                fuenteTexto = new Font(FontFactory.GetFont("Arial", 12, Font.NORMAL));
                resultado = generarLineaSinDatos(resultado, fuenteTexto);
                resultado = generarLineaSeparacion(resultado, 2f, 100f);
                return resultado;
            }

            for (int i = 0; i < datosEstudios.Rows.Count; i++)
            {
                listaCampos = new List<string>();
                listaValores = new List<string>();

                cadena1 = "Motivo Inicio: ";
                listaCampos.Add(cadena1);
                
                if(string.IsNullOrEmpty(datosEstudios.Rows[i]["motivoInicioTratamiento"].ToString()))
                {
                    fuenteTexto = new Font(FontFactory.GetFont("Arial", 12, Font.NORMAL));
                    listaValores.Add("N/A");
                    //resultado = generarCampoPDF(listaCampos, listaValores, resultado, 1);
                }
                else
                {
                    listaValores.Add(datosEstudios.Rows[i]["motivoInicioTratamiento"].ToString());
                    //resultado = generarCampoPDF(listaCampos, listaValores, resultado, 4);
                }

                cadena2 = "Fecha de Inicio: ";
                listaCampos.Add(cadena2);

                if (string.IsNullOrEmpty(datosEstudios.Rows[i]["fechaInicio"].ToString()))
                {
                    fuenteTexto = new Font(FontFactory.GetFont("Arial", 12, Font.NORMAL));
                    listaValores.Add("N/A");
                    //resultado = generarCampoPDF(listaCampos, listaValores, resultado, 1);
                }
                else
                {
                    DateTime fecha2 = Convert.ToDateTime(datosEstudios.Rows[i]["fechaInicio"].ToString());
                    listaValores.Add(fecha2.ToShortDateString());
                    //resultado = generarCampoPDF(listaCampos, listaValores, resultado, 4);
                }

                resultado = generarCampoPDF(listaCampos, listaValores, resultado, 4);

                listaCampos = new List<string>();
                listaValores = new List<string>();

                cadena1 = "Indicaciones: ";
                listaCampos.Add(cadena1);

                if (string.IsNullOrEmpty(datosEstudios.Rows[i]["indicaciones"].ToString()))
                {
                    fuenteTexto = new Font(FontFactory.GetFont("Arial", 12, Font.NORMAL));
                    listaValores.Add("N/A");
                    resultado = generarCampoPDF(listaCampos, listaValores, resultado, 2);
                }
                else
                {
                    listaValores.Add(datosEstudios.Rows[i]["indicaciones"].ToString());
                    resultado = generarCampoPDF(listaCampos, listaValores, resultado, 2);
                }

                listaCampos = new List<string>();
                listaValores = new List<string>();

                cadena1 = "Terapia: ";
                listaCampos.Add(cadena1);

                listaValores.Add(datosEstudios.Rows[i]["Terapia"].ToString());

                resultado = generarCampoPDF(listaCampos, listaValores, resultado, 1);

                listaCampos = new List<string>();
                listaValores = new List<string>();

                cadena1 = "Diagnóstico: ";
                listaCampos.Add(cadena1);

                listaValores.Add(datosEstudios.Rows[i]["diagnostico"].ToString());

                resultado = generarCampoPDF(listaCampos, listaValores, resultado, 1);

                listaCampos = new List<string>();
                listaValores = new List<string>();

                cadena1 = "Nombre Medicamento: ";
                listaCampos.Add(cadena1);

                listaValores.Add(datosEstudios.Rows[i]["Nombre Medicamento"].ToString());

                resultado = generarCampoPDF(listaCampos, listaValores, resultado, 1);

                listaCampos = new List<string>();
                listaValores = new List<string>();

                cadena1 = "Concentración: ";
                listaCampos.Add(cadena1);

                listaValores.Add(datosEstudios.Rows[i]["Cantidad"].ToString() + " " + datosEstudios.Rows[i]["UnidadMedida Concentracion"].ToString());

                resultado = generarCampoPDF(listaCampos, listaValores, resultado, 1);

                listaCampos = new List<string>();
                listaValores = new List<string>();

                cadena1 = "Frecuencia: ";

                listaCampos.Add(cadena1);

                if (string.IsNullOrEmpty(datosEstudios.Rows[i]["Frecuencia"].ToString()))
                {
                    fuenteTexto = new Font(FontFactory.GetFont("Arial", 12, Font.NORMAL));
                    listaValores.Add("N/A");
                    resultado = generarCampoPDF(listaCampos, listaValores, resultado, 1);
                }
                else
                {
                    listaValores.Add(datosEstudios.Rows[i]["Frecuencia"].ToString());
                    resultado = generarCampoPDF(listaCampos, listaValores, resultado, 4);
                }
                resultado.Add(Chunk.NEWLINE);
                resultado = generarLineaSeparacion(resultado, 2f, 100f);


                resultado.Add(Chunk.NEWLINE);
                resultado.Add(Chunk.NEWLINE);

                resultado = generarSubTituloPDF("Programación de Dosis", resultado);

                //Primera dosis
                listaCampos = new List<string>();
                listaValores = new List<string>();

                cadena1 = "Momento día 1: ";
                cadena2 = "Dosis 1: ";
            
                listaCampos.Add(cadena1);

                if (string.IsNullOrEmpty(datosEstudios.Rows[i]["Momento dia 1"].ToString()))
                {
                    fuenteTexto = new Font(FontFactory.GetFont("Arial", 12, Font.NORMAL));
                    listaValores.Add("N/A");
                    //resultado = generarCampoPDF(listaCampos, listaValores, resultado, 1);
                }
                else
                {
                    listaValores.Add(datosEstudios.Rows[i]["Momento dia 1"].ToString());
                    //resultado = generarCampoPDF(listaCampos, listaValores, resultado, 4);
                }


                listaCampos.Add(cadena2);

                if (string.IsNullOrEmpty(datosEstudios.Rows[i]["dosis 1"].ToString()))
                {
                    fuenteTexto = new Font(FontFactory.GetFont("Arial", 12, Font.NORMAL));
                    listaValores.Add("N/A");
                    //resultado = generarCampoPDF(listaCampos, listaValores, resultado, 1);
                }
                else
                {
                    listaValores.Add(datosEstudios.Rows[i]["dosis 1"].ToString());
                    //resultado = generarCampoPDF(listaCampos, listaValores, resultado, 4);
                }
                resultado = generarCampoPDF(listaCampos, listaValores, resultado, 1);

                listaCampos = new List<string>();
                listaValores = new List<string>();

                cadena3 = "Presentación Medicamento 1: ";
                cadena4 = "Hora 1: ";

                listaCampos.Add(cadena3);

                if (string.IsNullOrEmpty(datosEstudios.Rows[i]["Presentación Medicamento 1"].ToString()))
                {
                    fuenteTexto = new Font(FontFactory.GetFont("Arial", 12, Font.NORMAL));
                    listaValores.Add("N/A");
                    //resultado = generarCampoPDF(listaCampos, listaValores, resultado, 1);
                }
                else
                {
                    listaValores.Add(datosEstudios.Rows[i]["Presentación Medicamento 1"].ToString());
                    //resultado = generarCampoPDF(listaCampos, listaValores, resultado, 4);
                }

                listaCampos.Add(cadena4);

                if (string.IsNullOrEmpty(datosEstudios.Rows[i]["hora1"].ToString()))
                {
                    fuenteTexto = new Font(FontFactory.GetFont("Arial", 12, Font.NORMAL));
                    listaValores.Add("N/A");
                    //resultado = generarCampoPDF(listaCampos, listaValores, resultado, 1);
                }
                else
                {
                    listaValores.Add(datosEstudios.Rows[i]["hora1"].ToString());
                    //resultado = generarCampoPDF(listaCampos, listaValores, resultado, 4);
                }
                resultado = generarCampoPDF(listaCampos, listaValores, resultado, 1);
                resultado = generarLineaSeparacion(resultado, 2f, 100f);

                resultado.Add(Chunk.NEWLINE);
                resultado.Add(Chunk.NEWLINE);

                //Segunda dosis
                listaCampos = new List<string>();
                listaValores = new List<string>();

                cadena1 = "Momento día 2: ";
                cadena2 = "Dosis 2: ";
               

                listaCampos.Add(cadena1);

                if (string.IsNullOrEmpty(datosEstudios.Rows[i]["Momento dia 2"].ToString()))
                {
                    fuenteTexto = new Font(FontFactory.GetFont("Arial", 12, Font.NORMAL));
                    listaValores.Add("N/A");
                    //resultado = generarCampoPDF(listaCampos, listaValores, resultado, 1);
                }
                else
                {
                    listaValores.Add(datosEstudios.Rows[i]["Momento dia 2"].ToString());
                    //resultado = generarCampoPDF(listaCampos, listaValores, resultado, 4);
                }

                listaCampos.Add(cadena2);

                if (string.IsNullOrEmpty(datosEstudios.Rows[i]["dosis 2"].ToString()))
                {
                    fuenteTexto = new Font(FontFactory.GetFont("Arial", 12, Font.NORMAL));
                    listaValores.Add("N/A");
                    //resultado = generarCampoPDF(listaCampos, listaValores, resultado, 1);
                }
                else
                {
                    listaValores.Add(datosEstudios.Rows[i]["dosis 2"].ToString());
                    //resultado = generarCampoPDF(listaCampos, listaValores, resultado, 4);
                }

               resultado = generarCampoPDF(listaCampos, listaValores, resultado, 1);

                listaCampos = new List<string>();
                listaValores = new List<string>();

                cadena3 = "Presentación Medicamento 2: ";
                cadena4 = "Hora 2: ";

                listaCampos.Add(cadena3);

                if (string.IsNullOrEmpty(datosEstudios.Rows[i]["Presentación Medicamento 2"].ToString()))
                {
                    fuenteTexto = new Font(FontFactory.GetFont("Arial", 12, Font.NORMAL));
                    listaValores.Add("N/A");
                    //resultado = generarCampoPDF(listaCampos, listaValores, resultado, 1);
                }
                else
                {
                    listaValores.Add(datosEstudios.Rows[i]["Presentación Medicamento 2"].ToString());
                    //resultado = generarCampoPDF(listaCampos, listaValores, resultado, 4);
                }

                listaCampos.Add(cadena4);

                if (string.IsNullOrEmpty(datosEstudios.Rows[i]["hora2"].ToString()))
                {
                    fuenteTexto = new Font(FontFactory.GetFont("Arial", 12, Font.NORMAL));
                    listaValores.Add("N/A");
                    //resultado = generarCampoPDF(listaCampos, listaValores, resultado, 1);
                }
                else
                {
                    listaValores.Add(datosEstudios.Rows[i]["hora2"].ToString());
                    //resultado = generarCampoPDF(listaCampos, listaValores, resultado, 4);
                }
                resultado = generarCampoPDF(listaCampos, listaValores, resultado, 2);
                resultado = generarLineaSeparacion(resultado, 2f, 100f);

                resultado.Add(Chunk.NEWLINE);
                resultado.Add(Chunk.NEWLINE);

                //Tercera dosis
                listaCampos = new List<string>();
                listaValores = new List<string>();

                cadena1 = "Momento día 3: ";
                cadena2 = "Dosis 3: ";
               

                listaCampos.Add(cadena1);

                if (string.IsNullOrEmpty(datosEstudios.Rows[i]["Momento dia 3"].ToString()))
                {
                    fuenteTexto = new Font(FontFactory.GetFont("Arial", 12, Font.NORMAL));
                    listaValores.Add("N/A");
                    //resultado = generarCampoPDF(listaCampos, listaValores, resultado, 1);
                }
                else
                {
                    listaValores.Add(datosEstudios.Rows[i]["Momento dia 3"].ToString());
                    //resultado = generarCampoPDF(listaCampos, listaValores, resultado, 4);
                }

                listaCampos.Add(cadena2);

                if (string.IsNullOrEmpty(datosEstudios.Rows[i]["dosis 3"].ToString()))
                {
                    fuenteTexto = new Font(FontFactory.GetFont("Arial", 12, Font.NORMAL));
                    listaValores.Add("N/A");
                    //resultado = generarCampoPDF(listaCampos, listaValores, resultado, 1);
                }
                else
                {
                    listaValores.Add(datosEstudios.Rows[i]["dosis 2"].ToString());
                    //resultado = generarCampoPDF(listaCampos, listaValores, resultado, 4);
                }
                resultado = generarCampoPDF(listaCampos, listaValores, resultado, 2);

                listaCampos = new List<string>();
                listaValores = new List<string>();

                cadena3 = "Presentación Medicamento 3: ";
                cadena4 = "Hora 3: ";

                listaCampos.Add(cadena3);

                if (string.IsNullOrEmpty(datosEstudios.Rows[i]["Presentación Medicamento 3"].ToString()))
                {
                    fuenteTexto = new Font(FontFactory.GetFont("Arial", 12, Font.NORMAL));
                    listaValores.Add("N/A");
                    //resultado = generarCampoPDF(listaCampos, listaValores, resultado, 1);
                }
                else
                {
                    listaValores.Add(datosEstudios.Rows[i]["Presentación Medicamento 3"].ToString());
                    //resultado = generarCampoPDF(listaCampos, listaValores, resultado, 4);
                }

                listaCampos.Add(cadena4);

                if (string.IsNullOrEmpty(datosEstudios.Rows[i]["hora3"].ToString()))
                {
                    fuenteTexto = new Font(FontFactory.GetFont("Arial", 12, Font.NORMAL));
                    listaValores.Add("N/A");
                    //resultado = generarCampoPDF(listaCampos, listaValores, resultado, 1);
                }
                else
                {
                    listaValores.Add(datosEstudios.Rows[i]["hora3"].ToString());
                    //resultado = generarCampoPDF(listaCampos, listaValores, resultado, 4);
                }
                resultado = generarCampoPDF(listaCampos, listaValores, resultado, 2);


                listaCampos = new List<string>();
                listaValores = new List<string>();

                resultado = generarLineaSeparacion(resultado, 2f, 100f);
            }
            resultado.Add(Chunk.NEWLINE);
            return resultado;
        }
        public Document generarDatosPDFMostrarMedicionesPresionArterial(Document documento)
        {
            List<String> listaCampos = null;
            List<String> listaValores = null;
            String cadena1;
            String cadena2;
            String cadena3;

            HttpCookie cookie = Request.Cookies["idHc"];
            int idHc = Convert.ToInt32(cookie.Value);
            DataTable datosMedicionesPresionArterial = MedicionDePresionArterialLN.ObtenerMediciones(idHc);
            Document resultado = generarSubTituloPDF("Mediciones Presión Arterial", documento);
            if (datosMedicionesPresionArterial.Rows.Count == 0)
            {
                Font fuenteTexto = new Font(FontFactory.GetFont("Arial", 12, Font.NORMAL));
                resultado = generarLineaSinDatos(resultado, fuenteTexto);
                resultado = generarLineaSeparacion(resultado, 2f, 100f);
                return resultado;
            }

            for (int i = 0; i < datosMedicionesPresionArterial.Rows.Count; i++)
            {
                resultado = generarSubTituloPDF("Medición", documento);

                listaCampos = new List<string>();
                listaValores = new List<string>();

                cadena1 = "Fecha: ";
                listaCampos.Add(cadena1);

                DateTime fecha2 = Convert.ToDateTime(datosMedicionesPresionArterial.Rows[i]["Fecha"].ToString());
                listaValores.Add(fecha2.ToShortDateString());

                resultado = generarCampoPDF(listaCampos, listaValores, resultado, 1);

                listaCampos = new List<string>();
                listaValores = new List<string>();

                cadena1 = "Extremidad: ";
                cadena2 = "Ubicación Extremidad: ";

                listaCampos.Add(cadena1);
                listaCampos.Add(cadena2);

                listaValores.Add(datosMedicionesPresionArterial.Rows[i]["Extremidad"].ToString());

                if (string.IsNullOrEmpty(datosMedicionesPresionArterial.Rows[i]["Ubicacion Extremidad"].ToString()))
                {
                    Font fuenteTexto = new Font(FontFactory.GetFont("Arial", 12, Font.NORMAL));
                    listaValores.Add("N/A");
                    resultado = generarCampoPDF(listaCampos, listaValores, resultado, 1);
                }
                else
                {
                    listaValores.Add(datosMedicionesPresionArterial.Rows[i]["Ubicacion Extremidad"].ToString());
                    resultado = generarCampoPDF(listaCampos, listaValores, resultado, 2);
                }

                listaCampos = new List<string>();
                listaValores = new List<string>();

                cadena1 = "Sitio de Medición: ";
                cadena2 = "Momento del día: ";
                listaCampos.Add(cadena1);
                listaCampos.Add(cadena2);

                listaValores.Add(datosMedicionesPresionArterial.Rows[i]["Sitio Medicion"].ToString());
                listaValores.Add(datosMedicionesPresionArterial.Rows[i]["Momento del día"].ToString());

                resultado = generarCampoPDF(listaCampos, listaValores, resultado, 3);


                listaCampos = new List<string>();
                listaValores = new List<string>();

                cadena1 = "Posición: ";
                listaCampos.Add(cadena1);

                if (string.IsNullOrEmpty(datosMedicionesPresionArterial.Rows[i]["Posición"].ToString()))
                {
                    Font fuenteTexto = new Font(FontFactory.GetFont("Arial", 12, Font.NORMAL));
                    listaValores.Add("N/A");
                    resultado = generarCampoPDF(listaCampos, listaValores, resultado, 2);
                }
                else
                {
                    listaValores.Add(datosMedicionesPresionArterial.Rows[i]["Posición"].ToString());
                    resultado = generarCampoPDF(listaCampos, listaValores, resultado, 2);
                }

                //Agregar Detalle Mediciones

                listaCampos = new List<string>();
                listaValores = new List<string>();


                int id_medicion = Convert.ToInt32(datosMedicionesPresionArterial.Rows[i]["id_medicion"]);

                DataTable datosDetalleMedicionesPresionArterial = MedicionDePresionArterialLN.ObtenerDetalleMedicionesPresionArterial(idHc, id_medicion, null, null, null, null, null, null, null);

                resultado=generarSubTituloPDF("Detalle de la medición", resultado);

                for (int j = 0; j < datosDetalleMedicionesPresionArterial.Rows.Count; j++)
                {
                    listaCampos = new List<string>();
                    listaValores = new List<string>();

                    cadena1 = "NroMedición: ";
                    cadena2 = "Hora: ";
                    listaCampos.Add(cadena1);
                    listaCampos.Add(cadena2);

                    listaValores.Add(datosDetalleMedicionesPresionArterial.Rows[j]["NroMedición"].ToString());
                    listaValores.Add(datosDetalleMedicionesPresionArterial.Rows[j]["Hora"].ToString());

                    resultado = generarCampoPDF(listaCampos, listaValores, resultado, 1);

                    listaCampos = new List<string>();
                    listaValores = new List<string>();

                    cadena1 = "Sistólica: ";
                    cadena2 = "Diastólica: ";
                    cadena3 = "Pulso: ";
                    listaCampos.Add(cadena1);
                    listaCampos.Add(cadena2);
                    listaCampos.Add(cadena3);

                    listaValores.Add(datosDetalleMedicionesPresionArterial.Rows[j]["Valor Máximo"].ToString());
                    listaValores.Add(datosDetalleMedicionesPresionArterial.Rows[j]["Valor Mínimo"].ToString());
                    listaValores.Add(datosDetalleMedicionesPresionArterial.Rows[j]["Pulso"].ToString());

                    resultado = generarCampoPDF(listaCampos, listaValores, resultado, 2);
                    resultado = generarLineaSeparacion(resultado, 2f, 100f);
                }
                resultado = generarLineaSeparacion(resultado, 2f, 100f);
            }
            resultado.Add(Chunk.NEWLINE);
            return resultado;
        }
        public Document GenerarDatosPDFExamenGeneral(Document documento)
        {
            List<String> listaCampos = null;
            List<String> listaValores = null;
            String cadena1;
            String cadena2;
            String cadena3;

            HttpCookie cookie = Request.Cookies["idHc"];
            int idHc = Convert.ToInt32(cookie.Value);
            DataTable datosExamenes = ExamenGeneralLN.MostrarResumenExamenGeneral(idHc);
            Document resultado = generarSubTituloPDF("Exámenes Generales", documento);
            if (datosExamenes.Rows.Count == 0)
            {
                Font fuenteTexto = new Font(FontFactory.GetFont("Arial", 12, Font.NORMAL));
                resultado = generarLineaSinDatos(resultado, fuenteTexto);
                resultado = generarLineaSeparacion(resultado, 2f, 100f);
                return resultado;
            }

            for (int i = 0; i < datosExamenes.Rows.Count; i++)
            {
                listaCampos = new List<string>();
                listaValores = new List<string>();

                cadena1 = "Número de consulta: ";
                cadena2 = "Fecha Consulta: ";


                listaCampos.Add(cadena1);
                listaCampos.Add(cadena2);


                listaValores.Add(datosExamenes.Rows[i]["nroConsulta"].ToString());

                DateTime fecha = Convert.ToDateTime(datosExamenes.Rows[i]["fechaConsulta"]);
                listaValores.Add(fecha.ToShortDateString());

                resultado = generarCampoPDF(listaCampos, listaValores, resultado, 2);

                listaCampos = new List<string>();
                listaValores = new List<string>();

                cadena1 = "Hora: ";
                cadena2 = "Motivo Consulta: ";

                listaCampos.Add(cadena1);
                listaCampos.Add(cadena2);

                DateTime hora = Convert.ToDateTime(datosExamenes.Rows[i]["horaConsulta"].ToString());
                listaValores.Add(hora.ToShortTimeString());

                listaValores.Add(datosExamenes.Rows[i]["motivoConsulta"].ToString());

                resultado = generarCampoPDF(listaCampos, listaValores, resultado, 2, true);

                listaCampos = new List<string>();
                listaValores = new List<string>();

                cadena1 = "Concepto Inicial: ";
                cadena2 = "Diagnóstico: ";

                listaCampos.Add(cadena1);
                listaCampos.Add(cadena2);

                listaValores.Add(datosExamenes.Rows[i]["conceptoInicial"].ToString());

                listaValores.Add(datosExamenes.Rows[i]["motivoConsulta"].ToString());

                resultado = generarCampoPDF(listaCampos, listaValores, resultado, 2, true);

                listaCampos = new List<string>();
                listaValores = new List<string>();

                cadena1 = "Estado Diagnóstico: ";
                cadena2 = "Motivo Cambio Estado: ";
                cadena3 = "Fecha cambio estado: ";

                listaCampos.Add(cadena1);
                listaCampos.Add(cadena2);
                listaCampos.Add(cadena3);

                listaValores.Add(datosExamenes.Rows[i]["Estado Diagnóstico"].ToString());

                listaValores.Add(datosExamenes.Rows[i]["Motivo Cambio Estado"].ToString());

                DateTime fechaCambioEstado = Convert.ToDateTime(datosExamenes.Rows[i]["Fecha cambio estado"].ToString());
                listaValores.Add(fechaCambioEstado.ToShortDateString());

                resultado = generarCampoPDF(listaCampos, listaValores, resultado, 2, true);

                resultado = generarLineaSeparacion(resultado, 2f, 100f);
            }
            resultado.Add(Chunk.NEWLINE);
            return resultado;
        }
        public Document generarTituloPDF(String nuevotitulo, Document documento)
        {
            //Fuentes
            Font arialTitulo = new Font(FontFactory.GetFont("Arial", 28, Font.BOLD));
            //Agregar Titulo
            Paragraph titulo = new Paragraph(nuevotitulo, arialTitulo);
            titulo.Alignment = Element.ALIGN_CENTER;
            documento.Add(titulo);
            documento.Add(Chunk.NEWLINE);
            return documento;
        }
        public Document generarSubTituloPDF(String nuevoSubTitulo, Document documento)
        {
            //Fuente
            Font arialSubtitulo = new Font(FontFactory.GetFont("Arial", 15, Font.BOLD));
            //Agregar Subtitulo
            Paragraph subtitulo = new Paragraph(nuevoSubTitulo, arialSubtitulo);
            subtitulo.Alignment = Element.ALIGN_LEFT;
            documento.Add(subtitulo);
            documento.Add(Chunk.NEWLINE);
            return documento;
        }
        public Document generarCampoPDF(List<String> nuevosCampos,List<String> nuevosValores, Document documento, int cantTab)
        {
            Font fuenteTexto = new Font(FontFactory.GetFont("Arial", 12, Font.NORMAL));
            Font fuenteTextoSubrayado = new Font(FontFactory.GetFont("Arial", 12, Font.ITALIC));

            Chunk chunk = null;
            Phrase campo = null;
            Paragraph parrafoDedatos = null;

            String text = null;
            for (int i=0;i<nuevosCampos.Count;i++)
            {
                text = nuevosValores[i];
                chunk = new Chunk(nuevosCampos[i].ToString(), fuenteTextoSubrayado);
                campo = new Phrase();
                campo.Font = fuenteTexto;
                campo.Add(chunk);
                campo.Add(text);

                if(i==0)
                    parrafoDedatos = new Paragraph();

                parrafoDedatos.Add(campo);
                for(int j=0;j<cantTab;j++)
                {
                    parrafoDedatos.Add(Chunk.TABBING);
                }
            }
            
            documento.Add(parrafoDedatos);
            documento.Add(Chunk.NEWLINE);
            return documento;
        }
        public Document generarCampoPDF(List<String> nuevosCampos, List<String> nuevosValores, Document documento, int cantTab,Boolean nuevaLinea)
        {
            Font fuenteTexto = new Font(FontFactory.GetFont("Arial", 12, Font.NORMAL));
            Font fuenteTextoSubrayado = new Font(FontFactory.GetFont("Arial", 12, Font.ITALIC));

            Chunk chunk = null;
            Phrase campo = null;
            Paragraph parrafoDedatos = null;

            String text = null;
            for (int i = 0; i < nuevosCampos.Count; i++)
            {
                text = nuevosValores[i];
                chunk = new Chunk(nuevosCampos[i].ToString(), fuenteTextoSubrayado);
                campo = new Phrase();
                campo.Font = fuenteTexto;
                campo.Add(chunk);
                campo.Add(text);
               

                if (nuevaLinea == true)
                {
                    campo.Add(Chunk.NEWLINE);
                    campo.Add(Chunk.NEWLINE);
                }

                if (i == 0)
                    parrafoDedatos = new Paragraph();

                parrafoDedatos.Add(campo);
                //for (int j = 0; j < cantTab; j++)
                //{
                //    parrafoDedatos.Add(Chunk.TABBING);
                //}
             
            }

            documento.Add(parrafoDedatos);
            //documento.Add(Chunk.NEWLINE);
            return documento;
        }
        public Document generarLineaSeparacion(Document documento, float ancho, float porcentaje)
        {
            //Chunk linebreak = new Chunk(new LineSeparator(4f, 100f,BaseColor.GRAY, Element.ALIGN_CENTER, -1));
            Chunk linebreak = new Chunk(new LineSeparator(ancho, porcentaje, BaseColor.GRAY, Element.ALIGN_CENTER, -1));
            documento.Add(linebreak);
            return documento;
        }
        public Document generarLineaSinDatos(Document documento,Font fuente)
        {
            Paragraph parrafoDedatos = null;
            Phrase campo = null;
            Chunk chunk = null;

            chunk = new Chunk("N/A ",fuente);

            campo = new Phrase();
            campo.Add(chunk);

            parrafoDedatos = new Paragraph();
            parrafoDedatos.Add(campo);
            parrafoDedatos.Add(Chunk.TABBING);
            parrafoDedatos.Add(Chunk.TABBING);

            documento.Add(parrafoDedatos);

            return documento;
        }

        public void agregarDatosTabla()
        {
            HttpCookie cookie = Request.Cookies["idHc"];
            int idHc = Convert.ToInt32(cookie.Value);
            PdfPTable tabla = new PdfPTable(6);

            Paciente pacienteLogueado = PacienteLN.mostrarPacienteBuscado(idHc);

            Document document = new Document(iTextSharp.text.PageSize.A4, 50, 50, 50, 50);
            FileStream fs = new FileStream("C:/Users/usuario/HistoriaClinica.pdf", FileMode.Create);
            PdfWriter pw = PdfWriter.GetInstance(document, fs);

            document.Open();

            document.Add(new Paragraph("Historia Clínica"));

            document.Add(new Paragraph("\n\tDatos del Paciente"));

            PdfPCell nomPaciente = new PdfPCell(new Phrase("Nombre Paciente:"));
            nomPaciente.Border = Rectangle.NO_BORDER;

            tabla.AddCell(nomPaciente);
            tabla.AddCell(pacienteLogueado.nombre);
            tabla.AddCell("Apellido Paciente: ");
            tabla.AddCell(pacienteLogueado.apellido);
            tabla.AddCell("Fecha de Nacimiento:");
            tabla.AddCell(pacienteLogueado.fechaNacimiento.ToShortDateString());

            tabla.AddCell("Tipo de Documento: ");
            tabla.AddCell(pacienteLogueado.tipoDoc.nombre);
            tabla.AddCell("Número de documento:");
            tabla.AddCell(Convert.ToString(pacienteLogueado.nroDoc));
            tabla.AddCell("Telefono:");
            tabla.AddCell(Convert.ToString(pacienteLogueado.telefono));

            tabla.AddCell("Celular:");
            tabla.AddCell(Convert.ToString(pacienteLogueado.nroCelular));


            tabla.AddCell("Altura:");
            tabla.AddCell(Convert.ToString(pacienteLogueado.altura));

            tabla.AddCell("Peso:");
            tabla.AddCell(Convert.ToString(pacienteLogueado.peso));

            document.Add(tabla);

            document.Close();



            Process.Start("C:/Users/usuario/HistoriaClinica.pdf");
        
        }

        protected void CbSeleccionarTodos_CheckedChanged(object sender, EventArgs e)
        {
            if(cbSeleccionarTodos.Checked ==true)
            {
                cbAntecedentesMorbidos.Checked = true;
                cbAntecedentesGinecoObstetricos.Checked = true;
                cbAntecedentesPatologicosFamiliares.Checked = true;
                cbAntecedentesPersonales.Checked = true;
                cbAlergias.Checked = true;
                cbHabitoTabaquismo.Checked = true;
                cbHabitoAlcoholismo.Checked = true;
                cbHabitoDrogasIlicitas.Checked = true;
                cbHabitoDrogasLicitas.Checked = true;
                cbHabitoActividadFisica.Checked = true;
                cbConsultas.Checked = true;
                cbExamenesGenerales.Checked = true;
                cbTratamientos.Checked = true;
                cbTratamientoMedicamento.Checked = true;
                cbEstudioDiagnosticoPorImagen.Checked = true;
                cbAnalisisClinicos.Checked = true;
                cbPracticasComplementarias.Checked = true;
                cbMedicionesPresionArterial.Checked = true;
            }
            else
            {
                cbAntecedentesMorbidos.Checked = false;
                cbAntecedentesGinecoObstetricos.Checked = false;
                cbAntecedentesPatologicosFamiliares.Checked = false;
                cbAntecedentesPersonales.Checked = false;
                cbAlergias.Checked = false;
                cbHabitoTabaquismo.Checked = false;
                cbHabitoAlcoholismo.Checked = false;
                cbHabitoDrogasIlicitas.Checked = false;
                cbHabitoDrogasLicitas.Checked = false;
                cbHabitoActividadFisica.Checked = false;
                cbConsultas.Checked = false;
                cbExamenesGenerales.Checked = false;
                cbTratamientos.Checked = false;
                cbTratamientoMedicamento.Checked = false;
                cbEstudioDiagnosticoPorImagen.Checked = false;
                cbAnalisisClinicos.Checked = false;
                cbPracticasComplementarias.Checked = false;
                cbMedicionesPresionArterial.Checked = false;
            }

        }
    }
}