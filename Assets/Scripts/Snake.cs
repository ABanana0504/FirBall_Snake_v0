using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.SceneManagement;
//using UnityEngine.SceneManagement;

public class Snake : MonoBehaviour
{

    List<Transform> bodyList = new List<Transform>();
    public GameManager gm;
    public ComboSystem comboSystem;

    //开始默认向上移动
    Vector2 direction = Vector2.up;
    //移动一次的时间，也就是速度

    public float velocityTime = 0.05f;
    public GameObject gameObjecgtBody;

    //判断是否吃到果实
    private bool ate = false;
    public int ateCount = 0;

    void Start()
    {
        //
        InvokeRepeating("Move", 0.5f, velocityTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey("up") && direction != Vector2.down)
        {
            direction = Vector2.up;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey("down") && direction != Vector2.up)
        {
            direction = Vector2.down;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey("left") && direction != Vector2.right)
        {
            direction = Vector2.left;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey("right") && direction != Vector2.left)
        {
            direction = Vector2.right;
        }

    }

    void Move()
    {
        //头部位置
        Vector3 VPosition = transform.position;
        transform.Translate(direction);
        if (ate)
        {
            GameObject bodyPrefab = (GameObject)Instantiate(gameObjecgtBody, VPosition, Quaternion.identity);
            bodyList.Insert(0, bodyPrefab.transform);
            ate = false;
        }
        else if (bodyList.Count > 0)
        {
            bodyList.Last().position = VPosition;
            bodyList.Insert(0, bodyList.Last());
            bodyList.RemoveAt(bodyList.Count - 1);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Food"))
        {
            //Debug.Log("简简单单的果实!");
            Destroy(other.gameObject);            
            ate = true;
            ateCount++;
            gm.MakeFood();
            comboSystem.isAte = true;
            //Debug.Log(ateCount);

        }
        else
        {
            //如果撞上的不是果实
            //
            SceneManager.LoadScene("Scene");
            //Application.LoadLevel(1);
        }
    }
}
