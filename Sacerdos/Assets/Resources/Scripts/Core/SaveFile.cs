using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;

namespace Scrds.Core
{
    public static class SaveFileManagement
    {
        private static string pathToTheFile = "./save/";
        public static void SaveFile<T>(T objectToSave, string fileName)
        {
            string path = pathToTheFile + fileName + ".txt";

            CreateFileIfNotExists(fileName);

            File.WriteAllText(path, JsonConvert.SerializeObject(objectToSave));
        }

        public static void CreateFileIfNotExists(string fileName)
        {
            string path = pathToTheFile + fileName + ".txt";

            if (!File.Exists(path)) {
                File.Create(path);
            }
        }

        public static T LoadFile<T>(string fileName) {
            string path = pathToTheFile + fileName + ".txt";
            var json = File.ReadAllText(path);
            var jsonParsed = JsonConvert.DeserializeObject<T>(json);
            
            return jsonParsed;
        }
    }
}