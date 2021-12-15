using CrystalDecisions.CrystalReports.Engine;
using DAO;
using GPA.Reportes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.WebSockets;
using System.Windows.Forms;

namespace GPA
{
    public partial class ConsultarEstudios : Form
    {
        public int id_hc;
        public ConsultarEstudios(int idHc)
        {
            id_hc = idHc;
            InitializeComponent();
        }

        private void ConsultarEstudios_Load(object sender, EventArgs e)
        {

        }

        private void btnEstudiosDiagPorImagenes_Click(object sender, EventArgs e)
        {
            crHistoriaClinicaEstudioDiagnosticoPorImagen crEstudioDiagnosticoImagen = new crHistoriaClinicaEstudioDiagnosticoPorImagen();
            dsHistoriaClinicaEstudioDiagnosticoPorImagen dsEstudioDiagnosticoPorImagen = new dsHistoriaClinicaEstudioDiagnosticoPorImagen();
            try
            {
                dsEstudioDiagnosticoPorImagen = MostrarEstudioDiagnosticoPorImagen(id_hc);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error al estudios: " + ex.Message + " StackTrace: " + ex.StackTrace, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            try
            {
                if(dsEstudioDiagnosticoPorImagen != null && dsEstudioDiagnosticoPorImagen.Tables[0].Rows.Count > 0)
                {
                    crEstudioDiagnosticoImagen.SetDataSource(dsEstudioDiagnosticoPorImagen);
                    crystalReportViewer1.ReportSource = crEstudioDiagnosticoImagen;
                    crystalReportViewer1.RefreshReport();
                }
                else
                {
                    MessageBox.Show("No se encontró la información solicitada", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar reporte: " + ex.Message + " StackTrace: " + ex.StackTrace, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public dsHistoriaClinicaEstudioDiagnosticoPorImagen MostrarEstudioDiagnosticoPorImagen(int id_hc)
        {
            EstudioDiagnosticoPorImagenDAO.setCadenaConexion();
            SqlConnection cn = new SqlConnection(EstudioDiagnosticoPorImagenDAO.getCadenaConexion());
            dsHistoriaClinicaEstudioDiagnosticoPorImagen dsEstudioDiagnosticoImagen = null;

            SqlDataAdapter da = null;
            string consulta = @"select ed.fechaSolicitud,ne.nombre as 'nombreEstudio',COALESCE(NULL,CONVERT(varchar,ed.indicaciones),'N/A') as 'indicaciones', COALESCE(NULL,CONVERT(varchar,ed.fechaRealizacion),'N/A') as 'fechaRealizacion', ISNULL(ed.informe,'N/A') as 'informe', ISNULL(ed.observacionDeLosResultados,'N/A') as 'observacionesDeLosResultados', ediag.nombre as 'estadoDiagnostico',r.conceptoInicial,r.diagnostico,r.id_razonamiento
                                from Consulta co, ExamenGeneral ex, RazonamientoDiagnostico r, EstadoDiagnostico ediag, EstudiosDiagnosticoPorImagen ed, NombreEstudio ne
                                where r.id_estadoDiagnostico_fk=ediag.id_estadoDiagnostico
                                and ed.id_razonamientoDiagnostico_fk=r.id_razonamiento
                                and ed.id_nombreEstudio_fk=ne.id_nombreEstudio
                                and r.id_examenGeneral_fk=ex.id_examenGeneral
                                and co.id_examenGeneral_fk=ex.id_examenGeneral
                                and co.id_hc_fk=@id_hc
                                order by ed.fechaSolicitud desc";
            try
            {
                cn.Close();

                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@id_hc", id_hc);

                cmd.Connection = cn;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;

                da = new SqlDataAdapter(cmd);
                dsEstudioDiagnosticoImagen = new dsHistoriaClinicaEstudioDiagnosticoPorImagen();
                da.Fill(dsEstudioDiagnosticoImagen, "EstudiosDiagnosticoPorImagen");
                cn.Close();


            }
            catch (Exception e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                throw e;
            }
            return dsEstudioDiagnosticoImagen;
        }

        private void btnPracticasComplementarias_Click(object sender, EventArgs e)
        {
            crHistoriaClinicaPracticaComplementaria crPracticaComplementaria = new crHistoriaClinicaPracticaComplementaria();
            dsHistoriaClinicaPracticaComplementaria dsPracticaComplementaria = new dsHistoriaClinicaPracticaComplementaria();
            try
            {
                dsPracticaComplementaria = MostrarPracticasComplementarias(id_hc);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener información de estudios: " + ex.Message + " StackTrace: " + ex.StackTrace, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            try
            {
                if (dsPracticaComplementaria != null && dsPracticaComplementaria.Tables[0].Rows.Count > 0)
                {
                    crPracticaComplementaria.SetDataSource(dsPracticaComplementaria);
                    crystalReportViewer1.ReportSource = crPracticaComplementaria;
                    crystalReportViewer1.RefreshReport();
                }
                else
                {
                    MessageBox.Show("No se encontró la información solicitada", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar reporte: " + ex.Message + " StackTrace: " + ex.StackTrace, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public dsHistoriaClinicaPracticaComplementaria MostrarPracticasComplementarias(int id_hc)
        {
            AnalisisLaboratorioDAO.setCadenaConexion();
            SqlConnection cn = new SqlConnection(AnalisisLaboratorioDAO.getCadenaConexion());
            dsHistoriaClinicaPracticaComplementaria dsPracticaComplementaria = null;

            SqlDataAdapter da = null;
            string consulta = @"select pc.fechaSolicitud,tp.nombre as 'Practica', COALESCE(NULL,CONVERT(varchar,pc.indicaciones),'N/A') as 'indicaciones', COALESCE(NULL,CONVERT(varchar,pc.fechaRealizacion),'N/A') as 'fechaRealizacion', ISNULL(pc.observacionDeLosResultados,'N/A') as 'observacionesDeLosResultados',ediag.nombre as 'estadoDiagnostico',r.conceptoInicial,r.diagnostico,r.id_razonamiento
                                from  Consulta co, ExamenGeneral ex,RazonamientoDiagnostico r, EstadoDiagnostico ediag, PracticaComplementaria pc, TipoPracticaComplementaria tp
                                where r.id_estadoDiagnostico_fk=ediag.id_estadoDiagnostico
                                and pc.id_razonamientoDiagnostico_fk=r.id_razonamiento
                                and pc.id_tipoPractica_fk=tp.id_tipoPractica
                                and r.id_examenGeneral_fk=ex.id_examenGeneral
                                and co.id_examenGeneral_fk=ex.id_examenGeneral
                                and co.id_hc_fk=@id_hc
                                order by pc.fechaSolicitud desc";
            try
            {
                cn.Close();

                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@id_hc", id_hc);

                cmd.Connection = cn;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;

                da = new SqlDataAdapter(cmd);
                dsPracticaComplementaria = new dsHistoriaClinicaPracticaComplementaria();
                da.Fill(dsPracticaComplementaria, "PracticaComplementaria");
                cn.Close();
            }
            catch (Exception e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                throw e;
            }
            return dsPracticaComplementaria;
        }

        private void btnAnalisisLaboratorio_Click(object sender, EventArgs e)
        {
            crHistoriaClinicaAnalisisLaboratorio crAnalisisLaboratorio = new crHistoriaClinicaAnalisisLaboratorio();
            dsHistoriaClinicaAnalisisLaboratorio dsAnalisisLaboratorio = new dsHistoriaClinicaAnalisisLaboratorio();
            try
            {
                dsAnalisisLaboratorio = MostrarAnalisisLaboratorio(id_hc);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener información de analisis: " + ex.Message + " StackTrace: " + ex.StackTrace, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                if (dsAnalisisLaboratorio != null && dsAnalisisLaboratorio.Tables[0].Rows.Count > 0)
                {
                    crAnalisisLaboratorio.SetDataSource(dsAnalisisLaboratorio);
                    crystalReportViewer1.ReportSource = crAnalisisLaboratorio;
                    crystalReportViewer1.RefreshReport();
                }
                else
                {
                    MessageBox.Show("No se encontró la información solicitada", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar reporte: " + ex.Message + " StackTrace: " + ex.StackTrace, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public dsHistoriaClinicaAnalisisLaboratorio MostrarAnalisisLaboratorio(int id_hc)
        {
            PracticaComplementariaDAO.setCadenaConexion();
            SqlConnection cn = new SqlConnection(PracticaComplementariaDAO.getCadenaConexion());
            dsHistoriaClinicaAnalisisLaboratorio dsAnalisisLaboratorio = null;

            SqlDataAdapter da = null;
            string consulta = @"select l.fechaSolicitud,il.nombre as 'Estudio',ISNULL(l.indicaciones,'N/A') as 'indicaciones',COALESCE(NULL,CONVERT(varchar,l.fechaRealizacion),'N/A') as 'fechaRealizacion',ISNULL(l.observacionDeLosResultados,'N/A') as 'observacionDeLosResultados',r.conceptoInicial,r.diagnostico,ediag.nombre as 'estadoDiagnostico',r.id_razonamiento
                                from Consulta co, ExamenGeneral ex,RazonamientoDiagnostico r, EstadoDiagnostico ediag, LaboratorioNueva l, ItemLaboratorio il
                                where r.id_estadoDiagnostico_fk=ediag.id_estadoDiagnostico
                                and l.id_razonamientoDiagnostico_fk=r.id_razonamiento
                                and l.id_itemLaboratorio_fk=il.id_itemLaboratorio
                                and r.id_examenGeneral_fk=ex.id_examenGeneral
                                and co.id_examenGeneral_fk=ex.id_examenGeneral
                                and co.id_hc_fk=@id_hc
                                order by l.fechaSolicitud desc";
            try
            {
                cn.Close();

                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@id_hc", id_hc);

                cmd.Connection = cn;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;

                da = new SqlDataAdapter(cmd);
                dsAnalisisLaboratorio = new dsHistoriaClinicaAnalisisLaboratorio();
                da.Fill(dsAnalisisLaboratorio, "Laboratorio");
                cn.Close();
            }
            catch (Exception e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                throw e;
            }
            return dsAnalisisLaboratorio;
        }

        private void btnExamenesGenerales_Click(object sender, EventArgs e)
        {
            crExamenesGenerales CrExamenes = new crExamenesGenerales();
            dsHistoriaClinicaExamenGeneral dsExamen = new dsHistoriaClinicaExamenGeneral();
            crMensaje Crmensaje = new crMensaje();
            try
            {
                dsExamen = MostrarExamenesGeneralesExamenGeneral(id_hc);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener información los examénes: " + ex.Message + " StackTrace: " + ex.StackTrace, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                if (dsExamen != null && dsExamen.Tables[0].Rows.Count > 0)
                {
                    dsExamenGeneralPulso dsPulso = new dsExamenGeneralPulso();
                    crSubExamenGeneralPulso crPulso = new crSubExamenGeneralPulso();

                    dsExamenGeneralSintomas dsSintoma = new dsExamenGeneralSintomas();
                    crSubExamenGeneralSintomas crSintoma = new crSubExamenGeneralSintomas();

                    dsHistoriaClinicaPiel dsPiel = new dsHistoriaClinicaPiel();
                    crHistoriaClinicaPiel crPiel = new crHistoriaClinicaPiel();

                    dsExamenGeneralSistemaLinfatico dsSistemaLinfatico = new dsExamenGeneralSistemaLinfatico();
                    crExamenGeneralSistemaLinfatico crSistemaLinfatico = new crExamenGeneralSistemaLinfatico();

                    dsExamenGeneralTemperatura dsTemperatura = new dsExamenGeneralTemperatura();
                    crExamenGeneralTemperatura crTemperatura = new crExamenGeneralTemperatura();

                    dsExamenGeneralMedicionesPresionArterial dsMedicion = new dsExamenGeneralMedicionesPresionArterial();
                    crExamenGeneralMedicionPresionArterial crMedicion = new crExamenGeneralMedicionPresionArterial();

                    dsPiel = MostrarExamenesGeneralesPiel(id_hc);
                    dsSintoma = MostrarExamenesGeneralesSintomas(id_hc);
                    dsPulso = MostrarExamenesGeneralesPulso(id_hc);
                    dsSistemaLinfatico = MostrarExamenesSistemaLinfatico(id_hc);
                    dsTemperatura = MostrarExamenesTemperatura(id_hc);
                    dsMedicion = MostrarExamenesMedicionesPresionArterial(id_hc);

                    ReportDocument reportes = new ReportDocument();

                    //reportes.Load("C:\\Users\\usuario\\Desktop\\ProyectoFinal\\ProyectoFinal\\Gestor_PresiónArterial\\trunk\\Producto\\Iteración_2\\04 Implementacion\\Código\\GPA\\GPA\\Reportes\\crExamenesGenerales.rpt");

                    reportes.Load(Application.StartupPath.Replace("bin\\Debug", "") + "Reportes\\crExamenesGenerales.rpt");
                    if (dsSintoma != null && dsSintoma.Tables["Sintoma"].Rows.Count > 0)
                    {
                        reportes.Subreports["Síntomas"].SetDataSource(dsSintoma);
                    }
                    if (dsPiel != null && dsPiel.Tables["Piel"].Rows.Count > 0)
                    {
                        reportes.Subreports["Revisión de la Piel"].SetDataSource(dsPiel);
                    }
                    if (dsPulso != null && dsPulso.Tables["PulsoArterial"].Rows.Count > 0)
                    {
                        reportes.Subreports["Revisión Pulso"].SetDataSource(dsPulso);
                    }
                    if (dsSistemaLinfatico != null && dsSistemaLinfatico.Tables["SistemaLinfatico"].Rows.Count > 0)
                    {
                        reportes.Subreports["Revisión Sistema Linfático"].SetDataSource(dsSistemaLinfatico);
                    }
                    if (dsTemperatura != null && dsTemperatura.Tables["Temperatura"].Rows.Count > 0)
                    {
                        reportes.Subreports["Revisión Temperatura"].SetDataSource(dsTemperatura);
                    }
                    if (dsMedicion != null && dsMedicion.Tables["MedicionesPresionArterial"].Rows.Count > 0)
                    {
                        reportes.Subreports["Mediciones Presión Arterial"].SetDataSource(dsMedicion);
                    }
                    reportes.SetDataSource(dsExamen);

                    crystalReportViewer1.ReportSource = reportes;
                    crystalReportViewer1.RefreshReport();
                }
                else
                {
                    MessageBox.Show("No se encontró la información solicitada", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar reporte: " + ex.Message + " StackTrace: " + ex.StackTrace, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public dsHistoriaClinicaExamenGeneral MostrarExamenesGeneralesExamenGeneral(int id_hc)
        {
            ExamenGeneralDAO.setCadenaConexion();
            SqlConnection cn = new SqlConnection(ExamenGeneralDAO.getCadenaConexion());
            dsHistoriaClinicaExamenGeneral dsExamen;

            SqlDataAdapter da = null;
            string consulta = @"select c.id_consulta,
	                               c.nroConsulta, 
	                               c.fechaConsulta,
	                               c.horaConsulta,
	                               c.motivoConsulta,
	                               ISNULL(ex.posicionYDecubito,'N/A') as 'posicionYDecubito',
	                               ISNULL(ex.marchaYDeambulacion,'N/A') as 'marchaYDeambulacion',
	                               ISNULL(ex.facieExpresionFisonomia,'N/A') as 'facieExpresionFisonomia',
	                               ISNULL(ex.concienciaEstadoPsiquico,NULL) as 'concienciaEstadoPsiquico',
	                               ISNULL(ex.constitucionEstadoNutritivo,'N/A') as 'constitucionEstadoNutritivo',
	                               ISNULL(ex.peso,0) as 'peso',
	                               ISNULL(ex.talla,0) as 'talla',
	                               ex.id_examenGeneral,
	                               ex.descripcionComoRespira,
	                               ISNULL(ex.observacionesRespiracion,'N/A') as 'observacionesRespiracion'
                            from Consulta c full outer join ExamenGeneral ex on  c.id_examenGeneral_fk=ex.id_examenGeneral
                            full outer join Historia_Clinica hc on hc.id_hc=c.id_hc_fk 
                            where hc.id_hc=@id_hc
                            order by c.fechaConsulta desc";
            try
            {
                cn.Close();

                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@id_hc", id_hc);

                cmd.Connection = cn;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;

                da = new SqlDataAdapter(cmd);
                dsExamen = new dsHistoriaClinicaExamenGeneral();
                da.Fill(dsExamen, "ExamenGeneral");
                cn.Close();
            }
            catch (Exception e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                throw e;
            }
            return dsExamen;
        }
        public dsExamenGeneralPulso MostrarExamenesGeneralesPulso(int id_hc)
        {
            ExamenGeneralDAO.setCadenaConexion();
            SqlConnection cn = new SqlConnection(ExamenGeneralDAO.getCadenaConexion());
            dsExamenGeneralPulso dsPulso;

            SqlDataAdapter da = null;
            string consulta = @"select ISNULL(pu.auscultacion,'N/A') as 'auscultacion',
                               ISNULL(pu.observaciones,'N/A') as 'observaciones',
	                           p.nombre as 'Pulso', 
	                           ep.nombre as 'EscalaIzquierdo',
	                           ep2.nombre as 'EscalaDerecho',
	                           c.nroConsulta,
	                           ex.id_examenGeneral,
                               c.id_consulta
                        from PulsoArterial pu 
                        full outer join DetallePulsoArterial dpu on pu.id_pulsoArterial=dpu.id_pulsoArterial
                        full outer join EscalaPulso ep on dpu.id_izquierda_fk=ep.id_escalaPulso
                        full outer join EscalaPulso ep2 on dpu.id_derecha_fk=ep2.id_escalaPulso
                        full outer join Pulso p on p.id_Pulso=dpu.id_pulso_fk
                        full outer join ExamenGeneral ex on  ex.id_pulsoArterial_fk=pu.id_pulsoArterial
                        full outer join Consulta c on  c.id_examenGeneral_fk=ex.id_examenGeneral
                        full outer join Historia_Clinica hc on c.id_hc_fk=hc.id_hc
                        where hc.id_hc=@id_hc
                        order by c.fechaConsulta desc";
            try
            {
                cn.Close();

                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@id_hc", id_hc);

                cmd.Connection = cn;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;

                da = new SqlDataAdapter(cmd);
                dsPulso = new dsExamenGeneralPulso();
                da.Fill(dsPulso, "PulsoArterial");
                cn.Close();
            }
            catch (Exception e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                throw e;
            }
            return dsPulso;
        }
        public dsExamenGeneralSintomas MostrarExamenesGeneralesSintomas(int id_hc)
        {
            SintomaDAO.setCadenaConexion();
            SqlConnection cn = new SqlConnection(SintomaDAO.getCadenaConexion());
            dsExamenGeneralSintomas dsSintoma;

            SqlDataAdapter da = null;
            string consulta = @"select COALESCE(NULL,CONVERT(varchar,s.fechaInicioSintoma),'N/A') as 'fechaInicioSintoma',
                                COALESCE(NULL,CONVERT(varchar,ts.nombre),'N/A') as 'TipoSintoma', 
                                COALESCE(NULL,CONVERT(varchar,s.descripcion),'N/A') as 'descripcion' , 
                                COALESCE(NULL,CONVERT(varchar,pc.nombre),'N/A')  as 'ParteCuerpo', 
                                COALESCE(NULL,CONVERT(varchar,cd.nombre),'N/A')  as 'CaracterDolor', 
                                COALESCE(NULL,CONVERT(varchar,s.haciaDondeIrradia),'N/A') as 'haciaDondeIrradia', 
                                COALESCE(NULL,CONVERT(varchar,s.cantidadDeTiempo),'N/A')  as 'cantidadDiasInicio',
                                COALESCE(NULL,CONVERT(varchar,et.nombre),'N/A')  as 'elementoTiempo',
                                COALESCE(NULL,CONVERT(varchar,dt.nombre),'N/A')  as 'descripcionTiempo',
                                COALESCE(NULL,CONVERT(varchar,ms.nombre),'N/A')  as 'ComoSeModifica',
                                COALESCE(NULL,CONVERT(varchar,em.id_elementoDeModificacion),'N/A') as 'id_elementoDeModificacion', 
                                COALESCE(NULL,CONVERT(varchar,em.nombre),'N/A')  as 'ElementoModificacion',
                                COALESCE(NULL,CONVERT(varchar,ex.id_examenGeneral),'N/A') as id_examenGeneral,
                                COALESCE(NULL,CONVERT(varchar,c.id_consulta),'N/A') as id_consulta
                                from Consulta c
                                left outer join ExamenGeneral ex on c.id_examenGeneral_fk=ex.id_examenGeneral
                                left outer join Historia_Clinica hc on hc.id_hc=c.id_hc_fk 
                                left outer join Sintoma s on s.id_consulta_fk=c.id_consulta 
                                right outer join ElementoDelTiempo et on et.id_elementoDelTiempo=s.id_elementoDelTiempo_fk 
                                right outer join DescripcionDelTiempo dt on dt.id_descripcionDelTiempo=s.id_descripcionDelTiempo_fk
                                right outer join TipoSintoma ts on ts.id_TipoSintoma= s.id_tipoSintoma_fk
                                right outer join ParteDelCuerpo pc on pc.id_parteDelCuerpo=s.id_parteDelCuerpo_fk
                                right outer join CaracterDelDolor cd on cd.id_caracterDelDolor=s.id_caracterDolor_fk
                                right outer join ModificacionSintoma ms on ms.id_modificacionesSintoma=s.id_comoSeModifica_fk
                                left outer join ElementoDeModificacion em on em.id_elementoDeModificacion=s.id_elementoDeModificacion_fk
                                where hc.id_hc=@id_hc
                                order by c.fechaConsulta desc";
            try
            {
                cn.Close();

                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@id_hc", id_hc);

                cmd.Connection = cn;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;

                da = new SqlDataAdapter(cmd);
                dsSintoma = new dsExamenGeneralSintomas();
                da.Fill(dsSintoma, "Sintoma");
                cn.Close();
            }
            catch (Exception e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                throw e;
            }
            return dsSintoma;
        }
        public dsHistoriaClinicaPiel MostrarExamenesGeneralesPiel(int id_hc)
        {
            PielDAO.setCadenaConexion();
            SqlConnection cn = new SqlConnection(PielDAO.getCadenaConexion());
            dsHistoriaClinicaPiel dsPiel;

            SqlDataAdapter da = null;
            string consulta = @"select c.id_consulta,
                                c.nroConsulta, 
                                c.fechaConsulta,
                                c.horaConsulta,
                                ISNULL(p.color,'N/A') as 'color',
                                ISNULL(p.elasticidad,'N/A') as 'elasticidad', 
                                ISNULL(p.humedad,'N/A') as 'humedad',
                                ISNULL(p.lesiones,'N/A') as 'lesiones',
                                ISNULL(p.turgor,'N/A') as 'turgor',
                                ISNULL(p.untuosidad,'N/A') as 'untuosidad',
                                ISNULL(tp.nombre,'N/A') as 'temperatura',
                                ex.id_examenGeneral
                                from Consulta c, ExamenGeneral ex, Historia_Clinica hc, Piel  p, TemperaturaPiel tp
                                where c.id_examenGeneral_fk=ex.id_examenGeneral
                                and hc.id_hc=c.id_hc_fk 
                                and ex.id_piel_fk=p.id_piel
                                and p.id_temperatura_fk=tp.id_temperatura
                                and hc.id_hc=@id_hc
                                order by c.fechaConsulta desc";
            try
            {
                cn.Close();

                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@id_hc", id_hc);

                cmd.Connection = cn;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;

                da = new SqlDataAdapter(cmd);
                dsPiel = new dsHistoriaClinicaPiel();
                da.Fill(dsPiel, "Piel");
                cn.Close();
            }
            catch (Exception e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                throw e;
            }
            return dsPiel;
        }
        public dsExamenGeneralSistemaLinfatico MostrarExamenesSistemaLinfatico(int id_hc)
        {
            SistemaLinfaticoDAO.setCadenaConexion();
            SqlConnection cn = new SqlConnection(SistemaLinfaticoDAO.getCadenaConexion());
            dsExamenGeneralSistemaLinfatico dsSistemaLinfatico;

            SqlDataAdapter da = null;
            string consulta = @"select c.id_consulta,
                                c.nroConsulta,
                                c.fechaConsulta,
                                c.horaConsulta,
                                c.motivoConsulta,
                                usl.nombre as 'ubicacion',
                                slt.nombre as 'tamaño',
                                sl.aproximacionNumerica,
                                slc.nombre as 'consistencia',
                                sl.id_sistemaLinfatico,
                                ex.id_examenGeneral
                                from Consulta c, ExamenGeneral ex, Historia_Clinica hc, SistemaLinfatico sl, Ubicacion usl,Tamaño slt,Consistencia slc
                                where c.id_examenGeneral_fk=ex.id_examenGeneral
                                and hc.id_hc=c.id_hc_fk 
                                and ex.id_examenGeneral=sl.id_examenGeneral_fk
                                and sl.id_ubicacion_fk=usl.id_ubicacion
                                and sl.id_tamaño_fk=slt.id_tamaño
                                and sl.id_consistencia_fk=slc.id_consistencia
                                and hc.id_hc=@id_hc
                                order by c.fechaConsulta desc;";
            try
            {
                cn.Close();

                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@id_hc", id_hc);

                cmd.Connection = cn;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;

                da = new SqlDataAdapter(cmd);
                dsSistemaLinfatico = new dsExamenGeneralSistemaLinfatico();
                da.Fill(dsSistemaLinfatico, "SistemaLinfatico");
                cn.Close();
            }
            catch (Exception e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                throw e;
            }
            return dsSistemaLinfatico;
        }
        public dsExamenGeneralTemperatura MostrarExamenesTemperatura(int id_hc)
        {
            TemperaturaDAO.setCadenaConexion();
            SqlConnection cn = new SqlConnection(TemperaturaDAO.getCadenaConexion());
            dsExamenGeneralTemperatura dsTemperatura;

            SqlDataAdapter da = null;
            string consulta = @"select c.id_consulta,
                                c.nroConsulta,
                                c.fechaConsulta,
                                c.horaConsulta,
                                c.motivoConsulta,
                                ex.id_examenGeneral,
                                sm.nombre as 'SitioMedicion',
                                te.temperaturaGradosCentigrados,
                                rt.nombre as 'ResultadoTemperatura'
                                from Consulta c, ExamenGeneral ex, Historia_Clinica hc,Temperatura te,SitioMedicionTemperatura sm, ResultadoTemperatura rt
                                where c.id_examenGeneral_fk=ex.id_examenGeneral
                                and hc.id_hc=c.id_hc_fk
                                and ex.id_examenGeneral=te.id_examenGeneral_fk
                                and te.id_sitioMedicio_fk=sm.id_sitioMedicionTemperatura
                                and te.id_resultadoTemperatura_fk=rt.id_resultadoTemperatura
                                and hc.id_hc=@id_hc
                                order by c.fechaConsulta desc";
            try
            {
                cn.Close();

                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@id_hc", id_hc);

                cmd.Connection = cn;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;

                da = new SqlDataAdapter(cmd);
                dsTemperatura = new dsExamenGeneralTemperatura();
                da.Fill(dsTemperatura, "Temperatura");
                cn.Close();
            }
            catch (Exception e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                throw e;
            }
            return dsTemperatura;
        }
        public dsExamenGeneralMedicionesPresionArterial MostrarExamenesMedicionesPresionArterial(int id_hc)
        {
            MedicionDePresionArterialDAO.SetCadenaConexion();
            SqlConnection cn = new SqlConnection(MedicionDePresionArterialDAO.GetCadenaConexion());
            dsExamenGeneralMedicionesPresionArterial dsMedicion;

            SqlDataAdapter da = null;
            string consulta = @"select c.fechaConsulta,m.id_medicion,m.horaInicio,m.fecha,CAST(ex.nombre as nvarchar(100)) as 'Extremidad',CAST(uex.nombre as nvarchar(100)) as 'UbicacionExtremidad',CAST(sm.nombre as nvarchar(100)) as 'SitioMedicion',CAST(md.nombre as nvarchar(100)) as 'MomentoDelDía',CAST(p.nombre as nvarchar(100)) as 'Posicion',d.hora as 'horaDetallaMedicion',d.valorMaximo as 'Sistolica',d.valorMinimo as 'Diastolica',d.pulso,exa.id_examenGeneral,c.id_consulta
                                from Consulta c,ExamenGeneral exa, MedicionDePrecionArterial m, DetalleMedicionPresionArterial d,Extremidad ex,UbicacionExtremidad uex,SitioMedicion sm, MomentoDelDia md, Posicion p
                                where m.id_medicion=d.id_medicion_fk
                                and m.id_extremidad_fk=ex.id_extremidad
                                and m.id_ubicacionExtremidad_fk=uex.id_ubicacionExtremidad
                                and m.id_posicion_fk=p.id_posicion
                                and m.id_momentoDelDia_fk=md.id_momentoDelDia
                                and m.id_sitioMedicion_fk= sm.id_sitioMedicion
                                and m.id_hc_fk=@id_hc
                                and m.id_medicion=exa.id_medicion_fk
                                and c.id_examenGeneral_fk=exa.id_examenGeneral
                                order by c.fechaConsulta desc";
            try
            {
                cn.Close();

                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@id_hc", id_hc);

                cmd.Connection = cn;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;

                da = new SqlDataAdapter(cmd);
                dsMedicion = new dsExamenGeneralMedicionesPresionArterial();
                da.Fill(dsMedicion, "MedicionesPresionArterial");
                cn.Close();
            }
            catch (Exception e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                throw e;
            }
            return dsMedicion;
        }
        public dsTratamientoMedicamento MostrarTratamientoMedicamento(int id_hc)
        {
            TratamientoDAO.setCadenaConexion();
            SqlConnection cn = new SqlConnection(TratamientoDAO.getCadenaConexion());
            dsTratamientoMedicamento dsTratamientoMedicamento;

            SqlDataAdapter da = null;
            string consulta = @"select  t.id_tratamiento,COALESCE(NULL,CONVERT(varchar,t.indicaciones),'N/A') as 'indicaciones',t.fechaInicio, COALESCE(NULL,CONVERT(varchar,t.motivoInicioTratamiento),'N/A') as 'motivoInicioTratamiento', te.id_terapia, te.nombre  as 'Terapia', COALESCE(NULL,CONVERT(varchar,t.fechaFin),'N/A') as 'FechaFin' ,ISNULL(t.motivoFinTratamiento,'N\A') as 'motivoFinTratamiento',ISNULL(rd.diagnostico,'N\A') as 'diagnostico', me.nombreGenerico 'NombreMedicamento',me.concentracion, fre.nombre as 'Frecuencia', COALESCE(NULL,md1.nombre,'N/A') as 'Momento del dia 1', COALESCE(NULL,md2.nombre,'N/A') as 'Momento del dia 2',COALESCE(NULL,md3.nombre,'N/A') as 'Momento del Dia 3', case when CONCAT(pm.cantidadNumerador1, '/', pm.cantidadDenominador1) = '/' then 'N/A' else CONCAT(pm.cantidadNumerador1, '/', pm.cantidadDenominador1) END as 'Dosis 1',case when CONCAT(pm.cantidadNumerador2, '/', pm.cantidadDenominador2) = '/' then 'N/A' else CONCAT(pm.cantidadNumerador2, '/', pm.cantidadDenominador2) END as 'Dosis 2',case when CONCAT(pm.cantidadNumerador3, '/', pm.cantidadDenominador3) = '/' then 'N/A' else CONCAT(pm.cantidadNumerador3, '/', pm.cantidadDenominador3) END as 'Dosis 3', COALESCE(NULL,pre1.nombre,'N/A') as 'Presentacion Medicamento 1',COALESCE(NULL,pre2.nombre,'N/A') as 'Presentacion Medicamento 2', COALESCE(NULL,pre3.nombre,'N/A') as 'Presentacion Medicamento 3',COALESCE(NULL,CONVERT(varchar,pm.hora1),'N/A') as 'Hora 1', COALESCE(NULL,CONVERT(varchar,pm.hora2),'N/A') as 'Hora 2',COALESCE(NULL,CONVERT(varchar,pm.hora3),'N/A') as 'Hora 3', um.nombre as 'UnidadMedida', estp.nombre as 'EstadoProgramacion',esp.concentracion as 'Cantidad'
                                from Tratamiento t , Terapia te, RazonamientoDiagnostico rd, ExamenGeneral eg, Consulta c, ProgramacionMedicamento pm, Medicamento me, Frecuencia fre, MomentoDelDia md1,MomentoDelDia md2,MomentoDelDia md3, PresentacionMedicamento pre1, PresentacionMedicamento pre2, PresentacionMedicamento pre3, EstadoProgramacion estp, EspecificacionMedicamento esp, UnidadMedida um
                                where c.id_examenGeneral_fk=eg.id_examenGeneral
								and t.id_terapia_fk=te.id_terapia
								and rd.id_examenGeneral_fk=eg.id_examenGeneral
                                and t.id_razonamientoDiagnostico_fk=rd.id_razonamiento
								and c.id_hc_fk=@id_hc
								and te.nombre like 'Medicamentos'
								and t.id_tratamiento=pm.id_tratamiento_fk
								and pm.id_medicamento_fk=me.id_medicamento
								and pm.id_frecuencia_fk=fre.id_frecuencia
								and pm.id_momentoDia1_fk=md1.id_momentoDelDia
								and pm.id_momentoDia2_fk=md2.id_momentoDelDia
								and pm.id_momentoDia3_fk=md3.id_momentoDelDia
								and pm.id_presentacionMedicamento1_fk=pre1.id_presentacionMedicamento
								and pm.id_presentacionMedicamento2_fk=pre2.id_presentacionMedicamento
								and pm.id_presentacionMedicamento3_fk=pre3.id_presentacionMedicamento
								and pm.id_estado_fk=estp.id_estadoProgramacion
								and pm.id_especificacionMedicamento_fk=esp.id_especificacion
								and esp.id_unidadMedida_fk=um.id_unidadMedida";
            try
            {
                cn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@id_hc", id_hc);

                cmd.Connection = cn;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;

                da = new SqlDataAdapter(cmd);
                dsTratamientoMedicamento = new dsTratamientoMedicamento();
                da.Fill(dsTratamientoMedicamento, "ProgramacionMedicamento");
                cn.Close();
            }
            catch (Exception e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                throw e;
            }
            return dsTratamientoMedicamento;
        }
        public dsTratamientos MostrarTratamiento(int id_hc)
        {
            TratamientoDAO.setCadenaConexion();
            SqlConnection cn = new SqlConnection(TratamientoDAO.getCadenaConexion());
            dsTratamientos dsTratamiento;

            SqlDataAdapter da = null;
            string consulta = @"select  t.id_tratamiento,t.indicaciones,t.fechaInicio,t.motivoInicioTratamiento,  COALESCE(NULL,CONVERT(varchar,t.fechaFin),'N/A') as 'FechaFin', te.id_terapia, te.nombre  as 'Terapia',ISNULL(t.motivoFinTratamiento,'N\A') as 'motivoFinTratamiento',ISNULL(rd.diagnostico,'N\A') as 'diagnostico'
                                from Tratamiento t , Terapia te, RazonamientoDiagnostico rd, ExamenGeneral eg, Consulta c
                                where c.id_examenGeneral_fk=eg.id_examenGeneral
                                and t.id_terapia_fk=te.id_terapia
                                and rd.id_examenGeneral_fk=eg.id_examenGeneral
                                and t.id_razonamientoDiagnostico_fk=rd.id_razonamiento
                                and c.id_hc_fk=@id_hc
                                and te.nombre in('Dieta','Actividad Física')
                                order by c.fechaConsulta desc";
            try
            {
                cn.Close();

                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@id_hc", id_hc);

                cmd.Connection = cn;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;

                da = new SqlDataAdapter(cmd);
                dsTratamiento = new dsTratamientos();
                da.Fill(dsTratamiento, "Tratamiento");
                cn.Close();
            }
            catch (Exception e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                throw e;
            }
            return dsTratamiento;
        }

        private void btnTratamientos_Click(object sender, EventArgs e)
        {
            crTratamientos crTratamientos = new crTratamientos();
            dsTratamientoMedicamento dsTratamientoMedicamento = new dsTratamientoMedicamento();

            crOtrosTratamientos crOtroTratamiento = new crOtrosTratamientos();
            dsTratamientos dsTratamiento = new dsTratamientos();
            //try
            //{
                
            //}
            //catch(Exception ex)
            //{
            //    MessageBox.Show("Error al generar reporte: " + ex.Message + " StackTrace: " + ex.StackTrace, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}
            try
            {
                dsTratamientoMedicamento = MostrarTratamientoMedicamento(id_hc);
                dsTratamiento = MostrarTratamiento(id_hc);

                ReportDocument reportes = new ReportDocument();

                reportes.Load(Application.StartupPath.Replace("bin\\Debug", "") + "Reportes\\crTratamientos.rpt");
                if (dsTratamientoMedicamento != null && dsTratamientoMedicamento.Tables["ProgramacionMedicamento"].Rows.Count > 0)
                {
                    reportes.Subreports["Tratamiento Medicamento"].SetDataSource(dsTratamientoMedicamento);
                
                }
                if (dsTratamiento != null && dsTratamiento.Tables["Tratamiento"].Rows.Count > 0)
                {
                    reportes.Subreports["Otros Tratamientos"].SetDataSource(dsTratamiento);

                }

                crystalReportViewer1.ReportSource = reportes;
                crystalReportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar reporte: " + ex.Message + " StackTrace: " + ex.StackTrace, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
