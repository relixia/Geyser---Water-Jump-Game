using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapToStart : MonoBehaviour
{
    public static bool isGameStarted;
    public GameObject StartingText;
    void Start()
    {
        isGameStarted = false;

    }
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            isGameStarted = true;
            Destroy(StartingText);

        }

    }

}
