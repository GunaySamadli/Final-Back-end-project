using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Mejuri_Back_end.Models
{
    public class Setting
    {
        public int Id { get; set; }
        [StringLength(maximumLength: 150)]
        public string HomePageImg { get; set; }
        [StringLength(maximumLength: 50)]
        public string HomePageInfo { get; set; }
        [StringLength(maximumLength: 150)]
        public string LocationImg { get; set; }
        [StringLength(maximumLength: 25)]
        public string LocationTitle { get; set; }
        [StringLength(maximumLength: 150)]
        public string LocationSubTitle { get; set; }
        [StringLength(maximumLength: 150)]
        public string ShopImg { get; set; }
        [StringLength(maximumLength: 150)]
        public string ContactImg { get; set; }
        [StringLength(maximumLength: 150)]
        public string FaqImg { get; set; }
        [StringLength(maximumLength: 150)]
        public string CompanyImg { get; set; }
        [StringLength(maximumLength: 100)]
        public string Fb { get; set; }
        [StringLength(maximumLength: 50)]
        public string Twitter { get; set; }
        [StringLength(maximumLength: 50)]
        public string Insta { get; set; }
        [StringLength(maximumLength: 50)]
        public string Pinterest { get; set; }
        [StringLength(maximumLength: 150)]
        public string CopyRight { get; set; }
        [StringLength(maximumLength: 150)]
        public string FbUrl { get; set; }
        [StringLength(maximumLength: 150)]
        public string InstaUrl { get; set; }
        [StringLength(maximumLength: 150)]
        public string PinterestUrl { get; set; }
        [StringLength(maximumLength: 150)]
        public string TwitterUrl { get; set; }

        [StringLength(maximumLength: 25)]
        public string FaqTitle { get; set; }
        [StringLength(maximumLength: 25)]
        public string ContactTitle { get; set; }

        [StringLength(maximumLength: 150)]
        public string ContactSubtitle1 { get; set; }
        [StringLength(maximumLength: 250)]
        public string ContactSubtitle2 { get; set; }

        [NotMapped]
        public IFormFile HomePageImgFile { get; set; }
        [NotMapped]
        public IFormFile LocationImgFile { get; set; }
        [NotMapped]
        public IFormFile ShopImgFile { get; set; }
        [NotMapped]
        public IFormFile CompanyImgFile { get; set; }
        [NotMapped]
        public IFormFile ContactImgFile { get; set; }
        [NotMapped]
        public IFormFile FaqImgFile { get; set; }
    }
}
