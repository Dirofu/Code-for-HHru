using UnityEngine;

public class MenuButtons : MonoBehaviour
{
    [SerializeField] private MainButtons _mainButtons;
    [SerializeField] private PlayMenu _playMenu;
    [SerializeField] private SettingMenu _settingMenu;
    [SerializeField] private CarSelectMenu _storeMenu;

    private void SetActiveStatus(GameObject target, bool state) => target.SetActive(state);

    public void OpenPlayMenuButton()
    {
        SetActiveStatus(_playMenu.gameObject, true);
        SetActiveStatus(_mainButtons.gameObject, false);
    }
    public void ClosePlayMenuButton()
    {
        SetActiveStatus(_playMenu.gameObject, false);
        SetActiveStatus(_mainButtons.gameObject, true);
    }

    public void OpenSettingMenuButton()
    {
        SetActiveStatus(_settingMenu.gameObject, true);
        SetActiveStatus(_mainButtons.gameObject, false);
    }

    public void CloseSettingMenuButton()
    {
        SetActiveStatus(_settingMenu.gameObject, false);
        SetActiveStatus(_mainButtons.gameObject, true);
    }

    public void OpenStoreMenuButton()
    {
        SetActiveStatus(_storeMenu.gameObject, true);
        SetActiveStatus(_mainButtons.gameObject, false);
    }
    public void CloseStoreMenuButton()
    {
        SetActiveStatus(_storeMenu.gameObject, false);
        SetActiveStatus(_mainButtons.gameObject, true);
    }
}
