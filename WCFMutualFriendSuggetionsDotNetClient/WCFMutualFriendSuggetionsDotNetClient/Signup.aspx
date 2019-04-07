<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Signup.aspx.cs" Inherits="WCFMutualFriendSuggetionsDotNetClient.Signup" %>

<!DOCTYPE html>

<html lang="en" xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <title>Sign Up</title>

    <!-- Font Icon -->
    <link rel="stylesheet" href="fonts/material-icon/css/material-design-iconic-font.min.css">

    <!-- Main css -->
    <link rel="stylesheet" href="css/style.css">
</head>
<body>

    <div class="main">

        <!-- Sign up form -->
        <section class="signup">
            <div class="container">
                <div class="signup-content">
                    <div class="signup-form">
                        <h2 class="form-title">Sign up</h2>
                        <form id="form1" runat="server">
                            <div class="form-group">
                                <label for="name"><i class="zmdi zmdi-account material-icons-name"></i></label>&nbsp;
                                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                </div>
                            <div class="form-group">
                                <label for="name"><i class="zmdi zmdi-account material-icons-name"></i></label>&nbsp;
                                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                                </div>
                            <div class="form-group">
                                <label for="email"><i class="zmdi zmdi-email"></i></label>&nbsp;
                                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                                </div>
                            <div class="form-group">
                                <label for="pass"><i class="zmdi zmdi-lock"></i></label>&nbsp;
                                <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                                </div>
                            <div class="form-group">
                                <input type="checkbox" name="agree-term" id="agree-term" class="agree-term" />
                                <label for="agree-term" class="label-agree-term"><span><span></span></span>I agree all statements in  <a href="#" class="term-service">Terms of service</a></label>
                            </div>
                            <div class="form-group form-button">
                                <asp:Button ID="Button1" runat="server" CssClass="form-submit" OnClick="Button1_Click" Text="Sign up" />
&nbsp;</div>
                            <div>
                            <h5>
                                <asp:Label ID="Label1" runat="server"></asp:Label>
                            </h5>
                            </div>
                        </form>
                    </div>
                    <div class="signup-image">
                        <figure><img src="images/signup-image.jpg" alt="sing up image"></figure>
                        <a href="Login.aspx" class="signup-image-link">Sign In</a>
                    </div>
                </div>
            </div>
        </section>
</div>
    <!-- JS -->
    <script src="vendor/jquery/jquery.min.js"></script>
    <script src="js/main.js"></script>
</body><!-- This templates was made by Colorlib (https://colorlib.com) -->
</html>