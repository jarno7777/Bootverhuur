using System.ComponentModel.DataAnnotations;

namespace Bootverhuur.Models
{
    public class bootverhuurModel
    {
        [Key]
        public int boat_Id { get; set; }

        public int Owner_Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public decimal price_per_day { get; set; }
        public string Image_URL { get; set; }
        public int Speed { get; set; }
        public int beds { get; set; }
        public int petrol_litre { get; set; }
        public string Petrol_type { get; set; }

        public bootverhuurModel()
        {

        }

    }
}
