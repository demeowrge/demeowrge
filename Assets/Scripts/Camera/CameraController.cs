using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public int CameraMoveBoundary;
    public float CameraMoveSpeed;

    protected float ScreenHalfWidth;
    protected float ScreenHalfHeight;

    protected bool LockHorizontal = false;
    protected bool LockVertical = false;

    void Start()
    {
        ScreenHalfWidth = Camera.main.orthographicSize * Camera.main.aspect;
        ScreenHalfHeight = Camera.main.orthographicSize;

        float screenWidth = ScreenHalfWidth * 2f;
        float screenHeight = ScreenHalfHeight * 2f;

        if (screenHeight >= LevelGenerator.LevelPxWidth)
        {
            LockHorizontal = true;
        }

        if (screenWidth >= LevelGenerator.LevelPxHeight)
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

            position.x = (destination - ScreenHalfWidth > 0f) ? destination : ScreenHalfWidth;
        }

        if (!LockHorizontal && Input.mousePosition.x > Screen.width - CameraMoveBoundary)
        {
            float step = CameraMoveSpeed * Time.deltaTime;
            float destination = position.x + step;

            position.x = (destination + ScreenHalfWidth < LevelGenerator.LevelPxWidth) ? destination : LevelGenerator.LevelPxWidth - ScreenHalfWidth;
        }

        if (!LockVertical && Input.mousePosition.y < 0 + CameraMoveBoundary)
        {
            float step = CameraMoveSpeed * Time.deltaTime;
            float destination = position.y - step;

            position.y = (destination - ScreenHalfHeight > 0f) ? destination : ScreenHalfHeight;
        }

        if (!LockVertical && Input.mousePosition.y > Screen.height - CameraMoveBoundary)
        {
            float step = CameraMoveSpeed * Time.deltaTime;
            float destination = position.y + step;

            position.y = (destination + ScreenHalfHeight < LevelGenerator.LevelPxHeight) ? destination : LevelGenerator.LevelPxHeight - ScreenHalfHeight;
        }

        transform.position = position;
    }
}
