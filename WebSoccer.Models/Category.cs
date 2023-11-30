using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WebSoccer.Models.ViewModels;

namespace WebSoccer.Models
{
    public class Category
    {
        public Category() 
        {
            Status = true;
        }
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        [DisplayName("Danh mục")]
        public string Name { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public DateTime UpdateAt { get; set; }
        [Required]
        [DisplayName("Mô tả")]
        public string Description { get; set; }
        public bool Status { get; set; }
        public string? ImageUrl { get; set; }
    }
}
