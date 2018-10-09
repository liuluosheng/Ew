﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using X.Data.Attributes;
using X.Data.Attributes.Shema;

namespace X.Data.Entitys
{
    [AutoGeneratedController]
    public class Product : EntityBase
    {
        [Display(Name = "产品名称")]
        [Required]
        public string Name { get; set; }
        [Display(Name = "单重")]
        [Required]
        public decimal Weight { get; set; }
        [Display(Name = "产品描述")]
        public string Description { get; set; }

        [Display(Name = "采购人员")]
        [AutoComplete(DataType = "Employees", Search = "Name,PhoneNumber", Label = "Name"), PlaceHolder("搜索名称，联系电话")]
        [ODataProperty("Purchasing.Name")]
        public Guid? PurchasingId { get; set; }

       
        [ForeignKey("PurchasingId")]
        [Odata(ExpandNames = "Name")]
        public Employees Purchasing { get; set; }
    }
}
