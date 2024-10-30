using AutoMapper;
using SuperMarket.Application.DTOs.BranchDTOs;
using SuperMarket.Application.DTOs.CategoryDTOs;
using SuperMarket.Application.DTOs.CustomerDTOs;
using SuperMarket.Application.DTOs.InventoryDTOs;
using SuperMarket.Application.DTOs.OrderDetailsDTOs;
using SuperMarket.Application.DTOs.OrderDTOs;
using SuperMarket.Application.DTOs.PaymentDTOs;
using SuperMarket.Application.DTOs.ProductDTOs;
using SuperMarket.Application.DTOs.UserDTOs;
using SuperMarket.Domain.Entities;
using SuperMarket.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Application.AutoMappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
                CreateMap<Customer, CustomerCreateDTO>().ReverseMap();
                CreateMap<Customer, CustomerGetDTO>().ReverseMap();
                CreateMap<Customer, CustomerUpdateDTO>().ReverseMap();
                CreateMap<AppUser, CreateUserDTO>().ReverseMap();
                CreateMap<AppUser, GetUserDTO>().ReverseMap();
                CreateMap<AppUser, UpdateUserDTO>().ReverseMap();
                CreateMap<Product, ProductCreateDTO>().ReverseMap();
                CreateMap<Product, ProductGetDTO>().ReverseMap();
                CreateMap<Product, ProductUpdateDTO>().ReverseMap();
                CreateMap<Order, OrderCreateDTO>().ReverseMap();
                CreateMap<Order, OrderGetDTO>().ReverseMap();
                CreateMap<Order, OrderUpdateDTO>().ReverseMap();
                CreateMap<OrderDetails, OrderDetailsCreateDTO>().ReverseMap();
                CreateMap<OrderDetails, OrderDetailsGetDTO>().ReverseMap();
                CreateMap<OrderDetails, OrderDetailsUpdateDTO>().ReverseMap();
                CreateMap<Payment, PaymentCreateDTO>().ReverseMap();
                CreateMap<Payment, PaymentGetDTO>().ReverseMap();
                CreateMap<Payment, PaymentUpdateDTO>().ReverseMap();
                CreateMap<Branch, BranchCreateDTO>().ReverseMap();
                CreateMap<Branch, BranchGetDTO>().ReverseMap();
                CreateMap<Branch, BranchUpdateDTO>().ReverseMap();
                CreateMap<Inventory, InventoryCreateDTO>().ReverseMap();
                CreateMap<Inventory, InventoryGetDTO>().ReverseMap();
                CreateMap<Inventory, InventoryUpdateDTO>().ReverseMap();
                CreateMap<Category, CategoryCreateDTO>().ReverseMap();
                CreateMap<Category, CategoryGetDTO>().ReverseMap();
                CreateMap<Category, CategoryUpdateDTO>().ReverseMap();
        }
    }
}