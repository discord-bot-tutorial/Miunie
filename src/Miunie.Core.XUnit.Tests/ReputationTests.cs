﻿using System;
using System.Linq.Expressions;
using Xunit;
using Moq;
using System.Threading.Tasks;
using Miunie.Core.Logging;
using Miunie.Core.Providers;

namespace Miunie.Core.XUnit.Tests
{
    public class ReputationTests
    {
        private readonly Mock<IUserReputationProvider> _repProviderMock;
        private readonly ProfileService _profileService;
        private readonly DummyMiunieUsers _data;

        private readonly Expression<Func<MiunieUser, bool>> _hasDraxId;
        private readonly Expression<Func<MiunieUser, bool>> _hasPeterId;
        private readonly Expression<Func<MiunieUser, bool>> _hasSenneId;

        public ReputationTests()
        {
            _repProviderMock = new Mock<IUserReputationProvider>();
            var discordMsgMock = new Mock<IDiscordMessages>();
            _profileService = new ProfileService(discordMsgMock.Object, _repProviderMock.Object, new Mock<ILogger>().Object);
            _data = new DummyMiunieUsers();

            _hasDraxId = u => u.Id == _data.Drax.Id;
            _hasPeterId = u => u.Id == _data.Peter.Id;
            _hasSenneId = u => u.Id == _data.Senne.Id;
        }

        [Fact]
        public async Task ShouldCheckForTimeoutBeforeAdding()
        {
            await _profileService.GiveReputationAsync(_data.Drax, _data.Senne, new MiunieChannel(), "reason");

            _repProviderMock.Verify(rp => rp.AddReputationHasTimeout(
                It.Is<MiunieUser>(_hasDraxId),
                It.Is<MiunieUser>(_hasSenneId)
            ), Times.Once());

            _repProviderMock.Verify(rp => rp.AddReputation(
                It.Is<MiunieUser>(_hasDraxId),
                It.Is<MiunieUser>(_hasSenneId),
                "reason"
            ), Times.Once());
        }

        [Fact]
        public async Task ShouldNotAddRepToSelf()
        {
            await _profileService.GiveReputationAsync(_data.Senne, _data.Senne, new MiunieChannel(), "reason");

            // NOTE(Peter):
            // Makes sure the service didn't add reputation to self
            // and that it didn't bother with checking the timeout either.
            _repProviderMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldCheckForTimeoutBeforeRemoving()
        {
            var reason = "reason";
            await _profileService.RemoveReputationAsync(_data.Drax, _data.Senne, new MiunieChannel(), reason);

            _repProviderMock.Verify(rp => rp.RemoveReputationHasTimeout(
                It.Is<MiunieUser>(_hasDraxId),
                It.Is<MiunieUser>(_hasSenneId)
            ), Times.Once());

            _repProviderMock.Verify(rp => rp.RemoveReputation(
                It.Is<MiunieUser>(_hasDraxId),
                It.Is<MiunieUser>(_hasSenneId),
                reason
            ), Times.Once());
        }

        [Fact]
        public async Task ShouldNotRemoveRepFromSelf()
        {
            await _profileService.RemoveReputationAsync(_data.Senne, _data.Senne, new MiunieChannel(), "reason");

            _repProviderMock.VerifyNoOtherCalls();
        }
    }
}
