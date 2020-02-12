using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ComboSystem : MonoBehaviour
{
    [HideInInspector]public bool isAte;
    public Snake player;
    public int combo;
    public float timer =6f;
    float initialTimer;

    void Start()
    {
        initialTimer = timer;
        isAte = false;
        combo = 0;
    }

    public void eat()
    {
        isAte = true;
    }

    private void Update()
    {

        if (isAte)
        {
            timer = initialTimer;
            combo++;
            isAte = false;
            Debug.Log("combo数:" + combo);
        }
        if (combo != 0)
        {

            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                combo = 0;
                Debug.Log("combo时间结束");
                timer = initialTimer;

            }
        }

    }



}
