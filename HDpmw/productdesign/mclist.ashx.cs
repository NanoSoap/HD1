﻿using HDPages.productLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace HDpmw.productdesign
{
    /// <summary>
    /// kclist 的摘要说明
    /// </summary>
    public class mclist : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //System.Threading.Thread.Sleep(2000);

            if (!string.IsNullOrEmpty(context.Request["kidclassSearch"]))
            {

                context.Response.ContentType = "text/plain";
                context.Response.Write(GetSearchkidclassInfo());
            }
        }

        public string GetSearchkidclassInfo()
        {
            StringBuilder sb = new StringBuilder();

            pd_kidclass_main pm = new pd_kidclass_main();
            System.Data.DataTable dt = pm.getkidclass();

            foreach (DataRow r in dt.Rows)
            {
                sb.Append(r["mainname"].ToString().Trim() + ',');
            }

            return sb.ToString().TrimEnd(',');
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}