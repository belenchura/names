using Moq;
using names_ms.Application.Dtos;
using names_ms.Application.Interfaces;
using names_ms.Application.Services;
using names_ms.Domain.Entities;
using names_ms.Domain.Filters;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace names_ms.Tests.UnitTests
{
    public class NameServiceTests
    {
        private readonly Mock<INameRepository> _nameRepositoryMock;
        private readonly Mock<IEnumerable<IFilterStrategy>> _filterStrategiesMock;
        private readonly INameService _nameService;

        public NameServiceTests()
        {
            _nameRepositoryMock = new Mock<INameRepository>();
            _filterStrategiesMock = new Mock<IEnumerable<IFilterStrategy>>();
            _nameService = new NameService( _filterStrategiesMock.Object, _nameRepositoryMock.Object);
        }

        [Fact]
        public void GetNames_ReturnsFilteredNamesByGender()
        {
            // Arrange
            var names = new List<NameEntity>
            {
                new NameEntity { Gender = "M", Name = "Adrian" },
                new NameEntity { Gender = "F", Name = "Lucia" },
                new NameEntity { Gender = "M", Name = "Pablo" }
            };

            _nameRepositoryMock.Setup(repo => repo.GetAllNames()).Returns(names);

            var filterParameters = new NameFilterParameters { Gender = "M" };

            var genderFilterMock = new Mock<IFilterStrategy>();
            genderFilterMock.Setup(f => f.IsApplicable(filterParameters)).Returns(true);
            genderFilterMock.Setup(f => f.Apply(It.IsAny<IEnumerable<NameEntity>>(), filterParameters))
                            .Returns((IEnumerable<NameEntity> entities, NameFilterParameters parameters) =>
                                entities.Where(n => n.Gender.Equals(parameters.Gender, StringComparison.OrdinalIgnoreCase)));

            var filters = new List<IFilterStrategy> { genderFilterMock.Object };

            var result = _nameService.GetNames(filterParameters);

            Assert.Equal(2, result.Count());
            Assert.Contains(result, n => n == "Adrian");
            Assert.Contains(result, n => n == "Pablo");
        }

        [Fact]
        public void GetNames_ReturnsEmptyWhenNoNamesMatchGenderFilter()
        {
            var names = new List<NameEntity>
            {
                new NameEntity { Gender = "F", Name = "Lucia" }
            };

            _nameRepositoryMock.Setup(repo => repo.GetAllNames()).Returns(names);

            var filterParameters = new NameFilterParameters { Gender = "M" };

            var genderFilterMock = new Mock<IFilterStrategy>();
            genderFilterMock.Setup(f => f.IsApplicable(filterParameters)).Returns(true);
            genderFilterMock.Setup(f => f.Apply(It.IsAny<IEnumerable<NameEntity>>(), filterParameters)).Returns(new List<NameEntity>());

            _filterStrategiesMock.Setup(f => f).Returns(new[] { genderFilterMock.Object });

            var result = _nameService.GetNames(filterParameters);

            Assert.Empty(result);
        }

        [Fact]
        public void GetNames_ReturnsFilteredNamesByNameStartsWith()
        {
            var names = new List<NameEntity>
            {
                new NameEntity { Gender = "M", Name = "Adrian" },
                new NameEntity { Gender = "F", Name = "Lucia" },
                new NameEntity { Gender = "M", Name = "Pablo" }
            };

            _nameRepositoryMock.Setup(repo => repo.GetAllNames()).Returns(names);

            var filterParameters = new NameFilterParameters { NameStartsWith = "A" };

            var nameStartsWithFilterMock = new Mock<IFilterStrategy>();
            nameStartsWithFilterMock.Setup(f => f.IsApplicable(filterParameters)).Returns(true);
            nameStartsWithFilterMock.Setup(f => f.Apply(It.IsAny<IEnumerable<NameEntity>>(), filterParameters)).Returns(new List<NameEntity>
            {
                new NameEntity { Gender = "M", Name = "Adrian" }
            });

            _filterStrategiesMock.Setup(f => f).Returns(new[] { nameStartsWithFilterMock.Object });

            var result = _nameService.GetNames(filterParameters);

            Assert.Single(result);
            Assert.Contains(result, n => n == "Adrian");
        }
    }
}
