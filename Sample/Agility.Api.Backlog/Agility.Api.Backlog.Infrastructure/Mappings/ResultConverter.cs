﻿using Agility.Api.Backlog.Application;

using AutoMapper;

namespace Agility.Api.Backlog.Infrastructure.Mappings
{
    public class ResultConverter : IResultConverter
    {
        private readonly IMapper mapper;

        public ResultConverter()
        {
            mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AccountsProfile>();
                cfg.AddProfile<CustomersProfile>();
            }).CreateMapper();
        }

        public T Map<T>(object source)
        {
            T model = mapper.Map<T>(source);
            return model;
        }
    }
}
