<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.14.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.ASPxTreeList.v13.1, Version=13.1.14.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxTreeList" TagPrefix="dx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>

    <script type="text/javascript" language="javascript">
	function OnClientNumberChanged(s, name) {
		clientHiddenFieldStorage.Set(name, s.GetNumber());
	}
    </script>

    <form id="mainForm" runat="server">
        <div>
            <dx:ASPxHiddenField ID="ASPxHiddenFieldStorage" runat="server" ClientInstanceName="clientHiddenFieldStorage">
            </dx:ASPxHiddenField>
            <dx:ASPxGridView ID="ASPxGridViewWithTreeList" runat="server" KeyFieldName="ID" OnBeforePerformDataSelect="ASPxGridViewWithTreeList_BeforePerformDataSelect">
                <Columns>
                    <dx:GridViewDataTextColumn ReadOnly="True" VisibleIndex="0">
                        <EditFormSettings Visible="False" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="ID" VisibleIndex="1" GroupIndex="0" SortIndex="0" SortOrder="Ascending">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="Venue" VisibleIndex="2">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Buy" VisibleIndex="3">
                        <DataItemTemplate>
                            <dx:ASPxTreeList ID="ASPxTreeListInTemplate" runat="server" AutoGenerateColumns="False"
                                KeyFieldName="ID" OnInit="ASPxTreeListInTemplate_Init">
                                <Columns>
                                    <dx:TreeListTextColumn FieldName="ID" VisibleIndex="0">
                                    </dx:TreeListTextColumn>
                                    <dx:TreeListTextColumn FieldName="Details" VisibleIndex="1">
                                    </dx:TreeListTextColumn>
                                    <dx:TreeListTextColumn Caption="Count" VisibleIndex="2">
                                        <DataCellTemplate>
                                            <dx:ASPxSpinEdit ID="ASPxSpinEditInTemplate" runat="server" Height="20px" Number="0"
                                                OnInit="ASPxSpinEditInTemplate_Init" />
                                        </DataCellTemplate>
                                    </dx:TreeListTextColumn>
                                </Columns>
                            </dx:ASPxTreeList>
                        </DataItemTemplate>
                    </dx:GridViewDataTextColumn>
                </Columns>
                <Settings ShowGroupPanel="True" />
                <SettingsBehavior AutoExpandAllGroups="True" />
            </dx:ASPxGridView>
        </div>
        <dx:ASPxButton ID="ASPxButtonSubmit" runat="server" Text="Submit" OnClick="ASPxButtonSubmit_Click">
        </dx:ASPxButton>
    </form>
</body>
</html>
