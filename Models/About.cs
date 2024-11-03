namespace CompanyProject.Models
{
    public class About
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }=false;
        public string? Title { get; set; }
        public string? UserId { get; set; }



    }
}
