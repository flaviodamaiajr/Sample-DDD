<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sobre.aspx.cs" Inherits="Agenda.Web.Sobre" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
                    <li><a href="ExemploConsulta.aspx">Contatos</a></li>
                    <li class="active"><a href="Sobre.aspx">Sobre</a></li>
                </ul>
            </div>
            <!--/.nav-collapse -->
        </div>
    </div>

    <div class="container">
        <form id="formConsulta" runat="server">
            <div class="page-header">
                <h1>Caso de estudo utilizando DDD - Domain-Driven Design com NHibernate e Fluent NHibernate</h1>
            </div>
            <p class="lead">Este exemplo mostra o consumo do serviço do dominio listando todos os contatos cadastrados na agenda.
                <br />
                Para mais detalhes sobre o exemplo, acesse: <a href="https://github.com/flaviodamaiajr">https://github.com/flaviodamaiajr</a>&nbsp;<i class="fa fa-github"></i></p>

            <p>Voltar ao <a href="ExemploConsulta.aspx">exemplo</a>.</p>
        </form>
        <hr />

        <footer>
            <p>Copyright &copy; <a href="https://github.com/flaviodamaiajr">Flávio da Maia Júnior </a>2014</p>
        </footer>

    </div>
    <script src="Scripts/jquery-1.9.0.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
</body>
</html>
