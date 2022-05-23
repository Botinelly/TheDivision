using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    [SerializeField] public RectTransform _transform;
    private DragAndDrop drag;
    public string[] Tag;
    public Collider other;
    public bool podeMexer = false;

    void Start(){
        drag = GameObject.FindWithTag(Tag[0]).GetComponent<DragAndDrop>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (other.gameObject.tag == Tag[0]){
            podeMexer = true;
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = _transform.anchoredPosition;           
        }
    }
}