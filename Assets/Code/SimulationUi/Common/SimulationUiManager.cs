namespace Code.SimulationUi
{
    public class SimulationUiManager
    {
        private readonly SimulationUiFactory _factory;
        private readonly SimulationUiController _controller;

        public SimulationUiManager(SimulationUiFactory factory)
        {
            _factory = factory;
            _controller = _factory.CreateSimulationUiController();
        }

        public void IncrementPrey() => _controller.IncrementPrey();
        public void IncrementPredators() => _controller.IncrementPredators();
    }
}
