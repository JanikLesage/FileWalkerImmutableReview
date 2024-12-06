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
            IComponent agrumeFolder = fileSystemFacade.CreateFolder("agrumes_folder");
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
                fileSystemFacade.CreateFile("text_poire.txt", 10, "Poire"),
                agrumeFolder
            );
            fileSystemFacade.AddChildren(agrumeFolder,
                fileSystemFacade.CreateFile("text_orange.txt", 10, "Orange"),
                fileSystemFacade.CreateFile("text_citron.txt", 10, "Citron"),
                fileSystemFacade.CreateFile("text_pamplemousse.txt", 10, "Pamplemousse")
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
            IComponent agrumeFolder = fileSystemFacade.CreateFolder("agrumes_folder");
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
                fileSystemFacade.CreateFile("text_poire.txt", 10, "Poire"),
                agrumeFolder
            );
            fileSystemFacade.AddChildren(agrumeFolder,
                fileSystemFacade.CreateFile("text_orange.txt", 10, "Orange"),
                fileSystemFacade.CreateFile("text_citron.txt", 10, "Citron"),
                fileSystemFacade.CreateFile("text_pamplemousse.txt", 10, "Pamplemousse")
            );
            //Act
            IComponent file = fileSystemFacade.GetComponentByPath(fruitFolder, "text_wrong.txt");
            //Assert
            Assert.IsNull(file);
        }
        
        [Test]
        public void GetFolderFromRootButWrongFolderWhereFolderIsEmpty()
        {
            //Arrange
            FileSystemFacade fileSystemFacade = new FileSystemFacade();
            IComponent fruitFolder = fileSystemFacade.CreateFolder("fruit_folder");
            IComponent agrumeFolder = fileSystemFacade.CreateFolder("agrumes_folder");
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
                fileSystemFacade.CreateFile("text_poire.txt", 10, "Poire"),
                agrumeFolder
            );
            //Act & Assert
            Assert.Throws<KeyNotFoundException>(() => fileSystemFacade.GetComponentByPath(agrumeFolder, "banane.txt"));
        }
        
        [Test]
        public void GetFolderFromRootButWrongFolderWhereFolderIsNotEmpty()
        {
            //Arrange
            FileSystemFacade fileSystemFacade = new FileSystemFacade();
            IComponent fruitFolder = fileSystemFacade.CreateFolder("fruit_folder");
            IComponent agrumeFolder = fileSystemFacade.CreateFolder("agrumes_folder");
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
                fileSystemFacade.CreateFile("text_poire.txt", 10, "Poire"),
                agrumeFolder
            );
            fileSystemFacade.AddChildren(agrumeFolder,
                fileSystemFacade.CreateFile("text_orange.txt", 10, "Orange"),
                fileSystemFacade.CreateFile("text_citron.txt", 10, "Citron"),
                fileSystemFacade.CreateFile("text_pamplemousse.txt", 10, "Pamplemousse")
            );
            
            //Act
            IComponent file = fileSystemFacade.GetComponentByPath(agrumeFolder, "text_banane.txt");
            //Assert
            Assert.IsNull(file);
        }
        
        [Test]
        public void RenameFile()
        {
            //Arrange
            FileSystemFacade fileSystemFacade = new FileSystemFacade();
            IComponent fruitFolder = fileSystemFacade.CreateFolder("fruit_folder");
            IComponent agrumeFolder = fileSystemFacade.CreateFolder("agrumes_folder");
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
                fileSystemFacade.CreateFile("text_poire.txt", 10, "Poire"),
                agrumeFolder
            );
            fileSystemFacade.AddChildren(agrumeFolder,
                fileSystemFacade.CreateFile("text_orange.txt", 10, "Orange"),
                fileSystemFacade.CreateFile("text_citron.txt", 10, "Citron"),
                fileSystemFacade.CreateFile("text_pamplemousse.txt", 10, "Pamplemousse")
            );
            //Act
            IComponent file = fileSystemFacade.GetComponentByPath(fruitFolder, "text_banane.txt");
            fileSystemFacade.Rename(file, "text_banane_renamed.txt");
            IComponent renamedFile = fileSystemFacade.GetComponentByPath(fruitFolder, "text_banane_renamed.txt");
            //Assert
            Assert.IsNull(fileSystemFacade.GetComponentByPath(fruitFolder, "text_banane.txt"));
            Assert.IsNotNull(renamedFile);
            Assert.AreEqual("text_banane_renamed.txt", renamedFile.Name);
        }
        
        [Test]
        public void RenameFolderNotAsRoot()
        {
            //Arrange
            FileSystemFacade fileSystemFacade = new FileSystemFacade();
            IComponent fruitFolder = fileSystemFacade.CreateFolder("fruit_folder");
            IComponent agrumeFolder = fileSystemFacade.CreateFolder("agrumes_folder");
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
                fileSystemFacade.CreateFile("text_poire.txt", 10, "Poire"),
                agrumeFolder
            );
            fileSystemFacade.AddChildren(agrumeFolder,
                fileSystemFacade.CreateFile("text_orange.txt", 10, "Orange"),
                fileSystemFacade.CreateFile("text_citron.txt", 10, "Citron"),
                fileSystemFacade.CreateFile("text_pamplemousse.txt", 10, "Pamplemousse"),
                fileSystemFacade.CreateFolder("a_folder")
            );
            fileSystemFacade.AddChildren(fileSystemFacade.GetComponentByPath(agrumeFolder, "a_folder"),
                fileSystemFacade.CreateFile("text_orange.txt", 10, "Orange"),
                fileSystemFacade.CreateFile("text_citron.txt", 10, "Citron"),
                fileSystemFacade.CreateFile("text_pamplemousse.txt", 10, "Pamplemousse")
            );
            
            //Act
            IComponent folder = fileSystemFacade.GetComponentByPath(fruitFolder, agrumeFolder.Name);
            fileSystemFacade.Rename(folder, "agrumes_folder_renamed");
            IComponent renamedFolder = fileSystemFacade.GetComponentByPath(fruitFolder, "agrumes_folder_renamed");
            //Assert
            Assert.IsNotNull(renamedFolder);
            Assert.That(renamedFolder.Name, Is.EqualTo("agrumes_folder_renamed"));
            
        }
        
        [Test]
        public void RenameFolderAsRoot()
        {
            //Arrange
            FileSystemFacade fileSystemFacade = new FileSystemFacade();
            IComponent fruitFolder = fileSystemFacade.CreateFolder("fruit_folder");
            IComponent agrumeFolder = fileSystemFacade.CreateFolder("agrumes_folder");
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
                fileSystemFacade.CreateFile("text_poire.txt", 10, "Poire"),
                agrumeFolder
            );
            fileSystemFacade.AddChildren(agrumeFolder,
                fileSystemFacade.CreateFile("text_orange.txt", 10, "Orange"),
                fileSystemFacade.CreateFile("text_citron.txt", 10, "Citron"),
                fileSystemFacade.CreateFile("text_pamplemousse.txt", 10, "Pamplemousse")
            );
            //Act
            IComponent folder = fileSystemFacade.GetComponentByPath(fruitFolder);
            fileSystemFacade.Rename(folder, "fruit_folder_renamed");
            IComponent renamedFolder = fileSystemFacade.GetComponentByPath(fruitFolder);
            //Assert
            Assert.IsNotNull(renamedFolder);
            Assert.That(renamedFolder.Name, Is.EqualTo("fruit_folder_renamed"));
        }

        [Test] public void RenameFileAsNull()
        {
                        //Arrange
            FileSystemFacade fileSystemFacade = new FileSystemFacade();
            IComponent fruitFolder = fileSystemFacade.CreateFolder("fruit_folder");
            IComponent agrumeFolder = fileSystemFacade.CreateFolder("agrumes_folder");
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
                fileSystemFacade.CreateFile("text_poire.txt", 10, "Poire"),
                agrumeFolder
            );
            fileSystemFacade.AddChildren(agrumeFolder,
                fileSystemFacade.CreateFile("text_orange.txt", 10, "Orange"),
                fileSystemFacade.CreateFile("text_citron.txt", 10, "Citron"),
                fileSystemFacade.CreateFile("text_pamplemousse.txt", 10, "Pamplemousse")
            );
            //Act
            IComponent file = fileSystemFacade.GetComponentByPath(fruitFolder, "text_banane.txt");
            fileSystemFacade.Rename(file, null);
            IComponent renamedFile = fileSystemFacade.GetComponentByPath(fruitFolder, "text_banane_renamed.txt");
            //Assert
            Assert.IsNull(fileSystemFacade.GetComponentByPath(fruitFolder, "text_banane.txt"));
            Assert.IsNull(renamedFile);
                
        }
    }
}