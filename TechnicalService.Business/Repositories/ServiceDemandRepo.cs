using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalService.Businesss.Repositories.Abstracts.EntityFrameworkCore;
using TechnicalService.Core.Entities;
using TechnicalService.Data.Data;

namespace TechnicalService.Business.Repositories
{
    public class ServiceDemandRepo : RepositoryBase<ServiceDemand, int>
    {
        public ServiceDemandRepo(MyContext context) : base(context)
        {
        }
    }
}