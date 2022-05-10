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

        private void InitializeButtons() => 
            m_tutorialPanelModel.ExecuteStepButton.onClick.AddListener(m_tutorialSystemController.ProceedWithNextTutorialStep);

        private void DisposeButtons() => 
            m_tutorialPanelModel.ExecuteStepButton.onClick.AddListener(m_tutorialSystemController.ProceedWithNextTutorialStep);
    }
}