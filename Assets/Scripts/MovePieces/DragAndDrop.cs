using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{

    [SerializeField] public RectTransform _transform;
    [SerializeField] private Canvas _canvas;
    [SerializeField] private CanvasGroup _canvasGroup;
    private Vector3 initialPosition;
    public Vector3 initialPosition2;
    private ItemSlot item, item2;
    public string Tag, Tag2;
    public GameObject prefab;
    private Vector3 itemSize;
    private bool mexeu = false, mexeu2 = false;

    void Start(){
        item = GameObject.FindWithTag(Tag).GetComponent<ItemSlot>();
        item2 = GameObject.FindWithTag(Tag2).GetComponent<ItemSlot>();
        if(PlayerPrefs.GetInt(_transform.gameObject.tag) <= 0){
            GameObject.FindWithTag(_transform.gameObject.tag).SetActive(false);
        }
    }

    public void OnBeginDrag(PointerEventData eventData){
        initialPosition = _transform.position;
        itemSize = _transform.localScale;
        _canvasGroup.alpha = 0.5f;
        _canvasGroup.blocksRaycasts = false;
        Decrement();
    }

    public void OnEndDrag(PointerEventData eventData){
        _canvasGroup.alpha = 1f;
        _canvasGroup.blocksRaycasts = true;

        if(!item2.podeMexer && !item.podeMexer){
            _transform.position = initialPosition;
            if(LifeManager.actLife > 1){
                LifeManager.Dano();
                ScoreManager.DecrementUserPoints(1);
                Increment();
            } else {
                SceneManager.LoadScene("GameOver");
            }
        } else {
            ScoreManager.IncrementUserPoints(10);
            if(item.podeMexer){
                mexeu = true;
                item.podeMexer = false;
            }
            if(item2.podeMexer){
                mexeu2 = true;
                item2.podeMexer = false;
            }
        }

        if(PlayerPrefs.GetInt(_transform.gameObject.tag) > 0){
            if(mexeu | mexeu2){
                if(PlayerPrefs.GetInt(_transform.gameObject.tag) > 0){
                    GameObject newItem = Instantiate(prefab, initialPosition2, Quaternion.identity) as GameObject;
                    newItem.transform.SetParent(GameObject.FindGameObjectWithTag("CanvasPecas").transform, false);
                    newItem.transform.localScale = itemSize;
                }
            } else {
                Debug.Log("ja mexeu os dois");
            }
        }
        Debug.Log(ScoreManager.GetUserPoints());
        if(ScoreManager.GetUserPoints() > 20){
            ScoreManager.activateButton();
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        _transform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log("Apertou!");
    }
    
    public void Increment(){
        if(_transform.gameObject.tag == "Fuso"){
            ScoreManager.IncrementFuso();
        }
        if (_transform.gameObject.tag == "Cromossomo1") {
            ScoreManager.IncrementCromo();
        }
        if (_transform.gameObject.tag == "Cromossomo2") {
            ScoreManager.IncrementCromo2();
        }
    }
    public void Decrement(){
        if(_transform.gameObject.tag == "Fuso"){
            ScoreManager.DecrementFuso();
        }
        if (_transform.gameObject.tag == "Cromossomo1") {
            ScoreManager.DecrementCromo();
        }
        if (_transform.gameObject.tag == "Cromossomo2") {
            ScoreManager.DecrementCromo2();
        }
    }
}