using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] private float _scrollspeed;
    [SerializeField] private float _backgroundLenght; //длина задника
    private Vector3 _startPosition;  // стартовая позиция

    private void Start()
    {
        _startPosition = transform.position;
    }

    private void Update()
    {
        float newPosition = Mathf.Repeat(Time.time * _scrollspeed, _backgroundLenght);
        transform.position = _startPosition + Vector3.up * newPosition;
    }
}
