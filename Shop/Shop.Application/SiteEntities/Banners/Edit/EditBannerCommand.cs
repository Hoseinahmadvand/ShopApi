using Common.Application;
using Microsoft.AspNetCore.Http;
using Shop.Domain.SiteEntities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.SiteEntities.Banners.Edit
{
    public class EditBannerCommand:IBaseCommand
    {
        public long Id { get; set; }
        public string Link { get; set; }
        public IFormFile? ImageFile { get; set; }
        public BannerPosition Position { get; set; }
    }
}
