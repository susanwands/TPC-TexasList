using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TexasList.Data.Models;
using TexasList.Data;


namespace TexasList.Adapters.Interfaces
{
    public interface IPostAdapter
    {
        List<City> GetCities();
        List<Category> GetAllCategories();
        List<Subcategory> GetAllSubcategories();
        List<PostSubcategory> GetAllPostSubcategories();
        List<City> GetSelectedCity(int Id);
        List<PostSubcategory> GetListing(int cityId, int category, int subCat);
        List<Post> GetEntirePost(int postId);
        List<Post> GetUserPosts(int userId);
        List<User> GetAllUsers();
        List<User> GetUserById(int userId);
        int CreateUser(string UserName, string Email);
        int CreatePost(string title, string adBody, string amount, int userId, int subcatagoryId, int cityId);
        void CreatePostSubcategory(int newPostId, int subcatagoryId);
        int DeletePost(int deleteId);
        bool SearchForUser(string UserName);
        User GetUser(string UserName);

    }
}
