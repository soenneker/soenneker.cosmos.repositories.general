using Soenneker.Tests.HostedUnit;

namespace Soenneker.Cosmos.Repositories.General.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public class GeneralRepositoryTests : HostedUnitTest
{
    public GeneralRepositoryTests(Host host) : base(host)
    {
    }

    [Test]
    public void Default()
    {

    }
}
