using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    Outline outline;
    public string message;

    public UnityEvent invisible;
    public UnityEvent visible;

    // Start is called before the first frame update
    void Start()
    {
        outline = GetComponent<Outline>(); 
        outline.enabled = false;
    }

    public void deactive()
    {
        invisible.Invoke();
    }

    public void inactive()
    {
        visible.Invoke();
    }
    public void DisableOutline()
    {
        outline.enabled = false;
    }

    public void EnableOutline()
    {
        outline.enabled = true;
    }


}
