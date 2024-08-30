using UnityEngine;
using DG.Tweening;

public class UIPanelAnimator : MonoBehaviour
{
    // ������, ������� ����� �����������
    private RectTransform panel;

    // ����������������� ��������
    [SerializeField] float animationDuration = 0.5f;

    // ��������� � �������� ������� ������
    [SerializeField] private Vector3 hiddenScale = Vector3.zero;   // ������ ��� ������� ������
    [SerializeField] private Vector3 visibleScale = Vector3.one;   // ������ ��� ������� ������

    private void Awake()
    {
        panel = GetComponent<RectTransform>();
    }

    private void OnEnable()
    {
        // ������������� ��������� ������� ��� �������� ���������
        //panel = GetComponent<RectTransform>();

        panel.localScale = hiddenScale;

        // �������� ���������� �� �������� �������
        panel.gameObject.SetActive(true);  // ���������� ������
        panel.DOScale(visibleScale, animationDuration)
            .SetEase(Ease.OutBack)
            .SetUpdate(true); // ��������� � �������� �������
    }
}





