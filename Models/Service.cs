using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyProject.Models
{
    public class Service
    {
        public int Id { get; set; }
         public string?  Title { get; set; }
        public string? Description { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public string? UserId { get; set; }
        public Guid? ImageGuid { get; set; }
        [NotMapped]
        public string? ImagePath { get; set; }


    }
}
