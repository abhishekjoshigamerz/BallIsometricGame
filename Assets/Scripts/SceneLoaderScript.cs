using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoaderScript : MonoBehaviour
{
    [SerializeField]
    private Animator transition;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
         LoadNextScene();
        }
    }

    private void LoadNextScene(){
       StartCoroutine(  LoadLevel( SceneManager.GetActiveScene().buildIndex + 1));
    }
    IEnumerator LoadLevel(int levelIndex){
        //We will play the animation
        transition.SetTrigger("Start");
        //Wait
            yield return new WaitForSeconds(1);
        //Load Scene
       SceneManager.LoadScene(levelIndex);
    }

    public void PlayBack(){
        LoadPreviousScene();
    }
     private void LoadPreviousScene(){
       StartCoroutine(  LoadLevel( SceneManager.GetActiveScene().buildIndex - 1));
    }

    public void Quit(){
        Application.Quit();
    }
}
