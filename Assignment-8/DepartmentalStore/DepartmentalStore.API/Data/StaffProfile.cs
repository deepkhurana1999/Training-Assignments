using AutoMapper;
using DepartmentalStore.Domain;
using DepartmentalStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentalStore.API.Data
{
    public class StaffProfile: Profile
    {
        public StaffProfile()
        {
            this.CreateMap<Staff, StaffModel>().ReverseMap();
        }
    }
}
