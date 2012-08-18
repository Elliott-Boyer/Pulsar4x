﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pulsar4X.Entities
{
    public class Fleet
    {
        public int Id { get; set; }
        public Race Race { get; set; }
        public TaskForce TaskForce { get; set; }
        public string Name { get; set; }

        public long XSystem { get; set; }
        public long YSystem { get; set; }

        public int CurrentSpeed { get; set; }
        public int MaxSpeed { get; set; }

        public List<Ship> Ships { get; set; } 

    }
}
