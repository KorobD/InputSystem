using UnityEngine;
using UnityEngine.UI;

public class GamePauseUI : MonoBehaviour {

    public static GamePauseUI Instance { get; private set; }

    [SerializeField] private Button continueButton;
    [SerializeField] private Button settingButton;


    private void Awake() {
        Instance = this;
        continueButton.onClick.AddListener(() => {
            GameManager.Instance.TogglePauseGame();
        });

        settingButton.onClick.AddListener(() => {
            Hide();
            SettingUI.Instance.Show(Show);
        } );

    }
    private void Start() {
        GameManager.Instance.OnGamePaused += GameManager_OnGamePaused;
        GameManager.Instance.OnGameUnpaused += GameManager_OnGameUnpaused;

        Hide();
    }

    private void GameManager_OnGameUnpaused(object sender, System.EventArgs e) {
        Hide();
    }

    private void GameManager_OnGamePaused(object sender, System.EventArgs e) {
        Show();
    }

    public void Show() {
        gameObject.SetActive(true);

        continueButton.Select();
    }
    private void Hide() {
        gameObject.SetActive(false);
    } 
}
