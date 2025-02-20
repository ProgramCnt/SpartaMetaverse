using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraFollow : MonoBehaviour
{
    Camera camera;
    public Transform target;
    float offsetX;
    float offsetY;
    float cameraHeight;
    float cameraWidth;

    float left;
    float right;
    float bottom;
    float top;

    [SerializeField] private TilemapRenderer backRenderer;
    [SerializeField] private TilemapRenderer frontRenderer;

    private void Awake()
    {
        camera = GetComponent<Camera>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (target == null)     //타겟이 없으면 초기화 X
        {
            return;
        }

        cameraHeight = camera.orthographicSize * 2;
        cameraWidth = cameraHeight * Screen.width / Screen.height;

        left = camera.ScreenToWorldPoint(new Vector2(transform.position.x - cameraWidth / 2, 0)).x;
        right = camera.ScreenToWorldPoint(new Vector2(transform.position.x + cameraWidth / 2, 0)).x;
        bottom = camera.ScreenToWorldPoint(new Vector2(0, transform.position.y - cameraHeight / 2)).y;
        top = camera.ScreenToWorldPoint(new Vector2(0, transform.position.y + cameraHeight / 2)).y;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            return;
        }

        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(Mathf.Lerp(pos.x, target.position.x, Time.deltaTime * 5), frontRenderer.bounds.min.x - left + 0.9f, frontRenderer.bounds.max.x + right - 1.25f);
        pos.y = Mathf.Clamp(Mathf.Lerp(pos.y, target.position.y, Time.deltaTime * 5), frontRenderer.bounds.min.y - bottom, frontRenderer.bounds.max.y + top);
        transform.position = pos;
    }
}
