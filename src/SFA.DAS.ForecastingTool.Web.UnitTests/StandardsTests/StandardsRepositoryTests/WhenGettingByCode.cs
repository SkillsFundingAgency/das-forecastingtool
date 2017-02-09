﻿using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using SFA.DAS.ForecastingTool.Core.Models;
using SFA.DAS.ForecastingTool.Infrastructure.Services;
using SFA.DAS.ForecastingTool.Web.Infrastructure.FileSystem;
using SFA.DAS.ForecastingTool.Web.Standards;

namespace SFA.DAS.ForecastingTool.Web.UnitTests.StandardsTests.StandardsRepositoryTests
{
    public class WhenGettingByCode
    {
        private Mock<IFileInfo> _standardsFileInfo;
        private Mock<IFileSystem> _fileSystem;
        private ApprenticeshipRepository _repo;
        private Mock<IGetApprenticeship> _getStandard;

        [SetUp]
        public void Arrange()
        {
            var firstStandard = new Apprenticeship
            {
                Code = "11",
                Name = "Apprenticeship 11",
                Price = 24000,
                Duration = 12
            };
            var secondStandard = new Apprenticeship
            {
                Code = "22",
                Name = "Apprenticeship 22",
                Price = 12000,
                Duration = 6
            };

            _getStandard = new Mock<IGetApprenticeship>();
            _getStandard.Setup(x => x.GetByCode("11")).Returns(firstStandard);
            _getStandard.Setup(x => x.GetByCode("22")).Returns(secondStandard);

            _repo = new ApprenticeshipRepository(_getStandard.Object);
        }

        [TestCase("11", "Apprenticeship 11", 24000, 12)]
        [TestCase("22", "Apprenticeship 22", 12000, 6)]
        public async Task ThenItShouldReturnCorrectStandard(string code, string name, int price, int duration)
        {
            // Act
            var actual = await _repo.GetByCodeAsync(code);

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(code, actual.Code);
            Assert.AreEqual(name, actual.Name);
            Assert.AreEqual(price, actual.Price);
            Assert.AreEqual(duration, actual.Duration);
        }

        [Test]
        public async Task ThenItShouldReturnNullIfNoStandardWithCode()
        {
            // Act
            var actual = await _repo.GetByCodeAsync("33");

            // Assert
            Assert.IsNull(actual);
        }
    }
}
