using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class Wait : MonoBehaviour
{
    public VideoPlayer videoplayer;
    public int sceneIndex; 

    void Start()
    {
        videoplayer = GetComponentInParent<VideoPlayer>();
        StartCoroutine(WaitforVideoEnd());
    }

    private void Update()
    {
        if (Input.anyKey)
        {
            SceneManager.LoadScene(sceneIndex);
        }
    }

    IEnumerator WaitforVideoEnd()
    {
        float videolength = 12;
        yield return new WaitForSeconds(videolength);
        SceneManager.LoadScene(sceneIndex);
    }
}