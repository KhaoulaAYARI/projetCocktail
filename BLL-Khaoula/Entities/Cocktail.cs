using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_Khaoula.Entities
{
    public class Cocktail
    {

        public Guid Cocktail_id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string Instructions { get; set; }
        //public DateTime CreatedAt { get; set; }
        public DateTime _createdAt;
        public DateOnly CreatedAt { get { return DateOnly.FromDateTime(_createdAt); } }
        public Guid? CreatedBy { get; set; }
        public User? Creator { get; set; }  


        public Cocktail(Guid cocktail_id, string name, string? description, string instructions, DateTime createdAt, Guid? createdBy)
        {
            Cocktail_id = cocktail_id;
            Name = name;
            Description = description;
            Instructions = instructions;
            _createdAt = createdAt;
            CreatedBy = createdBy;
        }

        public Cocktail( string name, string? description, string instructions)
        {
            
            Name = name;
            Description = description;
            Instructions = instructions;
            
        }

    }
}
