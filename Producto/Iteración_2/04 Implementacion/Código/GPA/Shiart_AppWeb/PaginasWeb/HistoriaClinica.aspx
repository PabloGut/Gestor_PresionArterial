<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasWeb/EstructuraBase.Master" AutoEventWireup="true" CodeBehind="HistoriaClinica.aspx.cs" Inherits="Shiart_AppWeb.PaginasWeb.HistoriaClinica" %>
<asp:Content runat="server" ID="HistoriaClinica" ContentPlaceHolderID="HistoriaClinica" >
       <div class="container-fluid">

           <div class="row">
               <div class="col col-sm-12 col-md-12 col-lg-12">
                   <h1>Generar Informe de Historia Clínica</h1>
                   <p>Seleccionar la información a incluir en el informe</p>
               </div>
           </div>

           <div class="row infoHistoriaClinica">
               <div class="col col-sm-12 col-md-12 col-lg-12">
                   <h3>Antecedentes</h3>

                   <div class="form-check-inline">
                       <label class="form-check-label">
                           <input runat="server" type="checkbox" class="form-check-input" value="">Antecedentes Mórbidos
                       </label>
                   </div>

                   <div class="form-check-inline">
                       <label class="form-check-label">
                           <input runat="server" type="checkbox" class="form-check-input" value="">Antecedentes Gineco Obstétricos
                       </label>
                   </div>

                    <div class="form-check-inline">
                       <label class="form-check-label">
                           <input runat="server" type="checkbox" class="form-check-input" value="">Antecedentes Patológicos Familiares
                       </label>
                   </div>

                   <div class="form-check-inline">
                       <label class="form-check-label">
                           <input runat="server" type="checkbox" class="form-check-input" value="">Antecedentes Personales
                       </label>
                   </div>

               </div>

           </div>

           <div class="row infoHistoriaClinica">
                 <div class="col col-sm-12 col-md-12 col-lg-12">
                   <h3>Alergias</h3>

                   <div class="form-check-inline">
                       <label class="form-check-label">
                           <input runat="server" type="checkbox" class="form-check-input" value="">Alergias
                       </label>
                   </div>
               </div>
           </div>

           <div class="row infoHistoriaClinica">
               <div class="col col-sm-12 col-md-12 col-lg-12">
                   <h3>Hábitos</h3>

                   <div class="form-check-inline">
                       <label class="form-check-label">
                           <input runat="server" type="checkbox" class="form-check-input" value="">Hábitos Tabaquismo
                       </label>
                   </div>

                   <div class="form-check-inline">
                       <label class="form-check-label">
                           <input runat="server" type="checkbox" class="form-check-input" value="">Hábitos Drogas Ilicitas
                       </label>
                   </div>

                   <div class="form-check-inline">
                       <label class="form-check-label">
                           <input runat="server" type="checkbox" class="form-check-input" value="">Hábitos Drogas lìcitas
                       </label>
                   </div>

                   <div class="form-check-inline">
                       <label class="form-check-label">
                           <input runat="server" type="checkbox" class="form-check-input" value="">Hábitos Actividad Física
                       </label>
                   </div>

               </div>
           </div>

           <div class="row infoHistoriaClinica">
               <div class="col col-sm-12 col-md-12 col-lg-12">
                    <h3>Información de Atención en consultorio</h3>

                   <div class="form-check-inline">
                       <label class="form-check-label">
                           <input runat="server" type="checkbox" class="form-check-input" value="">Consultas/Exámenes generales/Diagnósticos
                       </label>
                   </div>
               </div>
           </div>

            <div class="row infoHistoriaClinica">
               <div class="col col-sm-12 col-md-12 col-lg-12">
                    <h3>Información Tratamientos</h3>

                   <div class="form-check-inline">
                       <label class="form-check-label">
                           <input runat="server" type="checkbox" class="form-check-input" value="">Tratamientos
                       </label>
                   </div>
               </div>
           </div>

            <div class="row infoHistoriaClinica">
               <div class="col col-sm-12 col-md-12 col-lg-12">
                    <h3>Información Prácticas</h3>

                   <div class="form-check-inline">
                       <label class="form-check-label">
                           <input runat="server" type="checkbox" class="form-check-input" value="">Estudios
                       </label>
                   </div>

                    <div class="form-check-inline">
                       <label class="form-check-label">
                           <input runat="server" type="checkbox" class="form-check-input" value="">Análisis Clínicos
                       </label>
                   </div>

                    <div class="form-check-inline">
                       <label class="form-check-label">
                           <input runat="server" type="checkbox" class="form-check-input" value="">Prácticas Complementarias
                       </label>
                   </div>
               </div>
           </div>

           <div class="row botonHistoriaClinica">
               <div class="col col-sm-12 col-md-12 col-lg-12 form-group">
                   <asp:Button runat="server" ID="Button1" CssClass="btn btn-primary" AutoPostBack="True" Text="Generar"></asp:Button>
               </div>
           </div>
   </div>
</asp:Content>