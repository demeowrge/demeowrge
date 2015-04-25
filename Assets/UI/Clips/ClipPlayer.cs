using UnityEngine;

public class ClipPlayer : MonoBehaviour
{
    public GameObject[] slides;
    private int SlideNumber;

	void Start ()
	{
	    SlideNumber = -1;
        NextSlide();
	}

    void NextSlide()
    {
        SlideNumber++;
        if (SlideNumber >= slides.GetLength(0))
            LevelManager.NextLevel();

        for (int i = 0; i < slides.GetLength(0); i++)
            slides[i].SetActive(i == SlideNumber);
    }

	void Update ()
	{
	    if (Input.GetMouseButtonDown(0))
	        NextSlide();
	}
}
