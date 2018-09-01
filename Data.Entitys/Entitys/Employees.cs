﻿using Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using X.Data.Entitys;
using X.Data.Utility.Attributes;

namespace X.Data.Entitys
{
    public class Employees : EntityBase
    {

        [Display(Name = "姓名")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "联系电话")]
        [Required]
        public string PhoneNumber { get; set; }

        [Display(Name = "区域")]
        [Required]
        public string Area { get; set; }

        [Display(Name = "职位")]
        [Required]
        public string Position { get; set; }

        [Display(Name = "Email")]
        [Required]
        [RegularExpression(@"^[A-Za-z0-9\u4e00-\u9fa5]+@[a-zA-Z0-9_-]+(\.[a-zA-Z0-9_-]+)+$", ErrorMessage = "Email格式不正确")]
        public string Email { get; set; }

        [Display(Name = "年龄")]
        public int Age { get; set; }

        [Display(Name = "性别")]
        public Gender Gender { get; set; }

        [Display(Name = "入职日期")]
        public DateTimeOffset? EntryDate { get; set; }

        [Display(Name = "系统ID"), SchemaIgnore]
        public Guid? IdentityUserId { get; set; }

    }
}
