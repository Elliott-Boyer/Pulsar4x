﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pulsar4X.Entities
{
    public class Commander
    {
        public Guid Id { get; set; }
        public Race Race { get; set; }
        public Species Species { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get { return string.Format("{0} {1}", FirstName, LastName); }
        }

        public CommanderTypes CommanderType { get; set; }
        public int Rank { get; set; }
        public string RankName { get; set; }

    }
}