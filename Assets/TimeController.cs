using UnityEngine;
using System.Collections;

public class TimeController: MonoBehaviour
{
    [SerializeField]
	private GameObject _gameObject;
    private ArrayList _playerPositions;
    private ArrayList _playerRotations;
    private bool isReversing = false;
    private int _index;

	void Start()
	{
        _playerPositions = new ArrayList();
        _playerRotations = new ArrayList();
	}

    void Update()
    {
        if(Input.GetKey(KeyCode.Space) || Input.touchCount > 0 && Input.GetTouch(1).phase == TouchPhase.Began)
        {
            if (_playerPositions.Count == 0)
            {
                isReversing = false;
                if (_gameObject.tag == "Player")
                {
                    _gameObject.SetActive(false);
                }
                
            }
            isReversing = true;
        }
        else
        {
            isReversing = false;
        }
    }
	
	void FixedUpdate()
    {
        if (!isReversing)
        {
            _playerPositions.Add(_gameObject.transform.position);
            _playerRotations.Add(_gameObject.transform.localEulerAngles);
            
        }

        else
        {
            if (_playerPositions.Count == 0)
            {
                isReversing = false;
            }

            if (_playerPositions.Count > 0)
            {
                _gameObject.transform.position = (Vector3) _playerPositions[_playerPositions.Count - 1];
                _playerPositions.RemoveAt(_playerPositions.Count - 1);

                _gameObject.transform.localEulerAngles = (Vector3) _playerRotations[_playerRotations.Count - 1];
                _playerRotations.RemoveAt(_playerRotations.Count - 1);
            }
           
        }
        
    }
}