using UnityEngine;

public enum QuestType
{
     Collection,
     Interaction,
     Reach
}

[CreateAssetMenu(fileName = "SO_Quest", menuName = "Scriptable Objects/SO_Quest")]
public class SO_Quest : ScriptableObject
{
     public QuestType questType;
     public string questDescription;
     public int questNumber;
     public bool needsQuestObject;
}
