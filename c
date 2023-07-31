using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace RandomVideoPlayer
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create the "Configs" folder if it doesn't exist
            string configFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Configs");
            Directory.CreateDirectory(configFolderPath);

            // Check if the config file exists
            string configFile = Path.Combine(configFolderPath, "videoFolder.txt");
            if (!File.Exists(configFile))
            {
                // If the config file doesn't exist, ask the user to input the video folder path
                Console.Write("Enter the path of the folder where your videos are stored: ");
                string folderPath = Console.ReadLine().Trim();

                // Save the folder path to the config file
                File.WriteAllText(configFile, folderPath);
            }

            // Load the folder path from the config file
            string videoFolderPath = File.ReadAllText(configFile).Trim();

            // Get all video files in the folder and its subfolders
            List<string> videoFiles = GetAllVideoFiles(videoFolderPath);

            if (videoFiles.Count == 0)
            {
                Console.WriteLine("No video files found in the specified folder.");
                return;
            }

            // Generate random indices for selecting a video file and a random time delay
            Random random = new Random();
            int videoIndex = random.Next(0, videoFiles.Count);
            int randomDelaySeconds = random.Next(5, 20); // Adjust the range of the delay as you like

            // Get the path of the selected video file
            string selectedVideoPath = videoFiles[videoIndex];

            // Print information about the selected video
            Console.WriteLine("Selected video: " + selectedVideoPath);
            Console.WriteLine("Random delay: " + randomDelaySeconds + " seconds");

            // Wait for the random time delay
            System.Threading.Thread.Sleep(randomDelaySeconds * 1000);

            // Use VLC to open and play the selected video
            Process.Start("vlc.exe", selectedVideoPath);
        }

        static List<string> GetAllVideoFiles(string folderPath)
        {
            List<string> videoFiles = new List<string>();
            string[] allowedExtensions = { ".mp4", ".avi", ".mkv", ".wmv" }; // Add more extensions if needed

            foreach (string file in Directory.GetFiles(folderPath, "*", SearchOption.AllDirectories))
            {
                if (Array.Exists(allowedExtensions, ext => ext.Equals(Path.GetExtension(file), StringComparison.OrdinalIgnoreCase)))
                {
                    videoFiles.Add(file);
                }
            }

            return videoFiles;
        }
    }
}
