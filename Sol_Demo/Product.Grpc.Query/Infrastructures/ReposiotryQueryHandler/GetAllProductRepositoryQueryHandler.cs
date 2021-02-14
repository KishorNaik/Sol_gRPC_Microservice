using Framework.SqlClient.Helper;
using MediatR;
using Product.Grpc.Query.Infrastructures.Abstract;
using Product.Grpc.Query.Infrastructures.RepositoryQuery;
using Product.Shared.DomainEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using System.Data;

namespace Product.Grpc.Query.Infrastructures.ReposiotryQueryHandler
{
    public sealed class GetAllProductRepositoryQueryHandler : ProductRepositoryQueryAbstract, IRequestHandler<GetAllProductRepositoryQuery, IReadOnlyList<ProductModel>>
    {
        private readonly ISqlClientDbProvider sqlClientDbProvider = null;

        public GetAllProductRepositoryQueryHandler(ISqlClientDbProvider sqlClientDbProvider)
        {
            this.sqlClientDbProvider = sqlClientDbProvider;
        }

        Task<IReadOnlyList<ProductModel>> IRequestHandler<GetAllProductRepositoryQuery, IReadOnlyList<ProductModel>>.Handle(GetAllProductRepositoryQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var dyanmicParametrerTask = base.GetParametersAsync("Get-Products", request);

                var result =
                        this
                        .sqlClientDbProvider
                        .DapperBuilder
                        .OpenConnection(sqlClientDbProvider.GetConnection())
                        .Parameter(async () => await dyanmicParametrerTask)
                        .Command(async (dbConnection, dynamicParameter) =>
                        {
                            var dbResult =
                                await
                                dbConnection
                                .QueryAsync<ProductModel>(sql: "uspGetProducts", param: dynamicParameter, commandType: CommandType.StoredProcedure);
                            return dbResult.ToList().AsReadOnly();
                        })
                        .ResultAsync<IReadOnlyList<ProductModel>>();

                return result;
            }
            catch
            {
                throw;
            }
        }
    }
}