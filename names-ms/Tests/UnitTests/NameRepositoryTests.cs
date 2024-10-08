using Moq;
using Xunit;
using System.Collections.Generic;
using names_ms.Domain.Entities;
using names_ms.Infrastructure.Repositories;

public class NameRepositoryTests
{
    [Fact]
    public void GetAllNames_ReturnsAllNames()
    {
        // Arrange
        var expectedNames = new List<NameEntity>
        {
            new NameEntity { Gender = "M", Name = "Adrian" },
            new NameEntity { Gender = "F", Name = "Lucia" }
        };

        var repository = new NameRepository();

        // Act
        var result = repository.GetAllNames();

        // Assert
        Assert.Equal(expectedNames.Count, result.Count());
        Assert.Contains(result, n => n.Name == "Adrian");
        Assert.Contains(result, n => n.Name == "Lucia");
    }
}
