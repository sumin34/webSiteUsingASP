using ContactDBandProduct.Models;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using System.Security.Cryptography;

namespace ContactDBandProduct.Controllers
{
    public class ProductController : Controller
    {
        
        private readonly MySqlConnection mySqlConnection;

        public ProductController(MySqlConnection mySqlConnection)
        {
            this.mySqlConnection = mySqlConnection;
        }
        
        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Register(Product product)
        {
            mySqlConnection.Open();
            Console.WriteLine(product.productName);
            Console.WriteLine(product.imageUrl);
            Console.WriteLine(product.productSeller);
            Console.WriteLine(product.Description);

            string sql = string.Format("INSERT INTO product VALUES ('{0}','{1}','{2}',{3},'{4}','{5}')",
                product.prodNum,product.imageUrl,product.productName,product.productPrice,
                product.productSeller,product.Description);

            MySqlCommand cmd = new MySqlCommand(sql,mySqlConnection);
            int result = cmd.ExecuteNonQuery();
            if(result == 1) {
                Console.WriteLine("store success");
                }else { Console.WriteLine("store failed"); }

            mySqlConnection.Close();
            return Redirect("/product/registerpage");
        }

        public IActionResult RegisterPage()
        {
            
            return View();
        }

        public IActionResult List()
        {
            mySqlConnection.Open();
            string sql = "SELECT * FROM product";
            MySqlCommand cmd = new MySqlCommand(sql, mySqlConnection);
            MySqlDataReader result = cmd.ExecuteReader();

            

            List<string> list = new List<string>();
            while (result.Read())
            {
                Console.WriteLine(result.GetString("id"));
                list.Add(result.GetString("imageUrl"));

            }


            mySqlConnection.Close();

            ViewData["list"] = list;
            return View();
        }
        public IActionResult Read(int id)
        {
            mySqlConnection.Open();

            mySqlConnection.Close();
            return View();
        }

    }
}
