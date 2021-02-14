using Dapper;
using Framework.SqlClient.Helper;
using MediatR;
using Product.Grpc.Command.Infrastructures.Abstract;
using Product.Grpc.Command.Infrastructures.RepositoryCommand;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Product.Grpc.Command.Infrastructures.RepositoryCommandHandler
{
    public sealed class UpdateProductRepositoryCommandHandler : ProductRepositoryCommandAbstract, IRequestHandler<UpdateProductRepositoryCommand, bool>
    {
        private readonly ISqlClientDbProvider sqlClientDbProvider = null;

        public UpdateProductRepositoryCommandHandler(ISqlClientDbProvider sqlClientDbProvider)
        {
            this.sqlClientDbProvider = sqlClientDbProvider;
        }

        Task<bool> IRequestHandler<UpdateProductRepositoryCommand, bool>.Handle(UpdateProductRepositoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return base.ExecuteAsync(this.sqlClientDbProvider, "Update", request);
            }
            catch
            {
                throw;
            }
        }
    }
}