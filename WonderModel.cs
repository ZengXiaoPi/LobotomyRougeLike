﻿using NewGameMode.Diffculty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace NewGameMode
{
    public class WonderModel
    {
        private static WonderModel _instance;
        public int money;

        private WonderModel()
        {
        }
        public static WonderModel instance
        {
            get
            {
                if (WonderModel._instance == null)
                {
                    WonderModel._instance = new WonderModel();
                }
                return WonderModel._instance;
            }
        }

        public void Init(int wonder)
        {
            this.money = wonder;
        }

        /*
        public Dictionary<string, object> GetSaveData()
        {
            return new Dictionary<string, object>
        {
            {
                "wonder",
                this.money
            }
        };
        }
        */

        public void LoadData(Dictionary<string, object> dic)
        {
            GameUtil.TryGetValue<int>(dic, "wonder", ref this.money);
        }
        public bool EnoughCheck(int cost)
        {
            return this.money >= cost;
        }

        public void Add(int added)
        {
            var nowDifficulty = DifficultyManager.GetNowDifficulty();
            float wonderTimes = nowDifficulty.WonderTimes();
            foreach (var meme in MemeManager.instance.current_list)
            {
                wonderTimes += meme.script.WonderTimes();
            }
            int wonderAdder = nowDifficulty.WonderAdder();
            foreach (var meme in MemeManager.instance.current_list)
            {
                wonderAdder += meme.script.WonderAdder();
            }
            int realAdded = (int)(Math.Round(added * wonderTimes)) + wonderAdder;
            this.money += realAdded;
            if (this.money < 0)
            {
                this.money = 0;
            }

            Harmony_Patch.dayResult[4] += realAdded;
        }

        public bool Pay(int cost)
        {
            if (this.money >= cost)
            {
                this.money -= cost;
                return true;
            }
            return false;
        }
    }

    /// <summary>
    /// 更新奇思数量
    /// </summary>
    public class UpdateWonder : MonoBehaviour
    {
        void Update()
        {
            base.gameObject.GetComponent<Text>().text = LocalizeTextDataModel.instance.GetText("Meme_Wonder") + ":" + WonderModel.instance.money;
        }
    }
}
