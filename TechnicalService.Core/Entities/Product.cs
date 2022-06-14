using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalService.Core.Entities.Abstract;

namespace TechnicalService.Core.Entities
{
	public class Product : BaseEntity<int>
	{
		public string Name { get; set; }
		public decimal UnitPrice { get; set; }
		public string Description { get; set; }

	}
}
