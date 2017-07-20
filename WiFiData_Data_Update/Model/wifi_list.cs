namespace WiFiData_Data_Update.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class wifi_list
    {
        [Key]
        public int RowIndex { get; set; }

        [Required]
        [StringLength(15)]
        public string GroupIndex { get; set; }

        [StringLength(50)]
        public string ssid { get; set; }

        [Required]
        [StringLength(20)]
        public string mac { get; set; }

        public int? channel { get; set; }

        public int? linkquality { get; set; }

        public int? rssi { get; set; }

        [StringLength(15)]
        public string status { get; set; }

        public DateTime? date { get; set; }

        public int? ping { get; set; }

        [StringLength(12)]
        public string studentID { get; set; }

        [StringLength(50)]
        public string location_code { get; set; }

        [StringLength(20)]
        public string location { get; set; }

        [StringLength(5)]
        public string floor { get; set; }

        [StringLength(10)]
        public string location_category { get; set; }

        [StringLength(10)]
        public string roomId { get; set; }
    }
}
