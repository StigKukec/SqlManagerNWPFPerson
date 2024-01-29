﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonManager.Dal
{
    class RepoFactory
    {
        private static readonly Lazy<IRepository> repository = new(() => new SqlRepository());
        public static IRepository GetRepository() => repository.Value; 
    }
}