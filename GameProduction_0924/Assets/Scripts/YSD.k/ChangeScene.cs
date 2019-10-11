using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    public string next_Scene_Name;

    // Use this for initialization
    void Start ()
    {

    }

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetKeyDown (KeyCode.Return))
            SceneManager.LoadScene (next_Scene_Name);

    }
}