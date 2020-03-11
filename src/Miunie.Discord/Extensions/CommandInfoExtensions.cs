using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Miunie.Discord
{
    internal static class CommandInfoExtensions
    {
        internal static TAttribute FindAttribute<TAttribute>(this CommandInfo command) where TAttribute : Attribute
            => command.Attributes.FirstOrDefault(x => x is TAttribute) as TAttribute;

        internal static IEnumerable<TAttribute> FindAttributes<TAttribute>(this CommandInfo command) where TAttribute : Attribute
            => command.Attributes.Where(x => x is TAttribute).Select(x => x as TAttribute);
    }
}
