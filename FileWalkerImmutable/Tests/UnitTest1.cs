using NUnit.Framework;
using FileWalkerImmutable.FileSystem;
using System.Collections.Immutable;

namespace Tests
{
    public class FileSystemTests
    {
        private FileSystem _fileSystem;
        private IComponent _component;
        private IComponentObserver _observer;

        [SetUp]
        public void Setup()
        {
            // Initialize the FileSystem and other necessary objects
            var initialMap = ImmutableDictionary<int, ImmutableList<IComponent>>.Empty;
            var initialObservers = ImmutableDictionary<int, ImmutableList<IComponentObserver>>.Empty;
            _fileSystem = new FileSystem(initialMap, initialObservers);

            // Mock or create instances of IComponent and IComponentObserver
            _component = new MockComponent(1, "TestComponent");
            _observer = new MockComponentObserver();
        }

        [Test]
        public void Rename_ShouldUpdateComponentName()
        {
            // Arrange
            var newName = "NewName";

            // Act
            var updatedFileSystem = _fileSystem.Rename(_component, newName);

            // Assert
            var renamedComponent = updatedFileSystem.GetComponentById(_component.ID);
            Assert.AreEqual(newName, renamedComponent.Name);
        }

        [Test]
        public void Delete_ShouldRemoveComponent()
        {
            // Act
            var updatedFileSystem = _fileSystem.Delete(_component);

            // Assert
            var deletedComponent = updatedFileSystem.GetComponentById(_component.ID);
            Assert.IsNull(deletedComponent);
        }

        [Test]
        public void Attach_ShouldAddObserver()
        {
            // Act
            var updatedFileSystem = _fileSystem.Attach(_component, _observer);

            // Assert
            var observers = updatedFileSystem.GetObserversById(_component.ID);
            Assert.Contains(_observer, observers);
        }

        [Test]
        public void Detach_ShouldRemoveObserver()
        {
            // Arrange
            var fileSystemWithObserver = _fileSystem.Attach(_component, _observer);

            // Act
            var updatedFileSystem = fileSystemWithObserver.Detach(_component, _observer);

            // Assert
            var observers = updatedFileSystem.GetObserversById(_component.ID);
            Assert.IsFalse(observers.Contains(_observer));
        }
    }

    // Mock implementations for IComponent and IComponentObserver
    public class MockComponent : IComponent
    {
        public int ID { get; }
        public string Name { get; private set; }

        public MockComponent(int id, string name)
        {
            ID = id;
            Name = name;
        }

        public IComponent Rename(string newName)
        {
            return new MockComponent(ID, newName);
        }
    }

    public class MockComponentObserver : IComponentObserver
    {
        // Implement necessary methods for IComponentObserver
    }
}