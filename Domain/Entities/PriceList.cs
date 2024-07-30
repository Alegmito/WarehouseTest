﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
  public class PriceList: BaseEntity<Guid>
  {
    public string Name { get; set; }

    public DateTime TimeCreated { get; set; }
    public List<Product> Products { get; set; }
    public List<PriceListColumn> Columns { get; set; }
  }
}