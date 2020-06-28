using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASPSnippets.GoogleAPI;
using System.Web.Script.Serialization;
using static WebApplication2.WebForm2;

namespace WebApplication2
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GoogleConnect.ClientId = "563190630000-edfh89boq75uo9c5ms9sjsrbp5262vfr.apps.googleusercontent.com";
            GoogleConnect.ClientSecret = "tbNjrOVZoqGkoAyXwp9ovMr_";
            GoogleConnect.RedirectUri = "https://localhost:44378/WebForm2.aspx";
            GoogleConnect.API = EnumAPI.Drive;
            if (!string.IsNullOrEmpty(Request.QueryString["code"]))
            {
                string code = Request.QueryString["code"];
                string json = GoogleConnect.PostFile(code, (HttpPostedFile)Session["File"],"");
                GoogleDriveFile file = (new JavaScriptSerializer()).Deserialize<GoogleDriveFile>(json);
                Label1.Text = "File Uploaded Successfully!!";
                Label1.Visible = true;
            }
            if (Request.QueryString["error"] == "access_denied")
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('Access denied.')", true);
            }
        }

        protected void UploadFile(object sender, EventArgs e)
        {
            Session["File"] = FileUpload1.PostedFile;
            
            GoogleConnect.Authorize("https://www.googleapis.com/auth/drive.file");

        }
        public class GoogleDriveFile
        {
            public string Id { get; set; }
            public string Title { get; set; }
            public string OriginalFilename { get; set; }
            public string ThumbnailLink { get; set; }
            public string IconLink { get; set; }
            public string WebContentLink { get; set; }
            public DateTime CreatedDate { get; set; }
            public DateTime ModifiedDate { get; set; }
        }
    }
}