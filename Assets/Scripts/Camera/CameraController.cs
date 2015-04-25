using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public int CameraMoveBoundary;
    public float CameraMoveSpeed;

    protected float ScreenHalfHeight;
    protected float ScreenHalfWidth;

    protected float ScreenHeight;
    protected float ScreenWidth;

    protected FloatRange CameraInnerHeightBorders;
    protected FloatRange CameraInnerWidthBorders;

    void Start()
    {
        ScreenHalfHeight = Camera.main.orthographicSize;
        ScreenHalfWidth = ScreenHalfHeight * Camera.main.aspect;
        ScreenHeight = ScreenHalfHeight * 2f;
        ScreenWidth = ScreenHalfWidth * 2f;
        CameraInnerHeightBorders = new FloatRange(ScreenHalfHeight, LevelGenerator.LevelPxHeight - ScreenHalfHeight);
        CameraInnerWidthBorders = new FloatRange(ScreenHalfWidth, LevelGenerator.LevelPxWidth - ScreenHalfWidth);

        Vector3 position = transform.position;

        if (CameraInnerHeightBorders.min > CameraInnerHeightBorders.max)
        {
            position.y = LevelGenerator.LevelPxHeight / 2f;
        }
        else if (position.y < CameraInnerHeightBorders.min)
        {
            position.y = CameraInnerHeightBorders.min;
        }
        else if (position.y > CameraInnerHeightBorders.max)
        {
            position.y = CameraInnerHeightBorders.max;
        }

        if (CameraInnerWidthBorders.min > CameraInnerWidthBorders.max)
        {
            position.x = LevelGenerator.LevelPxWidth / 2f;
        }
        else if (position.x < CameraInnerWidthBorders.min)
        {
            position.x = CameraInnerWidthBorders.min;
        }
        else if (position.x > CameraInnerWidthBorders.max)
        {
            position.x = CameraInnerWidthBorders.max;
        }

        transform.position = position;
    }

    void Update()
    {
        ScreenHalfHeight = Camera.main.orthographicSize;
        ScreenHalfWidth = ScreenHalfHeight * Camera.main.aspect;
        ScreenHeight = ScreenHalfHeight * 2f;
        ScreenWidth = ScreenHalfWidth * 2f;
        CameraInnerHeightBorders = new FloatRange(ScreenHalfHeight, LevelGenerator.LevelPxHeight - ScreenHalfHeight);
        CameraInnerWidthBorders = new FloatRange(ScreenHalfWidth, LevelGenerator.LevelPxWidth - ScreenHalfWidth);

        Vector3 position = transform.position;

        if (CameraInnerHeightBorders.min > CameraInnerHeightBorders.max)
        {
            position.y = LevelGenerator.LevelPxHeight/2f;
        }
        else if (Input.mousePosition.y < 0 + CameraMoveBoundary)
        {
            float step = CameraMoveSpeed * Time.deltaTime;
            float destination = position.y - step;
            position.y = Mathf.Max(destination, CameraInnerHeightBorders.min);
        }
        else if (Input.mousePosition.y > Screen.height - CameraMoveBoundary)
        {
            float step = CameraMoveSpeed * Time.deltaTime;
            float destination = position.y + step;
            position.y = Mathf.Min(destination, CameraInnerHeightBorders.max);
        }

        if (CameraInnerWidthBorders.min > CameraInnerWidthBorders.max)
        {
            position.x = LevelGenerator.LevelPxWidth/2f;
        }
        else if (Input.mousePosition.x < 0 + CameraMoveBoundary)
        {
            float step = CameraMoveSpeed * Time.deltaTime;
            float destination = position.x - step;
            position.x = Mathf.Max(destination, CameraInnerWidthBorders.min);
        }
        else if (Input.mousePosition.x > Screen.width - CameraMoveBoundary)
        {
            float step = CameraMoveSpeed * Time.deltaTime;
            float destination = position.x + step;
            position.x = Mathf.Min(destination, CameraInnerWidthBorders.max);
        }

        transform.position = position;
    }

}
