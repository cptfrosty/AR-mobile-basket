using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ProgrammManager : MonoBehaviour
{
    [SerializeField] private GameObject planeMarkerPrefab;
    [SerializeField] private GameObject prefabObject;
    [SerializeField] private GameObject basketObject;
    [SerializeField] private Text textForce;

    private ARRaycastManager arRaycastManager;

    public static float force;

    void Start()
    {
        arRaycastManager = FindObjectOfType<ARRaycastManager>();
        planeMarkerPrefab.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        ShowMarker();
        //CreateObjectTapScreen();

        UpdateTextForce(); //Обновление текста с силой
    }

    void ShowMarker()
    {
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        arRaycastManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.Planes);

        if (hits.Count > 0)
        {
            planeMarkerPrefab.transform.position = hits[0].pose.position;
            planeMarkerPrefab.SetActive(true);
        }
    }

    //Нажатие на экран и создание объекта
    void CreateObjectTapScreen()
    {
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Instantiate(prefabObject, planeMarkerPrefab.transform.position, planeMarkerPrefab.transform.rotation);
        }
    }

    void UpdateTextForce()
    {
        textForce.text = string.Format("{0:f1}",force);;
    }

    public void AddBasket()
    {
        Instantiate(basketObject, planeMarkerPrefab.transform.position, planeMarkerPrefab.transform.rotation);
    }
}
