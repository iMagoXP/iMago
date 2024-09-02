using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class HorizontalSlider : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
	public float distance;
	public List<RectTransform> sliderObjects = new List<RectTransform>();
	[Range(0, 1)]
	public float fullAnimationRange = 0.25f;
	private IEnumerator slidingCoroutine;
	bool interacting = false;
	public List<Image> Setas;

	public void OnPointerDown(PointerEventData pointerEventData){
		if (slidingCoroutine != null) StopCoroutine(slidingCoroutine);
		float interactionRatioX = 0.0f;
#if UNITY_EDITOR
		interactionRatioX = Input.mousePosition.x / Screen.width;
#else
		Touch touch = Input.GetTouch(0);
		interactionRatioX = touch.position.x / Screen.width;
#endif
		slidingCoroutine = SlidingRoutine(interactionRatioX);
		interacting = true;
		StartCoroutine(slidingCoroutine);
	}
	public void OnPointerUp(PointerEventData pointerEventData){
		interacting = false;
	}
	public IEnumerator SlidingRoutine(float originInteractionRatioX)
	{
		float actualInterctionRatioX = 0.0f;
		float fingerPos = 0.0f;
		while (interacting)
		{
#if UNITY_EDITOR
			actualInterctionRatioX = Input.mousePosition.x / Screen.width;
#else
			Touch touch = Input.GetTouch(0);
			actualInterctionRatioX = touch.position.x / Screen.width;
#endif
			if((((originInteractionRatioX) - (actualInterctionRatioX)) < 0)
			&& sliderObjects[0].name == "Tudo Pronto") break;
			else if(((((originInteractionRatioX) - (actualInterctionRatioX)) > 0)
			||(((originInteractionRatioX) - (actualInterctionRatioX)) < 0))
			&& sliderObjects[0].name == "") break;
			fingerPos = ((-1.0f) * ((originInteractionRatioX) - (actualInterctionRatioX))) / fullAnimationRange;
			if (fingerPos > 1.0f) fingerPos = 1.0f;
			else if (fingerPos < -1.0f) fingerPos = -1.0f;
			fingerPos = (1.0f + fingerPos) / 2.0f;
			HandleSliderElements(fingerPos);
			yield return null;
		}

		float dropOrigin = fingerPos;
		float dropTarget = 0.0f;
		if (fingerPos < 0.25f) dropTarget = 0.0f;
		else if (fingerPos > 0.75f) dropTarget = 1.0f;
		else dropTarget = 0.5f;
		float timer = 0.0f;
		while (timer <= 1.0f)
		{
			fingerPos = Mathf.Lerp(dropOrigin, dropTarget, timer);
			HandleSliderElements(fingerPos);
			timer += Time.deltaTime * 10.0f;
			yield return null;
		}
		HandleSliderElements(dropTarget);
		if (dropTarget == 0)
		{
				RectTransform temp = sliderObjects[0];
				sliderObjects.RemoveAt(0);
				sliderObjects.Add(temp);
				temp.localPosition = new Vector2(distance * 2, temp.localPosition.y);
		}
		else if (dropTarget == 1)
		{
			RectTransform temp = sliderObjects[sliderObjects.Count - 1];
			sliderObjects.RemoveAt(sliderObjects.Count - 1);
			sliderObjects.Insert(0, temp);
			temp.localPosition = new Vector2(distance * 2 * (-1), temp.localPosition.y);
		}
	}

	public IEnumerator SlidingNextRoutine()
	{
		float dropOrigin = 0.5f;
		float dropTarget = 0.0f;
		float timer = 0.0f;
		while (timer <= 1.0f)
		{
			HandleSliderElements(Mathf.Lerp(dropOrigin, dropTarget, timer));
			timer += Time.deltaTime * 10.0f;
			yield return null;
		}
		HandleSliderElements(dropTarget);

		RectTransform temp = sliderObjects[0];
		sliderObjects.RemoveAt(0);
		sliderObjects.Add(temp);
		temp.localPosition = new Vector2(distance * 2, temp.localPosition.y);
		
	}
	public void Next()
    {
		StartCoroutine(SlidingNextRoutine());
	}

	public void HandleSliderElements(float lerpValue){
		float actualDistanceValue = (-1.0f) * (distance * 2.0f);
		foreach(var sliderObject in sliderObjects){
			//MATHS FOR DISTANCE
			float originDistanceValue = actualDistanceValue - (distance);
			float destinationDistanceValue = actualDistanceValue + (distance);
			sliderObject.localPosition = new Vector2(Mathf.Lerp(originDistanceValue, destinationDistanceValue, lerpValue), sliderObject.localPosition.y);
			//MATHS FOR ALPHA AND SCALE
			if (actualDistanceValue >= (-1) * distance && actualDistanceValue <= distance){
				float originScale = 0.0f;
				float destinationScale = 0.0f;
				float originAlpha = 0.0f;
				float destinationAlpha = 0.0f;
				CanvasGroup img = sliderObject.GetComponent<CanvasGroup>();
				if (lerpValue < 0.5f){
					if (actualDistanceValue == 0)
					{
						originScale = 0.75f;
						destinationScale = 1.25f;
						originAlpha = 0.75f;
						destinationAlpha = 1.25f;
						sliderObject.localScale = Vector3.one * (Mathf.Lerp(originScale, destinationScale, lerpValue));
						float alphaOutput = Mathf.Lerp(originAlpha, destinationAlpha, lerpValue);
						img.alpha = alphaOutput;
					}
					else if (actualDistanceValue < 0){
						sliderObject.localScale = Vector3.one * 0.75f;
						img.alpha = 0.75f;
					}
					else if (actualDistanceValue > 0)
					{
						sliderObject.localScale = Vector3.one * 1.0f;
						img.alpha = 1.0f;
						originScale = 1.0f;
						destinationScale = 0.5f;
						originAlpha = 1.0f;
						destinationAlpha = 0.5f;
						sliderObject.localScale = Vector3.one * (Mathf.Lerp(originScale, destinationScale, lerpValue));
						float alphaOutput = Mathf.Lerp(originAlpha, destinationAlpha, lerpValue);
						img.alpha = alphaOutput;
					}
				}
				else{
					if (actualDistanceValue == 0)
					{
						originScale = 1.25f;
						destinationScale = 0.75f;
						originAlpha = 1.25f;
						destinationAlpha = 0.75f;
						sliderObject.localScale = Vector3.one * (Mathf.Lerp(originScale, destinationScale, lerpValue));
						float alphaOutput = Mathf.Lerp(originAlpha, destinationAlpha, lerpValue);
						img.alpha = alphaOutput;
					}
					else if (actualDistanceValue > 0)
					{
						sliderObject.localScale = Vector3.one * 0.75f;
						img.alpha = 0.75f;
					}
					else if (actualDistanceValue < 0)
					{
						sliderObject.localScale = Vector3.one * 1.0f;
						img.alpha = 1.0f;
						originScale = 0.5f;
						destinationScale = 1.0f;
						originAlpha = 0.5f;
						destinationAlpha = 1.0f;
						sliderObject.localScale = Vector3.one * (Mathf.Lerp(originScale, destinationScale, lerpValue));
						float alphaOutput = Mathf.Lerp(originAlpha, destinationAlpha, lerpValue);
						img.alpha = alphaOutput;
					}
				}
			}
			actualDistanceValue += distance;
		}
	}
}