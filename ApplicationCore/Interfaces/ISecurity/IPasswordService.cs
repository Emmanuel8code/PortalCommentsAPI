﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.ISecurity
{
    public interface IPasswordService
    {
        string Hash(string password);
    }
}
