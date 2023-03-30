using System;
using System.Collections.Generic;
using System.Text;
using ConsoleAppProject.Helpers;

namespace ConsoleAppProject.App04
{
   public class NetworkApp
	{

		private NewsFeed news = new NewsFeed();

        /// <summary>
        /// This code defines a method called "DisplayMenu" that,
        /// in a loop that lasts until the user chooses to end it,
        /// shows a menu and asks the user to choose an option.
        /// A switch statement is then used to carry out the chosen option.
        /// </summary>
        public void DisplayMenu()
		{
            ConsoleHelper.OutputHeading(" Mohammad Qasim Matloob News Feed");

            string[] choices = new string[]
            {
                "Post Message", "Post Image", "Remove Post",
                "Display All Posts", "Display Posts by Author",
                "Add Comment", "Like Post", "Quit"
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
					case 6: AddComment(); break;
					case 7: LikePosts(); break;
					case 8: wantToQuit = true; break;
				}
						
			} while (!wantToQuit);
		}

        /// <summary>
        ///This C# function inserts a comment into a news application post.
        ///The user's input is used to update the post with the latest comment.
        /// </summary>
        private void AddComment()
        {
            ConsoleHelper.OutputTitle("Adding a Comment");

            int id = (int)ConsoleHelper.InputNumber(
                "Please enter the post id >", 1, news.GetNumberOfPosts());
            
            Post post = news.FindPost(id);

            Console.Write("Please enter your name >");
            string author = Console.ReadLine();

            Console.Write("Please enter your comment >");
            string comment = Console.ReadLine();

            post.AddComment(comment, author);

            ConsoleHelper.OutputTitle("You have just added this comment:");

            post.Display();

        }

        /// <summary>
        ///The liked post is shown and a way for like a post in a news system is defined by this code.
        ///The Like() function of the associated post object is then called after the user is prompted to enter the post id.
        /// </summary>
        private void LikePosts()
        {
            ConsoleHelper.OutputTitle("Liking a Post");

            int id = (int)ConsoleHelper.InputNumber(
                "Please enter the post id >", 1, news.GetNumberOfPosts());
            
            Post post = news.FindPost(id);

            post.Like();

            ConsoleHelper.OutputTitle("You have just liked this post:");

            post.Display();
        }

        /// <summary>
        ///This method demonstrates articles written by a single author.
        ///The DisplayByAuthor function of the news object is called,
        ///and the user is prompted for the author's name.
        /// </summary>
        private void DisplayByAuthor()
        {
            ConsoleHelper.OutputTitle("Displaying Posts by Author");

            string author = InputName();
            news.DisplayByAuthor(author);
        }

        /// <summary>
        ///By asking the user for a post id, this method deletes the associated post from the 'news' object.
        ///To manage user input and output, it makes use of the 'ConsoleHelper' class.
        /// </summary>
        private void RemovePost()
        {
			ConsoleHelper.OutputTitle($"Removing a Post");

			int id = (int)ConsoleHelper.InputNumber(
                " Please enter the post id >", 1, news.GetNumberOfPosts());
			news.RemovePost(id);
        }


        /// <summary>
        ///This method demonstrates every piece of news in the news object.
        /// That doesn't produce any results.
        /// </summary>
        private void DisplayAll()
        {
            news.Display();
        }

        /// <summary>
        ///This method permits users to post messages, which are then displayed.
        ///It uses the ConsoleHelper class and the MessagePost class.
        /// </summary>
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

        /// <summary>
        ///This method permits posting of images and photos and shows them on the console.
        ///The post is added to a news feed using the PhotoPost class.
        /// </summary>
        private void PostImage()
        {
			ConsoleHelper.OutputTitle("Posting an Image/photo");

			string Author = InputName();

            Console.WriteLine("Please enter your Image Filename> ");
			string  filename = Console.ReadLine();

			Console.Write(" Please enter your image caption >");
			string caption = Console.ReadLine();

			PhotoPost post = new PhotoPost(Author, filename, caption);
			news.AddPhotoPost(post);

			ConsoleHelper.OutputTitle("You have just posted this image:");

			post.Display();

        }

        /// <summary>
        ///The user is prompted to submit their name using this method,
        ///which then returns the input as a string.
        ///A piece of content or message's author can be determined using the string that is returned. 
        /// </summary>
        private string InputName()
        {
			Console.WriteLine(" Please enter your name >");
			string Author = Console.ReadLine();

			return Author; 
        }
    }
}

