using System.Web.Http;
using System.Web.Mvc;

namespace BugTracker.Controllers.Api
{
    public abstract class BaseApiController : ApiController
    {
        //Swal format = "Title|Message|Icon"
        protected string swalTempData = "swal";
        private static string swalDelimiter = "|";
        protected string swal_Title_Success = "Success" + swalDelimiter;
        protected string swal_Title_Error = "Error" + swalDelimiter;
        protected string swal_Title_SomethingWentWrong = "Something Went Wrong" + swalDelimiter;

        protected string swal_Icon_Success = swalDelimiter + "success";
        protected string swal_Icon_Error = swalDelimiter + "error";
        protected string swal_Icon_Warning = swalDelimiter + "warning";

        protected string swal_Msg_MissingFields = "Invalid or missing fields.";


    }
}