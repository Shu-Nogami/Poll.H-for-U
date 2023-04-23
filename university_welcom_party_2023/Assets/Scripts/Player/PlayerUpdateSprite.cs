using System;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerUpdateSprite : MonoBehaviour
    {
        [SerializeField] private List<Sprite> attackUpSprite;
        [SerializeField] private List<Sprite> attackDownSprite;
        [SerializeField] private List<Sprite> attackRightSprite;
        [SerializeField] private List<Sprite> attackLeftSprite;

        private SpriteRenderer _spriteRenderer;
        private int attackUpCount;
        private int attackDownCount;
        private int attackRightCount;
        private int attackLeftCount;
        

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            attackUpCount = 0;
            attackDownCount = 0;
            attackRightCount = 0;
            attackLeftCount = 0;
        }

        public void SetPlayerAttackUpSprite()
        {
            if (attackUpCount % 2 == 0) _spriteRenderer.sprite = attackUpSprite[0];
            else _spriteRenderer.sprite = attackUpSprite[1];
            attackUpCount++;
        }
        
        public void SetPlayerAttackDownSprite()
        {
            if (attackDownCount % 2 == 0) _spriteRenderer.sprite = attackDownSprite[0];
            else _spriteRenderer.sprite = attackDownSprite[1];
            attackDownCount++;
        }

        public void SetPlayerAttackRightSprite()
        {
            if (attackRightCount % 2 == 0) _spriteRenderer.sprite = attackRightSprite[0];
            else _spriteRenderer.sprite = attackRightSprite[1];
            attackRightCount++;
        }

        public void SetPlayerAttackLeftSprite()
        {
            if (attackLeftCount % 2 == 0) _spriteRenderer.sprite = attackLeftSprite[0];
            else _spriteRenderer.sprite = attackLeftSprite[1];
            attackLeftCount++;
        }

    }
}