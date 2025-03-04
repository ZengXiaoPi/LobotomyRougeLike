﻿using NewGameMode.Diffculty;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace NewGameMode
{
    public static class DifficultyDataReader
    {
        public static string path = Path.GetDirectoryName(Uri.UnescapeDataString(new UriBuilder(Assembly.GetExecutingAssembly().CodeBase).Path));
        public static void Init()
        {
            XmlDocument xmlDoc = new();
            xmlDoc.Load(path + "/Config/DifficultyInfo.xml");
            XmlNodeList difficultyNodes = xmlDoc.SelectNodes("/difficultyInfo/difficulty");
            foreach (XmlNode difficultyNode in difficultyNodes)
            {
                int index = int.Parse(difficultyNode.Attributes["n"].InnerText);
                int wonderAdder = int.Parse(difficultyNode["WonderAdder"].InnerText);
                float wonderTimes = float.Parse(difficultyNode["WonderTimes"].InnerText);
                int agentAdder = int.Parse(difficultyNode["AgentAdder"].InnerText);
                int agentReplacer = int.Parse(difficultyNode["AgentReplacer"].InnerText);
                int bulletAdderOnFirstDay = int.Parse(difficultyNode["BulletAdderOnFirstDay"].InnerText);
                int MaxEnergyAdder = int.Parse(difficultyNode["MaxEnergyAdder"].InnerText);
                float MaxEnergyTimes = float.Parse(difficultyNode["MaxEnergyTimes"].InnerText);
                int AgentDamageAdder = int.Parse(difficultyNode["AgentDamageAdder"].InnerText);
                float AgentDamageTimes = float.Parse(difficultyNode["AgentDamageTimes"].InnerText);
                int OverloadAdder = int.Parse(difficultyNode["OverloadAdder"].InnerText);
                float WorkSuccessAdder = float.Parse(difficultyNode["WorkSuccessAdder"].InnerText);
                float CreatureMaxHPTimes = float.Parse(difficultyNode["CreatureMaxHPTimes"].InnerText);
                int CreatureTiredTimeAdder = int.Parse(difficultyNode["CreatureTiredTimeAdder"].InnerText);
                float FurnaceBoomAdder = float.Parse(difficultyNode["FurnaceBoomAdder"].InnerText);
                float UpLevel1RecipeProbAdder = float.Parse(difficultyNode["UpLevel1RecipeProbAdder"].InnerText);
                DifficultyStruct difficultyStruct = new(wonderAdder, wonderTimes, agentAdder, agentReplacer, bulletAdderOnFirstDay, MaxEnergyAdder, MaxEnergyTimes, AgentDamageAdder, AgentDamageTimes, OverloadAdder, WorkSuccessAdder, CreatureMaxHPTimes, CreatureTiredTimeAdder, FurnaceBoomAdder, UpLevel1RecipeProbAdder);
                DifficultyManager.AddDifficulty(index, difficultyStruct);
            }
        }
    }
}
