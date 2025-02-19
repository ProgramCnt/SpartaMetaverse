using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float highPosY = 1f;
    public float lowPosY = -1f;

    public float holeSizeMin = 1f;
    public float holeSizeMax = 3f;

    public Transform topObject;
    public Transform bottomObject;

    public float widthPadding = 4f;

    MiniGameManager miniGameManager;
    UIManager uiManager;

    private void Start()
    {
        miniGameManager = MiniGameManager.Instance;
        uiManager = UIManager.Instance;
    }

    public Vector3 SetRandomPlace(Vector3 lastPosition, int obstacleCount)
    {
        float holeSize = Random.Range(holeSizeMin, holeSizeMax);
        float halfHoleSize = holeSize / 2;

        topObject.localPosition = new Vector3(0, halfHoleSize);
        bottomObject.localPosition = new Vector3(0, -halfHoleSize);

        Vector3 obstaclePosition = lastPosition + new Vector3(widthPadding, 0);
        obstaclePosition.y = Random.Range(lowPosY, highPosY);

        transform.position = obstaclePosition;

        return obstaclePosition;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();

        if (player != null)
        {
            uiManager.SetInGameScore(miniGameManager.AddScore(1));
        }
    }
}
