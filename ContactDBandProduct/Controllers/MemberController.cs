using ContactDBandProduct.Models;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace ContactDBandProduct.Controllers
{
    public class MemberController : Controller
    {
        private readonly MySqlConnection _connection;
        public MemberController(MySqlConnection mySqlConnection)
        {
            _connection = mySqlConnection;
        }
        public IActionResult SignupPage()
        {
            return View();
        }
        public IActionResult Signup(MemberModel membermodel)
        {
            _connection.Open();

            string sql = string.Format("insert into member(userId, userPw, userName) values('{0}', '{1}', '{2}');",
                            membermodel.userId, membermodel.pw, membermodel.name);

            MySqlCommand cmd = new MySqlCommand(sql, _connection);
            int result = cmd.ExecuteNonQuery();

            _connection.Close();
            return Redirect("/member/loginpage");
        }

        public IActionResult Login(string id, string pw)
        {
            _connection.Open();
            string sql = string.Format("select * from member where userId='{0}' and userPw='{1}';", id, pw);
            MySqlCommand cmd = new MySqlCommand(sql, _connection);
            MySqlDataReader result = cmd.ExecuteReader();

            if (result.Read())
            {
                HttpContext.Session.SetInt32("id", result.GetInt32("id"));//서버쪽에 저장하는 정보

                _connection.Close();

                return Redirect("/home/Index");
            }
            else
            {
                _connection.Close();
                return Redirect("/member/loginPage");
            }
        }

        public IActionResult LoginPage(string id, string pw)
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
