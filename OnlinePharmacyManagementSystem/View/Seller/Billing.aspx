<%@ Page Title="" Language="C#" MasterPageFile="~/View/Seller/SellerMaster.Master" AutoEventWireup="true" CodeBehind="Billing.aspx.cs" Inherits="OnlinePharmacyManagementSystem.View.Seller.Billing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function PrintPanel() {
            var panel = document.getElementById("<%=BillGV.ClientID %>");
            var panel2 = document.getElementById("<%=GridTotTb.ClientID %>")
            var printWindow = window.open('Dhaka 1210', 'Thanks For Your Purchase!', 'height=768,width=1024,top=100,left=100,tollbar=0,scrolbars=1');
            printWindow.document.write('BD Online Pharmacy.');
            printWindow.document.write('');
            printWindow.document.write(panel.outerHTML);
            printWindow.document.write(panel2.innerHTML);
            printWindow.document.write('');
            printWindow.document.close();

            printWindow.print();
            printWindow.close();

        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <h4 class="text-success">Online Pharmacy Billing </h4>
        </div>
        <div class="row">
            <div class="col-md-4">
                <!--Left Side Column-->
                <div class="row mb-3">
                    <div class="col">
                        <label class="h6 text-success">Medicine Name</label>
                        <input type="text" class="form-control" placeholder="Medicine Name" runat="server" id="MedNameTb" autocomplete="off" readonly="true" />
                    </div>
                    <div class="col">
                        <label class="h6 text-success">Medicine Price</label>
                        <input type="text" class="form-control" placeholder="Medicine Price" runat="server" id="MedPriceTb" autocomplete="off" readonly="true" />
                    </div>

                </div>
                <div class="row mb-3">
                    <div class="col">
                        <label class="h6 text-success">Medicine Quantity</label>
                        <input type="text" class="form-control" placeholder="Medicine Quantity" runat="server" id="MedQtyTb" autocomplete="off" />
                    </div>
                    <div class="col">
                        <label class="h6 text-success">Billing Date</label>
                        <input type="date" class="form-control" placeholder="Date" runat="server" id="BillingDate" />
                    </div>

                </div>
                <div class="row">
                    <label class="text-danger text-center" id="ErrMSg" runat="server"></label>
                    <div class="col d-grid">
                        <asp:Button ID="AddBtn" runat="server" Text="Add To Bill" class="btn btn-success btn-block btn-block" OnClick="AddBtn_Click" />
                    </div>
                    <div class="col d-grid">
                        <asp:Button ID="ResetBtn" runat="server" Text="Reset" class="btn btn-danger btn-block btn-block" OnClick="ResetBtn_Click" />
                    </div>

                </div>

                <div class="row">
                    <div class="col">

                        <h2 class="text-success">Medicines List </h2>
                        <asp:GridView ID="MedicinesList" class="table table-success" runat="server" AutoGenerateSelectButton="True" OnSelectedIndexChanged="MedicinesList_SelectedIndexChanged" BackColor="#CCFF99"></asp:GridView>
                    </div>
                </div>
            </div>
            <div class="col-md-8">
                <h4 class="text-center text-success">Client's Bill </h4>
                <asp:GridView ID="BillGV" class="table table-success" runat="server"></asp:GridView>
                <div class="row">
                    <div class="col-5"></div>
                    <div class="col-6">
                        <label class="h5 text-danger text-center" id="GridTotTb" runat="server"></label>
                    </div>



                </div>

                <div class="row">
                    <div class="col d-grid">
                        <asp:Button ID="PrintBtn" runat="server" Text="Print" class="btn btn-success btn-block btn-block" OnClientClick="PrintPanel()" />
                    </div>
                    <div class="col d-grid">
                        <asp:Button ID="ClearBtn" runat="server" Text="Clear" class="btn text-white btn-warning b btn-block btn-block" OnClick="ClearBtn_Click"/>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
