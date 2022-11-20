 using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private float _speed;
    private RaycastHit _hit;

    void Update() 
    {
        if (Input.GetMouseButtonUp(0) || Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            _bullet.SetActive(true);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out _hit))
            {
                _bullet.transform.position = new Vector3(transform.position.x,_hit.point.y,transform.position.z);
            }
            
        }
        
        if (_bullet == true)
        {
            _bullet.transform.position = Vector3.Lerp(_bullet.transform.position,
                new Vector3(_hit.point.x, _bullet.transform.position.y, _hit.point.z + _speed),_speed * Time.deltaTime);
        }

    }
    
}
