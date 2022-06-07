using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalService.Core.Entities.Abstract;

namespace TechnicalService.Core.Entities; 

public class ServiceDemand : BaseEntity <int>
{
    public string Name { get; set; }
    public string SurName  { get; set; }
    public string Email { get; set; }
    public string BuildingNo { get; set; }
    public string FloorNo { get; set; }
    public string DoorNo { get; set; }
    public string Phone { get; set; }
    public string Message { get; set; }
    public string Adress { get; set; }
    public string UserId { get; set; }

}
