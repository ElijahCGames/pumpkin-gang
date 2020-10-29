using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Post_Wwise_Event : MonoBehaviour
{

    public AK.Wwise.Event myEvent;

    void Start()
    {
       myEvent.Post(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
