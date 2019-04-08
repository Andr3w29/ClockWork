using System;

namespace Clockwork.API.Core.Models
{
    public abstract class BaseModel
    {
        public int ID { get; set; }
        public DateTime? CreatedOn { get; set; }
     
        public DateTime? ModifiedOn { get; set; }
    }
}
