using UnityEngine;
using UnityEngine.UI;
public class Bar : MonoBehaviour
{
    [SerializeField] private Image bar;
    [SerializeField] private float maxCurrentFillBar = 1;
    [SerializeField] private static float CurrentFillBar = 1;
    [SerializeField] private float currentViewBar;
    private void Update()
    {
        currentViewBar = bar.fillAmount;
        bar.fillAmount = CurrentFillBar;
        if (CurrentFillBar > maxCurrentFillBar )
        {
            CurrentFillBar = maxCurrentFillBar;
        }
        if (CurrentFillBar < 0)
        {
            CurrentFillBar = 0;
        }
    }

}
