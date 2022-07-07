<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="OnlinePharmacyManagementSystem.View.Admin.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="../../Assets/lib/css/bootstrap.min.css" />
    <style>
       *{
           font-family:poppins;
        }
    </style>
</head>
<body class="bg-success">
    
    <div class="container-fluid">
        <div class="mb-3"> </div>
        <div class="row mt-5 mb-3">
            <div class="col-md-4"></div>
            <div class="col-md-4 bg-white">
                <h4 class="text-center">Online Pharmacy Management System</h4>
               <div class="justify-content-center"><img src="../../Assets/images/medicine2.jpg"/></div >
                <form runat="server">
  <div class="mb-3">
    <label for="exampleInputEmail1" class="form-label">Email address</label>
    <input type="email" class="form-control" id="Email" runat="server" autocomplete="off" aria-describedby="emailHelp"/>
    <div id="emailHelp" class="form-text">We'll never share your email with anyone else.</div>
  </div>
  <div class="mb-3">
    <label for="exampleInputPassword1" class="form-label">Password</label>
    <input type="password" class="form-control" id="Pass" runat="server" autocomplete="off"/>
  </div>
  
                    <div class="d-grid mb-3">
                          <label id="ErrMSg" class="text-danger" runat="server"></label>
                        <a href="../Seller/Login.aspx" class="text-success"> <label class=" h4 text-center">Seller</label></a>
                        <asp:Button ID="LoginBtn" runat="server" Text="Login" class="btn btn-success btn-block" OnClick="LoginBtn_Click"/>
                        </div>

</form>
            </div>
            <div class="col-md-4"></div>

        </div>

    </div>

</body>
</html>
