using System;
using System.Collections.Generic;

namespace YouTubeVideoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Video> videos = new List<Video>();

            // Creating videos
            Video video1 = new Video("Introduction to C#", "John Doe", 300);
            Video video2 = new Video("Advanced C# Techniques", "Jane Smith", 1200);
            Video video3 = new Video("C# Design Patterns", "Mike Brown", 900);

            // Adding comments to video1
            video1.AddComment(new Comment("Alice", "Great introduction!"));
            video1.AddComment(new Comment("Bob", "Very helpful, thanks!"));
            video1.AddComment(new Comment("Charlie", "Well explained."));

            // Adding comments to video2
            video2.AddComment(new Comment("Dave", "I learned a lot!"));
            video2.AddComment(new Comment("Eve", "This was too advanced for me."));
            video2.AddComment(new Comment("Frank", "Excellent content."));

            // Adding comments to video3
            video3.AddComment(new Comment("Grace", "Design patterns are really useful."));
            video3.AddComment(new Comment("Heidi", "Can you make more videos on this topic?"));
            video3.AddComment(new Comment("Ivan", "Clear and concise."));

            // Adding videos to the list
            videos.Add(video1);
            videos.Add(video2);
            videos.Add(video3);

            // Displaying video information and comments
            foreach (var video in videos)
            {
                Console.WriteLine($"Title: {video.Title}");
                Console.WriteLine($"Author: {video.Author}");
                Console.WriteLine($"Length: {video.Length} seconds");
                Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
                Console.WriteLine("Comments:");
                foreach (var comment in video.GetComments())
                {
                    Console.WriteLine($"- {comment.CommenterName}: {comment.Text}");
                }
                Console.WriteLine();
            }
        }
    }
}