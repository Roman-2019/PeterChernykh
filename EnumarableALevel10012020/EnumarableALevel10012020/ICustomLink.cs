﻿using System;

namespace EnumarableALevel10012020
{
    public interface ICustomLink
    {
        void Add(Notebook value);
        Notebook this[int index] { get; }
        bool Delete(Notebook value);
    }
}
