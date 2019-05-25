using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoButton : MonoBehaviour
{
    public BioDisplay bioPrefab;

    private Canvas canvas;

    void Start()
    {
        canvas = GameObject.FindObjectOfType<Canvas>();

        DoubleClickButton button = gameObject.GetComponent<DoubleClickButton>();
        if (button != null)
            button.OnSingleClick += ShowBio;
    }

    public void ShowBio()
    {
        if (GameObject.FindObjectOfType<BioDisplay>() == null)
            Instantiate(bioPrefab, canvas.transform, false);
    }
}
