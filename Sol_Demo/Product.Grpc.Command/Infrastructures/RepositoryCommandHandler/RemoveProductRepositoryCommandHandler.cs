using Framework.SqlClient.Helper;
using MediatR;
using Product.Grpc.Command.Infrastructures.Abstract;
using Product.Grpc.Command.Infrastructures.RepositoryCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using System.Data;

namespace Product.Grpc.Command.Infrastructures.RepositoryCommandHandler
{
    public sealed class RemoveProductRepositoryCommandHandler : ProductRepositoryCommandAbstract, IRequestHandler<RemoveProductRepositoryCommand, bool>
    {
        private readonly ISqlClientDbProvider sqlClientDbProvider = null;

        public RemoveProductRepositoryCommandHandler(ISqlClientDbProvider sqlClientDbProvider)
        {
            this.sqlClientDbProvider = sqlClientDbProvider;
        }

        Task<bool> IRequestHandler<RemoveProductRepositoryCommand, bool>.Handle(RemoveProductRepositoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return base.ExecuteAsync(this.sqlClientDbProvider, "Delete", request);
            }
            catch
            {
                throw;
            }
        }
    }
}