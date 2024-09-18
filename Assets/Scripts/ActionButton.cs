
using UnityEngine;
using UnityEngine.UI;

public abstract class ActionButton : MonoBehaviour
{
    private Button m_Button;
    protected ScreenManager m_ScreenManager;

    private void Start()
    {
        m_ScreenManager = FindObjectOfType<ScreenManager>();
        m_Button = GetComponent<Button>();
        m_Button.onClick.AddListener(OnClick);
    }
    public abstract void OnClick();
}
