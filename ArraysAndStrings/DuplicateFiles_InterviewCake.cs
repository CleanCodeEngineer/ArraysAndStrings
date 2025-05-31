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

    // Question: Given a list of file paths and contents, return all the files that have duplicate content, not just name. Use a class FilePaths with two properties: OriginalPath and DuplicatePath.
    // Input:
    // string[] files = {
    // "/dir1/file1.txt(content1)",
    // "/dir2/file2.txt(content1)",
    // "/dir3/file3.txt(content2)",
    // "/dir4/file4.txt(content1)"
    // };

    // Output:
    // Original: /dir1/file1.txt, Duplicate: /dir2/file2.txt
    // Original: /dir1/file1.txt, Duplicate: /dir4/file4.txt
    public class FilePaths
    {
        public string OriginalPath { get; set; }
        public string DuplicatePath { get; set; }

        public FilePaths(string original, string duplicate)
        {
            OriginalPath = original;
            DuplicatePath = duplicate;
        }
    }

    public class DuplicateFileFinder
    {
        public static List<FilePaths> FindDuplicateFiles(string[] fileEntries)
        {
            var contentToPaths = new Dictionary<string, List<string>>();
            var result = new List<FilePaths>();

            foreach (var entry in fileEntries)
            {
                // Parse: "/dir1/file1.txt(content1)"
                int leftParenIndex = entry.IndexOf('(');
                int rightParenIndex = entry.IndexOf(')');

                if (leftParenIndex == -1 && rightParenIndex == -1)
                    continue;

                string filePath = entry.Substring(0, leftParenIndex);
                string content = entry.Substring(rightParenIndex + 1, rightParenIndex - leftParenIndex - 1);

                if (!contentToPaths.ContainsKey(content))
                    contentToPaths[content] = new List<string>();

                contentToPaths[content].Add(filePath);
            }

            // Build result
            foreach (var kvp in contentToPaths)
            {
                var paths = kvp.Value;
                if (paths.Count > 1)
                {
                    string original = paths[0];
                    for (int i = 1; i < paths.Count; i++)
                    {
                        result.Add(new FilePaths(original, paths[i]));
                    }
                }
            }

            return result;
        }
    }
}
