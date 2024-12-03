using System;
using System.Collections.Immutable;
using NUnit.Framework;
using FileWalkerImmutable.Facade;
using FileWalkerImmutable.Components;

namespace FileWalkerImmutableTest
{
    //Test to get the file or the folder
    [TestFixture]
    public class UnitTest1
    {
        [SetUp]
        public void Prepare()
        {
        }
        [Test]
        public void GetFileFromRoot()
        {
            //Arrange
            FileSystemFacade fileSystemFacade = new FileSystemFacade();
            IComponent fruitFolder = fileSystemFacade.CreateFolder("fruit_folder");
            fileSystemFacade.AddChildren(fruitFolder,
                fileSystemFacade.CreateFile("text_banane.txt", 10, "Banane"),
                fileSystemFacade.CreateFile("text_pomme.txt", 10, "Pomme"),
                fileSystemFacade.CreateFile("text_cerise.txt", 10, "Cerise"),
                fileSystemFacade.CreateFile("text_raisin.txt", 10, "Raisin"),
                fileSystemFacade.CreateFile("text_fraise.txt", 10, "Fraise"),
                fileSystemFacade.CreateFile("text_melon.txt", 10, "Melon"),
                fileSystemFacade.CreateFile("text_ananas.txt", 10, "Ananas"),
                fileSystemFacade.CreateFile("text_kiwi.txt", 10, "Kiwi"),
                fileSystemFacade.CreateFile("text_mangue.txt", 10, "Mangue"),
                fileSystemFacade.CreateFile("text_pasteque.txt", 10, "Pasteque"),
                fileSystemFacade.CreateFile("text_poire.txt", 10, "Poire")
            );
            // Act
            IComponent file = fileSystemFacade.GetComponentByPath(fruitFolder, "text_banane.txt");

            // Assert
            Assert.IsNotNull(file);
            Assert.AreEqual("text_banane.txt", file.Name);
        }

        [Test]
        public void GetFolderFromRootButWrongFile()
        {
            //Arrange
            FileSystemFacade fileSystemFacade = new FileSystemFacade();
            IComponent fruitFolder = fileSystemFacade.CreateFolder("fruit_folder");
            fileSystemFacade.AddChildren(fruitFolder,
                fileSystemFacade.CreateFile("text_banane.txt", 10, "Banane"),
                fileSystemFacade.CreateFile("text_pomme.txt", 10, "Pomme"),
                fileSystemFacade.CreateFile("text_cerise.txt", 10, "Cerise"),
                fileSystemFacade.CreateFile("text_raisin.txt", 10, "Raisin"),
                fileSystemFacade.CreateFile("text_fraise.txt", 10, "Fraise"),
                fileSystemFacade.CreateFile("text_melon.txt", 10, "Melon"),
                fileSystemFacade.CreateFile("text_ananas.txt", 10, "Ananas"),
                fileSystemFacade.CreateFile("text_kiwi.txt", 10, "Kiwi"),
                fileSystemFacade.CreateFile("text_mangue.txt", 10, "Mangue"),
                fileSystemFacade.CreateFile("text_pasteque.txt", 10, "Pasteque"),
                fileSystemFacade.CreateFile("text_poire.txt", 10, "Poire")
            );
            //Act
            IComponent file = fileSystemFacade.GetComponentByPath(fruitFolder, "banane.txt");
            //Assert
            // Should trigger an assertion failure
            Assert.Throws()
        }
        [Test]
        public void GetFolderFromRootButNullFile()
        {
            //Arrange
            FileSystemFacade fileSystemFacade = new FileSystemFacade();
            IComponent fruitFolder = fileSystemFacade.CreateFolder("fruit_folder");
            fileSystemFacade.AddChildren(fruitFolder,
                fileSystemFacade.CreateFile("text_banane.txt", 10, "Banane"),
                fileSystemFacade.CreateFile("text_pomme.txt", 10, "Pomme"),
                fileSystemFacade.CreateFile("text_cerise.txt", 10, "Cerise"),
                fileSystemFacade.CreateFile("text_raisin.txt", 10, "Raisin"),
                fileSystemFacade.CreateFile("text_fraise.txt", 10, "Fraise"),
                fileSystemFacade.CreateFile("text_melon.txt", 10, "Melon"),
                fileSystemFacade.CreateFile("text_ananas.txt", 10, "Ananas"),
                fileSystemFacade.CreateFile("text_kiwi.txt", 10, "Kiwi"),
                fileSystemFacade.CreateFile("text_mangue.txt", 10, "Mangue"),
                fileSystemFacade.CreateFile("text_pasteque.txt", 10, "Pasteque"),
                fileSystemFacade.CreateFile("text_poire.txt", 10, "Poire")
            );
            //Act
            IComponent file = fileSystemFacade.GetComponentByPath(fruitFolder, null);
            //Assert
            Assert.IsNotNull(file);
            Assert.Throws()
        }
    }
}