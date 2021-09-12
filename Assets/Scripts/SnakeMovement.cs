using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{

    public List<Transform> bodyParts = new List<Transform>();

    [Header("Parameters")]
    public float minDistance = 0.25f;
    public int beginSize;
    public float speed = 1;

    [Header("GameObjects")]
    public GameObject bodyprefabs;
    public GameObject addSnake;
    public GameObject[] colorsOBJ;

    public Material[] Color;

    private float dis;
    private Transform curBodyPart;
    private Transform PrevBodyPart;

    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        Move();
        if (addSnake.activeSelf)
        {
            AddBodyPart();
            addSnake.SetActive(false);
        }
    }
    void Update()
    {
        CheckForColor();
    }

    public void Move()
    {

        float curspeed = speed;

        bodyParts[0].Translate(bodyParts[0].forward * curspeed * Time.smoothDeltaTime, Space.World);

        
        for (int i = 1; i < bodyParts.Count; i++)
        {

            curBodyPart = bodyParts[i];
            PrevBodyPart = bodyParts[i - 1];

            dis = Vector3.Distance(PrevBodyPart.position, curBodyPart.position);

            Vector3 newpos = PrevBodyPart.position;

            newpos.y = bodyParts[0].position.y;

            
            
            float T = Time.deltaTime * dis / minDistance * curspeed;

            if (T > 0.5f)
                T = 0.5f;
            
            curBodyPart.position = Vector3.Slerp(curBodyPart.position, newpos, T);
        }
    }


    public void AddBodyPart()
    {

        Transform newpart = (Instantiate(bodyprefabs, bodyParts[bodyParts.Count - 1].position, bodyParts[bodyParts.Count - 1].rotation) as GameObject).transform;

        newpart.SetParent(transform);

        bodyParts.Add(newpart);
    }
    private void CheckForColor()
    {
        if (colorsOBJ[0].activeSelf)
        {
            for (int i = 0; i < bodyParts.Count; i++)
            {
                bodyParts[i].gameObject.GetComponent<MeshRenderer>().material = Color[0];
                colorsOBJ[0].SetActive(false);
            }
        }
        if (colorsOBJ[1].activeSelf)
        {
            for (int i = 0; i < bodyParts.Count; i++)
            {
                bodyParts[i].gameObject.GetComponent<MeshRenderer>().material = Color[1];
                colorsOBJ[1].SetActive(false);
            }
        }
        if (colorsOBJ[2].activeSelf)
        {
            for (int i = 0; i < bodyParts.Count; i++)
            {
                bodyParts[i].gameObject.GetComponent<MeshRenderer>().material = Color[2];
                colorsOBJ[2].SetActive(false);
            }
        }
        if (colorsOBJ[3].activeSelf)
        {
            for (int i = 0; i < bodyParts.Count; i++)
            {
                bodyParts[i].gameObject.GetComponent<MeshRenderer>().material = Color[3];
                colorsOBJ[3].SetActive(false);
            }
        }
        if (colorsOBJ[4].activeSelf)
        {
            for (int i = 0; i < bodyParts.Count; i++)
            {
                bodyParts[i].gameObject.GetComponent<MeshRenderer>().material = Color[4];
                colorsOBJ[4].SetActive(false);
            }
        }
        if (colorsOBJ[5].activeSelf)
        {
            for (int i = 0; i < bodyParts.Count; i++)
            {
                bodyParts[i].gameObject.GetComponent<MeshRenderer>().material = Color[5];
                colorsOBJ[5].SetActive(false);
            }
        }
    }

}