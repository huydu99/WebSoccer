﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using WebSoccer.Models.Enums;

namespace WebSoccer.Models
{
    public class Product
    {
        public Product() 
        {
            Status = true;
        }
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tên")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Vui lòng nhập mô tả")]
        public string ShortDescription { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập mô tả")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập số lượng")]
        public int Quantity { get; set; }
        [Required]  
        public Brand Brand { get; set; }
        public bool Status { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public DateTime UpdateAt { get; set; }

        [Required]
        public double Price { get; set; }
        [Required]
        public double PromotionPrice { get; set; }
        [Required(ErrorMessage ="Vui lòng chọn danh mục")]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        [ValidateNever]
        public Category Category { get; set; }

        [ValidateNever]
        public List<ProductImage> ProductImages { get; set; }
    }
}
