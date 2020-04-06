using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;

namespace Scrds.Core
{
    public class PlayerStats
    {
        public int Experience { get; set; }
        public int Strength { get; set; }
        public int Intelligence { get; set; }
        public int Dexterity { get; set; }
        public PlayerEquipment Equipment { get; set; }
    }
    public class PlayerEquipment
    {
        public int Helmet { get; set; }
        public int Ring1 { get; set; }
        public int Ring2 { get; set; }
        public int Amulet { get; set; }
        public int Armor { get; set; }
        public int Gloves { get; set; }
        public int Shoes { get; set; }
        public int Weapon { get; set; }
        public int OffHand { get; set; }
        public int Belt { get; set; }
        public int Flask1 { get; set; }
        public int Flask2 { get; set; }
        public int Flask3 { get; set; }
        public int Flask4 { get; set; }
        public int Flask5 { get; set; }
    }
    public class FileSystem : MonoBehaviour
    {
        [SerializeField]
        private string pathToTheFile = "./game_data/";

        void Start() {
            PlayerStats playerStats = GetPlayerStats("player");
            int a = 0;
        }

        string GetFilePath(string fileName){
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

        public PlayerStats GetPlayerStats(string fileName) {
            string path = GetFilePath(fileName);
            var json = File.ReadAllText(path);
            PlayerStats playerStats = JsonConvert.DeserializeObject<PlayerStats>(json);
            return playerStats;
        }
    }
}