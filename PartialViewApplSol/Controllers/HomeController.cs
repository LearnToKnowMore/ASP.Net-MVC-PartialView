using Dapper;
using PartialViewApplSol.App_Start;
using PartialViewApplSol.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PartialViewApplSol.Controllers
{
    public class HomeController : Controller
    {
        static readonly string connectionString = ConfigurationManager.ConnectionStrings["DBConString"].ConnectionString;
        static readonly string command = "SELECT DepartmentID, Name AS DepartmentName FROM HumanResources.Department";
        // GET: Home
        public ActionResult Index()
        {
            try
            {
                Log.Message(System.Diagnostics.TraceEventType.Information, "Index Action Start");
                Task.Run(() => log4netHelper.LogMessage("Index Action Start"));
                using (IDbConnection con = new SqlConnection(connectionString))
                {
                    var DeptList = con.Query<Department>(command).ToList();
                    ViewBag.DepartmentList = new SelectList(DeptList, "DepartmentID", "DepartmentName");
                }
                Log.Message(System.Diagnostics.TraceEventType.Information, "Index Action End");
                Task.Run(() => log4netHelper.LogMessage("Index Action End"));
                return View();
            }
            catch (Exception ex)
            {
                Log.Error(System.Diagnostics.TraceEventType.Error, ex);
                Task.Run(() => log4netHelper.LogError("Error Occured", ex));
                throw;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EmployeeDeptHistory(string deptId)
        {
            IEnumerable<EmployeeDepartmentHistory> empHistList;
            using (IDbConnection con = new SqlConnection(connectionString))
            {
                empHistList = con.Query<EmployeeDepartmentHistory>("sp_EmployeeDepartmentHistory", new { DeptId = deptId }, commandType: CommandType.StoredProcedure);
            }
            return PartialView("_EmployeeDeptHistory", empHistList);
        }
    }
}