using UnityEngine;
using System.Collections;

public class FadeManager: MonoBehaviour
{
    private static FadeManager currentFade;
    public static float FadeTime = 1;
    public static Color FadeColor = Color.black;
    public static Material Material;

    public static bool Fading;
    public static bool Unfading;

    public static void Fade()
    {
        if (Fading || Unfading) return;
        Fading = true;
        currentFade = (new GameObject("Fade Manager")).AddComponent<FadeManager>();
        currentFade.StartCoroutine(currentFade.Fade(FadeTime, FadeColor));
    }

    public static void Unfade()
    {
        if (Fading || Unfading) return;
        Unfading = true;
        currentFade.StartCoroutine(currentFade.Unfade(FadeTime, FadeColor));
    }
    private void Awake()
    {
        DontDestroyOnLoad(this);
        Material = new Material("Shader \"Plane/No zTest\" { SubShader { Pass { Blend SrcAlpha OneMinusSrcAlpha ZWrite Off Cull Off Fog { Mode Off } BindChannels { Bind \"Color\",color } } } }");
    }
    private void DrawQuad(Color aColor, float aAlpha)
    {
        aColor.a = aAlpha;
        Material.SetPass(0);
        GL.Color(aColor);
        GL.PushMatrix();
        GL.LoadOrtho();
        GL.Begin(GL.QUADS);
        GL.Vertex3(0, 0, -1);
        GL.Vertex3(0, 1, -1);
        GL.Vertex3(1, 1, -1);
        GL.Vertex3(1, 0, -1);
        GL.End();
        GL.PopMatrix();
    }

    private IEnumerator Fade(float aFadeOutTime, Color aColor)
    {
        float t = 0.0f;
        while (t < 1.0f)
        {
            yield return new WaitForEndOfFrame();
            t = Mathf.Clamp01(t + Time.deltaTime / aFadeOutTime);
            DrawQuad(aColor, t);
        }
        Fading = false;
    }

    private IEnumerator Unfade(float aFadeInTime, Color aColor)
    {
        float t = 1.0f;
        while (t > 0.0f)
        {
            yield return new WaitForEndOfFrame();
            t = Mathf.Clamp01(t - Time.deltaTime / aFadeInTime);
            DrawQuad(aColor, t);
        }
        Unfading = false;
        Destroy(currentFade);
    }
}