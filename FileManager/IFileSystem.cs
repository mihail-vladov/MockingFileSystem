

namespace FileManager
{
	public interface IFileSystem
	{
		bool FileExists(string path);

		void MoveFile(string filePath, string newFilePath);
	}
}