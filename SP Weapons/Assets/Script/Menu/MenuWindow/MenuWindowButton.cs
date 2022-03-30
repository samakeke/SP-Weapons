using UnityEngine;
using UnityEngine.UI;

public class MenuWindowButton : MonoBehaviour
{
    /// <summary>
    /// メニューウィンドウに含まれる全てのボタン
    /// </summary>

    [SerializeField]
    private MenuSceneManager menuSceneManager;  // 自作クラス
    [SerializeField]
    private Button questButton;
    [SerializeField]
    private Button editButton;
    [SerializeField]
    private Button otherButton;
    [SerializeField]
    private Button optionButton;
    [SerializeField]
    private GameObject objQuestCanvas;
    [SerializeField]
    private GameObject objEditCanvas;
    [SerializeField]
    private GameObject objOtherCnvas;
    [SerializeField]
    private GameObject objOptionCanvas;
    [SerializeField]
    private GameObject objMenuNonTouchPanel;





    private void Start()
    {
        /* 各ボタンの登録 */

        ButtonRegist();
    }





    private void ButtonRegist()
    {
        questButton.onClick.AddListener(() =>
        {
            objMenuNonTouchPanel.SetActive(true);   // 遷移中のボタンタッチ防止用パネルをアクティブに

            menuSceneManager.PreviousWindowInfoRegist();    // 今いる画面を記録

            objQuestCanvas.SetActive(true); // 該当画面へ遷移
        });

        editButton.onClick.AddListener(() =>
        {
            objMenuNonTouchPanel.SetActive(true);

            menuSceneManager.PreviousWindowInfoRegist();

            objEditCanvas.SetActive(true);
        });

        otherButton.onClick.AddListener(() =>
        {
            objMenuNonTouchPanel.SetActive(true);

            menuSceneManager.PreviousWindowInfoRegist();

            objOtherCnvas.SetActive(true);
        });

        optionButton.onClick.AddListener(() =>
        {
            objMenuNonTouchPanel.SetActive(true);

            menuSceneManager.PreviousWindowInfoRegist();

            objOptionCanvas.SetActive(true);
        });
    }
}
