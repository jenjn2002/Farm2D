using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    public static GameSceneManager instance;

    private void Awake()
    {
        instance = this;
    }
    [SerializeField] SceenTint screenTint;
    string currentScene;

    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene().name;
    }

    public void InitSwitchScene(string to, Vector3 targetPosition)
    {
        StartCoroutine(Transition(to, targetPosition)); 
    }

    IEnumerator Transition(string to, Vector3 targetPosition)
    {
        screenTint.Tint();

        yield return new WaitForSeconds(1f / screenTint.speed +0.1f);

        SwitchScene(to, targetPosition);

        yield return new WaitForEndOfFrame();

        screenTint.UnTint();
    }

    public void SwitchScene(string to, Vector3 targetpPosition)
    {
        
        SceneManager.LoadScene(to, LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync(currentScene);
        currentScene = to;
        Transform playerTransform = GameManager1.instance.player.transform;

        Cinemachine.CinemachineBrain currentCamera = Camera.main.GetComponent<Cinemachine.CinemachineBrain>();

        currentCamera.ActiveVirtualCamera.OnTargetObjectWarped(playerTransform, targetpPosition - playerTransform.position);


        GameManager1.instance.player.transform.position= new Vector3( targetpPosition.x, targetpPosition.y, playerTransform.position.z);
    }
}
