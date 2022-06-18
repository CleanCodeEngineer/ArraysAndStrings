using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace ArraysAndStrings
{
    // Write a method that returns an array of all the duplicate files.
    // Return an array of FilePaths objects with properties for the original and duplicate paths.
    public class DuplicateFiles_InterviewCake
    {
        public class FilePaths
        {
            public string DuplicatePath { get; }
            public string OriginalPath { get; }

            public FilePaths(string duplicatePath, string originalPath)
            {
                DuplicatePath = duplicatePath;
                OriginalPath = originalPath;
            }

            public override string ToString()
            {
                return $"(original: {OriginalPath},  duplicate: {DuplicatePath})";
            }
        }

        public static IList<FilePaths> FindDuplicateFiles(string startingDirectory)
        {
            var filesSeenAlready = new Dictionary<string, FileInfo>();
            var stack = new Stack<FileSystemInfo>();
            stack.Push(new DirectoryInfo(startingDirectory));

            var duplicates = new List<FilePaths>();

            while (stack.Count > 0)
            {
                var currentInfo = stack.Pop();

                // If it's a directory, put the contents in our stack
                var currentDirectoryInfo = currentInfo as DirectoryInfo;
                if (currentDirectoryInfo != null)
                {
                    foreach (var info in currentDirectoryInfo.GetFileSystemInfos())
                    {
                        stack.Push(info);
                    }
                }

                // If it's a file
                var currentFileInfo = currentInfo as FileInfo;
                if (currentFileInfo != null)
                {
                    // Get its hash
                    var fileHash = SampleHashFile(currentFileInfo);

                    // If we've seen it before
                    if (filesSeenAlready.ContainsKey(fileHash))
                    {
                        var existingFileInfo = filesSeenAlready[fileHash];

                        if (currentFileInfo.LastWriteTime > existingFileInfo.LastWriteTime)
                        {
                            // Current file is the dupe!
                            duplicates.Add(new FilePaths(currentFileInfo.FullName, existingFileInfo.FullName));
                        }
                        else
                        {
                            // Other file is the dupe!
                            duplicates.Add(new FilePaths(existingFileInfo.FullName, currentFileInfo.FullName));

                            // But also update filesSeenAlready to have the new files's info
                            filesSeenAlready[fileHash] = currentFileInfo;
                        }
                    }
                    else
                    {
                        // Throw new files in filesSeenAlready so we can compare it later
                        filesSeenAlready[fileHash] = currentFileInfo;
                    }
                }
            }

            return duplicates;
        }

        private const int SampleSize = 4000;

        private static string SampleHashFile(FileInfo fileInfo)
        {
            long totalBytes = fileInfo.Length;

            byte[] digestBytes;
            using (var fileStream = fileInfo.OpenRead())
            {
                using (var fileReader = new BinaryReader(fileStream))
                {
                    // If the file is too short to take 3 samples, hash the entire file
                    if (totalBytes < SampleSize * 3)
                    {
                        digestBytes = fileReader.ReadBytes((int)totalBytes);
                    }
                    else
                    {
                        long numBytesBetweenSamples = (totalBytes - (SampleSize * 3)) / 2;
                        digestBytes = new byte[SampleSize * 3];

                        // Read first, middle and last bytes
                        for (int i = 0; i < 3; i++)
                        {
                            var sectionBytes = fileReader.ReadBytes(SampleSize);
                            sectionBytes.CopyTo(digestBytes, i * SampleSize);
                            fileStream.Seek(numBytesBetweenSamples, SeekOrigin.Current);
                        }
                    }
                }
            }

            using (var sha = new SHA256Managed())
            {
                var hash = sha.ComputeHash(digestBytes);
                return BitConverter.ToString(hash).Replace("-", string.Empty);
            }
        }
    }
}
