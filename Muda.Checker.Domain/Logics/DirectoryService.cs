using Muda.Checker.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muda.Checker.Domain.Logics
{
    public static class DirectoryService
    {
        public static async Task<ImmutableList<string>> GetAllDirectoriesAsync(TargetDirectory rootDirectory)
        {
            return await Task.Run(async () =>
            {
                ImmutableList<string> directories = [];
                var children = Directory.GetDirectories(rootDirectory.Value);
                if (children.Any())
                {
                    foreach (var child in children)
                    {
                        directories = directories.AddRange(await GetAllDirectoriesAsync(new TargetDirectory(child)));
                    }
                }
                return directories;
            });
        }
    }
}
