using ContactDBandProduct.Models;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace ContactDBandProduct.Controllers
{
    public class PostController : Controller
    {
        private readonly MySqlConnection _connection;
        public PostController(MySqlConnection mySqlConnection)
        {
            _connection = mySqlConnection;
        }

        public IActionResult Index()
        {

            return View();
        }
        public IActionResult List()
        {
            //나중에 추가된 게시글 목록이 위에서 차례대로 보이도록
            _connection.Open();
            string sql = "SELECT * FROM product";
            MySqlCommand cmd = new MySqlCommand(sql, _connection);
            MySqlDataReader result = cmd.ExecuteReader();


            List<string> list = new List<string>();

            while (result.Read())
            {
                list.Add(result.GetString("id"));
            }


            return View();
        }
        public MySqlDataReader LookPost(int postId)
        {
            _connection.Open();
            string sql = string.Format("select * from member where Id='{0}'", postId);
            MySqlCommand cmd = new MySqlCommand(sql, _connection);
            MySqlDataReader result = cmd.ExecuteReader();

            
            _connection.Close();

            return result;
        }

        [HttpGet]
        public IActionResult Post()
        {
            return View();
        }

        public IActionResult RegisterPost(PostModel postmodel)
        {
            _connection.Open();

            string sql = string.Format("insert into member(title, contents, writer) values('{0}', '{1}', '{2}');",
                            postmodel.title, postmodel.contents, postmodel.writer);

            MySqlCommand cmd = new MySqlCommand(sql, _connection);
            int result = cmd.ExecuteNonQuery();

            _connection.Close();

            return Redirect("/post/list");
        }

    }
}
