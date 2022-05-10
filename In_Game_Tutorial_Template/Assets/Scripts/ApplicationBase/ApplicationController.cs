using TutorialProject.Infrastructure.ApplicationEvents;
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
        public EventHolder EventHolder { get; private set; }
        
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
            EventHolder = new EventHolder();
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