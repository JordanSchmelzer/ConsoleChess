﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChess
{
    public enum EnumGameStatus
    {
        ACTIVE,
        BLACK_WIN,
        WHITE_WIN,
        FOREFIT,
        STALEMATE,
        RESIGNATION
    }
}
