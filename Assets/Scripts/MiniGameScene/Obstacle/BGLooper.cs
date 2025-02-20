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
        if (collision.CompareTag("Background"))     //��� �ݺ��� ���� �浹 ����
        {
            if (collision.GetComponent<BoxCollider2D>() != null)
            {
                float widthOfObject = collision.GetComponent<BoxCollider2D>().size.x;
                Vector3 pos = collision.transform.position;

                pos.x += widthOfObject * backgroundCount;                       //collision�� ��ġ�� �����ͼ� ���� �������� background �޺κ��� x���� ���Ѵ�
                collision.transform.position = pos;
                return;
            }
        }

        Obstacle obstacle = collision.GetComponent<Obstacle>();     //�浹�� obstacle�� ������
        if (obstacle)                                               //obstacle�� ������ ��
        {
            obstacleLastPosition = obstacle.SetRandomPlace(obstacleLastPosition, obstacleCount);        //obstacle�� �ִ� setRandomPlace �Լ� �����Ͽ� obstacle�� ��ġ�� ���ġ�Ѵ�
        }
    }
}
