using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class Movement : MonoBehaviour
{
    public bool isDead;

    bool mouseIsNotOverUI;

    public static float ms = 15;
    public Rigidbody rb;

    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
   
    void FixedUpdate()
    {

        mouseIsNotOverUI = EventSystem.current.currentSelectedGameObject == null;

        if (Input.GetMouseButton(0) && mouseIsNotOverUI)
        {
            transform.Translate(Vector3.up * ms * Time.deltaTime);
            rb.isKinematic = true;
        }
        else
        {
            rb.isKinematic = false;
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coins"))
        {
            Destroy(other.gameObject);
        }
    }
}
