using Dapper;
using Product.Shared.DomainEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using Framework.SqlClient.Helper;

namespace Product.Grpc.Query.Infrastructures.Abstract
{
    public abstract class ProductRepositoryQueryAbstract
    {
        protected Task<DynamicParameters> GetParametersAsync(string command, ProductModel productModel = null)
        {
            try
            {
                return Task.Run(() =>
                {
                    var dynamicParameter = new DynamicParameters();
                    dynamicParameter.Add("@Command", command, DbType.String, ParameterDirection.Input);

                    return dynamicParameter;
                });
            }
            catch
            {
                throw;
            }
        }
    }
}