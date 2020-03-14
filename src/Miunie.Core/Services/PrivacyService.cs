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

using Miunie.Core.Attributes;
using Miunie.Core.Discord;
using Miunie.Core.Entities.Discord;
using Miunie.Core.Providers;
using System.Threading.Tasks;

namespace Miunie.Core
{
    [Service]
    public class PrivacyService
    {
        private readonly IDiscordMessages _messages;
        private readonly IMiunieUserProvider _users;

        public PrivacyService(IDiscordMessages messages, IMiunieUserProvider users)
        {
            _messages = messages;
            _users = users;
        }

        public async Task OutputUserJsonDataAsync(MiunieUser user)
        {
            await _messages.SendDirectFileMessageAsync(user, Entities.PhraseKey.USER_PRIVACY_FILE_MESSAGE, user.Name);
        }

        public async Task RemoveUserData(MiunieUser user, MiunieChannel channel)
        {
            _users.RemoveUser(user);
            await _messages.SendMessageAsync(channel, Entities.PhraseKey.USER_PRIVACY_DATA_REMOVED, user.Name);
        }
    }
}
