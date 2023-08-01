using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoP
{
    internal class Configs
    {
        public string VideoFolderPath;

        public Configs()
        {
            VideoFolderPath = GetVideoFolderPath();
        }

        private string GetVideoFolderPath()
        {
            if (VideoFolderPath == null)
            {
                string configFolderPath = CriaPasta();
            }

            return VideoFolderPath;
        }

        private void EscreverConfig(string configFile)
        {
            string configFile = Path.Combine(configFolderPath, "videoFolder.txt");
            if (!File.Exists(configFile))
            {
                Console.Write("Enter the path of the folder where your videos are stored: ");
                VideoFolderPath = Console.ReadLine().Trim();

                File.WriteAllText(configFile, VideoFolderPath);
            }
            else
            {
                VideoFolderPath = File.ReadAllText(configFile).Trim();
            }
        }

        private static string CriaPasta()
        {
            string configFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Configs");
            Directory.CreateDirectory(configFolderPath);
            return configFolderPath;
        }

        public void SetVideoFolderPath(string VideoFolderPath)
        {
            Configs.VideoFolderPath = VideoFolderPath;

            string configFile = Path.Combine(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Configs"), "videoFolder.txt");
            File.WriteAllText(configFile, VideoFolderPath);
        }
    }
}