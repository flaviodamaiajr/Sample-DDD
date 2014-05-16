<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExemploConsulta.aspx.cs" Inherits="Agenda.Web.ExemploConsulta" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Exemplo DDD</title>
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="Content/font-awesome.min.css" rel="stylesheet" />
    <style>
        body {
            padding-top: 70px;
        }
    </style>

</head>
<body>
    <div class="navbar navbar-inverse navbar-fixed-top" role="navigation">
        <div class="container">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <a class="navbar-brand" href="#">Agenda</a>
            </div>
            <div class="collapse navbar-collapse">
                <ul class="nav navbar-nav">
                    <li class="active"><a href="#">Contatos</a></li>
                    <li><a href="Sobre.aspx">Sobre</a></li>
                </ul>
                <%--  <form class="navbar-form navbar-right" role="search">
                    <div class="input-group">
                        <input id="filtroNome" name="filtroNome" type="text" class="form-control" placeholder="Filtrar por nome..." onkeypress="filtrarPorNome();" />
                        <span class="input-group-addon"><i class="glyphicon glyphicon-search"></i></span>
                    </div>
                </form>--%>
            </div>
            <!--/.nav-collapse -->
        </div>
    </div>

    <div class="container">

        <div class="page-header">
            <h1 id="quantidade">&nbsp;</h1>
            <%--<p class="lead">Basic grid layouts to get you familiar with building within the Bootstrap grid system.</p>--%>
        </div>

        <form id="formConsulta" runat="server">
            <ol class="breadcrumb">
                <li><a href="CadastroContato.aspx" class="btn btn-success btn-sm"><i class='glyphicon glyphicon-plus-sign'></i> Novo Contato</a></li>
            </ol>
            <div id="agenda">
            </div>
        </form>
        <hr />

        <footer>
            <p>Copyright &copy; <a href="https://github.com/flaviodamaiajr">Flávio da Maia Júnior </a>2014</p>
        </footer>

    </div>

    <script src="Scripts/jquery-1.9.0.min.js"></script>
    <%--<script src="Scripts/jquery-1.9.0.intellisense.js"></script>--%>
    <script src="Scripts/bootstrap.min.js"></script>
    <%-- <script type="text/javascript" src="//datatables.net/release-datatables/media/js/jquery.dataTables.js"></script>--%>
    <script type="text/javascript">

        $(document).ready(function () {
            ListarContatos();
        });

        function BuildTable(value) {
            var table = '<table class="table table-hover"><thead><tr><th>Nome</th><th>Contato</th><th>Data Aniversário</th><th></th></thead><tbody>';
            var count = 0;
            for (var i in value) {
                var editar = "EditarContato('" + value[i].PsaId + "');";
                var excluir = "ExcluirContato('" + value[i].PsaId + "');";

                var row = "<tr>";
                row += "<td>" + value[i].PsaNome.toString() + " " + value[i].PsaSobreNome.toString() + "</td>";
                for (var c in value[i].ListaPessoaContato) {
                    if (value[i].ListaPessoaContato[c].PscTelefone.toString() !== '') {
                        row += "<td>" + value[i].ListaPessoaContato[c].PscTelefone.toString() + "</td>";
                    } else {
                        row += "<td colspan='2'></td>";
                    }
                }
                row += "<td>" + FormataDataGrid(value[i].PsaDataNascimento.toString()) + "</td>";
                row += "<td><a href='#' onclick=" + editar + " class='btn btn-default btn-sm'><i class='glyphicon glyphicon-pencil'></i> Editar</a>&nbsp;&nbsp;<a href='#' onclick=" + excluir + " class='btn btn-default btn-sm'><i class='glyphicon glyphicon-trash'></i> Excluír</a></td>";
                row += "</tr>";
                table += row;
                count++;
            }
            $('#agenda').html(table);
            var info = "<i class='fa fa-users'></i> Você não possui contatos";
            if (count === 1) {
                info = "<i class='fa fa-users'></i> Você possui " + count + " contato";
            } else {
                info = "<i class='fa fa-users'></i> Você possui " + count + " contatos";
            }
            $('#quantidade').html(info);

        }


        var EditarContato = function (c) {
            $.ajax({
                url: 'ExemploConsulta.aspx/EditarContato',
                type: 'POST',
                contentType: "application/json;charset=utf-8",
                dataType: "json",
                data: "{id: '" + c + "'}",
                success: function (data) {
                    window.location.href = "CadastroContato.aspx";
                }
            });
        }

        //var ExcluirContato = function (c) {
        //    $.ajax({
        //        url: 'Handler/ListaContatoFiltroHandler.ashx',
        //        type: 'POST',
        //        data: { method: 'FiltroPessoaNome', args: { nome: _nome } },
        //        before: function () {
        //            alert(_nome);
        //            if (_nome.length > 2) {
        //                return true;
        //            }
        //            return false;
        //        },
        //        success: function (data) {
        //            BuildTable(data);

        //        }
        //    });
        //}



        var ExcluirContato = function (c) {
            $.ajax({
                url: 'ExemploConsulta.aspx/ExcluirContato',
                type: 'POST',
                contentType: "application/json;charset=utf-8",
                dataType: "json",
                data: "{id: '" + c + "'}",
                before: function (data) {
                },
                success: function (data) {
                    ListarContatos();
                }
            });
        }

        var ListarContatos = function () {
            $.ajax({
                type: "GET",
                url: "Handler/ListaContatosHandler.ashx",
                contentType: "application/json;charset=utf-8",
                dataType: "json",
                success: function (value) {
                    BuildTable(value);
                }
            });
        }

        function FormataDataGrid(e) {
            var data = e.toString();
            data = data.substr(8, 2) + "/" + data.substr(5, 2) + "/" + data.substr(0, 4);
            return data;
        }

    </script>
</body>
</html>
