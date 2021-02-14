using Grpc.Core;
using Grpc.Net.Client;
using Product.Grpc.Query;
using System;
using System.Threading.Tasks;

namespace Produc.Query.UnitTestConsole
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var channel = GrpcChannel.ForAddress("https://localhost:5002");

            #region Add

            var client = new GetAllProductGrpc.GetAllProductGrpcClient(channel);

            using var call = client.GetAllProduct(new Google.Protobuf.WellKnownTypes.Empty());
            await foreach (var data in call.ResponseStream.ReadAllAsync())
            {
                Console.WriteLine($"Id:{data.ProductIdentity} Product Name :{data.ProductName} Unit Price:{data.UnitPrice}");
            }

            #endregion Add
        }
    }
}