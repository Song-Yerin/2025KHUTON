using AirFishLab.ScrollingList.ContentManagement;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
// The box used for displaying the content
// Must inherit from the class `ListBox`

namespace AirFishLab.ScrollingList.Demo
{
    public class IntListBox : ListBox
    {
        [SerializeField]
        private TextMeshProUGUI _contentText;
        // This function is invoked by the `CircularScrollingList` for updating the list
        protected override void UpdateDisplayContent(IListContent listContent)
        {
            var content = (MyIntListBank.Content)listContent;
            _contentText.text = content.Value.ToString();
        }

    }
}