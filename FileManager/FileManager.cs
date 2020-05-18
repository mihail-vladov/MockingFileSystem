using System;
using System.IO;

namespace FileManager
{
	public class FileManager
	{
		private IFileSystem fileSystem;

		public FileManager(IFileSystem fileSystem)
        {
            if (fileSystem == null)
                throw new ArgumentNullException("fileSystem");

            this.fileSystem = fileSystem;
        }

		public void Rename(string filePath)
		{
			if (this.FileDoesNotExist(filePath))
				throw new FileNotFoundException("File was not found", filePath);

			var renamedFilePath = "renamed.file";

			if (this.FileExists(renamedFilePath))
				throw new IOException("New filename already exists: " + renamedFilePath);

			this.fileSystem.MoveFile(filePath, renamedFilePath);
		}

		private bool FileDoesNotExist(string filePath)
		{
			return !this.FileExists(filePath);
		}

		private bool FileExists(string filePath)
		{
			return this.fileSystem.FileExists(filePath);
		}
	}
}
