using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{

    public string message;

    public UnityEvent invisible;
    public UnityEvent visible;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void deactive()
    {
        invisible.Invoke();
    }

    public void inactive()
    {
        visible.Invoke();
    }

}
