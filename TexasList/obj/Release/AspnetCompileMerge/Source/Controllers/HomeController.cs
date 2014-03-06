using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TexasList.Data;
using TexasList.Models;
using TexasList.Data.Models;
using TexasList.Adapters.Interfaces;
using TexasList.Adapters;

namespace TexasList.Controllers
{
    public class HomeController : Controller
    {
        private IPostAdapter _postAdapter;

        public HomeController()
        {
            _postAdapter = new PostAdapter();
        }

     

        public ActionResult Index()
        {
            ViewModel Cities = new ViewModel();

            Cities.Cities = _postAdapter.GetCities();
            
            return View(Cities);
        }

       public ActionResult CityPage(int Id)
        {
            //takes the selected City
            // gets the CityName and puts it in the title section
           
            ViewModel Cities = new ViewModel();

            TexasListContext db = new TexasListContext();

            Cities.Cities = _postAdapter.GetSelectedCity(Id);
      
            return View(Cities);
        }

        public ActionResult Listing(int cityId, int category, int subCat)
        {
            //take parameters and return posts
           
            ViewModel PostSubcategories = new ViewModel();
      
            PostSubcategories.PostSubcategories = _postAdapter.GetListing(cityId, category, subCat);
           
            return View(PostSubcategories);
        }

        public ActionResult Post(int postId)
        {
            //Take to postId and bring back the rest of the post to view
            ViewModel Posts = new ViewModel();

            Posts.Posts = _postAdapter.GetEntirePost(postId);
            Posts.Users = _postAdapter.GetAllUsers();

            return View(Posts);
        }

        public ActionResult Login()
        {
            

            return View();
        }


        [HttpPost]
        public ActionResult Login(string UserName, string Email)
        {
            bool match = _postAdapter.SearchForUser(UserName);

            if (match == true)
            {
                User signedUser = _postAdapter.GetUser(UserName);

                return RedirectToAction("Manage", new { signedId = signedUser.UserId });
            }

            else
            {
                int newId = _postAdapter.CreateUser(UserName, Email);

                return RedirectToAction("Manage", new { signedId = newId });
            }
        }

        public ActionResult Manage(int signedId)
        {
           
            ViewModel Users = new ViewModel();


            Users.Users = _postAdapter.GetUserById(signedId);
            Users.Posts = _postAdapter.GetUserPosts(signedId);
            Users.Categories = _postAdapter.GetAllCategories();
            Users.Subcategories = _postAdapter.GetAllSubcategories();
            Users.Cities = _postAdapter.GetCities();
            Users.PostSubcategories = _postAdapter.GetAllPostSubcategories();


            return View(Users);
        }

        [HttpPost]
        public ActionResult Manage(string title, string adBody, string amount, int userId, int subcatagoryId, int cityId)
        {
            ViewModel Users = new ViewModel();

            int newPostId = _postAdapter.CreatePost(title, adBody, amount, userId, subcatagoryId, cityId);

            _postAdapter.CreatePostSubcategory(newPostId, subcatagoryId);

            Users.Users = _postAdapter.GetUserById(userId);
            Users.Posts = _postAdapter.GetUserPosts(userId);
            Users.Categories = _postAdapter.GetAllCategories();
            Users.Subcategories = _postAdapter.GetAllSubcategories();
            Users.Cities = _postAdapter.GetCities();
            Users.PostSubcategories = _postAdapter.GetAllPostSubcategories();

            return View(Users);
        }

       

        public ActionResult Admin()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

       
        public ActionResult Delete(int deleteId)
        {
            
            int userId = _postAdapter.DeletePost(deleteId);

            return RedirectToAction("Manage", new { signedId = userId });
        }

        //public ActionResult Search(string searchString)
        //{
        //    TexasListContext db = new TexasListContext();
           

            

        //    return RedirectToAction("Listing");
        //}
        
      
    }
}