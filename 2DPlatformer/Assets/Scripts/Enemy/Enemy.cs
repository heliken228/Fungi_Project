using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Animator _animator;
    private SpriteRenderer _sprite;
    
    private void Start()
    {
        _sprite = GetComponentInChildren<SpriteRenderer>();
        _animator = GetComponentInChildren<Animator>();
    }
    private void Update()
    {
    }
    public void TakeDamage()
    {
        Death();
    }
    private void Death()
    {
        _animator.SetTrigger("Death");
        StartCoroutine(DeactivateAfterAnimation());
    }

    private IEnumerator DeactivateAfterAnimation()
    {
        yield return new WaitForSeconds(_animator.GetCurrentAnimatorStateInfo(0).length);
        //yield return new WaitForSeconds(_audioSource.clip.length);
        gameObject.SetActive(false);
    }
}
