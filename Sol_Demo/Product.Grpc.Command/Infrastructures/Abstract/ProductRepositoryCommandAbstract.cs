using Dapper;
using Product.Shared.DomainEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using Framework.SqlClient.Helper;

namespace Product.Grpc.Command.Infrastructures.Abstract
{
    public abstract class ProductRepositoryCommandAbstract
    {
        protected Task<DynamicParameters> SetParametersAsync(string command, ProductModel productModel = null)
        {
            try
            {
                return Task.Run(() =>
                {
                    var dynamicParameter = new DynamicParameters();
                    dynamicParameter.Add("@Command", command, DbType.String, ParameterDirection.Input);
                    dynamicParameter.Add("@ProductIdentity", productModel?.ProductIdentity, DbType.Guid, ParameterDirection.Input);
                    dynamicParameter.Add("@ProductName", productModel?.ProductName, DbType.String, ParameterDirection.Input);
                    dynamicParameter.Add("@UnitPrice", productModel?.UnitPrice, DbType.Double, ParameterDirection.Input);

                    return dynamicParameter;
                });
            }
            catch
            {
                throw;
            }
        }

        protected Task<bool> ExecuteAsync(ISqlClientDbProvider sqlClientDbProvider, string procedureCommand, ProductModel productModel)
        {
            try
            {
                var dynamicParameterTask = this.SetParametersAsync(procedureCommand, productModel);

                var result =
                     sqlClientDbProvider
                     ?.DapperBuilder
                     ?.OpenConnection(sqlClientDbProvider.GetConnection())
                     ?.Parameter(async () => await dynamicParameterTask)
                     ?.Command(async (dbConnection, dynamicParameter) =>
                     {
                         bool dbResult;
                         try
                         {
                             _ = await
                             dbConnection
                             .ExecuteAsync(sql: "uspSetProducts", param: dynamicParameter, commandType: CommandType.StoredProcedure);

                             dbResult = true;
                         }
                         catch (Exception ex) when (ex.Message.Contains("IX_tblProduct_ProductName"))
                         {
                             dbResult = false;
                         }
                         catch
                         {
                             throw;
                         }

                         return dbResult;
                     })
                     ?.ResultAsync<bool>();

                return result;
            }
            catch
            {
                throw;
            }
        }
    }
}