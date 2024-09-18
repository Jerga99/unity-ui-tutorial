

public class BackButton : ActionButton
{
    public override void OnClick()
    {
        AudioManager.Instance.PlayButtonClickSound();
        m_ScreenManager.NavigateBack();
    }
}
