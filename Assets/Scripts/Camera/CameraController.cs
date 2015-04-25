using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public int CameraMoveBoundary;
    public float CameraMoveSpeed;

    protected float ScreenHalfRelWidth;
    protected float ScreenHalfRelHeight;

    protected bool LockHorizontal = false;
    protected bool LockVertical = false;

    void Start()
    {
        ScreenHalfRelWidth = Camera.main.orthographicSize * Camera.main.aspect;
        ScreenHalfRelHeight = Camera.main.orthographicSize;

        float screenRelWidth = ScreenHalfRelWidth * 2f;
        float screenRelHeight = ScreenHalfRelHeight * 2f;

        if (screenRelHeight >= LevelGenerator.LevelPxWidth)
        {
            LockHorizontal = true;
        }

        if (screenRelWidth >= LevelGenerator.LevelPxHeight)
        {
            LockVertical = true;
        }

        transform.position = new Vector3(
            LevelGenerator.LevelPxWidth / 2f,
            LevelGenerator.LevelPxHeight / 2f,
            -10f
        );
    }

    void Update()
    {
        Vector3 position = transform.position;

        if (!LockHorizontal && Input.mousePosition.x < 0 + CameraMoveBoundary)
        {
            float step = CameraMoveSpeed * Time.deltaTime;
            float destination = position.x - step;

            position.x = (destination - ScreenHalfRelWidth > 0f) ? destination : ScreenHalfRelWidth;
        }

        if (!LockHorizontal && Input.mousePosition.x > Screen.width - CameraMoveBoundary)
        {
            float step = CameraMoveSpeed * Time.deltaTime;
            float destination = position.x + step;

            position.x = (destination + ScreenHalfRelWidth < LevelGenerator.LevelPxWidth) ? destination : LevelGenerator.LevelPxWidth - ScreenHalfRelWidth;
        }

        if (!LockVertical && Input.mousePosition.y < 0 + CameraMoveBoundary)
        {
            float step = CameraMoveSpeed * Time.deltaTime;
            float destination = position.y - step;

            position.y = (destination - ScreenHalfRelHeight > 0f) ? destination : ScreenHalfRelHeight;
        }

        if (!LockVertical && Input.mousePosition.y > Screen.height - CameraMoveBoundary)
        {
            float step = CameraMoveSpeed * Time.deltaTime;
            float destination = position.y + step;

            position.y = (destination + ScreenHalfRelHeight < LevelGenerator.LevelPxHeight) ? destination : LevelGenerator.LevelPxHeight - ScreenHalfRelHeight;
        }

        transform.position = position;
    }
}
