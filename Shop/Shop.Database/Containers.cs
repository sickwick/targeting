using FakeLibrary.CopiedModels;
using Shop.Database.Interfaces;
using Unity;

namespace Shop.Database
{
    public class Containers
    {
        private readonly UnityContainer _unityContainer;

        public Containers()
        {
            _unityContainer = new UnityContainer();
        }

        public UnityContainer GetContainers()
        {
            return _unityContainer;
        }
        
        
    }
}