using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using SalesInventory.Models.DbModels;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace SalesInventory.Data.DbContext
{
    public class DbHelper
    {

        public string dbConnString = "UserID=postgres;Password=root;Host=localhost;Port=5432;Database=Inventory;";
        public string dbSchema = "public";


        private string GetConnectionString(IConfiguration configuration)
        {

            string dbCon = dbConnString;
            return dbCon;


        }
        private string GetDbSchema(IConfiguration configuration)
        {
            return dbSchema;
        }

        private NpgsqlConnection CreateConnection()
        {
            try
            {
                return new NpgsqlConnection(dbConnString);
            }
            catch (Exception ex)
            {
                // _logger.LogError(ex);
                return null;
            }
        }
        private void DisposeConnection(NpgsqlConnection con)
        {
            try
            {
                if (con != null)
                {
                    con.Close();
                    con.Dispose();
                }
            }
            catch
            {
                //Ignore exception
            }
        }

        public List<ProductModels> GetAllProducts()
        {
            List<ProductModels> allProducts = new List<ProductModels>();
            var dbCon = CreateConnection();
            try
            {
                using (dbCon)
                {
                    dbCon.Open();
                    allProducts = dbCon.Query<ProductModels>("\"GetAllProduct\"", commandType: System.Data.CommandType.StoredProcedure).ToList();
                }
                DisposeConnection(dbCon);
                return (List<ProductModels>)allProducts;
            }
            catch (Exception ex)
            {
                DisposeConnection(dbCon);

                //_logger.LogError(ex);
                return (List<ProductModels>)allProducts;
            }

        }

        public List<ProductCategoryModels> GetAllProductCategories()
        {
            List<ProductCategoryModels> allProducts = new List<ProductCategoryModels>();
            var dbCon = CreateConnection();
            try
            {
                using (dbCon)
                {
                    dbCon.Open();
                    allProducts = dbCon.Query<ProductCategoryModels>("\"GetAllProductCategories\"", commandType: CommandType.StoredProcedure).ToList();
                }
                DisposeConnection(dbCon);
                return (List<ProductCategoryModels>)allProducts;
            }
            catch (Exception ex)
            {
                DisposeConnection(dbCon);

                //_logger.LogError(ex);
                return (List<ProductCategoryModels>)allProducts;
            }

        }

        public List<ProductSalesModels> GetAllSales()
        {
            List<ProductSalesModels> allProducts = new List<ProductSalesModels>();
            var dbCon = CreateConnection();
            try
            {
                using (dbCon)
                {
                    dbCon.Open();
                    allProducts = dbCon.Query<ProductSalesModels>("\"GetAllSales\"", commandType: CommandType.StoredProcedure).ToList();
                }
                DisposeConnection(dbCon);
                return (List<ProductSalesModels>)allProducts;
            }
            catch (Exception ex)
            {
                DisposeConnection(dbCon);

                //_logger.LogError(ex);
                return (List<ProductSalesModels>)allProducts;
            }

        }

        public List<ProductSalesModels> GetAllSalesById(int productId)
        {
            List<ProductSalesModels> allProducts = new List<ProductSalesModels>();
            var dbCon = CreateConnection();
            try
            {
                using (dbCon)
                {
                    dbCon.Open();
                    allProducts = dbCon.Query<ProductSalesModels>("\"GetAllSalesByProductId\"", new { _productId = productId }, commandType: CommandType.StoredProcedure).ToList();
                }
                DisposeConnection(dbCon);
                return (List<ProductSalesModels>)allProducts;
            }
            catch (Exception ex)
            {
                DisposeConnection(dbCon);

                //_logger.LogError(ex);
                return (List<ProductSalesModels>)allProducts;
            }

        }



    }
}
