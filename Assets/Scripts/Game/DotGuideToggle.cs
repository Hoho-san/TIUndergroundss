using UnityEngine;
using UnityEngine.UI;

public class DotGuideToggle : MonoBehaviour
{
    public Toggle dotToggle;

    private void Start()
    {
        // Load the previous state from PlayerPrefs
        bool dotState = PlayerPrefs.GetInt("DotState", 1) == 1; // Default to true if not found

        // Set the initial state of the Dot UI component
        dotToggle.isOn = dotState;
    }

    public void ToggleDot()
    {
        // Save the current state to PlayerPrefs
        PlayerPrefs.SetInt("DotState", dotToggle.isOn ? 1 : 0);
        PlayerPrefs.Save();
    }
}
