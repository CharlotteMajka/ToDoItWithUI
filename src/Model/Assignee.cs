using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class Assignee
    {
        public int Id { get; set; }
        
        [MaxLength(75), Required]
        public string Name { get; set; }

        public List<Task> tasks { get; set; }
    }
}