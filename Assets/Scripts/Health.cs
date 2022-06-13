using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    public GameObject Player;
    public ScoreDisplay ScoreMechanics;
    public CameraControl Camera;
    public GameObject FuelBar;
    public GameObject Restart;

    public int health;
    public int numOfHearths;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public GameObject FloatingDamageForBirdInteraction;

    public Transform bloodParticle;

    private bool hasCollide = false;
    WaitForSeconds shortWait = new WaitForSeconds(0.5f);

    

    // Start is called before the first frame update
    void Start()
    {
        Restart.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

        if (health > numOfHearths)
        {
            health = numOfHearths;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < numOfHearths)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }


    }

    IEnumerator DidCollide()
    {
        yield return shortWait;
        hasCollide = false;
        if (health != 0)
        {
            Movement.ms = 15;
        }
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bird"))
        {
            if (hasCollide == false)
            {
                StartCoroutine(DidCollide());
                hasCollide = true;
                Movement.ms = -3;
                health--;
                Instantiate(FloatingDamageForBirdInteraction, transform.position, Quaternion.identity);
            }

            if (health == 0)
            {
                ScoreMechanics.GetComponent<ScoreDisplay>().enabled = false;
                Camera.GetComponent<CameraControl>().enabled = false;
                Movement.ms = -5;
                Player.transform.DetachChildren();
                Restart.SetActive(true);
                Destroy(Instantiate(bloodParticle, transform.position, Quaternion.identity), 3f);
            }
        }
        
    }
}
