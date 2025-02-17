using Muda.Checker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muda.Checker.Domain.Logics
{
    public static class CsvService
    {
        public static async Task SaveAsync(ImmutableList<Result> results)
        {
            string[] lines = results.Select(a => $"\"{a.FileName}\",\"{a.LastAccessTime:yyyy-MM-dd HH:mm:ss}\"").ToArray();
            string path = GetPath(1);
            await File.WriteAllTextAsync(path, string.Join(Environment.NewLine, lines));
        }

        private static string GetPath(int rev)
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), $"target{rev}.txt");
            if (Path.Exists(path))
            {
                return GetPath(rev + 1);
            }
            return path;
        }
    }
}
