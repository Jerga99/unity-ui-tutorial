using System.Collections.Generic;
using UnityEngine;

public struct NavigationData
{
    public string ScreenName;
    public object Data;
}

public class ScreenManager : MonoBehaviour
{
    [SerializeField]
    private GameObject m_HomeScreen;
    [SerializeField]
    private GameObject m_SettingsScreen;
    [SerializeField]
    private GameObject m_ShopScreen;
    [SerializeField]
    private GameObject m_CreditsScreen;
    [SerializeField]
    private GameObject m_AudioSettingsScreen;
    [SerializeField]
    private GameObject m_MapSelectionScreen;

    private Stack<NavigationData> m_NavigationStack = new();
    private Dictionary<string, GameObject> m_Screens = new();
    private GameObject m_CurrentScreen;


    private void Start()
    {
        m_Screens.Add("Home", m_HomeScreen);
        m_Screens.Add("Settings", m_SettingsScreen);
        m_Screens.Add("Shop", m_ShopScreen);
        m_Screens.Add("Credits", m_CreditsScreen);
        m_Screens.Add("AudioSettings", m_AudioSettingsScreen);
        m_Screens.Add("MapSelection", m_MapSelectionScreen);

        NavigateTo("Home");
    }

    public void NavigateTo(string screenName, object data = null)
    {
        m_NavigationStack.Push(new NavigationData { ScreenName = screenName, Data = data });
        OnStackChanged();
    }

    public void NavigateBack()
    {
        if (m_NavigationStack.Count > 0)
        {
            m_NavigationStack.Pop();
            OnStackChanged();
        }
    }

    public void OnStackChanged()
    {
        if (m_NavigationStack.Count > 0)
        {
            var screenName = m_NavigationStack.Peek().ScreenName;

            if (m_Screens.ContainsKey(screenName))
            {
                if (m_CurrentScreen != null)
                {
                    m_CurrentScreen.SetActive(false);
                }

                m_CurrentScreen = m_Screens[screenName];
                m_CurrentScreen.SetActive(true);
            }
        }
    }

    public object GetNavigationData()
    {
        if (m_NavigationStack.Count > 0)
        {
            return m_NavigationStack.Peek().Data;
        }

        return null;
    }
}
