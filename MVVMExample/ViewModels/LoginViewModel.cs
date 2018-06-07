using MVVMExample.Models;
using SRDATA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MVVMExample.ViewModels
{
    public class LoginViewModel
    {
        IDictionary<string, string> SQLPV = new Dictionary<string, string>();

        public string login(LoginModel model)
        {
            var userID = "0";
            HttpContext.Current.Session["SelectedCustomerID"] = 310; //set this in customer select somewhere else in the application.

            SQLPV.Clear();
            SQLPV.Add("userName", model.Username);
            SQLPV.Add("ProtectedID", model.ProtectedID);
            SQLPV.Add("Password", model.Password);
            SQLPV.Add("IPAddress", HttpContext.Current.Request.UserHostAddress);

            var connString = string.Empty;
            try
            {
                using (DataTable dt = new DataTable())
                {
                    connString = SQLCOMM.connString("securityRecords");
                    Helpers.DataTableFiller("SecurityRecords", "usr_LoginAccessDetail", dt, SQLPV);
                    userID = dt.Rows[0]["UserID"].ToString();
                    HttpContext.Current.Session["customerLogo"] = dt.Rows[0]["LogoText"].ToString();
                    HttpContext.Current.Session["FirstName"] = dt.Rows[0]["FirstName"].ToString();
                    HttpContext.Current.Session["LastName"] = dt.Rows[0]["LastName"].ToString();
                    HttpContext.Current.Session["CustomerID"] = dt.Rows[0]["CustomerID"].ToString();
                }
            }
            catch (Exception ex)
            {
                var body = "";
                var subject = "MVVMExample Login error";

                body += "<strong>An error occurred in MVVMExample.</strong>";
                body += "<br/><br/>";
                body += "<strong>User: </strong>" + model.Username + "<br/>";
                body += "<strong>DB Connection String: </strong>" + connString + "<br/>";
                body += "<br/><br/>";
                body += "<strong>Error Message: </strong>" + ex.Message;
                body += "<br/><strong>AccountViewModel</strong>";
                body += "<br/><strong>Action: </strong>login";
                body += "<br/><br/>";
                body += "<strong>Stack Trace: </strong><br/>";
                body += ex.StackTrace;

                CodeHelper.SendEmail("staylor@instakey.com", "ITSupport@InstaKey.com", "", "",
                    subject, body);
            }

            if (userID != "0")
            {
                HttpContext.Current.Session["userID"] = userID;

                CodeHelper.SetUserSessionVars(Convert.ToInt32(HttpContext.Current.Session["UserID"]));
                try
                {
                    System.Web.Security.FormsAuthentication.SetAuthCookie(userID, false);
                }
                catch (Exception ex) { }

                return userID;
            }
            else
            {
                return userID;
            }
        }
        public string CheckSecurityAnswer(string userID)
        {
            string securityAnswer = "";

            SQLPV.Clear();
            SQLPV.Add("UserID", userID);

            securityAnswer = Helpers.VariableFill("SecurityRecords", "usr_getSecurityAnswer", SQLPV);

            return securityAnswer;
        }
    }
}