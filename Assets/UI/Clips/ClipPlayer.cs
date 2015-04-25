using UnityEngine;

public class ClipPlayer : MonoBehaviour
{
    public bool isLastClip = false;
    public GameObject[] slides;

    private bool isEnded;
    private int SlideNumber;

	void Start ()
	{
	    SlideNumber = -1;
        NextSlide();
	}

    void NextSlide()
    {
        if (isEnded) return;
        SlideNumber++;

        if (SlideNumber >= slides.GetLength(0))
        {
            isEnded = true;
            if (!isLastClip)
                LevelManager.NextLevel();
            else
                LevelManager.MainMenu();
        } else
            for (int i = 0; i < slides.GetLength(0); i++)
                slides[i].SetActive(i == SlideNumber);
    }

	void FixedUpdate()
	{
	    if (Input.GetMouseButtonDown(0))
	        NextSlide();
	}
}
