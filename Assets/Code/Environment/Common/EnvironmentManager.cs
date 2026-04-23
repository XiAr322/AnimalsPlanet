namespace Code.Environment
{
    public class EnvironmentManager
    {
        private readonly EnvironmentFactory _factory;

        public EnvironmentManager(EnvironmentFactory factory)
        {
            _factory = factory;
            CreateEnvironment();
        }

        private void CreateEnvironment()
        {
            _factory.CreateEnvironment();
        }
    }
}
