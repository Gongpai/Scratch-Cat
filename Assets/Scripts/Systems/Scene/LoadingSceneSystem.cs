using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using GDD.Timer;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class LoadingSceneSystem : MonoBehaviour
{
    [SerializeField] private GameObject LoadingScreen;
    [SerializeField] private UnityEvent _startLoadingEvent;
    [SerializeField] private Image LoadingBarfill;
    [SerializeField] private TextMeshProUGUI m_textloading;
    [SerializeField] private string m_addtextLoading;
    [SerializeField] private bool isUseAwaitTimer;

    private float progressValue;
    string Scene_ID;
    private Animator animator;
    AsyncOperation operation;
    private UnityAction _action_loading;
    private UnityAction _action_loaded;
    private AwaitTimer timer;

    public UnityAction action_loading_scane
    {
        get => _action_loading;
        set => _action_loading = value;
    }
    
    public UnityAction action_loaded_scane
    {
        get => _action_loaded;
        set => _action_loaded = value;
    }

    private void OnEnable()
    {
        Cursor.visible = true;
    }

    private void OnDisable()
    {
        Cursor.visible = false;
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void LoadScene(string SceneID)
    {
        LoadingScreen.SetActive(true);
        Scene_ID = SceneID;
        animator.SetBool("IsIn", true);
        animator.SetBool("IsOut", false);
    }

    public void EndLoadScene()
    {
        operation.allowSceneActivation = true;
    }

    private void OpenScene()
    {
        animator.SetBool("IsIn", false);
        animator.SetBool("IsOut", true);
        
        if(_action_loaded != null)
            _action_loaded.Invoke();
    }

    public void StartLoading()
    {
        if(_action_loading != null)
            _action_loading.Invoke();
        
        if(_startLoadingEvent != null)
            _startLoadingEvent.Invoke();

        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);
        StartCoroutine(LoadSceneAsync(Scene_ID));
    }
    
    IEnumerator LoadSceneAsync(string SceneName)
    {
        operation = SceneManager.LoadSceneAsync(SceneName);
        operation.allowSceneActivation = false;

        print("PRRR : " + operation);

        while (!operation.isDone)
        {
            progressValue = Mathf.Clamp01(operation.progress / 0.9f);

            if (LoadingBarfill != null)
                LoadingBarfill.GetComponent<Image>().fillAmount = progressValue;

            if (m_textloading != null)
                m_textloading.text = m_addtextLoading + $"{(int)(progressValue * 100)} %";
            print("Loading : " + operation.progress + " ----------------------------------------------");
            yield return null;
            if ((operation.progress / 0.9f) >= 1)
            {
                if (m_textloading != null)
                    m_textloading.text = m_addtextLoading + $"99 %";
                
                if (isUseAwaitTimer)
                {
                    timer = new AwaitTimer(4, () =>
                    {
                        if (m_textloading != null)
                            m_textloading.text = m_addtextLoading + $"100 %";
                        OpenScene();
                    }, current => { });
                    timer.Start();
                }
                else
                    OpenScene();
            }
            //operation.allowSceneActivation = true;
        }
    }
}
