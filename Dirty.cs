using UnityEngine;

public class Dirty : MonoBehaviour
{
    [SerializeField] Color to;
    [SerializeField] float smoothing;

    private SpriteRenderer sprite;
    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        DirtyManager.Instance.Add(this);
    }

    public void Clean()
    {
        sprite.color = Color.Lerp(sprite.color, to, smoothing * Time.deltaTime);

        if (sprite.color == to || sprite.color.a < .2f)
        {
            Destroy(gameObject);
            DirtyManager.Instance.Remove(this);
        }
    }
}