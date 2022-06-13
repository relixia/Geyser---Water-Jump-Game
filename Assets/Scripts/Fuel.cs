using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Fuel : MonoBehaviour
{
    public GameObject Player;
    public Slider FuelBar;
    public float fuelValue;
    public ScoreDisplay ScoreMechanics;
    public CameraControl Camera;
    public GameObject Restart;

    bool mouseIsNotOverUI;
   
    void FixedUpdate()
    {
        mouseIsNotOverUI = EventSystem.current.currentSelectedGameObject == null;

        if (Input.GetMouseButton(0) && mouseIsNotOverUI)
        {
            fuelValue = 0.001f;
            FuelBar.value -= fuelValue; 
        }
        if (FuelBar.value == 0)
        {
            ScoreMechanics.GetComponent<ScoreDisplay>().enabled = false;
            Camera.GetComponent<CameraControl>().enabled = false;
            Movement.ms = -5;
            Player.transform.DetachChildren();
            Restart.SetActive(true);
        }
    }
}
