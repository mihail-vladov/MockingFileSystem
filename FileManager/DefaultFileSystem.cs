using System.IO;

namespace FileManager
{
	public sealed class DefaultFileSystem : IFileSystem
	{
		public bool FileExists(string path)
		{
			return File.Exists(path);
		}

		public void MoveFile(string filePath, string newFilePath)
		{
			File.Move(filePath, newFilePath);
		}
	}
}