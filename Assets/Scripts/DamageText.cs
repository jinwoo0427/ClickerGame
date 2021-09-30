using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;  

public class DamageText : MonoBehaviour
{
    [SerializeField]
    private Canvas canvas = null;
    [SerializeField]
    private Transform pool = null;
    private Text damageText = null;
    public void Show(Vector3 vec)
    {
        float randomX = Random.Range(4f, -5f);
        float randomY = Random.Range(2f, 3f);
        vec = new Vector3(randomX, randomY, 10f);
        damageText = GetComponent<Text>();
        damageText.text = string.Format("-{0}", GameManager.Instance.CurrentUser.damage);

        transform.SetParent(canvas.transform);
        transform.position = Camera.main.WorldToViewportPoint(vec);
        transform.position = new Vector3(transform.position.x, transform.position.y, 10f);
        gameObject.SetActive(true);

        RectTransform rectTransform = GetComponent<RectTransform>();
        float targetPositionY = rectTransform.anchoredPosition.y + 50f;

        damageText.DOFade(0f, 0.5f).OnComplete(() => Despawn());
        rectTransform.DOAnchorPosY(targetPositionY, 0.5f);

    }
    public void Despawn()
    {
        damageText.DOFade(1f, 0f);
        transform.SetParent(pool);
        gameObject.SetActive(false);
    }
}
