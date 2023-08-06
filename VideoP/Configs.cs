using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoP
{
    internal class Configs
    {
        public string VideoFolderPath = @"C:\backupsON\DEL VIDINHOS LEVAR PAI";
        public string ConfigsPath = "@Configs";

        public Configs()
        {
            //VideoFolderPath = GetVideoFolderPath();
        }

        private void EscreverConfig(string configFile)
        {
            configFile = Path.Combine(ConfigsPath, "videoFolder.txt");
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

        public void SetVideoFolderPath(string videoFolderPath)
        {
            VideoFolderPath = videoFolderPath;

            string configFile = Path.Combine(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Configs"), "videoFolder.txt");
            File.WriteAllText(configFile, videoFolderPath);
        }
    }
}