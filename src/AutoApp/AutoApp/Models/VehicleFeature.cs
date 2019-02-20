using System.ComponentModel.DataAnnotations.Schema;

namespace AutoApp.Models
{
    [Table("VehiclesFeatures")]
    public class VehicleFeature
    {
        public int VehicleId {get; set;}
        public int FeatureId {get; set;}

        public Vehicle Vehicle {get; set;}
        public Feature Feature {get; set;}
    }
}