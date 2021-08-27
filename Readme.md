<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128548809/13.1.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E2008)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [Default.aspx](./CS/WebSite/Default.aspx) (VB: [Default.aspx](./VB/WebSite/Default.aspx))
* [Default.aspx.cs](./CS/WebSite/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/WebSite/Default.aspx.vb))
<!-- default file list end -->
# How to store template control values when the ASPxTreeList has nodes collapsed
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/e2008/)**
<!-- run online end -->


<p>When the ASPxGridView or the ASPxTreeList uses controls in cell templates, they don't store values when a control is invisible. This is the ASP.NET design behavior, because the server doesn't recreate controls if they aren't required. A possible solution is to contain items in an intermediate container, such as ASPxHiddenField, where you should store values on the client side, and then restore them on the server side, as it is described in the Knowledge Base article: <a href="https://www.devexpress.com/Support/Center/p/K18282">The general technique of using the Init/Load event handler</a>.</p>

<br/>


