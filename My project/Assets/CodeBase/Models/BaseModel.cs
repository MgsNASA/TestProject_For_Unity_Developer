using UnityEngine;

namespace CodeBase.Models
{
    public abstract class BaseModel :MonoBehaviour
    {
  
        public abstract void Initialize( params object [ ] parameters );


        public abstract string GetState( );
    }
}
