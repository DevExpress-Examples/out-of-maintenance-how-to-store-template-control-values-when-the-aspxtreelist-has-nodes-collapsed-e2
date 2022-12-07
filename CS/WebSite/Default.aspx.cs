using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web;
using DevExpress.Web.ASPxTreeList;
using System.Text;

public partial class _Default : System.Web.UI.Page {
    protected void Page_Init(object sender, EventArgs e) {
        ASPxGridViewWithTreeList.DataBind();
    }   
	
    protected void ASPxTreeListInTemplate_Init(object sender, EventArgs e) {
		ASPxTreeList treeList = (ASPxTreeList)sender;
		GridViewDataItemTemplateContainer templateContainer = (GridViewDataItemTemplateContainer)treeList.NamingContainer;
        treeList.ID = string.Format("tl_{0}", templateContainer.KeyValue);
        treeList.ClientInstanceName = string.Format("tl_{0}", templateContainer.KeyValue);

		TreeListNode nodeParent1 = treeList.AppendNode(1);
		nodeParent1["ID"] = 1;
		nodeParent1["Details"] = "Details1";

		TreeListNode node1 = treeList.AppendNode(2, nodeParent1);
		node1["ID"] = 2;
		node1["Details"] = "Details2";
	}
	
    protected void ASPxSpinEditInTemplate_Init(object sender, EventArgs e) {
		ASPxSpinEdit spinEdit = (ASPxSpinEdit)sender;
		TreeListDataCellTemplateContainer templateContainer = (TreeListDataCellTemplateContainer)spinEdit.NamingContainer;
		ASPxTreeList treeList = (ASPxTreeList)templateContainer.TreeList;

		string clientInstanceName = string.Format("{0}_spEdit_{1}", treeList.ClientInstanceName, templateContainer.NodeKey);
        spinEdit.ID = clientInstanceName;
        spinEdit.ClientInstanceName = clientInstanceName;
		
		spinEdit.ClientSideEvents.NumberChanged = string.Format("function(s, e) {{ OnClientNumberChanged(s, '{0}'); }}", clientInstanceName);
		
        if (ASPxHiddenFieldStorage.Contains(clientInstanceName))
            spinEdit.Number = decimal.Parse(ASPxHiddenFieldStorage[clientInstanceName].ToString());
	}

	protected void ASPxButtonSubmit_Click(object sender, EventArgs e) {
        StringBuilder result = new StringBuilder();
		foreach (KeyValuePair<string, object> item in ASPxHiddenFieldStorage) {
            result.AppendFormat("{0}, ", item.Value);
		}
		Response.Write(result);
	}

	private List<DemoDataSource> CreateDataSource() {
		List<DemoDataSource> dataSource = new List<DemoDataSource>();
		dataSource.Add(new DemoDataSource() { ID = 1, Venue = "Name1" });
		dataSource.Add(new DemoDataSource() { ID = 2, Venue = "Name2" });
		return dataSource;
	}

    protected void ASPxGridViewWithTreeList_BeforePerformDataSelect(object sender, EventArgs e)
    {
        ASPxGridViewWithTreeList.DataSource = CreateDataSource();
    }
}
public class DemoDataSource {
	public int ID { get; set; }
	public string Venue { get; set; }
}