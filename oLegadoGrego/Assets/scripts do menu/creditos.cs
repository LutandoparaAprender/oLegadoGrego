using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creditos : MonoBehaviour
{
    public float ScSpeed;
    public Transform tr;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(tr.position.y);
        if (tr.position.y < 28)
        {
            transform.Translate(Vector3.up * ScSpeed * Time.deltaTime);
        }
    }


    void OnEnable()
    {
        transform.position = tr.position;
    }
}