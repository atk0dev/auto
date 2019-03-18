using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AutoApp.Controllers.Resources
{
    public class MakeResource
    {
        public int Id { get; set; } 
        
        public string Name { get; set; }

        public ICollection<KeyValuePairResource> Models { get; set; }

        public MakeResource()
        {
            this.Models = new Collection<KeyValuePairResource>();
        }

        
    }
}