using System;

namespace TestApp.Interfaces.Entities
{
    public interface ITestAppEntity
    {
        Guid UniqueKey { get; }

        string Name { get; }
    }
}
