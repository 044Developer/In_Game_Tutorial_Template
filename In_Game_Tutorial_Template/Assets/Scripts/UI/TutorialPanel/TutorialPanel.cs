using TutorialProject.ApplicationBase;
using TutorialProject.Infrastructure.TutorialSystem.Controller;
using TutorialProject.UI.TutorialPanel.Model;
using UnityEngine;

namespace TutorialProject.UI.TutorialPanel
{
    public class TutorialPanel : MonoBehaviour
    {
        [SerializeField] private TutorialPanelModel m_tutorialPanelModel = null;

        private TutorialSystemController m_tutorialSystemController = null;
        
        private void Start()
        {
            m_tutorialSystemController = ApplicationController.Instance.TutorialSystemController;
            m_tutorialSystemController.Initialize(m_tutorialPanelModel);
            InitializeButtons();
        }
        
        private void OnDestroy()
        {
            DisposeButtons();
        }

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.A))
                TriggerTutorial(0);
        }

        public void TriggerTutorial(int tutorialID) => 
            m_tutorialSystemController.StartTutorial(tutorialID);

        private void InitializeButtons() => 
            m_tutorialPanelModel.ExecuteStepButton.onClick.AddListener(m_tutorialSystemController.ProceedWithNextTutorialStep);

        private void DisposeButtons() => 
            m_tutorialPanelModel.ExecuteStepButton.onClick.AddListener(m_tutorialSystemController.ProceedWithNextTutorialStep);
    }
}