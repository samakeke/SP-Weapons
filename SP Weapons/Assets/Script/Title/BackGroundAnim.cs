using UnityEngine;
using System.Collections;

public class BackGroundAnim : MonoBehaviour
{
    [SerializeField]
    private FadeControll fadeControll;
    [SerializeField]
    private GameObject[] obj = new GameObject[2];   // TitleText,SystemText
    [SerializeField]
    private Animator animBackGround;

    private const byte TAP = 0;
    private const byte LAYER = 0;
    private const byte ANIMATIN_TIME_BORDER = 1;
    private const float SKIP_PLAY_ANIMATION = 0.8f;
    private const string SKIP_TRIGGER_NAME = "SkipTrigger";

    public GameObject[] Get_Obj => this.obj;





    public IEnumerator Movie()
    {
        /* スキップ処理 */
        if (animBackGround.GetBool(SKIP_TRIGGER_NAME)) // true
        {
            Debug.Log("SkipTrigger is true");

            yield return StartCoroutine(Skip());
        }

        /* シーン遷移処理 */
        if (animBackGround.GetCurrentAnimatorStateInfo(LAYER).normalizedTime >= ANIMATIN_TIME_BORDER)
        {
            Debug.Log("Animation End");

            yield return StartCoroutine(SceneChange());
        }
    }





    private IEnumerator Skip()
    {
        for (; ; )
        {
            if (Input.GetMouseButtonDown(TAP))
            {
                Debug.Log("Skip Success");

                animBackGround.Play(animBackGround.GetCurrentAnimatorStateInfo(LAYER).fullPathHash, LAYER, SKIP_PLAY_ANIMATION);
                yield break;
            }
            else if (!animBackGround.GetBool(SKIP_TRIGGER_NAME)) // false
            {
                Debug.Log("SkipTrigger is false");

                yield break;
            }
            yield return null;
        }
    }





    private IEnumerator SceneChange()
    {
        for (; ; )
        {
            if (Input.GetMouseButtonDown(TAP))
            {
                Debug.Log("SceneChange Success");
                
                /* ロード画面をアクティブに */
                yield return StartCoroutine(fadeControll.LoadUI_Active());

                /* 次のシーンをロード */
                yield return StartCoroutine(fadeControll.NextSceneLoad());
            }
            yield return null;
        }
    }





    /* AnimationEvent */
    public void ObjActive()
    {
        foreach(GameObject _obj in obj)
        {
            _obj.SetActive(true);
        }
    }

    public void SkipTriggerChange(int trigger)
    {
        switch(trigger)
        {
            case 1:
                animBackGround.SetBool(SKIP_TRIGGER_NAME, true);
                break;
            case 0:
                animBackGround.SetBool(SKIP_TRIGGER_NAME, false);
                break;
        }
    }
}