﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewGameMode
{
    [Serializable]
    public class MemeRequire
    {
        public MemeRequireType type;
        public int value;
        public bool check = false;
    }
}
