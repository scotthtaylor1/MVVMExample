using MVVMExample.Models;
using SRDATA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MVVMExample.ViewModels
{
    public class MenuViewModel
    {
        public void GetMenuItems(string userID)
        {
            if (userID != "0")
            {
                HttpContext.Current.Session["ParentMenu"] = GetParentMenuList(userID);
                HttpContext.Current.Session["ChildMenu"] = GetChildMenuList(userID);
            }
        }

        IDictionary<string, string> SQLPV = new Dictionary<string, string>();
        private List<ParentMenu> GetParentMenuList(string userID)
        {
            List<ParentMenu> topMenu = new List<ParentMenu>();
            SQLPV.Clear();
            SQLPV.Add("lowerID", "101");
            SQLPV.Add("upperID", "110");
            SQLPV.Add("userID", userID);
            SQLPV.Add("isLite", "1");

            using (DataTable dt = new DataTable())
            {
                Helpers.DataTableFiller("SecurityRecords", "mnu_GetTopMenus2", dt, SQLPV);

                foreach (DataRow dr in dt.Rows)
                {
                    topMenu.Add(new ParentMenu
                    {
                        ReportID = Convert.ToInt16(dr["ReportID"]),
                        ReportName = dr["ReportName"].ToString(),
                        LiteURL = dr["LiteURL"].ToString(),
                        Controller = dr["Controller"].ToString(),
                    });
                }
            }

            return topMenu;

        }

        private List<ChildMenu> GetChildMenuList(string userID)
        {
            List<ChildMenu> childMenu = new List<ChildMenu>();
            SQLPV.Clear();
            SQLPV.Add("lowerID", "101");
            SQLPV.Add("upperID", "110");
            SQLPV.Add("userID", userID);
            SQLPV.Add("isLite", "1");

            using (DataTable dt = new DataTable())
            {
                Helpers.DataTableFiller("SecurityRecords", "mnu_GetSubMenus2", dt, SQLPV);

                foreach (DataRow dr in dt.Rows)
                {
                    childMenu.Add(new ChildMenu
                    {
                        ParentReportID = Convert.ToInt16(dr["ParentMenuReportID"]),
                        ReportName = dr["ReportName"].ToString(),
                        LiteURL = dr["LiteURL"].ToString(),
                        Controller = dr["Controller"].ToString(),
                    });
                }
            }

            return childMenu;
        }
    }
}