namespace LabbAsignment2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Travelers
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int? AgencyID { get; set; }

        public int? DestinationID { get; set; }

        public virtual Agency Agency { get; set; }

        public virtual Destination Destination { get; set; }
    }
}
