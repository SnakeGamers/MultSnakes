using UnityEngine;
using UnityEngine.UI; // Содержит Image
using DIG.UIExpansion; // Содержит ToggleSlide

public class ToggleChangeBG : MonoBehaviour
{
    // Цвет фона камеры, на который меняем
    [SerializeField] private Color backgroundCameraColor = Color.gray;
    // Фон самого компонента UI Toggle(CheckBox)
    [SerializeField] private Image backgroundToggle;

    [SerializeField] private Color offColor = Color.red; // Фон при неактивном Toggle
    [SerializeField] private Color onColor = Color.green; // Фон при активном Toggle
    
    private ToggleSlide toggle; // Сам Toggle 
    private Color backgroundCameraBasic; // Изначальный цвет фона камеры 
    private void Start()
    {
        backgroundCameraBasic = Camera.main.backgroundColor;

        toggle = GetComponent<ToggleSlide>(); // Получаем Toggle
        // Добавляем событие, которое будет обрабатываться при нажатии на Toggle
        toggle.OnValueChange.AddListener(OnToggleChanged);

        // Начальный вызов события для синхронизации элемента с параметрами
        OnToggleChanged(toggle.IsActive);
    }
    
    // isOn - флаг того, активен ли сейчас компонент
    public void OnToggleChanged(bool isOn)
    {
        if (isOn)
        {
            // Основная камера всего одна, обращаемся к ней напрямую и меняем фон
            Camera.main.backgroundColor = backgroundCameraColor;
            backgroundToggle.color = onColor;
        } else
        {
            Camera.main.backgroundColor = backgroundCameraBasic;
            backgroundToggle.color = offColor;
        }
    }
}
