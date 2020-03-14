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

using Discord.Commands;
using Discord.WebSocket;
using Miunie.Core;
using Miunie.Core.Entities.Discord;
using Miunie.Discord.Convertors;
using System.Threading.Tasks;

namespace Miunie.Discord.CommandModules
{
    public class ProfileCommand : ModuleBase<SocketCommandContext>
    {
        private readonly EntityConvertor _entityConvertor;
        private readonly ProfileService _profileService;

        public ProfileCommand(EntityConvertor entityConvertor, ProfileService profileService)
        {
            _entityConvertor = entityConvertor;
            _profileService = profileService;
        }

        [Command("profile")]
        public async Task ShowProfileAsync(MiunieUser user = null)
        {
            if (user is null)
            {
                user = _entityConvertor.ConvertUser(Context.User as SocketGuildUser);
            }

            var channel = _entityConvertor.ConvertChannel(Context.Channel as SocketGuildChannel);
            await _profileService.ShowProfileAsync(user, channel);
        }

        [Command("rep log")]
        public async Task ShowReputationLogAsync(int page = 1)
        {
            var source = _entityConvertor.ConvertUser(Context.User as SocketGuildUser);
            var channel = _entityConvertor.ConvertChannel(Context.Channel as SocketGuildChannel);
            await _profileService.ShowReputationLogAsync(source, page, channel);
        }

        [Command("rep log for")]
        public async Task ShowReputationLogAsync(MiunieUser user, int page = 1)
        {
            var source = _entityConvertor.ConvertUser(Context.User as SocketGuildUser);
            var channel = _entityConvertor.ConvertChannel(Context.Channel as SocketGuildChannel);
            await _profileService.ShowReputationLogAsync(source, user, page, channel);
        }

        [Command("+rep")]
        public async Task AddReputationAsync(MiunieUser user)
        {
            var source = _entityConvertor.ConvertUser(Context.User as SocketGuildUser);
            var channel = _entityConvertor.ConvertChannel(Context.Channel as SocketGuildChannel);
            await _profileService.GiveReputationAsync(source, user, channel);
        }

        [Command("-rep")]
        public async Task RemoveReputationAsync(MiunieUser user)
        {
            var source = _entityConvertor.ConvertUser(Context.User as SocketGuildUser);
            var channel = _entityConvertor.ConvertChannel(Context.Channel as SocketGuildChannel);
            await _profileService.RemoveReputationAsync(source, user, channel);
        }

        [Command("guild")]
        public async Task ShowGuildInfoAsync()
        {
            var guild = _entityConvertor.ConvertGuild(Context.Guild);
            var channel = _entityConvertor.ConvertChannel(Context.Channel as SocketGuildChannel);
            await _profileService.ShowGuildProfileAsync(guild, channel);
        }
    }
}
