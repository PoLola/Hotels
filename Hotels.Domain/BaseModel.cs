using System.ComponentModel.DataAnnotations.Schema;

namespace Hotels.Domain
{
    public abstract class BaseModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public abstract long Id { get; set; }
    }
}
