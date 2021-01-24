using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities.Identity
{
    [Table("Photos")]
    public class Photo
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public bool IsMain { get; set; }
        public string PublicId { get; set; }
        public Account Account { get; set; }
        public int AccountId { get; set; }
    }
}