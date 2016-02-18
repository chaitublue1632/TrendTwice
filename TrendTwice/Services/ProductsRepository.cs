using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrendTwice.Models;

namespace TrendTwice.Services
{
    public class ProductsRepository
    {
        public List<Listings> GetAllListings()
        {
            List<Listings> allListings = null;
            using (dbModel model = new dbModel())
            {
                allListings = model.Listings.ToList();
            }
            return allListings;
        }

        public Sale GetListingById(int itemId)
        {
            Sale listing = null;
            using (dbModel model = new dbModel())
            {
                listing = model.Listings.Where(item => item.ListingId == itemId).Select(y => new Sale{
                    Price = y.Dress.Price,
                    Color = y.Dress.DressColors.Name,
                    ListingId = y.ListingId,
                    Size = y.Dress.DressSize.Name
                }).FirstOrDefault();
            }
            return listing;
        }
    }
}