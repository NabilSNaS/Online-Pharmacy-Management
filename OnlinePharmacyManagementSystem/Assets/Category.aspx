<%@ Page Title="" Language="C#" MasterPageFile="~/View/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Category.aspx.cs" Inherits="OnlinePharmacyManagementSystem.Assets.Category" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MyBody" runat="server">
      <div class="container-fluid">
        <div class="row mt-5">
            <div class="col-md-4">
                        <div class="row mb-3">
                            <div class="col">
                               <input type="text" class="form-control" autocomplete="off" placeholder="Category Name" id="CatNameTb" runat="server">
                        </div>
                      </div>
                        <div class="row">
                            <label id="ErrMSg" class="text-danger" runat="server"></label>
                            <div class="col d-grid">
                                 <asp:Button ID="EditBtn" runat="server" Text="Edit" class="btn btn-success btn-block" OnClick="EditBtn_Click" />
                         
                            </div>
                            <div class="col d-grid">
                                  <asp:Button ID="SaveBtn" runat="server" Text="Save" class="btn btn-primary btn-block" OnClick="SaveBtn_Click" />
                                </div>
                            <div class="col d-grid ">
                                   <asp:Button ID="DeleteBtn" runat="server" Text="Delete" class="btn btn-danger btn-block" OnClick="DeleteBtn_Click"/>
                            </div>                    
                       
                 </div>
                 </div>
                    <div class="col-md-8">
                        <h2 class="text-success">Category List </h2>
                        <asp:GridView ID="CategoryList" class="table table-success" runat="server" AutoGenerateSelectButton="True" OnSelectedIndexChanged="CategoryList_SelectedIndexChanged"></asp:GridView>

                    </div>
                </div>  
        </div>
   
     
</asp:Content>
