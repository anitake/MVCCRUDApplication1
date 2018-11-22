using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCCRUDApplication1.Models.parital_class
{
    [MetadataType(typeof(ProductMetadata))]
    public partial class Product
    {
        public class ProductMetadata
        {
            [Required]
            [DisplayName("產品編號")]
            public int ProductID { get; set; }
            [Required]
            [DisplayName("產品類別")]
            public int CategoryID { get; set; }
            [DisplayName("產品型號")]
            public string ModelNumber { get; set; }
            [DisplayName("產品名稱")]
            public string ModelName { get; set; }
            [DisplayName("產品圖片路徑")]
            public string ProductImage { get; set; }
            [DisplayName("產品價格")]
            [DisplayFormat(DataFormatString = "{0:c0}")]
            public decimal UnitCost { get; set; }
            [DisplayName("產品說明")]
            [DataType(DataType.MultilineText)]
            public string Description { get; set; }
            [DisplayName("產品圖片")]
            public Byte[] BytesImage { get; set; }
        }
    }
}