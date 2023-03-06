using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Add the SceneManagement Library
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public string nextSceneName;
    public float delayTime;

    //When the player collides with this object, move on to the next scene
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Invoke("ChangeScene", delayTime);

            //Note: This would be a good spot to put any code for animating
            //the player or playing sound effects that go with the scene change

        }
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}