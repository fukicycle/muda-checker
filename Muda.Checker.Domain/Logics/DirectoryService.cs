using Muda.Checker.Domain.ValueObjects;
using System.Collections.Immutable;

namespace Muda.Checker.Domain.Logics
{
    public static class DirectoryService
    {
        public static async Task<ImmutableList<string>> GetAllDirectoriesAsync(TargetDirectory rootDirectory)
        {
            return await Task.Run(async () =>
            {
                ImmutableList<string> children = Directory.GetDirectories(rootDirectory.Value).ToImmutableList();
                if (children.Any())
                {
                    foreach (var child in children)
                    {
                        children = children.AddRange(await GetAllDirectoriesAsync(new TargetDirectory(child)));
                    }
                }
                return children;
            });
        }
    }
}
