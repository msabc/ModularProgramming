using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebClient
{
    public partial class MainMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        
        protected void NavBtn_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;

            switch (btn.ID)
            {
                case "btnAbout":
                    
                    break;
                case "btnHome":
                    break;
                case "btnContact":
                    break;
                default:
                    return;
            }
        }
    }
}