using RCP.BL;
using RCP.Model;
using RCP.UI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RCP.UI.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        public ActionResult Blog()
        {
            BlogRepository blogRepository = new BlogRepository();
            BlogPhotoRepository blogPhotoRepository = new BlogPhotoRepository();
            BlogCommentRepository blogCommentRepository = new BlogCommentRepository();
            UserRepository userRepository = new UserRepository();

            List<BlogViewModel> blogView = new List<BlogViewModel>();
            var blogresult = blogRepository.GetAll();
            var blogphotoresult = blogPhotoRepository.GetAll();
            var blogcommentresult = blogCommentRepository.GetAll();

            foreach (var item in blogresult)
            {
                blogView.Add(new BlogViewModel
                {
                    Id = item.Id,
                    Content = item.Content,
                    Star = item.Star,
                    Title = item.Title,
                    RegisterDate = item.RegisterDate,
                    UserId = item.UserId,
                    Users = userRepository.GetById(item.UserId),
                });
            }

            foreach (var item in blogphotoresult)
            {
                blogView.ForEach(x => x.Photo = item.Photo);
            }

            return View(blogView);
        }
        public ActionResult Detail(int id)
        {
            BlogRepository blogRepository = new BlogRepository();
            BlogPhotoRepository blogPhotoRepository = new BlogPhotoRepository();
            BlogCommentRepository blogCommentRepository = new BlogCommentRepository();

            BlogDetailViewModel blogView = new BlogDetailViewModel();
            var blogresult = blogRepository.GetById(id);
            var blogphotoresult = blogPhotoRepository.GetByFilter(X => X.BlogId == id);
            var blogcommentresult = blogCommentRepository.GetByFilter(x => x.BlogId == id);

            blogView.Content = blogresult.Content;
            blogView.Star = blogresult.Star;
            blogView.Title = blogresult.Title;
            blogView.RegisterDate = blogresult.RegisterDate;
            blogView.UserId = blogresult.UserId;
            blogView.Users = blogresult.Users;
            blogView.blogComment = blogcommentresult;
            blogView.blogPhoto = blogphotoresult;
            return View(blogView);
        }
        [HttpPost]
        public ActionResult Detail(BlogComment model)
        {
            BlogCommentRepository commentRepository = new BlogCommentRepository();
            commentRepository.Add(new RCP.Model.BlogComment
            {
                Content = model.Content,
                Title = model.Title,
                BlogId = model.BlogId,
                Blogs = model.Blogs,
                
                Id = model.Id,
                IsDelete = false,
                RegisterDate = DateTime.Now

            });
            return View();
        }
    }
}