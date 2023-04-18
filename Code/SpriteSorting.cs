using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSorting : MonoBehaviour
{
    public string sortingLayerName = "Default";
    public int sortingOrder = 0;
    public LayerMask blockingLayer;

    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Установка порядка слоя для спрайта персонажа
        spriteRenderer.sortingLayerName = sortingLayerName;
        spriteRenderer.sortingOrder = sortingOrder;

        // Настройка порядка слоев для объектов, через которые персонаж не должен проходить
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 1f, blockingLayer);
        for (int i = 0; i < colliders.Length; i++)
        {
            SpriteRenderer blockingSprite = colliders[i].GetComponent<SpriteRenderer>();
            if (blockingSprite != null && blockingSprite.sortingOrder < spriteRenderer.sortingOrder)
            {
                blockingSprite.sortingOrder = spriteRenderer.sortingOrder;
            }
        }
    }
}
