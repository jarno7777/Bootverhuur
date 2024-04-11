using System.ComponentModel.DataAnnotations;

namespace Bootverhuur.Models
{
    public class reviewsModel
    {
        [Key]
        public int review_id { get; set; }

        public int boat_id { get; set; }
        public int customer_id { get; set; }
        public int rating { get; set; }
        public string Comment { get; set; }

        public reviewsModel()
        {

        }

    }
}
