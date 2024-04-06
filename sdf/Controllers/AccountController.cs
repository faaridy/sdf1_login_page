using System.Web.Mvc;
using sdf.Models;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace sdf.Controllers
{
    public class AccountController : Controller
    {
        MySqlConnection connection = new MySqlConnection();
        MySqlCommand command = new MySqlCommand();
        MySqlDataReader reader;
        // GET: Account
        [HttpGet]
        public ActionResult Login()
        {

            return View();
        }
        void connectionString()
        {
            connection.ConnectionString = "server=localhost;uid=root;" +
    "pwd=12345;database=login";
        }
        [HttpPost]
        public ActionResult Verify(Account acc)
        {
            connectionString();
            connection.Open();
            command.Connection = connection;
            command.CommandText = "select * from login where username = '"+acc.Name+"' and password = '"+acc.Password+"'";
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                connection.Close();
                return View("Create");
            }
            else
            {
                connection.Close();
                return View("Error");
            }
            
            
    }
    }
    
}