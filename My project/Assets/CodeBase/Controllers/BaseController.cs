using CodeBase.Models;
using CodeBase.Views;
using UnityEngine;

namespace CodeBase.Controllers
{
    public abstract class BaseController: MonoBehaviour
    {
        protected BaseModel model;
        protected BaseView view;

     
        public abstract void Initialize( BaseModel model , BaseView view );
        public abstract void HandleUserInput( object input );
        
        public virtual void UpdateView( )
        {
            view.UpdateView ( model );
        }
    }
}
