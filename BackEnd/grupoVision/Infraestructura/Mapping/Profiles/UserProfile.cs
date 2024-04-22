using AutoMapper;
using Core.Domain;
using Infraestructura.Repositories.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Mapping.Profiles
{
    public class UserProfile:Profile
    {
        public UserProfile() { 
         CreateMap<Usuariotbl,Usuario>().ReverseMap();
        }
    }
}
