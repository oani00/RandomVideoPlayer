using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoP
{
    internal class Player
    {
        private Configs Configs;

        public Player(Configs configs)
        {
            Configs = configs;
        }

        public void PlayRandomVideo()
        {
            List<string> videoFiles = GetAllVideoFiles(Configs.VideoFolderPath);

            if (videoFiles.Count == 0)
                throw new Exception("No video files found in the specified folder.");

            Random random = new Random();
            int videoIndex = random.Next(0, videoFiles.Count);
            int randomDelaySeconds = random.Next(5, 20); // Adjust the range of the delay as you like

            string selectedVideoPath = videoFiles[videoIndex];

            Console.WriteLine("Selected video: " + selectedVideoPath);
            Console.WriteLine("Random delay: " + randomDelaySeconds + " seconds");

            System.Threading.Thread.Sleep(randomDelaySeconds * 1000);

            Process.Start("vlc.exe", selectedVideoPath);
        }

        private List<string> GetAllVideoFiles(string folderPath)
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