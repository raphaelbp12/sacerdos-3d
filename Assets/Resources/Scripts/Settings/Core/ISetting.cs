﻿using System;

namespace Scrds.Settings.Core
{
    public interface ISetting
    {
        string Id { get; }

        event Action Changed;

        void SetDefault();

        void Load(string saveData);

        string Save();
    }
} 