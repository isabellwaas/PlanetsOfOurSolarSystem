using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    public static UIController instance { get; private set; } = null;
    [SerializeField] private TextMeshProUGUI planetName;
    [SerializeField] private TextMeshProUGUI planetSize;
    [SerializeField] private TextMeshProUGUI zoomValue;

    //Making sure that there's always only one instance of UIController
    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(this);
    }

    //Quitting graphic by clicking ESC
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit();
    }

    //Showing name and information on UI
    public void UpdatePlanetText(string name, string information)
    {
        planetName.text = name;
        planetSize.text = information;
    }
    
    //Showing zoomlevel on UI
    public void UpdateZoomValue(string value)
    {
        zoomValue.text = value;
    }
}
