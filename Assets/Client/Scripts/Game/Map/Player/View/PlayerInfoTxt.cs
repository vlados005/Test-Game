using DG.Tweening;
using TMPro;
using UnityEngine;

public class PlayerInfoTxt : MonoBehaviour
{
    private TMP_Text _text;
    private RectTransform _rectTransform;

    private void Start()
    {
        _text = GetComponent<TMP_Text>();
        _rectTransform = GetComponent<RectTransform>();

        PlayTextAnim();
    }

    private void PlayTextAnim()
    {
        // Text animation 
        Sequence seq = DOTween.Sequence();
        seq.Append(_rectTransform.DOLocalMoveY(0.3f, 1).SetEase(Ease.Linear))
            .Insert(0.7f, _text.DOFade(0, 0.5f).SetEase(Ease.Linear))
            .OnComplete(() => { Destroy(gameObject); });
    }

    public void SetText(string text)
    {
        if (_text == null)
            _text = GetComponent<TMP_Text>();

        _text.text = text;
    }
}
