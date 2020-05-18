using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using Telerik.JustMock;

namespace FileManager.Tests
{
	[TestClass]
	public class RenameTests
	{
		private IFileSystem fileSystem;
		private FileManager fileManager;

		[TestInitialize]
		public void Initialize()
		{
			this.fileSystem = Mock.Create<IFileSystem>();
			this.fileManager = new FileManager(this.fileSystem);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void Constructor_Throws_WhenNullFileSystemIsPassed()
		{
			var manager = new FileManager(null);
		}

		[TestMethod]
		[ExpectedException(typeof(FileNotFoundException))]
		public void Rename_Throws_WhenTheSpecifiedFileDoesNotExist()
		{
			Mock.Arrange(() => this.fileSystem.FileExists("file.to.rename")).Returns(false);
		
			this.fileManager.Rename("file.to.rename");
		}

		[TestMethod]
		[ExpectedException(typeof(IOException))]
		public void Rename_Throws_WhenTheTheNewFileNameExists()
		{
			Mock.Arrange(() => this.fileSystem.FileExists("file.to.rename")).Returns(true);
			Mock.Arrange(() => this.fileSystem.FileExists("renamed.file")).Returns(true);

			this.fileManager.Rename("file.to.rename");
		}

		[TestMethod]
		public void Rename_RenamesTheInputFile_WhenInputExistsAndNewFileNameDoesNotExist()
		{
			Mock.Arrange(() => this.fileSystem.FileExists("file.to.rename")).Returns(true);
			Mock.Arrange(() => this.fileSystem.FileExists("renamed.file")).Returns(false);
			
			this.fileManager.Rename("file.to.rename");

			Mock.Assert(() => this.fileSystem.MoveFile("file.to.rename", "renamed.file"), Occurs.Once());
		}
	}
}
