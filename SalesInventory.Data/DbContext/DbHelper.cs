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

        public List<ProductSalesModels> GetAllSalesByProductId(int productId)
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

        public string  InsertSale(int productId, int quantitySold, double totalAmount, string soldBy)
        {
            string  dbResponse = string.Empty;
            var dbCon = CreateConnection();
            try
            {
                using (dbCon)
                {
                    dbCon.Open();
                    dbResponse = dbCon.QueryFirstOrDefault<string>("\"InsertSale\"", new
                    {
                        _productId = productId,
                        _quantitySold = quantitySold,
                        _totalAmount = totalAmount,
                        _soldBy = soldBy
                    }, commandType: CommandType.StoredProcedure);
                }
                DisposeConnection(dbCon);
                return (string) dbResponse;
            }
            catch (Exception ex)
            {
                DisposeConnection(dbCon);

                //_logger.LogError(ex);
                return (string)dbResponse;
            }

        }

        public ProductModels GetProductById(int productId)
        {
            ProductModels allProducts = new ProductModels();
            var dbCon = CreateConnection();
            try
            {
                using (dbCon)
                {
                    dbCon.Open();
                    allProducts = dbCon.QueryFirst<ProductModels>("\"GetProductById\"", new { _productId = productId }, commandType: CommandType.StoredProcedure);
                }
                DisposeConnection(dbCon);
                return (ProductModels)allProducts;
            }
            catch (Exception ex)
            {
                DisposeConnection(dbCon);

                //_logger.LogError(ex);
                return (ProductModels)allProducts;
            }

        }

        public string InsertProduct(string productName, int productCategoryId, int stockAvailable, double cost)
        {
            string dbResponse = string.Empty;
            var dbCon = CreateConnection();
            try
            {
                using (dbCon)
                {
                    dbCon.Open();
                    dbResponse = dbCon.QueryFirstOrDefault<string>("\"InsertProduct\"", new
                    {
                        _productName = productName,
                        _productCategoryId = productCategoryId,
                        _stockAvailable = stockAvailable,
                        _cost = cost
                    }, commandType: CommandType.StoredProcedure);
                }
                DisposeConnection(dbCon);
                return (string)dbResponse;
            }
            catch (Exception ex)
            {
                DisposeConnection(dbCon);

                //_logger.LogError(ex);
                return (string)dbResponse;
            }

        }

        public string DeleteProduct( int productId)
        {
            string dbResponse = string.Empty;
            var dbCon = CreateConnection();
            try
            {
                using (dbCon)
                {
                    dbCon.Open();
                    dbResponse = dbCon.QueryFirstOrDefault<string>("\"DeleteProduct\"", new
                    {
                        _productId = productId,
                        
                    }, commandType: CommandType.StoredProcedure);
                }
                DisposeConnection(dbCon);
                return (string)dbResponse;
            }
            catch (Exception ex)
            {
                DisposeConnection(dbCon);

                //_logger.LogError(ex);
                return (string)dbResponse;
            }

        }

        public string UpdateProduct(int productId, string productName, int productCategoryId, double cost, int stockAvailable)
        {
            string dbResponse = string.Empty;
            var dbCon = CreateConnection();
            try
            {
                using (dbCon)
                {
                    dbCon.Open();
                    dbResponse = dbCon.QueryFirstOrDefault<string>("\"UpdateProduct\"", new
                    {
                        _productId = productId,
                        _productName = productName,
                        _productCategoryId = productCategoryId,
                        _cost = cost,
                        _stockAvailable = stockAvailable


                    }, commandType: CommandType.StoredProcedure);
                }
                DisposeConnection(dbCon);
                return (string)dbResponse;
            }
            catch (Exception ex)
            {
                DisposeConnection(dbCon);

                //_logger.LogError(ex);
                return (string)dbResponse;
            }

        }



    }
}
