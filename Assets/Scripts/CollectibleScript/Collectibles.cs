using UnityEngine;

public class Collectibles : MonoBehaviour
{
   [SerializeField]private CollectibleType collectibleType;

   public CollectibleType type => collectibleType;
}
