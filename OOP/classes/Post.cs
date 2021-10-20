using System;
using System.Linq;
using System.Collections.Generic;

namespace classes
{
    class Post
    {
        private int likes = 0;
        private List<string> comments = new List<string>();

        public void Like()
        {
            likes++;
        }
        
        public int GetLikesNumber()
        {
            return likes;
        }

        public void LeaveComment(string comment) 
        {
            comments.Add(comment);
        }

        public List<string> GetComments() 
        {
            return comments;
        }
    }
}