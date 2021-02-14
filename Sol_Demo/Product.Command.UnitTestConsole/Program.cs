using Grpc.Net.Client;
using Product.Grpc.Command;
using System;
using System.Threading.Tasks;

namespace Product.Command.UnitTestConsole
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var channel = GrpcChannel.ForAddress("https://localhost:5001");

            #region Add

            var client = new CreateProductGrpc.CreateProductGrpcClient(channel);
            var createProductRequets = new CreateProductRequest()
            {
                ProductName = "Coffee",
                UnitPrice = 200
            };
            var result = await client.CreateProductAsync(createProductRequets);
            Console.WriteLine(result.Result);

            #endregion Add

            //#region Update

            //var client = new UpdateProductGrpc.UpdateProductGrpcClient(channel);
            //var updateProductRequest = new UpdateProductRequest()
            //{
            //    ProductIdentity = Guid.Parse("6ab93824-aad3-4f3c-b9f3-c6b282d7e63d").ToString(),
            //    ProductName = "Coffee",
            //    UnitPrice = 200
            //};
            //var result = await client.UpdateProductAsync(updateProductRequest);
            //Console.WriteLine(result.Result);

            //#endregion Update

            //#region Delete

            //var client = new RemoveProductGrpc.RemoveProductGrpcClient(channel);
            //var removeProductRequest = new RemoveProductRequest()
            //{
            //    ProductIdentity = Guid.Parse("6ab93824-aad3-4f3c-b9f3-c6b282d7e63d").ToString(),
            //};
            //var result = await client.RemoveProductAsync(removeProductRequest);
            //Console.WriteLine(result.Result);

            //#endregion Delete
        }
    }
}