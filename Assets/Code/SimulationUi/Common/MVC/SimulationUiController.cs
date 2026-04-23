using Code.MVC;

namespace Code.SimulationUi
{
    public class SimulationUiController : Controller<SimulationUiView, SimulationUiModel>
    {
        protected override void OnApplyView(SimulationUiView view)
        {
            base.OnApplyView(view);
            view.Render(Model.DeadPrey, Model.DeadPredators);
        }

        public void IncrementPrey()
        {
            Model.DeadPrey++;
            View.Render(Model.DeadPrey, Model.DeadPredators);
        }

        public void IncrementPredators()
        {
            Model.DeadPredators++;
            View.Render(Model.DeadPrey, Model.DeadPredators);
        }
    }
}
