using System;
using System.Linq;
using System.Collections.Generic;

namespace classes
{
    class Program
    {
        static void Main(string[] args)
        {
            Rect rect = new Rect(4, 5, new Point(4, 10));
            System.Console.WriteLine("rect point start: " + rect.point);
            System.Console.WriteLine("rect Area: " + rect.GetArea());
            
            System.Console.WriteLine("rect Perimeter: " + rect.GetPerimeter());
            
            rect.Move(5);
            System.Console.WriteLine("Rect point before edit 5: " + rect.point);

            Post post = new Post();

            post.Like();
            post.Like();

            post.LeaveComment("Cool post");
            post.LeaveComment("Nice Dog");

            System.Console.WriteLine("Likes: " + post.GetLikesNumber() + "\n");
            List<string> comments = post.GetComments();

            foreach(var comment in comments)
            {
                System.Console.WriteLine(comment);
            }

            
        }
    }
}
