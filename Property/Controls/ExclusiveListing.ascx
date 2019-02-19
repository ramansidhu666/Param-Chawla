<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ExclusiveListing.ascx.cs" Inherits="Property.Controls.ExclusiveListing" %>



<div class="In_bg">
     
    <asp:Label ID="resultSearch" CssClass="in_bg_label_property" Visible="false" runat="server"></asp:Label>
    <asp:UpdatePanel ID="upSearch" runat="server" UpdateMode="Conditional" Visible="false">
        <ContentTemplate>

            <div id="DivGridSearch" runat="server" style="display: none" class="In_bg">
                <asp:Repeater ID="rptSearchResults" runat="server" OnItemCommand="rptSearchResults_ItemCommand"
                    OnItemDataBound="rptSearchResults_ItemDataBound">

                    <HeaderTemplate>
                        <div class="">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <div class="col-md-3 col-sm-3">
                            <asp:HyperLink ID="hypBoxDetail" runat="server">
                                <div class="search_boxx">
                                    
                                    <div class="search_boxx_left2">
                                        <img src='<%# Eval("ImageUrl")%>' alt='' title=''
                                            width="180px" height="134">
                                    </div>
                                    <div class="text_bg">
                                       
                                        <span><%# Eval("Title") %></span><p>
                                            <span><%# Eval("Description") %></span>
                                        </p>
                                        <div class="text_bg_bottom">
                                            <asp:Button ID="btnDetails" runat="server" Text="Details" CssClass="detail" CommandName="Details"
                                                CommandArgument='<%# Eval("Id") %>' ToolTip="Click For Details" CausesValidation="false" />
                                        </div>
                                      
                                    </div>
                                </div>
                            </asp:HyperLink>
                        </div>
                    </ItemTemplate>
                  
                    <FooterTemplate>
                        </div>

                    </FooterTemplate>

                </asp:Repeater>
               
            </div>          
  <div id="DivListSearch" runat="server" style="display: block" class="In_bg">
                <asp:Repeater ID="rptSearchResultList" runat="server" OnItemCommand="rptSearchResultList_ItemCommand"
                    OnItemDataBound="rptSearchResultList_ItemDataBound">
                    <HeaderTemplate>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <div class="search_boxx_list_5">                            
                            <div class="search_boxx_right_bg">
                                <asp:HyperLink ID="hypImage" runat="server">
                                        <div class="search_boxx_left">
                                            <img src='<%# Eval("ImageUrl")%>' alt='' title='<%# Eval("Title")%>' width="180px"
                                                height="134">
                                        </div>
                                </asp:HyperLink>
                                <span>
                                    <asp:HyperLink ID="hypAddress" runat="server"><%# Eval("Title") %></asp:HyperLink></span>
                                <div class="para">
                                    <p>
                                        <%# Eval("Description") %>
                                    </p>
                                    <p>
                                        <asp:HyperLink ID="hypBoxreadmore" CssClass="read_more_btn3" Text="Read More" runat="server"></asp:HyperLink>
                                    </p>
                                </div>

                            </div>
                        
                        </div>
                    </ItemTemplate>
                 
                </asp:Repeater>
               
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="lnkNext" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
    <div class="col-md-3 col-sm-3">
          <div class="count_date">
        <asp:Label ID="lbldate" Style="float: right;" runat="server"></asp:Label>
    </div></div>
 <div class="col-md-4 col-sm-4">
       
    </div>
    <div class="col-md-5 col-sm-5">
    <div class="changer table-responsive" runat="server" id="pagesLink" visible="true">
        <table class="table">
            <tr>
                <td>
                    <asp:LinkButton ID="lnkFirst" runat="server" Font-Bold="true" PostBackUrl="~/Search.aspx"
                        OnClick="lnkFirst_Click">First</asp:LinkButton>
                </td>
                <td>
                    <asp:LinkButton ID="lnkPrevious" runat="server" Font-Bold="true" Style="margin-left: 6px;" PostBackUrl="~/Search.aspx"
                        OnClick="lnkPrevious_Click">Prev</asp:LinkButton>
                </td>
                <td>
                    <asp:DataList ID="RepeaterPaging" runat="server" RepeatDirection="Horizontal" OnItemCommand="RepeaterPaging_ItemCommand"
                        OnItemDataBound="RepeaterPaging_ItemDataBound">
                        <ItemTemplate>
                            <asp:LinkButton ID="Pagingbtn" runat="server" CommandArgument='<%# Eval("PageIndex") %>'
                                CommandName="newpage" Text='<%# Eval("PageText") %> ' Width="20px"></asp:LinkButton>&nbsp&nbsp
                        </ItemTemplate>
                    </asp:DataList>
                </td>
                <td>
                    <asp:LinkButton ID="lnkNext" runat="server" Font-Bold="true" PostBackUrl="~/Search.aspx"
                        OnClick="lnkNext_Click">Next</asp:LinkButton>
                </td>
                <td>
                    <asp:LinkButton ID="lnkLast" runat="server" Style="margin-left: 6px;" Font-Bold="true" PostBackUrl="~/Search.aspx"
                        OnClick="lnkLast_Click">Last</asp:LinkButton>
                </td>
            </tr>
        </table>
    </div>
        </div>
    </div>
  

