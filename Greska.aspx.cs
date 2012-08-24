using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TALARIS_1
{
    public partial class Greska : System.Web.UI.Page
    {
        public string greska;

        protected void Page_Load(object sender, EventArgs e)
        {
            greska = RadSaBazom.greska;
            this.DataBind();
        }
    }
}