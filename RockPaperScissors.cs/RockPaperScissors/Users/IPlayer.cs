﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors.Logic
{
    public interface IPlayer
    {
        ThrowStatus Throw();
    }
}
