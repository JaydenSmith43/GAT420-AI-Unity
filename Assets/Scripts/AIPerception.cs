using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIPerception : MonoBehaviour
{
	[SerializeField] protected string tagName = "";
	[SerializeField] protected float distance = 1;
	[SerializeField] protected float maxAngle = 45;
	[SerializeField] protected LayerMask layerMask = Physics.AllLayers;

	public string TagName { get { return tagName; } } //getter uppercase
	public float Distance { get { return distance; } }
	public float MaxAngle { get {  return maxAngle; } }

	public abstract GameObject[] GetGameObjects();
}
