<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasWeb/EstructuraBase.Master" AutoEventWireup="true" CodeBehind="HistoriaClinica.aspx.cs" Inherits="Shiart_AppWeb.PaginasWeb.HistoriaClinica" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<%--<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Cu<a href="HistoriaClinica.aspx">HistoriaClinica.aspx</a>lture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>--%>
<asp:Content runat="server" ID="HistoriaClinica" ContentPlaceHolderID="HistoriaClinica" >
       <div class="container-fluid">

           <div class="row">
               <div class="col col-sm-12 col-md-12 col-lg-12">
                   <h1>Generar Informe de Historia Clínica</h1>
                   <div class="col col-sm-12 col-md-12 col-lg-12">
                       <div class="form-check-inline">
                           <label class="form-check-label">
                               <p>Seleccionar la información a incluir en el informe</p>
                           </label>
                   </div>
                       <div class="form-check-inline">
                           <label class="form-check-label">
                               <asp:CheckBox runat="server" type="checkbox" class="form-check-input" value="" ID="cbSeleccionarTodos" Text="Seleccionar Todos" OnCheckedChanged="CbSeleccionarTodos_CheckedChanged" AutoPostBack="True" />
                           </label>
                       </div>
                   </div>
               </div>
           </div>

           <div class="row infoHistoriaClinica">
               <div class="col col-sm-12 col-md-12 col-lg-12">
                   <h3>Antecedentes</h3>

                   <div class="form-check-inline">
                       <label class="form-check-label">
                           <asp:CheckBox runat="server" type="checkbox" class="form-check-input" value="" id="cbAntecedentesMorbidos" Text="Antecedentes Mórbidos"/>
                       </label>
                   </div>

                   <div class="form-check-inline">
                       <label class="form-check-label">
                            <asp:CheckBox runat="server" type="checkbox" class="form-check-input" value="" id="cbAntecedentesGinecoObstetricos" Text="Antecedentes Gineco Obstétricos"/>
                       </label>
                   </div>

                    <div class="form-check-inline">
                       <label class="form-check-label">
                            <asp:CheckBox runat="server" type="checkbox" class="form-check-input" value="" id="cbAntecedentesPatologicosFamiliares" Text="Antecedentes Patológicos Familiares"/>
                       </label>
                   </div>

                   <div class="form-check-inline">
                       <label class="form-check-label">
                           <asp:CheckBox runat="server" type="checkbox" class="form-check-input" value="" id="cbAntecedentesPersonales" Text="Antecedentes Personales"/>
                       </label>
                   </div>

               </div>

           </div>

           <div class="row infoHistoriaClinica">
                 <div class="col col-sm-12 col-md-12 col-lg-12">
                   <h3>Alergias</h3>

                   <div class="form-check-inline">
                       <label class="form-check-label">
                            <asp:CheckBox runat="server" type="checkbox" class="form-check-input" value="" id="cbAlergias" Text="Alergias"/>
                       </label>
                   </div>
               </div>
           </div>

           <div class="row infoHistoriaClinica">
               <div class="col col-sm-12 col-md-12 col-lg-12">
                   <h3>Hábitos</h3>

                   <div class="form-check-inline">
                       <label class="form-check-label">
                           <asp:CheckBox runat="server" type="checkbox" class="form-check-input" value="" id="cbHabitoTabaquismo" Text="Hábitos Tabaquismo"/>
                       </label>
                   </div>

                   <div class="form-check-inline">
                       <label class="form-check-label">
                           <asp:CheckBox runat="server" type="checkbox" class="form-check-input" value="" id="cbHabitoAlcoholismo" Text="Hábitos Alcoholismo"/>
                       </label>
                   </div>

                   <div class="form-check-inline">
                       <label class="form-check-label">
                           <asp:CheckBox runat="server" type="checkbox" class="form-check-input" value="" id="cbHabitoDrogasIlicitas" Text="Hábitos Drogas Ilicitas"/>
                       </label>
                   </div>

                   <div class="form-check-inline">
                       <label class="form-check-label">
                            <asp:CheckBox runat="server" type="checkbox" class="form-check-input" value="" id="cbHabitoDrogasLicitas" Text="Hábitos Drogas Lícitas"/>
                       </label>
                   </div>

                   <div class="form-check-inline">
                       <label class="form-check-label">
                             <asp:CheckBox runat="server" type="checkbox" class="form-check-input" value="" id="cbHabitoActividadFisica" Text="Hábitos Actividad Física"/>
                       </label>
                   </div>

               </div>
           </div>

           <div class="row infoHistoriaClinica">
               <div class="col col-sm-12 col-md-12 col-lg-12">
                    <h3>Información de Atención en consultorio</h3>

                   <div class="form-check-inline">
                       <label class="form-check-label">
                             <asp:CheckBox runat="server" type="checkbox" class="form-check-input" value="" id="cbConsultas" Text="Consultas"/>
                       </label>
                   </div>

                   <div class="form-check-inline">
                       <label class="form-check-label">
                             <asp:CheckBox runat="server" type="checkbox" class="form-check-input" value="" id="cbExamenesGenerales" Text="Exámenes"/>
                       </label>
                   </div>
               </div>
           </div>

            <div class="row infoHistoriaClinica">
               <div class="col col-sm-12 col-md-12 col-lg-12">
                    <h3>Información Tratamientos</h3>

                   <div class="form-check-inline">
                       <label class="form-check-label">
                            <asp:CheckBox runat="server" type="checkbox" class="form-check-input" value="" id="cbTratamientos" Text="Tratamientos"/>
                       </label>
                   </div>

                    <div class="form-check-inline">
                       <label class="form-check-label">
                            <asp:CheckBox runat="server" type="checkbox" class="form-check-input" value="" id="cbTratamientoMedicamento" Text="Tratamientos de Medicamentos"/>
                       </label>
                   </div>
               </div>
           </div>

            <div class="row infoHistoriaClinica">
               <div class="col col-sm-12 col-md-12 col-lg-12">
                    <h3>Información Prácticas</h3>

                   <div class="form-check-inline">
                       <label class="form-check-label">
                            <asp:CheckBox runat="server" type="checkbox" class="form-check-input" value="" id="cbEstudioDiagnosticoPorImagen" Text="Estudios Diagnstico por Imagen"/>
                       </label>
                   </div>

                    <div class="form-check-inline">
                       <label class="form-check-label">
                             <label class="form-check-label">
                                 <asp:CheckBox runat="server" type="checkbox" class="form-check-input" value="" ID="cbAnalisisClinicos" Text="Análisis Clínicos" />
                             </label>
                       </label>
                   </div>

                    <div class="form-check-inline">
                       <label class="form-check-label">
                                <label class="form-check-label">
                                    <asp:CheckBox runat="server" type="checkbox" class="form-check-input" value="" ID="cbPracticasComplementarias" Text="Prácticas Complementarias" />
                                </label>
                       </label>
                   </div>
               </div>
           </div>

             <div class="row infoHistoriaClinica">
               <div class="col col-sm-12 col-md-12 col-lg-12">
                    <h3>Mediciones de presión arterial</h3>

                   <div class="form-check-inline">
                       <label class="form-check-label">
                            <asp:CheckBox runat="server" type="checkbox" class="form-check-input" value="" id="cbMedicionesPresionArterial" Text="Mediciones de presión arterial"/>
                       </label>
                   </div>
               </div>
           </div>


           <div class="row botonHistoriaClinica">
               <div class="col col-sm-12 col-md-12 col-lg-12 form-group">
                   <asp:Button runat="server" ID="btnGenerarInformeHistoriClinica" CssClass="btn btn-primary" AutoPostBack="True" Text="Generar" OnClick="btnGenerarInformeHistoriClinica_Click"></asp:Button>
              
               </div>
           </div>
             
   </div>

   
      
</asp:Content>