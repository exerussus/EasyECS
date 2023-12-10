
using UnityEngine;

namespace Exerussus.Example.Source.MonoBehaviours
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private float speed;
        
        public Rigidbody2D Rigidbody => _rigidbody;
        public SpriteRenderer SpriteRenderer => _spriteRenderer;
        public float Speed => speed;
    }
}
