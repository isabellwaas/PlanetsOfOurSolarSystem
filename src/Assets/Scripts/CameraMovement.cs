using UnityEngine;
using System.Collections.Generic;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private GameObject solarSystem;
    private int destinationPlanetIndex;
    private int zoomLevel;
    private Dictionary<int, float> zoomDictionary;

    //Moving camera to first planet and setting zoomlevels when starting the graphic
    void Start()
    {
        destinationPlanetIndex = 0;
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, solarSystem.transform.GetChild(destinationPlanetIndex).position.z);
        
        zoomDictionary = new Dictionary<int, float>
        {
            {0, 25f},
            {1, 15f},
            {2, 5f},
            {3, 2.5f},
            {4, 0f},
            {5, -0.25f}
        };
        
        zoomLevel = 0;
        UpdateZoomValueOnUI();
    }

    //Moving camera with arrow keys
    void Update()
    {
        //Moving camera from planet to planet with left and right arrow keys
        if(gameObject.transform.position.z != solarSystem.transform.GetChild(destinationPlanetIndex).position.z)
        {
            if(gameObject.transform.position.z < solarSystem.transform.GetChild(destinationPlanetIndex).position.z) MoveCameraOnZAxis(1);
            else MoveCameraOnZAxis(-1);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && destinationPlanetIndex != solarSystem.transform.childCount - 1)
        {
            destinationPlanetIndex++;
            UpdatePlanetInformationOnUI();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && destinationPlanetIndex != 0)
        {
            destinationPlanetIndex--;
            UpdatePlanetInformationOnUI();
        }
        
        
        //Zooming camera to current planet with up and down arrow keys
        if(gameObject.transform.position.x != zoomDictionary[zoomLevel])
        {
            if(gameObject.transform.position.x < zoomDictionary[zoomLevel]) MoveCameraOnXAxis(0.25f);
            else MoveCameraOnXAxis(-0.25f);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && zoomLevel != zoomDictionary.Count - 1)
        {
            zoomLevel++;
            UpdateZoomValueOnUI();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && zoomLevel != 0)
        {
            zoomLevel--;
            UpdateZoomValueOnUI();
        }
    }

    //Updating planet information on UI
    void UpdatePlanetInformationOnUI()
    {
        string name = solarSystem.transform.GetChild(destinationPlanetIndex).name;
        UIController.instance.UpdatePlanetText(name, PlanetData.instance.GetPlanetSize(name));
    }
    
    //Updating zoomlevel on UI
    void UpdateZoomValueOnUI()
    {
        UIController.instance.UpdateZoomValue(zoomLevel.ToString());
    }

    //Moving camera a certain range to the right if range is positive and to the left if range is negative
    void MoveCameraOnZAxis(int range)
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z+range);
    }
    
    //Moving camera a certain range to the front if range is positive and to the back if range is negative
    void MoveCameraOnXAxis(float range)
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x+range, gameObject.transform.position.y, gameObject.transform.position.z);
    }

    //Zooming out if camera is so close to a planet that it is colliding with it
    private void OnTriggerEnter(Collider other)
    {
        gameObject.transform.position = new Vector3(zoomDictionary[--zoomLevel], gameObject.transform.position.y, gameObject.transform.position.z);
        UpdateZoomValueOnUI();
    }
    
    //Zooming out if camera is still colliding with the planet after the first collision
    private void OnTriggerStay(Collider other)
    {
        gameObject.transform.position = new Vector3(zoomDictionary[--zoomLevel], gameObject.transform.position.y, gameObject.transform.position.z);
        UpdateZoomValueOnUI();
    }
}
