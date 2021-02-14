using Microsoft.Extensions.DependencyInjection;
using Product.Grpc.Command;
using Product.Grpc.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.Aggregate.Api.Extensions
{
    public static class gRpcClientServiceExtension
    {
        public static void AddgRPCClients(this IServiceCollection services)
        {
            var commandUrl = new Uri("https://localhost:5001");
            var queryUrl = new Uri("https://localhost:5002");

            services.AddGrpcClient<CreateProductGrpc.CreateProductGrpcClient>((configClient) =>
            {
                configClient.Address = commandUrl;
            });

            services.AddGrpcClient<UpdateProductGrpc.UpdateProductGrpcClient>((configClient) =>
            {
                configClient.Address = commandUrl;
            });

            services.AddGrpcClient<RemoveProductGrpc.RemoveProductGrpcClient>((configClient) =>
            {
                configClient.Address = commandUrl;
            });

            services.AddGrpcClient<GetAllProductGrpc.GetAllProductGrpcClient>((configClient) =>
            {
                configClient.Address = queryUrl;
            });
        }
    }
}