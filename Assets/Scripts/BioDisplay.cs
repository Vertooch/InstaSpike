using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BioDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DoubleClickButton button = gameObject.GetComponent<DoubleClickButton>();
        button.OnSingleClick += DismissBio;
    }

    private void DismissBio()
    {
        Destroy(gameObject);
    }
}
