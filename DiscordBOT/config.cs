﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace DiscordBOT
{
    class Config
    {
        private const string configFolder = "Resources";
        private const string configFile = "config.json";
        private const string configPath = configFolder + "/" + configFile;

        public static BotConfig bot;

        static Config()
        {
            if (!Directory.Exists(configFolder)) Directory.CreateDirectory(configFolder);
            if (!File.Exists(configFolder + "/" + configFile))
            {
                bot = new BotConfig();
                string json = JsonConvert.SerializeObject(bot, Formatting.Indented);
                File.WriteAllText(configFolder + "/" + configFile, json);
            }
            else
            {
                string json = File.ReadAllText(configFolder + "/" + configFile);
                bot = JsonConvert.DeserializeObject<BotConfig>(json);
            }
        
        }
    }

    public struct BotConfig
    {
        public string token;
        public string cmdPrefix;
    }
}
