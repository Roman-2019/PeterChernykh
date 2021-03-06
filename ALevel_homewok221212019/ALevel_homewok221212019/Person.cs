﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALevel_homewok221212019
{
    public abstract class Person
    {
        public abstract bool CanMakeRoomRevision { get; }
        public abstract bool CanBeInRoom { get; }

        public string Name { get; set; }
    }
    public class Admin : Person
    {
        public override bool CanMakeRoomRevision => true;
        public override bool CanBeInRoom => false;

        public string Name { get; set; }
    }
    public class Student : Person
    {
        public override bool CanMakeRoomRevision => false;
        public override bool CanBeInRoom => true;

        public string Name { get; set; }
    }
    class Teacher : Person
    {
        public override bool CanMakeRoomRevision => false;
        public override bool CanBeInRoom => true;

        public string Name { get; set; }
    }
}
