using Code.MVC;
using TMPro;
using UnityEngine;

namespace Code.SimulationUi
{
    public class SimulationUiView : View<SimulationUiModel>
    {
        [SerializeField] private TMP_Text _preyText;
        [SerializeField] private TMP_Text _predatorText;

        public void Render(int deadPrey, int deadPredators)
        {
            _preyText.text = $"Dead Prey: {deadPrey}";
            _predatorText.text = $"Dead Predators: {deadPredators}";
        }
    }
}
