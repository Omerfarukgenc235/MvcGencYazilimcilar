using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CommentManager : ICommentService
    {
        ICommentDal _commentDal;


        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

    
        public List<Comment> CommentByStatusTrue()
        {
            return _commentDal.List(x => x.CommentStatus == true);
        }
        public List<Comment> CommentByStatusFalse()
        {
            return _commentDal.List(x => x.CommentStatus == false);
        }
           
        public int CommentStatusChangeToFalse(int id)
        {
            Comment commenttt = _commentDal.Find(x => x.CommentID == id);
            commenttt.CommentStatus = false; 
            return _commentDal.Update(commenttt);
        }
        public int CommentStatusChangeToTrue(int id)
        {
            Comment commenttt = _commentDal.Find(x => x.CommentID == id);
            commenttt.CommentStatus = true;
            return _commentDal.Update(commenttt);
        }

        public List<Comment> GetList()
        {
           return _commentDal.List();
        }

        public List<Comment> GetByID(int id)
        {
            return _commentDal.List(x => x.BlogID == id);
        }

        public void CommentDelete(Comment comment)
        {
            _commentDal.Delete(comment);
        }

        public void CommentUpdate(Comment comment)
        {
            if(comment.CommentStatus == true)
            {
                comment.CommentStatus = false;
            }
            else
            {
                comment.CommentStatus = true;
            }
            _commentDal.Update(comment);
        }

        public void CommentAdd(Comment comment)
        {
            _commentDal.Insert(comment);
        }
    }
}
