﻿using Microsoft.EntityFrameworkCore;
using ProductCatalogApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCatalogApi.Data
{
    public static class CatalogSeed
    {
        // contact with data(CatalogContext)
        public static void Seed(CatalogContext context)
        {
            // before writing the data check migration is available
            // or my table or schema is ready
            context.Database.Migrate();

            // don't want to add data multiple times so check if there is no data in the table
            // context is your DB, CatalogBrands is the table
            if (!context.CatalogBrands.Any())
            {
                // add multiple rows of data by using AddRange()
                context.CatalogBrands.AddRange(GetPreConfiguredCatalogBrands());
                // commit data
                context.SaveChanges();
            }

            if (!context.CatalogTypes.Any())
            {
                context.CatalogTypes.AddRange(GetPreConfiguredCatalogTypes());
                context.SaveChanges();
            }

            if (!context.CatalogItems.Any())
            {
                context.CatalogItems.AddRange(GetPreConfiguredCatalogItems());
                context.SaveChanges();
            }
        }

        private static IEnumerable<CatalogItem> GetPreConfiguredCatalogItems()
        {
            return new List<CatalogItem>()
            {
                new CatalogItem { CatalogTypeId=2,CatalogBrandId=3, Description = "A ring that has been around for over 100 years", Name = "World Star", Price = 199.5M, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/1" },
                new CatalogItem { CatalogTypeId=1,CatalogBrandId=2, Description = "will make you world champions", Name = "White Line", Price= 88.50M, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/2" },
                new CatalogItem { CatalogTypeId=2,CatalogBrandId=3, Description = "You have already won gold medal", Name = "Prism White", Price = 129, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/3" },
                new CatalogItem { CatalogTypeId=2,CatalogBrandId=2, Description = "Olympic runner", Name = "Foundation Hitech", Price = 12, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/4" },
                new CatalogItem { CatalogTypeId=2,CatalogBrandId=1, Description = "Roslyn Red Sheet", Name = "Roslyn White", Price = 188.5M, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/5" },
                new CatalogItem { CatalogTypeId=2,CatalogBrandId=2, Description = "Lala Land", Name = "Blue Star", Price = 112, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/6" },
                new CatalogItem { CatalogTypeId=2,CatalogBrandId=1, Description = "High in the sky", Name = "Roslyn Green", Price = 212, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/7"  },
                new CatalogItem { CatalogTypeId=1,CatalogBrandId=1, Description = "Light as carbon", Name = "Deep Purple", Price = 238.5M, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/8" },
                new CatalogItem { CatalogTypeId=1,CatalogBrandId=2, Description = "High Jumper", Name = "Antique Ring", Price = 129, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/9" },
                new CatalogItem { CatalogTypeId=2,CatalogBrandId=3, Description = "Dunker", Name = "Elequent", Price = 12, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/10" },
                new CatalogItem { CatalogTypeId=1,CatalogBrandId=2, Description = "All round", Name = "Inredeible", Price = 248.5M, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/11" },
                new CatalogItem { CatalogTypeId=2,CatalogBrandId=1, Description = "Pricesless", Name = "London Sky", Price = 412, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/12" },
                new CatalogItem { CatalogTypeId=3,CatalogBrandId=3, Description = "You ar ethe star", Name = "Elequent", Price = 123, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/13" },
                new CatalogItem { CatalogTypeId=3,CatalogBrandId=2, Description = "A ring popular in the 16th and 17th century in Western Europe that was used as an engagement wedding ring", Name = "London Star", Price = 218.5M, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/14" },
                new CatalogItem { CatalogTypeId=3,CatalogBrandId=1, Description = "A floppy, bendable ring made out of links of metal", Name = "Paris Blues", Price = 312, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/15" }

            };
        }

        private static IEnumerable<CatalogType> GetPreConfiguredCatalogTypes()
        {
            return new List<CatalogType>
            {
                new CatalogType {Type = "Engagement Ring"},
                new CatalogType {Type = "Wedding Ring"},
                new CatalogType {Type = "Fashion Ring"}
            };
        }

        private static IEnumerable<CatalogBrand> GetPreConfiguredCatalogBrands()
        {
            return new List<CatalogBrand>
            {
                new CatalogBrand{Brand = "Tiffany & Co."},
                new CatalogBrand{Brand = "Bebeers"},
                new CatalogBrand{Brand = "Graff"}
            };
        }
    }
}
