using Microsoft.Data.SqlClient;
using System.Data;

namespace ProductsMVC.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Rate { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }

        public static Product GetSingleProduct(int id)
        {
            Product? pd = new Product();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSqlLocalDb;Initial Catalog=KTjune23;Integrated Security=true";
            cn.Open();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Products WHERE ProductId = @a1";
                cmd.Parameters.AddWithValue("@a1", id);
                SqlDataReader dr = cmd.ExecuteReader();


                if (dr.Read())
                {
                    pd.ProductId = id;
                    pd.ProductName = dr.GetString("ProductName");
                    pd.Rate = dr.GetDecimal("Rate");
                    pd.Description = dr.GetString("Description");
                    pd.CategoryName = dr.GetString("CategoryName");

                }
                else
                {
                    Console.WriteLine("Not Found");
                }
                dr.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return pd;

        }


        public static List<Product> GetAllProducts()
        {
            List<Product> lstPd = new List<Product>();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSqlLocalDb;Initial Catalog=KTjune23;Integrated Security=true";
            cn.Open();

            try
            {
                //SqlCommand cmd = cn.CreateCommand();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Products";


                SqlDataReader dr = cmd.ExecuteReader();
                Product pd;

                while (dr.Read())
                {
                    pd = new Product();
                    pd.ProductId = dr.GetInt32("ProductId");
                    pd.ProductName = dr.GetString("ProductName");
                    pd.Rate = dr.GetDecimal("Rate");
                    pd.Description = dr.GetString("Description");
                    pd.CategoryName = dr.GetString("CategoryName");
                    lstPd.Add(pd);
                }

                dr.Close();

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }

            return lstPd;
        }

        public static void Update(Product product)
        {

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSqlLocalDb;Initial Catalog=KTjune23;Integrated Security=true";
            cn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE Products SET ProductName = @ProductName, Rate = @Rate, Description = @Description, CategoryName=@CategoryName  WHERE ProductId = @ProductId";

                cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
                cmd.Parameters.AddWithValue("@Rate", product.Rate);
                cmd.Parameters.AddWithValue("@Description", product.Description);
                cmd.Parameters.AddWithValue("@CategoryName", product.CategoryName);
                cmd.Parameters.AddWithValue("@ProductId", product.ProductId);


                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static void Create(Product product)
        {

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSqlLocalDb;Initial Catalog=KTjune23;Integrated Security=true";
            cn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO Products (ProductId, ProductName, Rate, Description, CategoryName) VALUES (@ProductId, @ProductName, @Rate, @Description, @CategoryName)";

                cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
                cmd.Parameters.AddWithValue("@Rate", product.Rate);
                cmd.Parameters.AddWithValue("@Description", product.Description);
                cmd.Parameters.AddWithValue("@CategoryName", product.CategoryName);
                cmd.Parameters.AddWithValue("@ProductId", product.ProductId);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static void Delete(int id)
        {

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSqlLocalDb;Initial Catalog=KTjune23;Integrated Security=true";
            cn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Delete from Products Where ProductId = @ProductId";

                cmd.Parameters.AddWithValue("@ProductId", id);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}
