using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;//场景头部引入

public class GameManager : MonoBehaviour
{

    public GameObject foodPrefab;
    int i=0;
	void Start () {
        Invoke("MakeFood", 1f);
	}


    public void MakeFood()
    {
        int x = Random.Range(-30, 30);
        int y = Random.Range(-22, 22);
        Instantiate(foodPrefab, new Vector2(x,y), Quaternion.identity);
        i++;
        //Debug.Log(i);
    }

    public void GameOver()
    {
        SceneManager.LoadScene(1);
    }
}
