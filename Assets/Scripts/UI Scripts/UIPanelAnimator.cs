using UnityEngine;
using DG.Tweening;

public class UIPanelAnimator : MonoBehaviour
{
    // Панель, которую будем анимировать
    private RectTransform panel;

    // Продолжительность анимации
    [SerializeField] float animationDuration = 0.5f;

    // Начальный и конечный размеры панели
    [SerializeField] private Vector3 hiddenScale = Vector3.zero;   // Размер для скрытой панели
    [SerializeField] private Vector3 visibleScale = Vector3.one;   // Размер для видимой панели

    private void Awake()
    {
        panel = GetComponent<RectTransform>();
    }

    private void OnEnable()
    {
        // Устанавливаем начальный масштаб для анимации появления
        //panel = GetComponent<RectTransform>();

        panel.localScale = hiddenScale;

        // Анимация увеличения до видимого размера
        panel.gameObject.SetActive(true);  // Активируем панель
        panel.DOScale(visibleScale, animationDuration)
            .SetEase(Ease.OutBack)
            .SetUpdate(true); // Обновлять в реальном времени
    }
}





