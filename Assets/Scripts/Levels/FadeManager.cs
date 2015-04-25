using UnityEngine;
using System.Collections;

public class FadeManager: MonoBehaviour
{
    private static GameObject fp;
    private static SpriteRenderer sr;
    public GameObject FadePrefab;
    float speed = 1f;
    float alpha = 0;

    public static bool Fading;
    public static bool Unfading;

    public delegate void act();

    public static void Fade(act postFade)
    {
        if (Fading || Unfading) return;
        var go = Instantiate(fp);
        var fm = go.GetComponent<FadeManager>();
        sr = go.GetComponent<SpriteRenderer>();
        DontDestroyOnLoad(go);
        Fading = true;
        fm.StartCoroutine(fm.WaitForFade(postFade));
    }

    public IEnumerator WaitForFade(act postFade)
    {
        while (Fading)
        {
            yield return new WaitForEndOfFrame();
        }
        postFade();
    }

    public static void Unfade()
    {
        if (Fading || Unfading) return;
        Unfading = true;
    }

    // Use this for initialization
    void Start()
    {
        if (fp != null) return;
        fp = FadePrefab;
        Destroy(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (Unfading)
        {
            alpha = alpha - speed * Time.deltaTime;
            if (alpha > 0)
                sr.color = new Color(sr.color.a, sr.color.b, sr.color.g, alpha);
            else
            {
                sr.color = new Color(sr.color.a, sr.color.b, sr.color.g, 0f);
                Unfading = false;
                Destroy(gameObject);
            }
        }
        if (Fading)
        {
            alpha = alpha + speed * Time.deltaTime;
            if (alpha < 1)
                sr.color = new Color(sr.color.a, sr.color.b, sr.color.g, alpha);
            else
            {
                sr.color = new Color(sr.color.a, sr.color.b, sr.color.g, 1f);
                Fading = false;
            }
        }
    }
}