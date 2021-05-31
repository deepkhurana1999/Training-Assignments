using AutoMapper;
using DepartmentalStore.Domain;
using DepartmentalStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepartmentalStore.API.Data
{
    public class InventoryProfile: Profile
    {
        public InventoryProfile()
        {
            this.CreateMap<Inventory, InventoryModel>().ReverseMap();
        }
    }
}
