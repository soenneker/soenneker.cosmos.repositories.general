using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Cosmos.Repositories.General.Tests;

[Collection("Collection")]
public class GeneralRepositoryTests : FixturedUnitTest
{
    public GeneralRepositoryTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
    }

    [Fact]
    public void Default()
    {

    }
}
