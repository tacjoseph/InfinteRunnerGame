using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Rocket : MonoBehaviour
{
    public Vector3[] rocketPos;
    public int currPosIndex = 1;
    public float t = 0;
    public float moveSpeed = 7;

    public SpriteRenderer s;
    public Color flinchColor = new Color(0.5f, 0, 0, 0);
    public bool isAlive = true;
    public bool isFlinching = false;
    public int hp = 3;
    public int score = 0;
    public float flinchDur = 5;
    public float ft = 0;
    // Start is called before the first frame update
    void Start()
    {
        s = GetComponent<SpriteRenderer>();  
    }

    void KillPlayer()
    {
        s.enabled = false;
    }

    private void OnTriggerEnter2D(Collide2D col)
    {
        if(col.gameObkect.name == "Asteroid")
        {
            hp = hp - 1;
            isFlinching = true;
            if(hp > 0)
            {
                isAlive = false;
            }
        }
        if(col.gameObject.name == "Points")
        {
            score = score + 1;
        }
        if(!isAlive)
        {
            KillPlayer();
        }
    }

    // Update is called once per frame
    void Update()
    {
        t = Time.deltaTime * moveSpeed;
        transform.position = Vector3.Lerp(transform.position, rocketPos[currPosIndex], t);

        if(Input.GetKeyDown(KeyCode.S))
        {
            currPosIndex = currPosIndex + 1;
            if(currPosIndex > rocketPos.Length - 1)
            {
                currPosIndex = rocketPos.Length - 1;
            }
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            currPosIndex = currPosIndex - 1;
            if(currPosIndex < 0)
                {
                currPosIndex = 0;
            }
        }
    }
}
