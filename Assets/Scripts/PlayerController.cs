using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public int targetRaiderIndex;

    public void SetTargetPlayerIndex(int index) {
        Debug.Log(index);
        targetRaiderIndex = index;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
