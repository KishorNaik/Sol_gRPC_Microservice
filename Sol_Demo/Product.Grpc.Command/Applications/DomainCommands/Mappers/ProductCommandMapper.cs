using AutoMapper;
using Product.Grpc.Command.Applications.DomainCommands.Commands;
using Product.Grpc.Command.Infrastructures.RepositoryCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.Grpc.Command.Applications.DomainCommands.Mappers
{
    public class ProductCommandMapper : Profile
    {
        public ProductCommandMapper()
        {
            base.CreateMap<CreateProductCommand, CreateProductRepositoryCommand>();
            base.CreateMap<UpdateProductCommand, UpdateProductRepositoryCommand>();
            base.CreateMap<RemoveProductCommand, RemoveProductRepositoryCommand>();
        }
    }
}