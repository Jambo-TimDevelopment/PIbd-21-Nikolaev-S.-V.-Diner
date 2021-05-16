﻿
using System;
using System.Collections.Generic;

namespace AbstractDinerBusinessLogic.BindingModels
{
    public class WarehouseBindingModel
    {
        public int? Id { get; set; }

        public string WarehouseName;

        public string ResponsiblePerson { get; set; }

        public DateTime CreateDate { get; set; }

        public Dictionary<int, (string, int)> WarehouseComponents { get; set; }
    }
}
