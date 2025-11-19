using UnityEngine;

public class TwoPanelNavigation : MonoBehaviour
{
    [Header("Panels")]
    public GameObject panelA;
    public GameObject panelB;

    void Start()
    {
        ShowPanelA(); // start with Panel A visible
    }

    // Show Panel A
    public void ShowPanelA()
    {
        panelA.SetActive(true);
        panelB.SetActive(false);
    }

    // Show Panel B
    public void ShowPanelB()
    {
        panelA.SetActive(false);
        panelB.SetActive(true);
    }
}
