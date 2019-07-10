using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIDIT.Models
{
    public class ApiFunct
    {
        DITContext dc = new DITContext();


        //User kısmı

        public void UpdateUser(int id, User user)
        {
            var u1 = dc.User.First(u => u.UserId == id);

            u1.UserName = user.UserName;
            u1.UserPassword = user.UserPassword;
            u1.UserEmail = user.UserEmail;
            u1.UserPhone = user.UserPhone;
            u1.UserAddress = user.UserAddress;
            dc.SaveChanges();
        }

        public IEnumerable<User> GetUsers()
        {
            try
            {
                return dc.User.ToList();
            }
            catch
            {
                throw;
            }
        }
        public User GetUsersByEmail(string email)
        {
            try
            {
                return dc.User.Where(e => e.UserEmail == email).First();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void CreateUser(User user)
        {
            dc.User.Add(user);
            dc.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            User user = new User();
            user = dc.User.Where((c => c.UserId == id)).First();
            dc.User.Remove(user);
            dc.SaveChangesAsync();
        }

        // Campaign kısmı
        public IEnumerable<Campaign> GetCampaign()
        {
            try
            {
                var campaign = (from u in dc.Product
                                from  p in dc.Campaign
                                where u.ProductId ==p.ProductId
                                select p).ToList();
                return campaign;
            }
            catch
            {
                throw;
            }
        }

        public void CreateCampaign(Campaign campaign)
        {
            dc.Campaign.Add(campaign);
            dc.SaveChanges();
        }

        public void DeleteCampaign(int id)
        {
            Campaign campaign = new Campaign();
            campaign = dc.Campaign.Where((c => c.CampaignId == id)).First();
            dc.Campaign.Remove(campaign);
            dc.SaveChangesAsync();
        }

        public void UpdateCampaign(int id,Campaign campaign)
        {
            var c1 = dc.Campaign.First(c=> c.CampaignId == id);
            
            c1.CampaignDetail = campaign.CampaignDetail;
            c1.CampaignType = campaign.CampaignType;
            c1.ValidationTime = campaign.ValidationTime;
            //dc.Campaign.Update(campaign);
            dc.SaveChanges();
        }


        //Product kısmı
        public void CreateProduct(Product product)
        {
            dc.Product.Add(product);
            dc.SaveChanges();
        }

        public IEnumerable<Product> GetProducts()
        {
            try
            {
                return dc.Product.ToList();
            }
            catch 
            {

                throw;
            }
        }
        public void DeleteProduct(long id)
        {
            Product product = new Product();
            product = dc.Product.Where((p => p.ProductId == id)).First();
            dc.Product.Remove(product);
            dc.SaveChanges();
        }
        public void UpdateProduct(long id,Product product)
        {
            var product1 = dc.Product.First(p => p.ProductId == id);
            product1.ProductName = product.ProductName;
            product1.ProductBarcode = product.ProductBarcode;
            product1.ProductCount = product.ProductCount;
            dc.SaveChanges();

        }
        
    }
}
