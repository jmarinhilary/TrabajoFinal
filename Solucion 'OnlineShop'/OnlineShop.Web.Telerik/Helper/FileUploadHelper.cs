
namespace System.Web.Mvc
{
    public static class FileUploadHelper
    {
        public static MvcHtmlString FileUploadBoostrap(this HtmlHelper htmlHelper, string nameId) 
        {
            //<input id="input-702" name="kartik-input-702[]" type="file" multiple=true class="file-loading">
            string fileTemplate = @"<input id='{0}' name='{0}[]' type='file' multiple='true' class='file-loading' />";
            return new MvcHtmlString(string.Format(fileTemplate, nameId));
        }

    }
}