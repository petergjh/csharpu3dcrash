using System;

namespace Managers {
    public abstract class IGameSystem
    {
        protected ManagerController SystemManager { get; private set; }
        protected IGameSystem(ManagerController mc)
        {
            SystemManager = mc;
        }

        public virtual void Initialize() {}

        public virtual void Release() { }

        public virtual void Update() { }

    }
}

