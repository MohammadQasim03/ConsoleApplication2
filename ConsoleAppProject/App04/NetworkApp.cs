using System;
using System.Collections.Generic;
using System.Text;
using ConsoleAppProject.Helpers;

namespace ConsoleAppProject.App04
{
   public class NetwrokApp
	{

		private NewsFeed news = new NewsFeed();

		/// <summary>
		/// 
		/// </summary>
		public void DisplayMenu()
		{
            ConsoleHelper.OutputHeading(" Mohammad Qasim Matloob nNews Feed");

            string[] choices = new string[]
                {
                "Post Message", "Post Image", "Remove Post",
                "Display All Posts", "Display Posts by Author",
                "Display Posts by Date", "Add Comment", "Like Post", "Quit"
                 };

            bool wantToQuit = false;
			do
			{
				int choice = ConsoleHelper.SelectChoice(choices);
				switch (choice)
				{
					case 1: PostMessage(); break;
					case 2: PostImage(); break;
					case 3: RemovePost(); break;
					case 4: DisplayAll(); break;
					case 5: DisplayByAuthor(); break;
					case 6: DisplayByDate(); break;
					case 7: AddComment(); break;
					case 8: LikePosts(); break;
					case 9: wantToQuit = true; break;
				}
						
			} while (!wantToQuit);
		}

        private void AddComment()
        {

            ConsoleHelper.OutputTitle("Adding a Comment");

            int id = (int)ConsoleHelper.InputNumber("Please enter the post id >",
                1, Post.GetNumberOfPost());
            Post post = news.GetPostById(id);

            Console.Write("Please enter your name >");
            string author = Console.ReadLine();

            Console.Write("Please enter your comment >");
            string comment = Console.ReadLine();

            post.AddComment(author, comment);

            ConsoleHelper.OutputTitle("You have just added this comment:");

            post.Display();

        }

        private void LikePosts()
        {
            ConsoleHelper.OutputTitle("Liking a Post");

            int id = (int)ConsoleHelper.InputNumber("Please enter the post id >", 1, Post.GetNumberOfPost());
            Post post = news.GetPostById(id);

            Console.Write("Please enter your name >");
            string author = Console.ReadLine();

            post.AddLike(author);

            ConsoleHelper.OutputTitle("You have just liked this post:");

            post.Display();
        }



        private void DisplayByDate()
        {
            ConsoleHelper.OutputTitle("Displaying Posts by Date");

            DateTime fromDate = ConsoleHelper.InputDate("Please enter the from date (dd/MM/yyyy) >");
            DateTime toDate = ConsoleHelper.InputDate("Please enter the to date (dd/MM/yyyy) >");

            news.DisplayByDate(fromDate, toDate);
        }

        private void DisplayByAuthor()
        {
            ConsoleHelper.OutputTitle("Displaying Posts by Author");

            string author = InputName();
            news.DisplayByAuthor(author);
        }

        private void RemovePost()
        {
			ConsoleHelper.OutputTitle($"Removing a Post");

			int id = (int)ConsoleHelper.InputNumber(" Please enter the post id >",
				                                     1, Post.GetNumberOfPost());
			news.RemovePost(id);
        }

        private void DisplayAll()
        {
            news.Display();
        }

        private void PostMessage()
        {
            ConsoleHelper.OutputTitle("Posting a Message");

            string author = InputName();

            Console.Write("Please enter your message >");
            string message = Console.ReadLine();

            MessagePost post = new MessagePost(author, message);
            news.AddMessagePost(post);

            ConsoleHelper.OutputTitle("You have just posted this message:");

            post.Display();
        }

        private void PostImage()
        {
			ConsoleHelper.OutputTitle("Posting an Image/photo");

			string Author = InputName();

			Console.WriteLine("Please enter your Image Filename> ")
			string  filename = Console.ReadLine();

			Console.Write(" Please enter your image caption >");
			string caption = Console.ReadLine();

			PhotoPost post = new PhotoPost(Author, filename, caption);
			news.AddPhotoPost(post);

			ConsoleHelper.OutputTitle("You have just posted this image:");

			post.Display();

        }


		/// <summary>
		/// 
		/// </summary>
        private string InputName()
        {
			Console.WriteLine(" Please enter your name >");
			string Author = Console.ReadLine();

			return Author; 
        }
    }
}

