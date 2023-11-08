using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingUI : MonoBehaviour {

    
    public static SettingUI Instance { get; private set; }
    
    [SerializeField] private Button moveLeftButton;
    [SerializeField] private Button moveRigntButton;
    [SerializeField] private Button jumpButton;
    [SerializeField] private Button useButton;
    [SerializeField] private Button pauseButton;
    [SerializeField] private Button backButton;

    [SerializeField] private Button gamepadJumpButton;
    [SerializeField] private Button gamepadUseButton;
    [SerializeField] private Button gamepadPauseButton;

    [SerializeField] private TextMeshProUGUI moveLeftText;
    [SerializeField] private TextMeshProUGUI moveRightText;
    [SerializeField] private TextMeshProUGUI jumpText;
    [SerializeField] private TextMeshProUGUI useText;
    [SerializeField] private TextMeshProUGUI pauseText;

    [SerializeField] private TextMeshProUGUI gamepadJumpText;
    [SerializeField] private TextMeshProUGUI gamepadUseText;
    [SerializeField] private TextMeshProUGUI gamepadPauseText;

    [SerializeField] private Transform pressToRebindKeyTransform;

    private Action onCloseButtonAction;

    private void Awake() {
        Instance = this;

        backButton.onClick.AddListener(() => {
            Hide();
            onCloseButtonAction();
        });

        moveLeftButton.onClick.AddListener(() => { RebindBinding(GameInput.Binding.Move_Left); });
        moveRigntButton.onClick.AddListener(() => { RebindBinding(GameInput.Binding.Move_Right); });
        jumpButton.onClick.AddListener(() => { RebindBinding(GameInput.Binding.Jump); });
        useButton.onClick.AddListener(() => { RebindBinding(GameInput.Binding.Use); });
        pauseButton.onClick.AddListener(() => { RebindBinding(GameInput.Binding.Pause); });
        gamepadJumpButton.onClick.AddListener(() => { RebindBinding(GameInput.Binding.Gamepad_Jump); });
        gamepadUseButton.onClick.AddListener(() => { RebindBinding(GameInput.Binding.Gamepad_Use); });
        gamepadPauseButton.onClick.AddListener(() => { RebindBinding(GameInput.Binding.Gamepad_Pause); });
    }

    private void Start() {
        GameManager.Instance.OnGameUnpaused += GameManager_OnGameUnpaused;
        UpdateVisual();

        HidePressToRebindKey();
        Hide();
    }

    private void GameManager_OnGameUnpaused(object sender, System.EventArgs e) {
        Hide();
    }

    private void UpdateVisual() {
        moveLeftText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Move_Left);
        moveRightText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Move_Right);
        jumpText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Jump);
        useText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Use);
        pauseText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Pause);
        gamepadJumpText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Gamepad_Jump);
        gamepadUseText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Gamepad_Use);
        gamepadPauseText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Gamepad_Pause);
    }

    public void Show(Action onCloseButtonAction) {
        this.onCloseButtonAction = onCloseButtonAction;
        gameObject.SetActive(true);

        backButton.Select();
    }

    private void Hide() {
        gameObject.SetActive(false);
    }

    private void ShowPressToRebindKey() {
        pressToRebindKeyTransform.gameObject.SetActive(true);
    }

    private void HidePressToRebindKey() {
        pressToRebindKeyTransform.gameObject.SetActive(false);
    }

    private void RebindBinding(GameInput.Binding binding) {
        ShowPressToRebindKey();
        GameInput.Instance.RebindBinding(binding, () => {
            HidePressToRebindKey();
            UpdateVisual();
        });
    }
}
