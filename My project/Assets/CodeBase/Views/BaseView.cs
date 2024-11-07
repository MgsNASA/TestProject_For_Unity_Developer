using CodeBase.Models;
using UnityEngine;

namespace CodeBase.Views
{
    public abstract class BaseView : MonoBehaviour
    {
        public abstract void UpdateView( BaseModel model );
        public abstract void OnUserInteraction( );
    }
}
