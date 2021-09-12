using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CNTRL : MonoBehaviour
{
    private Vector3 position;
    private float width;
    private float height;
    private bool death;

    private bool invulnerable, forInv;
    private float diamondTiming, TimingIn3sec;
    private int multiplier, dmndsForInv;

    private int diamonds, eatenPeople;

    public Text diamondstxt;
    public Text eatentxt;
    public Material[] Color;
    [Header("GameObjects")]
    public GameObject addSnake;
    public GameObject[] colorsOBJ;
    public GameObject finish;
    public GameObject lose, replay;

    private void Awake()
    {
        ScreenAndPosition();
    }
    void Start()
    {
        multiplier = 1;
        colorsOBJ[0].SetActive(false);
        Time.timeScale = 1f;
        death = false;
    }

    void Update()
    {
        Fever();
        TouchController();
    }
    private void FixedUpdate()
    {
        Moving();
    }
    void TouchController()
    {
        if (death != true && invulnerable != true)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Moved)
                {
                    Vector2 pos = touch.position;
                    pos.x = (pos.x - width) / width;
                    position = new Vector3(pos.x, gameObject.transform.position.y, gameObject.transform.position.z);

                    transform.position = position;
                }

            }
        }   
    }
    void Moving()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z + 0.05f * multiplier);
    }
    void ScreenAndPosition()
    {
        width = (float)Screen.width / 2.0f;
        height = (float)Screen.height / 2.0f;


        position = gameObject.transform.position;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "People")
        {
            eatenPeople++;
            addSnake.SetActive(true);
            Destroy(other.gameObject);
            eatenPeople++;
            eatentxt.GetComponent<Text>().text = "" + eatenPeople;
        }
        if (other.tag == "Obstacle") 
        {
            if (invulnerable != true)
            {
                lose.SetActive(true);
                Time.timeScale = 0f;
                death = true;
                replay.SetActive(true);
            }
        }
        if (other.tag == "VioletCheckPoint")
        {
            gameObject.GetComponent<MeshRenderer>().material = Color[0];
            colorsOBJ[0].SetActive(true);
        }
        if (other.tag == "Red")
        {
            gameObject.GetComponent<MeshRenderer>().material = Color[1];
            colorsOBJ[1].SetActive(true);
        }
        if (other.tag == "Grey")
        {
            gameObject.GetComponent<MeshRenderer>().material = Color[2];
            colorsOBJ[2].SetActive(true);
        }
        if (other.tag == "Orange")
        {
            gameObject.GetComponent<MeshRenderer>().material = Color[3];
            colorsOBJ[3].SetActive(true);
        }
        if (other.tag == "Blue")
        {
            gameObject.GetComponent<MeshRenderer>().material = Color[4];
            colorsOBJ[4].SetActive(true);
        }
        if (other.tag == "DarkRed")
        {
            gameObject.GetComponent<MeshRenderer>().material = Color[5];
            colorsOBJ[5].SetActive(true);
        }
        if (other.tag == "Finish")
        {
            replay.SetActive(true);
            finish.SetActive(true);
            Time.timeScale = 0f;
        }
        if (other.tag == "Diamond")
        {
            forInv = true;
            dmndsForInv++;
            diamonds++;
            diamondstxt.GetComponent<Text>().text = "" + diamonds;
            Destroy(other.gameObject);
        }
        if (invulnerable)
        {
            Destroy(other.gameObject);
        }
    }
    public void Fever()
    {
        if (invulnerable)
        {
            transform.position = new Vector3(0f, transform.position.y, transform.position.z);
            multiplier = 3;
            diamondTiming += Time.deltaTime;
            diamonds = 0;
        }
        if (diamondTiming > 5f)
        {
            multiplier = 1;
            invulnerable = false;
        }
        if (forInv)
        {
            TimingIn3sec += Time.deltaTime;
        }
        if (TimingIn3sec > 0.3f)
        {
            TimingIn3sec = 0f;
            dmndsForInv = 0;
            forInv = false;
        }
        if (dmndsForInv >= 3)
        {
            invulnerable = true;
        }
    }
    public void Replay()
    {
        SceneManager.LoadScene("SampleScene");
    }

}
