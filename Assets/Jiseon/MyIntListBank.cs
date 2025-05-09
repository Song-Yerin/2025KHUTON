using AirFishLab.ScrollingList;
using AirFishLab.ScrollingList.ContentManagement;

// The bank for providing the content for the box to display
// Must be inherit from the class BaseListBank
public class MyIntListBank : BaseListBank
{
    // The content to be passed to the list box
    // must inherit from the class `IListContent`.
    public class Content : IListContent
    {
        public string Value;  
    }

    private readonly string[] _contents = {
        "����", "���", "��Ĩ", "���", "û��", "���", "����", "�Ҹ�", "����", "����",
        "�Ҽ�", "�뼭", "����", "ó��", "���", "�ߺ�", "�ѷ�", "��", "�Ե�",
        "�Ҽ�", "�뼳", "����", "����", "����"
    };

    // This function will be invoked by the `CircularScrollingList`
    // to get the content to display.
    public override IListContent GetListContent(int index)
    {
        var content = new Content
        {
            Value = _contents[index]
        };
        return content;
    }

    public override int GetContentCount()
    {
        return _contents.Length;
    }
}
