using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGLooper : MonoBehaviour
{
    private int obstacleCount = 0;
    private Vector3 obstacleLastPosition = Vector3.zero;
    private int backgroundCount = 5;

    // Start is called before the first frame update
    void Start()
    {
        Obstacle[] obstacles = FindObjectsOfType<Obstacle>();
        obstacleLastPosition = obstacles[0].transform.position;
        obstacleCount = obstacles.Length;

        for (int i = 0; i < obstacleCount; i++)
        {
            obstacleLastPosition = obstacles[i].SetRandomPlace(obstacleLastPosition, obstacleCount);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Background"))     //배경 반복을 위한 충돌 감지
        {
            if (collision.GetComponent<BoxCollider2D>() != null)
            {
                float widthOfObject = collision.GetComponent<BoxCollider2D>().size.x;
                Vector3 pos = collision.transform.position;

                pos.x += widthOfObject * backgroundCount;                       //collision의 위치를 가져와서 가장 마지막의 background 뒷부분인 x값을 구한다
                collision.transform.position = pos;
                return;
            }
        }

        Obstacle obstacle = collision.GetComponent<Obstacle>();     //충돌한 obstacle을 가져옴
        if (obstacle)                                               //obstacle이 존재할 때
        {
            obstacleLastPosition = obstacle.SetRandomPlace(obstacleLastPosition, obstacleCount);        //obstacle에 있는 setRandomPlace 함수 실행하여 obstacle의 위치를 재배치한다
        }
    }
}
