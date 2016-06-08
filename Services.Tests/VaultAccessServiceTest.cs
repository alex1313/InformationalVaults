namespace Services.Tests
{
    using System;
    using System.Collections.Generic;
    using DomainModel.Definitions;
    using DomainModel.Entities;
    using Implementations;
    using Moq;
    using NUnit.Framework;
    using Providers;

    [TestFixture]
    public class VaultAccessServiceTest
    {
        private static VaultAccessService _service;
        private const string SomeString = "Some string";

        private static TimeSpan _inOpenHours;
        private static TimeSpan _outOfOpenHours;

        private static Vault _vault;
        private static User _userWithoutPermissions;
        private static User _vaultUser;

        [OneTimeSetUp]
        public static void FixtureSetUp()
        {
            var openTime = new TimeSpan(0, 8, 0, 0);
            var closeTime = new TimeSpan(0, 22, 0, 0);
            _inOpenHours = new TimeSpan(0, 14, 56, 22);
            _outOfOpenHours = new TimeSpan(0, 7, 21, 17);

            _vault = new Vault(It.IsAny<string>(), It.IsAny<string>(), openTime, closeTime);
            _userWithoutPermissions = new User(It.IsAny<string>(), SomeString, 1)
            {
                Role = new Role(RoleNames.User)
            };
            _vaultUser = new User(It.IsAny<string>(), SomeString, 1)
            {
                Role = new Role(RoleNames.User),
                Vaults = new List<Vault> { _vault }
            };
        }

        [Test]
        public void UserShouldHaveAccess()
        {
            var dateTimeMock = new Mock<IDateTimeProvider>();
            dateTimeMock.SetupGet(tp => tp.PresentTime).Returns(_inOpenHours);
            _service = new VaultAccessService(dateTimeMock.Object);

            var hasAccess = _service.IsUserHasAccess(_vaultUser, _vault);

            Assert.IsTrue(hasAccess);
        }

        [Test]
        public void AccessShouldBeDeniedBecauseUserDoesNotHaveAccessRights()
        {
            var dateTimeMock = new Mock<IDateTimeProvider>();
            dateTimeMock.SetupGet(tp => tp.PresentTime).Returns(_inOpenHours);
            _service = new VaultAccessService(dateTimeMock.Object);

            var hasAccess = _service.IsUserHasAccess(_userWithoutPermissions, _vault);

            Assert.IsFalse(hasAccess);
        }

        [Test]
        public void AccessShouldBeDeniedBecauseOutOfOpenHours()
        {
            var dateTimeMock = new Mock<IDateTimeProvider>();
            dateTimeMock.SetupGet(tp => tp.PresentTime).Returns(_outOfOpenHours);
            _service = new VaultAccessService(dateTimeMock.Object);

            var hasAccess = _service.IsUserHasAccess(_vaultUser, _vault);

            Assert.IsFalse(hasAccess);
        }
    }
}