using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TexasList.Adapters.Interfaces;
using TexasList.Data;
using TexasList.Data.Models;
using TexasList.Models;

namespace TexasList.Adapters
{
    public class PostAdapter : IPostAdapter
    {
      public List<City> GetCities(){

          TexasListContext db = new TexasListContext();
          
          List<City> returnedCities = db.Cities.ToList();

          return (returnedCities);

      }

      public List<Category> GetAllCategories()
      {
          TexasListContext db = new TexasListContext();

          List<Category> returnedCategories = db.Categories.ToList();
          List<Subcategory> returnedSubcategories = db.Subcategories.ToList();

          return (returnedCategories);

      }

      public List<PostSubcategory> GetAllPostSubcategories()
      {
          TexasListContext db = new TexasListContext();
          
          List<PostSubcategory> returnedPostSubcategories = db.PostSubcategories.ToList();
          

          return (returnedPostSubcategories);

      }


      public List<Subcategory> GetAllSubcategories()
      {
          TexasListContext db = new TexasListContext();

          List<Subcategory> returnedSubcategories = db.Subcategories.ToList();

          return (returnedSubcategories);

      }


      public List<User> GetAllUsers()
      {
          TexasListContext db = new TexasListContext();

          List<User> returnedUsers = db.Users.ToList();

          return (returnedUsers);
      }

        public List<City> GetSelectedCity(int Id){

            TexasListContext db = new TexasListContext();

            List<City> selectedCity = db.Cities.Where(c => c.CityId == Id).ToList();

            return(selectedCity);
           
        }

        public List<PostSubcategory> GetListing(int cityId, int category, int subCat)
        {
            TexasListContext db = new TexasListContext();
            List<Post> posts = db.Posts.ToList();
            List<City> cities = db.Cities.ToList();
            List<PostSubcategory> listing = db.PostSubcategories.Where(p => p.SubcategoryId == subCat).Where(p=> p.Post.CityId == cityId).ToList();
                                                                      
            return (listing);


        }

        public List<Post>  GetEntirePost(int postId){

            TexasListContext db = new TexasListContext();

            List<Post> returnedPost = db.Posts.Where(p => p.PostId == postId).ToList();
            return(returnedPost);
        }

        public int CreateUser(string UserName, string Email){

            TexasListContext db = new TexasListContext();
            User newUser = db.Users.Create();

            newUser.UserName = UserName;
            newUser.Email = Email;

            db.Users.Add(newUser);
            db.SaveChanges();

            int newId = newUser.UserId;

            return (newId);
        }

        public bool SearchForUser(string UserName){

            TexasListContext db = new TexasListContext();

            var match = db.Users.SingleOrDefault(u => u.UserName == UserName);

            if (match != null)
            {
                return true;
            }

            else return false;
        }

        public User GetUser(string UserName)
        {
            TexasListContext db = new TexasListContext();

            User signedUser = db.Users.Where(u => u.UserName == UserName).First();

            return signedUser;
        }

        public List<User> GetUserById(int userId)
        {
            TexasListContext db = new TexasListContext();

            List<User> signedUser = db.Users.Where(u => u.UserId == userId).ToList();

            return signedUser;
        }

        public List<Post> GetUserPosts(int userId)
        {
            TexasListContext db = new TexasListContext();

            List<Post> userPosts = db.Posts.Where(p => p.UserId == userId).ToList();

            return userPosts;
        }

        public int CreatePost(string title, string adBody, string amount, int userId, int subcatagoryId, int cityId)
        {
            TexasListContext db = new TexasListContext();

            Subcategory catHolder = db.Subcategories.Where(c => c.SubcategoryId == subcatagoryId).First();

            Post newPost = db.Posts.Create();
            newPost.Title = title;
            newPost.AdBody = adBody;
            newPost.Amount = amount;
            newPost.UserId = userId;
            newPost.CityId = cityId;
            newPost.CategoryId = catHolder.CategoryId;

            db.Posts.Add(newPost);
            db.SaveChanges();

            return (newPost.PostId);
        }

        public void CreatePostSubcategory(int newPostId, int subcatagoryId)
        {
            TexasListContext db = new TexasListContext();
            PostSubcategory newSubCat = db.PostSubcategories.Create();
            newSubCat.PostId = newPostId;
            newSubCat.SubcategoryId = subcatagoryId;
            db.PostSubcategories.Add(newSubCat);
            db.SaveChanges();
        }

        public int DeletePost(int deleteId)
        {
            TexasListContext db = new TexasListContext();
            int userId;

            Post editPost = db.Posts.Where(p => p.PostId == deleteId).First();
            userId = editPost.UserId;
            db.Posts.Remove(editPost);
            db.SaveChanges();

            return (userId);
        }


    }
}