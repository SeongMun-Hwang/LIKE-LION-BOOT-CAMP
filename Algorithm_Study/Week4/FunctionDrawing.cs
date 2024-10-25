using System;
using UnityEngine;

public class Graph : MonoBehaviour
{
    int orderLayer = 0;
    void Start()
    {
        DrawGrid(1, 100, Color.gray, 0.03f);
        DrawAxis();

        DrawFunction(Circle, -1, 1, 0.1f, Color.cyan, 0.1f, false);
        DrawFunction(Mathf.Sin, 0, 10, 0.1f, Color.yellow, 0.1f, false);
        DrawFunction(Mathf.Cos, 0, 10, 0.1f, Color.red, 0.1f, false);
    }
    float Circle(float x)
    {
        return Mathf.Sqrt(1-x*x);
    }
    float Square(float x)
    {
        return x*x;
    }
    float Sqrt(float x)
    {
        return Mathf.Sqrt(x);
    }
    float Sin(float x)
    {
        return Mathf.Sin(x);
    }
    float Fusion(float x)
    {
        return Sin(Square(x));
    }
    float ThirdRandomFunc(float x)
    {
        return 1f / 3 * x * x;
    }
    float LineEquation(float x)
    {
        return 1f / 2 * x - 2;
    }float LineEquation2(float x)
    {
        return 1f / 2 * x - 3;
    }

    void DrawAxis()
    {
        DrawLine(new Vector3(-100, 0, 0), new Vector3(100, 0, 0), Color.red, 0.1f);
        DrawLine(new Vector3(0, -100, 0), new Vector3(0, 100, 0), Color.green, 0.1f);
    }

    void DrawGrid(float gridSize, int gridCount, Color color, float thickness)
    {
        for (int i = -gridCount; i < gridCount; i++)
        {
            float t = thickness;
            if (i % 5 == 0)
            {
                t *= 2;
            }
            DrawLine(new Vector3(i * gridSize, -gridCount * gridSize),
                new Vector3(i * gridSize, gridCount * gridSize), color, t);
            DrawLine(new Vector3(-gridCount * gridSize, i * gridSize),
                new Vector3(gridCount * gridSize, i * gridSize), color, t);
        }
    }
    void DrawPoint(Vector3 position, Color color, float size = 0.15f)
    {
        GameObject point = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        point.transform.position = position;
        point.transform.localScale = new Vector3(size, size, size);
        Renderer renderer = point.GetComponent<Renderer>();
        renderer.material.color = color;
    }
    void DrawLine(Vector3 start, Vector3 end, Color color, float thickness = 0.05f)
    {
        GameObject lineObj = new GameObject("Line");
        LineRenderer lineRenderer = lineObj.AddComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, start);
        lineRenderer.SetPosition(1, end);
        lineRenderer.startWidth = thickness;
        lineRenderer.endWidth = thickness;
        lineRenderer.material.color = color;
        lineRenderer.sortingOrder = orderLayer;
        orderLayer++;
    }

    void DrawFunction(Func<float, float> function, float start, float end,
        float step, Color color, float thickness, bool usePoint)
    {
        if (usePoint)
        {
            for (float i = start; i < end; i += step)
            {
                float y = function(i);
                DrawPoint(new Vector3(i, y, 0), color, thickness);
            }
        }
        else
        {
            int pointCount = Mathf.CeilToInt((end - start) / step);

            GameObject lineObj = new GameObject("FunctionGraph");
            LineRenderer lineRenderer = lineObj.AddComponent<LineRenderer>();
            lineRenderer.positionCount = pointCount;
            lineRenderer.startWidth = thickness;
            lineRenderer.endWidth = thickness;
            lineRenderer.material.color = color;
            lineRenderer.sortingOrder = orderLayer;
            orderLayer++;
            int index = 0;
            for (float i = start; i < end; i += step)
            {
                float y = function(i);
                lineRenderer.SetPosition(index, new Vector3(i, y, 0));
                index++;
            }
        }

    }
}
