namespace WEBAPILab02.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class news
    {
        public int id { get; set; }

        [Required]
        public string title { get; set; }

        public string pref { get; set; }

        [Required]
        public string desc { get; set; }

        [StringLength(50)]
        public string photo { get; set; }

        public int? user_id { get; set; }

        public int? catogery_id { get; set; }

        public DateTime date { get; set; }

        public virtual catogery catogery { get; set; }

        public virtual user user { get; set; }
    }
}
