using UnityEngine;
using UnityEngine.UI;

public class QuestWindowButton : MonoBehaviour
{
    /// <summary>
    /// クエストウィンドウに含まれる全てのボタン
    /// </summary>

    [SerializeField]
    private MenuSceneManager menuSceneManager;
    [SerializeField]
    private Button homeButton;
    [SerializeField]
    private Button backButton;
    [SerializeField]
    private GameObject objMenuCanvas;
    [SerializeField]
    private GameObject objQuestNonTouchPanel;





    private void Start()
    {
        ButtonRegist();
    }





    /* 各ボタンの登録 */

    private void ButtonRegist()
    {
        /*homeButton.onClick.AddListener(() =>
        {
            
        });*/

        backButton.onClick.AddListener(() =>
        {
            objQuestNonTouchPanel.SetActive(true);  // 遷移中のボタンタッチ防止用パネルをアクティブに

            menuSceneManager.PreviousWindowInfoRegist();    // 今いる画面を記録

            objMenuCanvas.SetActive(true);  // 該当画面へ遷移
        });
    }
}
