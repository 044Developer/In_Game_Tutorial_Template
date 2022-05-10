using UnityEngine;

namespace TutorialProject.Infrastructure.TutorialSystem.Data.HighlightedData
{
    public class SpriteRendererHighlightedElement : IHighlightedTutorialElement
    {
        private const int TUTORIAL_LAYER_INDEX = 210;
        
        private readonly SpriteRenderer m_spriteRenderer;
        private int m_cachedSortingLayer = 0;

        public SpriteRendererHighlightedElement(SpriteRenderer spriteRenderer)
        {
            m_spriteRenderer = spriteRenderer;
        }
        
        public void HighlightElement()
        {
            m_cachedSortingLayer = m_spriteRenderer.sortingLayerID;
            m_spriteRenderer.sortingLayerID = TUTORIAL_LAYER_INDEX;
        }

        public void ReleaseElement()
        {
            m_spriteRenderer.sortingLayerID = m_cachedSortingLayer;
        }
    }
}