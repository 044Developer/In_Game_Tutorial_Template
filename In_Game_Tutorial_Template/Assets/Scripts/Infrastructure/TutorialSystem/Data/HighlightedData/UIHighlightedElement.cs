using UnityEngine;
using UnityEngine.UI;

namespace TutorialProject.Infrastructure.TutorialSystem.Data.HighlightedData
{
    public class UIHighlightedElement : IHighlightedTutorialElement
    {
        private const int TUTORIAL_LAYER_INDEX = 210;
        
        private readonly GameObject m_canvasElement;
        private bool m_hadCanvasComponent = false;
        private bool m_hadGraphicRaycasterComponent = false;
        private int m_cachedSortingLayer = 0;
        private Canvas m_tempCanvas = null;
        private GraphicRaycaster m_tempGraphicRaycaster = null;

        public UIHighlightedElement(GameObject canvasElement)
        {
            m_canvasElement = canvasElement;
        }
        
        public void HighlightElement()
        {
            m_tempCanvas = m_canvasElement.GetComponent<Canvas>();
            if (m_tempCanvas == null)
            {
                m_hadCanvasComponent = false;
                m_tempCanvas = m_canvasElement.AddComponent<Canvas>();
                SetCanvasSettings(m_tempCanvas);
            }
            else
            {
                m_hadCanvasComponent = true;
                m_cachedSortingLayer = m_tempCanvas.sortingOrder;
                SetCanvasSettings(m_tempCanvas);
            }
            
            m_tempGraphicRaycaster = m_canvasElement.GetComponent<GraphicRaycaster>();

            if (m_tempGraphicRaycaster == null)
            {
                m_hadGraphicRaycasterComponent = false;
                m_tempGraphicRaycaster = m_canvasElement.AddComponent<GraphicRaycaster>();
            }
            else
            {
                m_hadGraphicRaycasterComponent = true;
            }
        }

        private static void SetCanvasSettings(Canvas objectCanvas)
        {
            objectCanvas.overrideSorting = true;
            objectCanvas.sortingOrder = TUTORIAL_LAYER_INDEX;
        }

        public void ReleaseElement()
        {
            if (!m_hadGraphicRaycasterComponent) 
                Object.Destroy(m_tempGraphicRaycaster);

            if (!m_hadCanvasComponent)
                Object.Destroy(m_tempCanvas);
            else
                m_tempCanvas.sortingOrder = m_cachedSortingLayer;
        }
    }
}