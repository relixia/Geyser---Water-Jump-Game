using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreDisplay : MonoBehaviour
{
    public GameObject Player;
    public GameObject scoreDisplay;
    public float scoreY;
    void FixedUpdate()
    {
        Vector3 lastPosition = Player.transform.position;
        scoreY = lastPosition.y;
        int a = (int)scoreY;
        scoreDisplay.GetComponent<Text>().text = "" + a;
    }
}
