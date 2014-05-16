<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Agenda.Web.Login" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta http-equiv="content-type" content="text/html; charset=UTF-8">
    <meta charset="utf-8">
    <title>Exemplo DDD - Flávio da Maia Jr</title>
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">
    <link href="//netdna.bootstrapcdn.com/bootstrap/3.0.3/css/bootstrap.min.css" rel="stylesheet">

    <!--[if lt IE 9]>
          <script src="//html5shim.googlecode.com/svn/trunk/html5.js"></script>
        <![endif]-->
    <link rel="shortcut icon" href="/bootstrap/img/favicon.ico">
    <link rel="apple-touch-icon" href="/bootstrap/img/apple-touch-icon.png">
    <link rel="apple-touch-icon" sizes="72x72" href="/bootstrap/img/apple-touch-icon-72x72.png">
    <link rel="apple-touch-icon" sizes="114x114" href="/bootstrap/img/apple-touch-icon-114x114.png">

    <!-- CSS code from Bootply.com editor -->

    <style type="text/css">
        .modal-footer {
            border-top: 0px;
        }
    </style>
</head>

<!-- HTML code from Bootply.com editor -->

<body>
    <!--login modal-->
    <div id="loginModal" runat="server" class="modal show" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                    <h1 class="text-center">Login</h1>
                </div>
                <div class="modal-body">
                    <form id="formLogin" runat="server" class="form col-md-12 center-block">
                        <div class="form-group">
                            <input type="text" id="usuario" name="usuario" class="form-control input-lg" placeholder="Email">
                        </div>
                        <div class="form-group">
                            <input type="password" id="senha" name="senha" class="form-control input-lg" placeholder="Password">
                        </div>
                        <div class="form-group">
                            <button class="btn btn-primary btn-lg btn-block">Entrar</button>
                        </div>
                    </form>
                </div>
                <div class="modal-footer">
                    <div class="col-md-12">
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type='text/javascript' src="//ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
    <script type='text/javascript' src="//netdna.bootstrapcdn.com/bootstrap/3.0.3/js/bootstrap.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#formLogin").bind('submit', function (event) {
                event.preventDefault();
                $.ajax({
                    type: "POST",
                    url: "Login.aspx/Auth",
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    data: JSON.stringify($('form#formLogin').serializeObject()),
                    timeout: 10000,
                    success: function (data) {                        
                        location.href = data.d;
                    }
                });
            });

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
        });
    </script>

</body>
</html>
