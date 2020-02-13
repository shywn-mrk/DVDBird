using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawn : MonoBehaviour
{
    public GameObject pipe;
    private int pipePosition;
    // Start is called before the first frame update
    void Start()
    {
        time = Time.time;
    }
    float time = 0;
    // Update is called once per frame
    void FixedUpdate()
    {
        float x = (Time.time - time) * 50 * Random.Range(5F, 10F);
        float baseY = 0;
        float lowerDiff = Random.Range(3F, 5F);
        float upperDiff = Random.Range(3F, 5F);
        Instantiate(pipe, new Vector3(x, baseY - lowerDiff, 0), Quaternion.identity);
        Transform upperPipe = ((GameObject)Instantiate(pipe, new Vector3(x, baseY + upperDiff, 0), Quaternion.identity)).transform;
        upperPipe.Rotate(0, 0, 180);
    }
}