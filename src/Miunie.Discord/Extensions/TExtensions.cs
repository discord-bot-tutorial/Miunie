// This file is part of Miunie.
//
//  Miunie is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  Miunie is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with Miunie. If not, see <https://www.gnu.org/licenses/>.

using System;
using System.Collections.Generic;
using System.Linq;

namespace Miunie.Discord
{
    internal static class TExtensions
    {
        internal static string StringJoinOrDefault<T>(
            this IEnumerable<T> values,
            Func<T, string> formatter,
            string separator,
            string fallback = "")
            => values?.Count() > 0
            ? string.Join(separator, values.Select(x => formatter.Invoke(x)))
            : fallback ?? string.Empty;
    }
}
