namespace CustomWebAPI.Services
{
    // Interfaces
    public interface ISingletonService { Guid GetGuid(); }
    public interface IScopedService { Guid GetGuid(); }
    public interface ITransientService { Guid GetGuid(); }
    public class SingletonService : ISingletonService
    {
        private readonly Guid _guid;
        public SingletonService()
        {
            _guid = Guid.NewGuid();
        }
        public Guid GetGuid()
        {
            return _guid;
        }
    }

    public class ScopedService : IScopedService
    {
        private readonly Guid _guid;
        public ScopedService()
        {
            _guid = Guid.NewGuid();
        }
        public Guid GetGuid()
        {
            return _guid;
        }
    }

    public class TransientService : ITransientService
    {
        private readonly Guid _guid;
        public TransientService()
        {
            _guid = Guid.NewGuid();
        }
        public Guid GetGuid()
        {
            return _guid;
        }
    }
}
