using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;

namespace Scrds.Classes
{
    public class FileSystem
    {
        static private string pathToTheFile = "./game_data/";

        static string GetFilePath(string fileName){
            string path = pathToTheFile + "player.txt";

            if (fileName != "")
            {
                path = pathToTheFile + fileName + ".txt";
            }

            if (File.Exists(path)) {
                return path;
            } else 
            {
                return null;
            }
        }

        public static T ParseJsonFile<T>(string fileName) {
            string path = GetFilePath(fileName);
            var json = File.ReadAllText(path);
            T playerStats = JsonConvert.DeserializeObject<T>(json);
            return playerStats;
        }
    }
}