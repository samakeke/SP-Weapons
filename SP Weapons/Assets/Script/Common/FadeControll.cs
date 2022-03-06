using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class FadeControll : MonoBehaviour
{
    [SerializeField]
    private Animator animFadePanel;
    [SerializeField]
    private Sprite loadImage;
    [SerializeField]
    private GameObject loadingTextSummary;
    [SerializeField]
    private GameObject[] loadingText = new GameObject[13];  // LoadingText ALL Child

    private BackGroundAnim titleObj = null; // DiscardObj“øØƒﬁÇ≈nullîªíËÇçsÇ¡ÇƒÇ¢ÇÈÇÃÇ≈null
    private AsyncOperation async = default;
    private Image imageBackGround = default;
    private string currentSceneName = default;
    private string nextSceneName = default;

    private const string FADE_TRIGGER_NAME = "FadeTrigger";
    private const string FIRST_SCENE_NAME = "Title";
    private const string SECOND_SCENE_NAME = "Menu";
    private const string FINDWITHTAG_OBJ = "BackGround";
    private const int ANIM_TIME_BORDER = 1;
    private const int ANIM_LAYER = 0;
    private const float LOAD_PROGRESS_BORDER = 0.9f;
    private const float LOAD_SUCCESS_WAIT = 3f;
    private const float LOADINGTEXT_ACTIVE_WAIT = 0.1f;





    private void Start()
    {
        imageBackGround = GameObject.FindWithTag(FINDWITHTAG_OBJ).GetComponent<Image>();
        currentSceneName = SceneManager.GetActiveScene().name;

        DiscardObj(); // ifÇí ÇÈ
    }





    public void DiscardObj()
    {
        switch (currentSceneName)
        {
            case FIRST_SCENE_NAME:
                if (titleObj == null)
                {
                    titleObj = GameObject.FindWithTag(FINDWITHTAG_OBJ).GetComponent<BackGroundAnim>();
                    nextSceneName = SECOND_SCENE_NAME;
                }
                else
                {
                    foreach (GameObject obj in titleObj.Get_Obj)
                    {
                        Destroy(obj);
                    }
                }
                break;

            case SECOND_SCENE_NAME:

                break;
        }
    }





    public IEnumerator LoadUI_Active()
    {
        animFadePanel.SetBool(FADE_TRIGGER_NAME, false); // FadeOut

        yield return null;

        for (; ; )
        {
            float fadeOutTime;

            fadeOutTime = animFadePanel.GetCurrentAnimatorStateInfo(ANIM_LAYER).normalizedTime;

            if (fadeOutTime >= ANIM_TIME_BORDER)
            {
                DiscardObj(); // elseÇí ÇÈ

                imageBackGround.sprite = loadImage;

                animFadePanel.SetBool(FADE_TRIGGER_NAME, true);    // FadeIn

                break;
            }
            yield return null;
        }
    }





    public IEnumerator NextSceneLoad()
    {
        async = SceneManager.LoadSceneAsync(nextSceneName);

        async.allowSceneActivation = false;

        loadingTextSummary.SetActive(true);

        yield return StartCoroutine(LoadingTextActivate());

        for (; ; )
        {
            if (async.progress >= LOAD_PROGRESS_BORDER)
            {
                yield return new WaitForSeconds(LOAD_SUCCESS_WAIT);

                animFadePanel.SetBool(FADE_TRIGGER_NAME, false);     // FadeOut

                yield return null;

                for (; ; )
                {
                    if (animFadePanel.GetCurrentAnimatorStateInfo(ANIM_LAYER).normalizedTime >= ANIM_TIME_BORDER)
                    {
                        async.allowSceneActivation = true;
                    }
                    yield return null;
                }
            }
            yield return null;
        }
    }





    private IEnumerator LoadingTextActivate()
    {
        foreach (GameObject txt in loadingText)
        {
            txt.SetActive(true);

            yield return new WaitForSeconds(LOADINGTEXT_ACTIVE_WAIT);
        }
    }
}