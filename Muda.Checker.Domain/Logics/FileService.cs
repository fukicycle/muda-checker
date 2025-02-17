using Muda.Checker.Domain.Entities;
using Muda.Checker.Domain.ValueObjects;
using System.Collections.Immutable;

namespace Muda.Checker.Domain.Logics
{
    public static class FileService
    {
        public static async Task<ImmutableList<Result>> GetAllFilesAsync(ImmutableList<string> directories, TargetYear targetYear)
        {
            return await Task.Run(() =>
            {
                ImmutableList<Result> targetFiles = [];
                foreach (var directory in directories)
                {
                    string[] files = Directory.GetFiles(directory);
                    foreach (var file in files)
                    {
                        try
                        {
                            FileInfo fileInfo = new FileInfo(file);
                            if (fileInfo.LastAccessTime.AddYears(targetYear.Value) < DateTime.Today)
                            {
                                Result result = new Result(fileInfo.FullName, fileInfo.LastAccessTime);
                                targetFiles = targetFiles.Add(result);
                            }
                        }
                        catch (Exception)
                        {
                            continue;
                        }
                    }
                }
                return targetFiles;
            });
        }
    }
}
