<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateBookDetails.aspx.cs" Inherits="BooksManagement.UpdateBookDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Update Book</title>

      <!-- CSS only -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-gH2yIJqKdNHPEq0n4Mqa/HGKIhSkIHeL5AyhkYV8i59U5AR6csBvApHHNl/vI1Bx" crossorigin="anonymous" />

    <!-- JavaScript Bundle with Popper -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0/dist/js/bootstrap.bundle.min.js" integrity="sha384-A3rJD856KowSb7dwlZdYEkO39Gagi7vIsF0jrRAoQmDKKtQBHUuLZ9AsSv4jD4Xa" crossorigin="anonymous"></script>

    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.3.0/font/bootstrap-icons.css" />

      <style>
        .AuthorData {
            display: flex;
            justify-content: center;
            align-items: center;
            flex-direction: column;
        }
        .col-md-12{
            display:flex;
            justify-content:center;
            align-items:center;
            padding:20px;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
          <div class="container-fluid">
            <div class="row">
                <div class="col-sm-auto bg-light sticky-top">
                    <div class="d-flex flex-sm-column flex-row flex-nowrap bg-light align-items-center sticky-top">
                        <a href="/" class="d-block p-3 link-dark text-decoration-none" title="" data-bs-toggle="tooltip" data-bs-placement="right" data-bs-original-title="Icon-only">
                            <i class="bi-book fs-1"></i>
                        </a>
                        <h4 style="text-decoration: underline">Book Management</h4>
                        <ul class="nav nav-pills nav-flush flex-sm-column flex-row flex-nowrap mb-auto mx-auto text-center align-items-center">
                            <li class="nav-item"></li>
                            <li>
                                <a href="AddNewBook.aspx" class="nav-link py-3 px-2" title="" data-bs-toggle="tooltip" data-bs-placement="right" data-bs-original-title="Dashboard">
                                    <i class="bi bi-file-earmark-plus fs-1"></i>
                                    <p>Add New Book</p>
                                </a>
                            </li>
                            <li>
                                <a href="AddNewAuthor.aspx" class="nav-link py-3 px-2" title="" data-bs-toggle="tooltip" data-bs-placement="right" data-bs-original-title="Dashboard">
                                    <i class="bi bi-person-plus fs-1"></i>
                                    <p>Add Author Details</p>
                                </a>
                            </li>
                            <li>
                                <a href="BookList.aspx" class="nav-link py-3 px-2" title="" data-bs-toggle="tooltip" data-bs-placement="right" data-bs-original-title="Orders">
                                    <i class="bi bi-card-list fs-1"></i>
                                    <p>Book List</p>
                                </a>
                            </li>
                        </ul>
                    </div>
                </div>
                <div class="col-sm p-3 min-vh-100">
                    <div class="card">
                        <h3 class="card-header">Update Book Details</h3>
                        <div class="card-body">
                            <div class="card-body AuthorData">
                                <h5 class="card-title">Update Book Information</h5>
                                <div class="card" style="width: 60rem;">
                                    <div class="card-body">
                                        <div style="padding: 5px">
                                            <div class="row">
                                                <div class="col-md-6">
                                                    <label for="exampleFormControlInput1" class="form-label">ID</label>
                                                    <asp:TextBox runat="server" ID="BookId" CssClass="form-control"  placeholder="Book ID" disabled></asp:TextBox>
                                                </div>
                                                <div class="col-md-6">
               
                                                </div>
                                            </div>
                                              <div class="row">
                                                <div class="col-md-6">
                                                    <label class="form-label">Book Name</label>
                                                    <asp:TextBox runat="server" ID="BookName" CssClass="form-control"  placeholder="BookName" disabled></asp:TextBox>
                                                </div>
                                                <div class="col-md-6">
                                                    <label class="form-label">Change Book Name</label>
                                                    <asp:TextBox runat="server" ID="ChangeBook" CssClass="form-control"  placeholder="Book Name"></asp:TextBox>
                                                    
                                                </div>
                                            </div>
                                            <div class="row" style="margin-top:20px;">
                                                <div class="col-md-6">
                                                    <label for="Date" class="form-label">Author Name</label>
                                                    <asp:TextBox runat="server" CssClass="form-control" ID="AName" placeholder="Author Name" disabled></asp:TextBox>
                                                </div>
                                                <div class="col-md-6">
                                                     <label for="AutherName" class="form-label">Change Author Name</label>
                                                    <asp:DropDownList runat="server" OnSelectedIndexChanged="Auther_SelectedIndexChanged" ID="Auther" CssClass="form-control">
                                                        <asp:ListItem>Select Author</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                             <div class="row" style="margin-top:20px;">
                                                <div class="col-md-6">
                                                    <label class="form-label">Publish Date</label>
                                                    <asp:TextBox runat="server" CssClass="form-control" ID="PublishDate" disabled></asp:TextBox>
                                                </div>
                                                <div class="col-md-6">
                                                    <label class="form-label">Change Publish Date</label>
                                                    <asp:TextBox runat="server" type="date" CssClass="form-control" ID="ChangeDate"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <asp:Button ID="AddBook" Text="Update Details" OnClick="AddBook_Click" CssClass="btn btn-success" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
