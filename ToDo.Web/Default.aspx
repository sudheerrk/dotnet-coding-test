<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ToDo.Web.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ACME To Do List</title>

    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/2.2.0/jquery.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {

            // detect the edit link click
            $(".lnkEdit").click(function () {

                // get task id
                var id = $(this).data("id");
                alert(id);

                // pass id to WebMethod in back end to get any dependent tasks
                $.ajax({
                    url: '\Default.aspx\GetAnyDependentTasks',
                    data: { 'id': id },
                    type: "get",
                    cache: false,
                    success: function (data) {

                        alert(data);
                        // only show if data is not empty
                        if (data != "") {

                            // append header title
                            $('#' + id).append("<p>Associated Tasks:</p> <br/>");

                            // append dependant tasks
                            $('#' + id).append(data);
                        }

                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        // notify user of any errors
                        $('#' + id).html(thrownError);
                    }
                });
            });

        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>ACME To Do List</h1>
        <div>
            <asp:TextBox runat="server" ID="txtTask"></asp:TextBox>
            <br />
            <asp:TextBox runat="server" ID="txtDescription"></asp:TextBox>
            <asp:Button runat="server" ID="btnAddTask" Text="Add Task" OnClick="btn_AddTask_Click" />
        </div>
        <asp:DataList runat="server" ID="dlTasks" OnEditCommand="dlTasks_EditCommand" OnUpdateCommand="dlTasks_UpdateCommand" DataKeyField="Id" >
            <HeaderTemplate>
                <div id="todoItems">
                    <ol>
            </HeaderTemplate>

            <ItemTemplate>
                        <li>
                            <%# DataBinder.Eval(Container.DataItem, "Title") %> <asp:CheckBox runat="server" ID="chkComplete" Enabled="false" Checked='<%# DataBinder.Eval(Container.DataItem, "Complete") %>' />
                            <br />
                            <asp:LinkButton runat="server" ID="lbEdit" Text="Edit" data-id='<%# DataBinder.Eval(Container.DataItem, "Id") %>' class="lnkEdit" CommandName="Edit"></asp:LinkButton>
                        </li>
            </ItemTemplate>

            <EditItemTemplate>
                        <li>
                            <asp:TextBox runat="server" ID="txtUpdateTitle" Text='<%# DataBinder.Eval(Container.DataItem, "Title") %>'></asp:TextBox>
                            <br />
                            <asp:TextBox runat="server" ID="txtUpdateDescription" Text='<%# DataBinder.Eval(Container.DataItem, "Description") %>'></asp:TextBox>
                            <br />
                            <asp:CheckBox runat="server" ID="chkComplete" Checked='<%# DataBinder.Eval(Container.DataItem, "Complete") %>' />
                            <br />
                            <asp:Button runat="server" ID="btnUpdate" Text="Save" CommandName="Update" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Id") %>' />
                            <br />
                            <div id='<%# DataBinder.Eval(Container.DataItem, "Id") %>'>

                            </div>
                        </li>
            </EditItemTemplate>

            <FooterTemplate>
                    </ol>
                </div>    
            </FooterTemplate>
        </asp:DataList>
    </div>
    </form>
</body>
</html>
