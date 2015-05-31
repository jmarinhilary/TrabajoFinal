using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Reporting.WebForms;

namespace OnlineShop.Web.Telerik.Helper
{
    public class Helper
    {
        public void CreatePdf(string FileName, string DataSourceName, Object DataSource, String[] ArrayReportParameter, HttpResponseBase Response)
        {
            ReportDataSource rds = new ReportDataSource(DataSourceName, DataSource);

            Warning[] warnings;
            string[] streamIds;
            string mimeType = string.Empty;
            string encoding = string.Empty;
            string extension = string.Empty;

            ReportViewer viewer = new ReportViewer();
            viewer.ProcessingMode = ProcessingMode.Local;
            viewer.LocalReport.ReportPath = "Reportes/" + FileName + ".rdlc";
            if (ArrayReportParameter != null)
            {
                List<ReportParameter> lstParameter = new List<ReportParameter>();
                foreach (var item in ArrayReportParameter)
                {
                    ReportParameter parameter = new ReportParameter(item.Split(',')[0].ToString(), item.Split(',')[1].ToString());
                    lstParameter.Add(parameter);
                }
                if (lstParameter.Count() > 0)
                    viewer.LocalReport.SetParameters(lstParameter);
            }
            viewer.LocalReport.DataSources.Add(rds);

            byte[] bytes = viewer.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
            Response.Buffer = true;
            Response.Clear();
            Response.ContentType = mimeType;
            Response.AddHeader("content-disposition", "attachment; filename=" + FileName + "." + extension);
            Response.BinaryWrite(bytes);
            Response.Flush();
        }
    }
}