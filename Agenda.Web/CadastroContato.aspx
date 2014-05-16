<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CadastroContato.aspx.cs" Inherits="Agenda.Web.CadastroContato" %>

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
        <form id="formCadastroContato" class="form-horizontal" runat="server">
            <fieldset>

                <!-- Form Name -->
                <legend>Cadastro do Contato</legend>

                <!-- Text input-->
                <div class="form-group">
                    <div class="col-md-6">
                        <input id="id" name="id" type="hidden" value="0">
                    </div>
                </div>

                <!-- Text input-->
                <div class="form-group">
                    <label class="col-md-4 control-label" for="nome">Nome:</label>
                    <div class="col-md-6">
                        <input id="nome" name="nome" type="text" placeholder="Informe o nome..." class="form-control input-md" required="">
                    </div>
                </div>

                <!-- Text input-->
                <div class="form-group">
                    <label class="col-md-4 control-label" for="sobreNome">Sobrenome:</label>
                    <div class="col-md-6">
                        <input id="sobreNome" name="sobreNome" type="text" placeholder="Informe o sobrenome..." class="form-control input-md" required="">
                    </div>
                </div>

                <!-- Text input-->
                <div class="form-group">
                    <label class="col-md-4 control-label" for="dataAniversario">Data de Aniversário:</label>
                    <div class="col-md-6">
                        <input id="dataAniversario" name="dataAniversario" type="text" placeholder="dd/MM/aaaa" class="form-control input-md" required="">
                    </div>
                </div>

                <!-- Text input-->
                <div class="form-group">
                    <label class="col-md-4 control-label" for="contato">Contato:</label>
                    <div class="col-md-6">
                        <input id="contato" name="contato" type="text" placeholder="(99)9999-9999" class="form-control input-md">
                    </div>
                </div>

                <!-- Button (Double) -->
                <div class="form-group">
                    <label class="col-md-4 control-label" for="btnSalvar"></label>
                    <div class="col-md-8">
                        <input id="btnSalvar" type="submit" class="btn btn-success" value="Salvar" />
                        <a href="#" class="btn btn-primary" onclick="redirecionamento();">Sair</a>
                    </div>
                </div>

                <div id="mensagem">
                </div>

            </fieldset>
            <hr />

            <footer>
                <p>Copyright &copy; <a href="https://github.com/flaviodamaiajr">Flávio da Maia Júnior </a>2014</p>
            </footer>
        </form>
    </div>
    <script src="Scripts/jquery-1.9.0.min.js"></script>
    <script src="Scripts/jquery.mask.min.js"></script>
    <%--<script src="Scripts/jquery-1.9.0.intellisense.js"></script>--%>
    <script src="Scripts/bootstrap.min.js"></script>

    <script type="text/javascript">

        $(document).ready(function () {
            setarContato();
        });

        $("#formCadastroContato").bind('submit', function (event) {
            event.preventDefault();
            $.ajax({
                type: "POST",
                url: "CadastroContato.aspx/SalvarContato",
                contentType: "application/json;charset=utf-8",
                dataType: "json",
                data: JSON.stringify($('form#formCadastroContato').serializeObject()),
                timeout: 10000,
                beforeSend: function () {
                    if (validarForm() == false) {
                        $("div#mensagem").removeClass();
                        $("div#mensagem").addClass('alert alert-danger');
                        $('#mensagem').html('Todos os campos são obrigatórios!');
                        return false;
                    }
                    $('#btnSalvar').button('loading');
                    $("div#mensagem").removeClass();
                    $('#mensagem').html('');
                },
                success: function () {
                    redirecionamento();
                }
            });
        });

        var setarContato = function () {
            $.ajax({
                type: "POST",
                url: "Handler/EditarContatoHandler.ashx",
                contentType: "application/json;charset=utf-8",
                dataType: "json",
                timeout: 10000,
                //before: function () {
                //    alert($("#id").val());
                //    return false;
                //    if ($("#id").val() !== "0") {
                //        return true;
                //    }
                //    return false;
                //},
                success: function (pessoa) {
                    $("#id").val(pessoa.PsaId.toString());
                    $("#nome").val(pessoa.PsaNome);
                    $("#sobreNome").val(pessoa.PsaSobreNome);
                    $("#dataAniversario").val(FormataData(pessoa.PsaDataNascimento.toString()));
                    $("#contato").val(pessoa.ListaPessoaContato[0].PscTelefone.toString());
                }
            });
        }



        var redirecionamento = function () {
            $.ajax({
                type: "POST",
                url: "CadastroContato.aspx/LimparContato",
                contentType: "application/json;charset=utf-8",
                dataType: "json",
                timeout: 10000,
                success: function (pessoa) {
                    setTimeout(function () {
                        window.location.href = "ExemploConsulta.aspx";
                    }, 1000)
                }
            });


        }

        function validarForm() {
            if (!$('#nome').val()) {
                return false;
            }
            if (!$('#sobreNome').val()) {
                return false;
            }
            if (!$('#dataAniversario').val()) {
                return false;
            }
            if (!$('#contato').val()) {
                return false;
            }
            return true;
        }

        $.fn.serializeObject = function () {
            var o = {};
            var a = this.serializeArray();
            $.each(a, function () {
                if (o[this.name] !== undefined) {
                    if (!o[this.name].push) {
                        o[this.name] = [o[this.name]];
                    }
                    o[this.name].push(this.value || '');
                } else {
                    o[this.name] = this.value || '';
                }
            });
            return o;
        };

        $(function ($) {
            $('#dataAniversario').mask('99/99/9999');
            $('#contato').mask('(99)9999-9999');
        });

        function FormataData(e) {
            var data = e.toString();
            data = data.substr(8, 2) + "/" + data.substr(5, 2) + "/" + data.substr(0, 4);
            return data;
        }
    </script>
</body>
</html>
