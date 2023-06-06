using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameEvent", menuName = "Scriptable/Events")]
public class GameEvent : ScriptableObject
{
    //Lista de todos los objetos que est�n "escuchando" al evento en cuestion
    private List<GameEventListener> listeners = new List<GameEventListener>();

    //Cuando algu�en llama a Raise del evento, iteramos sobre todos los listeners para que se enteren de que el evento ha sido lanzado
    public void Raise()
    {
        for (int i = 0; i < listeners.Count; i++)
        {
            listeners[i].OnEventRaised();
        }
    }

    //Metodos para a�adir y quitar listeners del evento
    public void RegisterListener(GameEventListener listener)
    {
        listeners.Add(listener);
    }

    public void UnregisterListener(GameEventListener listener)
    {
        listeners.Remove(listener);
    }
}
