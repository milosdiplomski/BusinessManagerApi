﻿using AutoMapper;
using BusinessManager.Models.DtoModels;
using BusinessManager.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessManagerApi.MappingConfiguration
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Products, ProductsDto>()
                .ReverseMap();
        }
    }
}
