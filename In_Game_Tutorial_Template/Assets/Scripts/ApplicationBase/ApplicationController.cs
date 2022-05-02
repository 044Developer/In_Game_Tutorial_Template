using TutorialProject.Infrastructure.TutorialSystem.Controller;
using TutorialProject.Infrastructure.TutorialSystem.TutorialDataBase;
using UnityEngine;

namespace TutorialProject.ApplicationBase
{
    public class ApplicationController : MonoBehaviour
    {
        public static ApplicationController Instance = null;
        
        public TutorialSystemController TutorialSystemController { get; private set; }
        public ITutorialDataBase TutorialDataBase { get; private set; }
        
        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(this);
            
            DontDestroyOnLoad(this);
        }

        private void Start()
        {
            InitializeApplication();
        }

        private void InitializeApplication()
        {
            TutorialDataBase = new TutorialDataBaseHolder();
            TutorialSystemController = new TutorialSystemController(TutorialDataBase);
        }

        private void DisposeApplication()
        {
            TutorialDataBase.Dispose();
        }

        private void OnDestroy()
        {
            DisposeApplication();
        }
    }
}