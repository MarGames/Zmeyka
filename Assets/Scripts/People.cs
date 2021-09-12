using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class People : MonoBehaviour
{
    Rigidbody rb;

    bool ComeToMouth;
    Vector3 snakeDrection;

    [Header ("GameObj")]
    public GameObject Snake;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (ComeToMouth)
        {
            snakeDrection = -(transform.position - Snake.transform.position).normalized;
            rb.velocity = new Vector3(snakeDrection.x, snakeDrection.y, snakeDrection.z * 3.5f);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //Debug.Log("Entered");
            ComeToMouth = true;
        }
    }
}
