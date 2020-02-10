// Copyright (C) 2020  Control.NET <https://github.com/control-net>
// This program is free software: you can redistribute it and/or modify it
// under the terms of the GNU General Public License as published by the
// Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.

namespace Miunie.Core.Configuration
{
    public class BotConfiguration : IBotConfiguration
    {
        public string DiscordToken { get; set; }
    }
}
