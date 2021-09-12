using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouth : MonoBehaviour
{
    [Header("GameObjects")]
    public GameObject Snake;

    void Update()
    {
        transform.position = Snake.transform.position;
    }

}
