namespace CompanyProject.Models
{
    public class Media
    {
        public Guid Id { get; set; }
        public string? RecordId { get; set; } 
        public string? Name { get; set; }   
        public string? Type { get; set; }      
        public string? TableName { get; set; } 
        public bool IsActive { get; set; }

        public int? ServiceId { get; set; }
        public Service? Service { get; set; }
        //when retrieve i give him the id of the record 
        //to store media in one place
        //un in media service  
    }
}
