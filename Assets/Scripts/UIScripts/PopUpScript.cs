using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class PopUpScript : MonoBehaviour
{
    [SerializeField] private CanvasGroup _bodyAlphaGroup;
    [SerializeField] private CanvasGroup _titleAlphaGroup;
    public List<GameObject> items = new List<GameObject>();
    public float fadeTime = 1f;
    private void Awake()
    {
        _bodyAlphaGroup.alpha = 0f;
        _titleAlphaGroup.alpha = 0f;
    }

    public void Show()
    {
        _bodyAlphaGroup.DOFade(1, fadeTime);
        StartCoroutine("TitleAnimation");
        StartCoroutine("ItemsAnimation");
    }

    public void Hide()
    {
        _bodyAlphaGroup.DOFade(0, 1f).OnComplete(() => transform.gameObject.SetActive(false));
    }

    public void ShowAdv()
    {
        Debug.LogError("Здесь будет ваша реклама.");
    }

    IEnumerator TitleAnimation()
    {
        _titleAlphaGroup.DOFade(1, fadeTime);
        yield return new WaitForSeconds(1f);
    }
    IEnumerator ItemsAnimation()
    {
        foreach (var item in items)
        {
            item.transform.localScale = Vector3.zero;
        }
        foreach (var item in items)
        {
            item.transform.DOScale(1f, fadeTime).SetEase(Ease.OutBounce);
            yield return new WaitForSeconds(0.25f);
        }
    }
    
    
}
