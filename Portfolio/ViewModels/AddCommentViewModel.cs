using System;
using Portfolio.Models;
namespace Portfolio.ViewModels
{
    public class AddComment
    {
        public Post Post { get; set; }
        public Comment Comment { get; set; } = new Comment();
        public AddComment(Post post)
        {
            Post = post;
            Comment.PostId = post.PostId;
        }
    }
}